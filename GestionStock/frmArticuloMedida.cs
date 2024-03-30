using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GestionStock.Data.EntityFramework;
using GestionStock.Data.EntityFramework.Filtros;
using GestionStock.Data.EntityFramework.Entidades;

namespace GestionStock
{
    public partial class frmArticuloMedida : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroArticuloMedida Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroArticuloMedida();
        private Repositorio<ArticuloMedida> Repositorio = new Repositorio<ArticuloMedida>(new ArticuloMedidaIdentificador());
        private Repositorio<Articulo> RepositorioArticulo = new Repositorio<Articulo>(new ArticuloIdentificador());
        private Repositorio<Medida> RepositorioMedida = new Repositorio<Medida>(new MedidaIdentificador());
        private Repositorio<ArticuloMedidaPosicion> ramp = new Repositorio<ArticuloMedidaPosicion>(new ArticuloMedidaPosicionIdentificador());
        private bool Editando = false;

        public frmArticuloMedida()
        {
            InitializeComponent();
        }
        private void ActualizaGrilla()
        {
            articuloMedidaBindingSource.DataSource = null;
            articuloMedidaBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void CargarArticulos()
        {
            List<Articulo> Articulos = new List<Articulo>();
            Articulos.AddRange(RepositorioArticulo.Listar(new FiltroArticulo(), out _));
            articuloBindingSource.DataSource = Articulos;
        }
        private void CargarMedidas()
        {
            List<Medida> Medidas = new List<Medida>();
            Medidas.AddRange(RepositorioMedida.Listar(new FiltroMedida(), out _));
            medidaBindingSource.DataSource = Medidas;
        }
        private void CargarPosiciones(List<ArticuloMedidaPosicion> seleccionados = null)
        {
            if (seleccionados == null)
            {
                seleccionados = new List<ArticuloMedidaPosicion>();
            }
            Repositorio<Posicion> repositoriopo = new Repositorio<Posicion>(new PosicionIdentificador());
            var posiciones = repositoriopo.Listar(new FiltroPosicion(), out _);
            chklbPosiciones.Items.Clear();
            ((ListControl)chklbPosiciones).DisplayMember = "Nombre";
            ((ListControl)chklbPosiciones).ValueMember = "IdPosicion";
            foreach (var item in posiciones)
            {
                chklbPosiciones.Items.Add(item, seleccionados.Any(x => x.IdPosicion == item.IdPosicion));
            }
        }

        private void frmArticuloMedida_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            
            articuloMedidaBindingSource1.DataSource = new ArticuloMedida();
            Editando = false;
            ActualizaGrilla();
            HabilitarControles(true);
            CargarArticulos();
            CargarMedidas();
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de ArticulosMedidas";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nuevo ArticuloMedida";
                }
                else
                {
                    grpFiltro.Text = "Datos del ArticuloMedida";
                }
            }
            cbxArticulo.Visible = !filtro;
            chklbPosiciones.Visible = !filtro;
            cbxMedida.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtIdArticuloMedida.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro; 
            nudCantidad.Enabled = !filtro;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            Editando = true;
            articuloMedidaBindingSource1.DataSource = new ArticuloMedida();
            CargarPosiciones();
            try
            {
                cbxMedida.SelectedIndex = 0;
                cbxArticulo.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No existen medidas o articulos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ArticuloMedida actual = articuloMedidaBindingSource1.DataSource as ArticuloMedida;
            if (actual == null)
            {
                MessageBox.Show("No se esta editando una entidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            bool nuevo = actual.IdArticuloMedida == 0;
            Repositorio.Guardar(actual);
            var posiciones = chklbPosiciones.CheckedItems.Cast<Posicion>();
            List<ArticuloMedidaPosicion> ArticuloMP = ramp.Listar(new FiltroArticuloMedidaPosicion() { IdArticuloMedida = actual.IdArticuloMedida }, out _);
            foreach (var item in posiciones)
            {
                if (!ArticuloMP.Any(x => x.IdPosicion == item.IdPosicion))
                {
                    var nartposicion = new ArticuloMedidaPosicion() { IdArticuloMedida = actual.IdArticuloMedida, IdPosicion = item.IdPosicion };
                    ramp.Agregar(nartposicion);
                    ArticuloMP.Add(nartposicion);
                }
            }
            if (!nuevo)
            {
                foreach (var item in ArticuloMP)
                {
                    if (!posiciones.Any(x => x.IdPosicion == item.IdPosicion))
                    {
                        ramp.Eliminar(item);
                    }
                }
            }
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            articuloMedidaBindingSource1.DataSource = new ArticuloMedida();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este articuloMedida?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ArticuloMedida actual = articuloMedidaBindingSource1.DataSource as ArticuloMedida;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void articuloMedidaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ArticuloMedida actual = articuloMedidaBindingSource.Current as ArticuloMedida;
            if (Editando)
            {
                HabilitarControles(false, false);
                articuloMedidaBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ArticuloMedida actual = articuloMedidaBindingSource1.DataSource as ArticuloMedida;

            if (actual.IdArticuloMedida != 0)
            {
                Filtro.IdArticuloMedida = actual.IdArticuloMedida;
            }
            else
            {
                Filtro.IdArticuloMedida = null;
            }
            
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ArticuloMedida actual = articuloMedidaBindingSource.Current as ArticuloMedida;
            Editando = actual != null;
            if (Editando)
            {
                List<ArticuloMedidaPosicion> amp = ramp.Listar(new FiltroArticuloMedidaPosicion() { IdArticuloMedida = actual.IdArticuloMedida }, out _);
                CargarPosiciones(amp);
                HabilitarControles(false, false);
                articuloMedidaBindingSource1.DataSource = actual;
                var Articulo = RepositorioArticulo.Listar(new FiltroArticulo() { IdArticulo = actual.IdArticulo }, out _).FirstOrDefault();
                if (Articulo != null)
                {
                    List<Articulo> Articulos = articuloBindingSource.DataSource as List<Articulo>;
                    if (Articulo != null)
                    {
                        cbxArticulo.SelectedItem = Articulos.FirstOrDefault(x => x.IdArticulo == Articulo.IdArticulo);
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
                for (int i = 0; i < grvArticuloMedida.Columns.Count; i++)
                {
                    var columna = grvArticuloMedida.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }

        private void grvArticuloMedida_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = grvArticuloMedida.Columns[e.ColumnIndex];
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

        

        private void articuloMedidaBindingSource_CurrentChanged_1(object sender, EventArgs e)
        {
            ArticuloMedida actual = articuloMedidaBindingSource.Current as ArticuloMedida;
            if (Editando)
            {
                HabilitarControles(false, false);
                articuloMedidaBindingSource1.DataSource = actual;
            }
        }
    }
}
