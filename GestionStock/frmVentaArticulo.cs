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
    public partial class frmVentaArticulo : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroVentaArticulo Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroVentaArticulo();
        private Repositorio<VentaArticulo> Repositorio = new Repositorio<VentaArticulo>(new VentaArticuloIdentificador());
        private Repositorio<Venta> repVenta = new Repositorio<Venta>(new VentaIdentificador());
        private Repositorio<Articulo> repArticulo = new Repositorio<Articulo>(new ArticuloIdentificador());
        private Repositorio<ArticuloMedida> repArticuloMedida = new Repositorio<ArticuloMedida>(new ArticuloMedidaIdentificador());

        private bool Editando = false;
        public frmVentaArticulo()
        {
            InitializeComponent();
        }
        private void ActualizaGrilla()
        {
            ventaArticuloBindingSource.DataSource = null;
            ventaArticuloBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de Ventas";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos de nueva Venta";
                }
                else
                {
                    grpFiltro.Text = "Datos de Venta";
                }
            }
            cbArticulo.Visible = !filtro;
            cbArticuloMedida.Visible = !filtro;
            cbVenta.Visible=!filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtVentaArticulo.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
        }
        private void frmVentaArticulo_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);

            ventaArticuloBindingSource1.DataSource = new VentaArticulo();
            Editando = false;

            ActualizaGrilla();
            HabilitarControles(true);
            CargarVentas();
            CargarArticulos();
            CargarArticulosMedidas();
        }
        private void CargarVentas(List<Cliente> seleccionados = null)
        {
            List<Venta> ventas = new List<Venta>();
            ventas.AddRange(repVenta.Listar(new FiltroVenta(), out _));
            ventaBindingSource.DataSource = ventas;
        }
        private void CargarArticulos(List<FormaPago> seleccionados = null)
        {
            List<Articulo> articulos = new List<Articulo>();
            articulos.AddRange(repArticulo.Listar(new FiltroArticulo(), out _));
            articuloBindingSource.DataSource = articulos;
        }
        private void CargarArticulosMedidas(List<FormaPago> seleccionados = null)
        {
            List<ArticuloMedida> articulosMed = new List<ArticuloMedida>();
            articulosMed.AddRange(repArticuloMedida.Listar(new FiltroArticuloMedida(), out _));
            articuloMedidaBindingSource.DataSource = articulosMed;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Editando = true;

            ventaArticuloBindingSource1.DataSource = new VentaArticulo();

            try
            {
                cbArticulo.SelectedIndex = 0;
                cbArticuloMedida.SelectedIndex = 0;
                cbVenta.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existen articulos, medidas o ventas", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            VentaArticulo actual = ventaArticuloBindingSource1.DataSource as VentaArticulo;
            if (actual == null)
            {
                MessageBox.Show("No se esta editando una entidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (actual.Monto == 0)
            {
                MessageBox.Show("El Monto es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (actual.MontoUnitario == 0)
            {
                MessageBox.Show("El Monto Unitario es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Repositorio.Guardar(actual);
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            ventaArticuloBindingSource1.DataSource = new VentaArticulo();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar esta venta?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                VentaArticulo actual = ventaArticuloBindingSource1.DataSource as VentaArticulo;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void ventaArticuloBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            VentaArticulo actual = ventaArticuloBindingSource.Current as VentaArticulo;
            if (Editando)
            {
                HabilitarControles(false, false);
                ventaArticuloBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            VentaArticulo actual = ventaArticuloBindingSource1.DataSource as VentaArticulo;
            
            if (actual.IdVentaArticulo != 0)
            {
                Filtro.IdVentaArticulo = actual.IdVentaArticulo;
            }
            else
            {
                Filtro.IdVentaArticulo = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            VentaArticulo actual = ventaArticuloBindingSource.Current as VentaArticulo;
            Editando = actual != null;
            if (Editando)
            {

                HabilitarControles(false, false);
                ventaArticuloBindingSource1.DataSource = actual;

                var art = repArticulo.Listar(new FiltroArticulo() { IdArticulo = actual.IdArticulo }, out _).FirstOrDefault();
                var artmed = repArticuloMedida.Listar(new FiltroArticuloMedida() { IdArticuloMedida = actual.IdArticuloMedida }, out _).FirstOrDefault();
                var vent = repVenta.Listar(new FiltroVenta() { IdVenta = actual.IdVenta }, out _).FirstOrDefault();


                if (art != null )
                {
                    List<Articulo> articulos = articuloBindingSource.DataSource as List<Articulo>;
                    

                    if (art != null )
                    {
                        cbArticulo.SelectedItem = articulos.FirstOrDefault(x => x.IdArticulo == art.IdArticulo);
                       
                    }
                }
                if (artmed != null)
                {
                    List<ArticuloMedida> articulosM = articuloMedidaBindingSource.DataSource as List<ArticuloMedida>;


                    if (artmed != null)
                    {
                        cbArticuloMedida.SelectedItem = articulosM.FirstOrDefault(x => x.IdArticuloMedida == artmed.IdArticuloMedida);

                    }
                }
                if (vent != null)
                {
                    List<Venta> ventas = ventaBindingSource.DataSource as List<Venta>;


                    if (vent != null)
                    {
                        cbVenta.SelectedItem = ventas.FirstOrDefault(x => x.IdVenta == vent.IdVenta);


                    }
                }
            }
        }

        private void nupTamanioPagina_ValueChanged(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void nupPagina_ValueChanged(object sender, EventArgs e)
        {
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
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
                for (int i = 0; i < dgvVentas.Columns.Count; i++)
                {
                    var columna = dgvVentas.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }

        private void dgvVentas_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = dgvVentas.Columns[e.ColumnIndex];
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
    }

    
    
}
