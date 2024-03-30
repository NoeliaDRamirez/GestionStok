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

namespace GestionStock
{
    public partial class frmCatergoria : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroCatergoria Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroCatergoria();
        private Repositorio<Catergoria> Repositorio = new Repositorio<Catergoria>(new CatergoriaIdentificador());
        private Repositorio<CategoriaRelacion> RepositorioCatRel = new Repositorio<CategoriaRelacion>(new CategoriaRelacionIdentificador());
        private bool Editando = false;
        public frmCatergoria()
        {
            InitializeComponent();
        }

        private void ActualizaGrilla()
        {
            CatergoriaBindingSource.DataSource = null;
            CatergoriaBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas :  1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }

        private void CargarPadres()
        {
            List<Catergoria> Padres = new List<Catergoria>();
            Padres.Add(new Catergoria() { Nombre = "Sin Padre", IdCategoria = 0 });
            Padres.AddRange(Repositorio.Listar(new FiltroCatergoria(), out _));
            catergoriaBindingSource2.DataSource = Padres;
        }

        private TreeNode ProcesarCategoria(Catergoria actual, List<Catergoria> categorias, List<CategoriaRelacion> relaciones)
        {
            var hijos = relaciones.Where(x=> x.IdCategoriaPadre == actual.IdCategoria).ToList();
            TreeNode tn = new TreeNode(actual.Nombre);
            foreach (var item in hijos)
            {
                var hijo = categorias.FirstOrDefault(x => x.IdCategoria == item.IdCategoriaHijo);
                if (hijo != null)
                {
                    tn.Nodes.Add(ProcesarCategoria(hijo, categorias, relaciones));
                }
            }
            return tn;
        }

        private void InicializarArbol()
        {
            treeView1.Nodes.Clear();
            TreeNode nodo = new TreeNode("Categorias");
            var listado = Repositorio.Listar(new FiltroCatergoria(), out _);
            var relaciones = RepositorioCatRel.Listar(new FiltroCategoriaRelacion(), out _);
            foreach (var item in listado)
            {
                if (relaciones.Any(x=> x.IdCategoriaHijo == item.IdCategoria))
                {
                    continue;
                }
                var nodohijo = ProcesarCategoria(item, listado, relaciones);
                if (nodohijo != null)
                {
                    nodo.Nodes.Add(nodohijo);
                }
            }
            treeView1.Nodes.Add(nodo);
        }

        private void frmCatergoria_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            CatergoriaBindingSource1.DataSource = new Catergoria();
            Editando = false;
            HabilitarControles(true);
            CargarPadres();
            InicializarArbol();
        }

        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de Catergorias";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nuevo Catergoria";
                }
                else
                {
                    grpFiltro.Text = "Datos del Catergoria"; 
                }
            }
            cbPadre.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtCatergoria.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
            chkActivo.ThreeState = filtro;
            chkActivo.CheckState = filtro ? CheckState.Indeterminate : CheckState.Unchecked;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            CatergoriaBindingSource1.DataSource = new Catergoria();
            Editando = true;
            cbPadre.SelectedIndex = 0;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Catergoria actual = CatergoriaBindingSource1.DataSource as Catergoria;
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
            Repositorio.Guardar(actual);
            Catergoria categoriapadre = cbPadre.SelectedItem as Catergoria;
            var Padre = RepositorioCatRel.Listar(new FiltroCategoriaRelacion() { IdCategoriaHijo = actual.IdCategoria }, out _).FirstOrDefault();
            if (categoriapadre != null && categoriapadre.IdCategoria > 0)
            {                
                if (Padre != null)
                {
                    if (Padre.IdCategoriaPadre != categoriapadre.IdCategoria)
                    {
                        Padre.IdCategoriaPadre = categoriapadre.IdCategoria;
                        RepositorioCatRel.Actualizar(Padre);
                    }
                }
                else
                {
                    Padre = new CategoriaRelacion();
                    Padre.IdCategoriaPadre = categoriapadre.IdCategoria;
                    Padre.IdCategoriaHijo = actual.IdCategoria;
                    RepositorioCatRel.Agregar(Padre);
                }
            }
            else if (Padre != null)
            {
                RepositorioCatRel.Eliminar(Padre);
            }
            ActualizaGrilla();
            CargarPadres();
            InicializarArbol();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            CatergoriaBindingSource1.DataSource  = new Catergoria();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este Catergoria?", "Eliminacion",MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                Catergoria actual = CatergoriaBindingSource1.DataSource as Catergoria;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
                CargarPadres();
                InicializarArbol();
            }
        }

        private void grvCatergoria_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void CatergoriaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Catergoria actual = CatergoriaBindingSource.Current as Catergoria;
            if (Editando)
            {
                HabilitarControles(false, false);
                CatergoriaBindingSource1.DataSource = actual;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Catergoria actual = CatergoriaBindingSource1.DataSource as Catergoria;
            if (chkActivo.CheckState != CheckState.Indeterminate)
            {
                Filtro.Activo = actual.Activo;
            }
            else
            {
                Filtro.Activo = null;
            }
            Filtro.Codigo = actual.Codigo;            
            Filtro.Nombre = actual.Nombre;
            if (actual.IdCategoria != 0)
            {
                Filtro.IdCatergoria = actual.IdCategoria;
            }
            else
            {
                Filtro.IdCatergoria = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Catergoria actual = CatergoriaBindingSource.Current as Catergoria;
            Editando = actual != null;            
            if (Editando)            
            {
                HabilitarControles(false, false);
                CatergoriaBindingSource1.DataSource = actual;
                // esto fuerza la existencia de un solo padre
                var Padre = RepositorioCatRel.Listar(new FiltroCategoriaRelacion() { IdCategoriaHijo = actual.IdCategoria }, out _).FirstOrDefault();
                if (Padre != null)
                {
                    List<Catergoria> Padres = catergoriaBindingSource2.DataSource as List<Catergoria>;
                    if (Padre != null)
                    {
                        cbPadre.SelectedItem = Padres.FirstOrDefault(x => x.IdCategoria == Padre.IdCategoriaPadre);
                    }
                }
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
                for (int i = 0; i < grvCatergoria.Columns.Count; i++)
                {
                    var columna = grvCatergoria.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }
        private void grvCatergoria_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = grvCatergoria.Columns[e.ColumnIndex];
            string nombrecampo = columna.DataPropertyName;            
            if (!string.IsNullOrWhiteSpace(nombrecampo))
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

        private void btnGuardar_Click_1(object sender, EventArgs e)
        {

        }
    }
}
