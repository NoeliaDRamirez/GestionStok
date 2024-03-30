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
    public partial class frmProveedorArticulo : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroProveedorArticulo Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroProveedorArticulo();
        private Repositorio<ProveedorArticulo> Repositorio = new Repositorio<ProveedorArticulo>(new ProveedorArticuloIdentificador());
        private Repositorio<ArticuloMedida> RArticuloMedida = new Repositorio<ArticuloMedida>(new ArticuloMedidaIdentificador());
        private Repositorio<Proveedor> RProveedor= new Repositorio<Proveedor>(new ProveedorIdentificador());
        private Repositorio<FormaPago> RForma = new Repositorio<FormaPago>(new FormaPagoIdentificador());
        private bool Editando = false;

        public frmProveedorArticulo()
        {
            InitializeComponent();
        }
        private void ActualizaGrilla()
        {
            proveedorArticuloBindingSource.DataSource = null;
            proveedorArticuloBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void CargarArticuloMedidas()
        {
            List<ArticuloMedida> ArticulosMedida = new List<ArticuloMedida>();
            ArticulosMedida.AddRange(RArticuloMedida.Listar(new FiltroArticuloMedida(), out _));
            articuloMedidaBindingSource.DataSource = ArticulosMedida;
        }
        private void CargarProveedores()
        {
            List<Proveedor> proveedor = new List<Proveedor>();
            proveedor.AddRange(RProveedor.Listar(new FiltroProveedor(), out _));
            proveedorBindingSource.DataSource = proveedor;
        }
        private void CargarFormas()
        {
            List<FormaPago> formas = new List<FormaPago>();
            formas.AddRange(RForma.Listar(new FiltroFormaPago(), out _));
            formaBindingSource.DataSource = formas;
        }

        private void frmProveedorArticulo_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            
            proveedorArticuloBindingSource1.DataSource = new ProveedorArticulo();
            Editando = false;
            ActualizaGrilla();
            HabilitarControles(true);
            CargarArticuloMedidas();
            CargarProveedores();
            CargarFormas();
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de ProveedorArticulo";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nuevo ProveedorArticulo";
                }
                else
                {
                    grpFiltro.Text = "Datos del ProveedorArticulo";
                }
            }
            cbArticuloMedida.Visible = !filtro;
            cbProveedor.Visible = !filtro;
            cbForma.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtIdProveedorArticulo.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro; 
            nudCantidad.Enabled = !filtro;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            
            Editando = true;
            proveedorArticuloBindingSource1.DataSource = new ProveedorArticulo();
            try
            {
                cbArticuloMedida.SelectedIndex = 0;
                cbProveedor.SelectedIndex = 0;
                cbForma.SelectedIndex = 0;
            }
            catch(Exception ex)
            {
                MessageBox.Show("No existen articulosMedidas, proveedores o formas de pago", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            ProveedorArticulo actual = proveedorArticuloBindingSource1.DataSource as ProveedorArticulo;
            if (actual == null)
            {
                MessageBox.Show("No se esta editando una entidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }            
            Repositorio.Guardar(actual);
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            proveedorArticuloBindingSource1.DataSource = new ProveedorArticulo();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este ProveedorArticulo?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                ProveedorArticulo actual = proveedorArticuloBindingSource1.DataSource as ProveedorArticulo;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void ProveedorArticuloBindingSource1_CurrentChanged(object sender, EventArgs e)
        {
            ProveedorArticulo actual = proveedorArticuloBindingSource.Current as ProveedorArticulo;
            if (Editando)
            {
                HabilitarControles(false, false);
                proveedorArticuloBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            ProveedorArticulo actual = proveedorArticuloBindingSource1.DataSource as ProveedorArticulo;
            if (chkEntregado.CheckState != CheckState.Indeterminate)
            {
                Filtro.Entregado = actual.Entregado;
            }
            else
            {
                Filtro.Entregado = null;
            }
            Filtro.IdArticuloMedida = actual.IdArticuloMedida;
            /*Filtro.IdProveedor = actual.IdProveedor;
            Filtro.IdForma = actual.IdForma; 
            Filtro.Precio = actual.Precio;
            Filtro.Cantidad = actual.Cantidad;
            Filtro.FechaCompra = actual.FechaCompra;
            Filtro.FechaPedido = actual.FechaPedido;
            Filtro.PlazoPactado = actual.PlazoPactado;*/
            if (actual.IdProveedorArticulo != 0)
            {
                Filtro.IdProveedorArticulo = actual.IdProveedorArticulo;
            }
            else
            {
                Filtro.IdProveedorArticulo = null;
            }
            
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ProveedorArticulo actual = proveedorArticuloBindingSource.Current as ProveedorArticulo;
            Editando = actual != null;
            if (Editando)
            {
                HabilitarControles(false, false);
                proveedorArticuloBindingSource1.DataSource = actual;
                /*var articuloMedida = RArticuloMedida.Listar(new FiltroArticuloMedida() { IdArticuloMedida = actual.IdArticuloMedida }, out _).FirstOrDefault();
                if (articuloMedida != null)
                {
                    List<ArticuloMedida> ArtMedidas = articuloMedidaBindingSource.DataSource as List<ArticuloMedida>;
                    if (ArtMedidas != null)
                    {
                        cbArticuloMedida.SelectedItem = ArtMedidas.FirstOrDefault(x => x.IdArticuloMedia == ArtMedidas.IdArticuloMedida);
                    }
                }*/
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
                for (int i = 0; i < grvProveedorArticulo.Columns.Count; i++)
                {
                    var columna = grvProveedorArticulo.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }

        private void grvProveedorArticulo_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = grvProveedorArticulo.Columns[e.ColumnIndex];
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

        private void ProveedorArticuloBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            ProveedorArticulo actual = proveedorArticuloBindingSource.Current as ProveedorArticulo;
            if (Editando)
            {
                HabilitarControles(false, false);
                proveedorArticuloBindingSource1.DataSource = actual;
            }
        }
    }
}
