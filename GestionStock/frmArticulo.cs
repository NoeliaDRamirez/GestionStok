using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionStock.Data;
using GestionStock.Data.EntityFramework;
using GestionStock.Data.EntityFramework.Filtros;
using GestionStock.Data.EntityFramework.Entidades;

namespace GestionStock
{
    public partial class frmArticulo : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroArticulo Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroArticulo();
        private Repositorio<Articulo> Repositorio = new Repositorio<Articulo>(new ArticuloIdentificador());
        private Repositorio<ArticuloCategoria> repartcategorias = new Repositorio<ArticuloCategoria>(new ArticuloCategoriaIdentificador());
        
        private bool Editando = false;
        public frmArticulo()
        {
            InitializeComponent();
        }

        private void ActualizaGrilla()
        {
            articuloBindingSource.DataSource = null;
            articuloBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }

        private void frmArticulo_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            articuloBindingSource1.DataSource = new Articulo();
            Editando = false;
            HabilitarControles(true);
        }

        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de Articulos";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nuevo articulo";
                }
                else
                {
                    grpFiltro.Text = "Datos del articulo"; 
                }
            }
            chklbCategorias.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtArticulo.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
            chkActivo.ThreeState = filtro;
            chkActivo.CheckState = filtro ? CheckState.Indeterminate : CheckState.Unchecked;
        }

        private void CargarCategorias(List<ArticuloCategoria> seleccionados = null)
        {
            if (seleccionados == null)
            {
                seleccionados = new List<ArticuloCategoria>();
            }
            Repositorio<Catergoria> repcategorias = new Repositorio<Catergoria>(new CatergoriaIdentificador());
            var categorias = repcategorias.Listar(new FiltroCatergoria(), out _);
            chklbCategorias.Items.Clear();
            ((ListControl)chklbCategorias).DisplayMember = "Nombre";
            ((ListControl)chklbCategorias).ValueMember = "IdCategoria";
            foreach (var item in categorias)
            {
                chklbCategorias.Items.Add(item, seleccionados.Any(x=> x.IdCategoria == item.IdCategoria));
            }
        }
        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            articuloBindingSource1.DataSource = new Articulo();
            CargarCategorias();
            Editando = true;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Articulo actual = articuloBindingSource1.DataSource as Articulo;
            if (actual == null)
            {
                MessageBox.Show("No se esta editando una entidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(actual.Nombre))
            {
                MessageBox.Show("El nombre es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(actual.Codigo))
            {
                MessageBox.Show("El codigo es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool nuevo = actual.IdArticulo == 0;
            Repositorio.Guardar(actual);
            var categorias = chklbCategorias.CheckedItems.Cast<Catergoria>();
            List<ArticuloCategoria> categoriasArticulo = repartcategorias.Listar(new FiltroArticuloCategoria() { IdArticulo = actual.IdArticulo }, out _);
            
            foreach (var item in categorias)
            {
                if (!categoriasArticulo.Any(x=> x.IdCategoria == item.IdCategoria))
                {
                    var nartcategoria = new ArticuloCategoria() { IdArticulo = actual.IdArticulo, IdCategoria = item.IdCategoria };
                    repartcategorias.Agregar(nartcategoria);
                    categoriasArticulo.Add(nartcategoria);
                }
            }
            
            if (!nuevo)
            {
                foreach (var item in categoriasArticulo)
                {
                    if (!categorias.Any(x=> x.IdCategoria == item.IdCategoria))
                    {
                        repartcategorias.Eliminar(item);
                    }
                }
            }
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            articuloBindingSource1.DataSource  = new Articulo();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este articulo?", "Eliminacion",MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                Articulo actual = articuloBindingSource1.DataSource as Articulo;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void articuloBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Articulo actual = articuloBindingSource.Current as Articulo;
            if (Editando)
            {
                HabilitarControles(false, false);
                articuloBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Articulo actual = articuloBindingSource1.DataSource as Articulo;
            if (chkActivo.CheckState != CheckState.Indeterminate)
            {
                Filtro.Activo = actual.Activo;
            }
            else
            {
                Filtro.Activo = null;
            }
            Filtro.Codigo = actual.Codigo;
            Filtro.Descripcion = actual.Descripcion;
            Filtro.Nombre = actual.Nombre;
            if (actual.IdArticulo != 0)
            {
                Filtro.IdArticulo = actual.IdArticulo;
            }
            else
            {
                Filtro.IdArticulo = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Articulo actual = articuloBindingSource.Current as Articulo;
            Editando = actual != null;            
            if (Editando)            
            {
                List<ArticuloCategoria> categoriasArticulo = repartcategorias.Listar(new FiltroArticuloCategoria() { IdArticulo = actual.IdArticulo }, out _);
                
                CargarCategorias(categoriasArticulo);
                HabilitarControles(false, false);
                articuloBindingSource1.DataSource = actual;
            }
        }

        private void nupPagina_ValueChanged(object sender, EventArgs e)
        {
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
        }

        private void nupTamanioPagina_ValueChanged(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private const string up = " ↑";
        private const string down = " ↓";

        private string LimpiarNombre(string nombre)
        {
            if (nombre.Contains(up) || nombre.Contains(down))
            {
                nombre = nombre.Replace(up, string.Empty).Replace(down, string.Empty);
            }
            return nombre;
        }

        private void LimpiarOrdenamiento(string nombrecampo)
        {
            if (Filtro.Orden != null && Filtro.Orden != nombrecampo)
            {
                for (int i = 0; i < grvArticulo.Columns.Count; i++)
                {
                    var columna = grvArticulo.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }
        private void grvArticulo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = grvArticulo.Columns[e.ColumnIndex];
            string nombrecampo = columna.DataPropertyName;            
            if (!string.IsNullOrWhiteSpace(nombrecampo) && nombrecampo != nameof(Articulo.Descripcion))
            {
                LimpiarOrdenamiento(nombrecampo);
                var texto = LimpiarNombre(columna.HeaderText);
                Filtro.Descendente = Filtro.Orden == nombrecampo ? !Filtro.Descendente : false;
                texto += Filtro.Descendente ? down : up;
                columna.HeaderText = texto;
                Filtro.Orden = nombrecampo;
                ActualizaGrilla();
            }
        }

    }
}
