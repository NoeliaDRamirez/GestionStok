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
    public partial class frmMovimiento : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroMovimiento Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroMovimiento();
        private Repositorio<Movimiento> Repositorio = new Repositorio<Movimiento>(new MovimientoIdentificador());
        private Repositorio<ArticuloMedida> repArticuloMedida = new Repositorio<ArticuloMedida>(new ArticuloMedidaIdentificador());
        private Repositorio<TipoMovimiento> repTipoMovimiento = new Repositorio<TipoMovimiento>(new TipoMovimientoIdentificador());
        private Repositorio<Posicion> repPosicionO = new Repositorio<Posicion>(new PosicionIdentificador());
        private Repositorio<Posicion> repPosicionD = new Repositorio<Posicion>(new PosicionIdentificador());
        private Repositorio<Proveedor> repProveedorO = new Repositorio<Proveedor>(new ProveedorIdentificador());
        private Repositorio<Proveedor> repProveedorD = new Repositorio<Proveedor>(new ProveedorIdentificador());
        private Repositorio<Venta> repVentaO = new Repositorio<Venta>(new VentaIdentificador());
        private Repositorio<Venta> repVentaD = new Repositorio<Venta>(new VentaIdentificador());

        private bool Editando = false;

        public frmMovimiento()
        {
            InitializeComponent();
        }

        private void ActualizaGrilla()
        {
            movimientoBindingSource.DataSource = null;
            movimientoBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de movimientos";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos de nuevo movimiento";
                }
                else
                {
                    grpFiltro.Text = "Datos de movimiento";
                }
            }
            cbPosicionOrigen.Visible = !filtro;
            cbArticuloMedida.Visible = !filtro;
            cbTipoMovimiento.Visible = !filtro;
            cbPosicionDestino.Visible = !filtro;
            cbProveedorOrigen.Visible = !filtro;
            cbProveedorDestino.Visible = !filtro;
            cbVentaOrigen.Visible = !filtro;
            cbVentaDestino.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtMovimiento.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
        }
        private void frmMovimiento_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);

            movimientoBindingSource1.DataSource = new Movimiento();
            Editando = false;

            ActualizaGrilla();
            HabilitarControles(true);

            CargarTipoMovimiento();
            CargarArticulosMedidas();
            CargarPosicionesO();
            CargarPosicionesD();
            CargarProveedoresO();
            CargarProveedoresD();
            CargarVentasO();
            CargarVentasD();


        }
        private void CargarTipoMovimiento(List<TipoMovimiento> seleccionados = null)
        {
            List<TipoMovimiento> ventas = new List<TipoMovimiento>();
            ventas.AddRange(repTipoMovimiento.Listar(new FiltroTipoMovimiento(), out _));
            tipoMovimientoBindingSource.DataSource = ventas;
        }
        
        private void CargarArticulosMedidas(List<ArticuloMedida> seleccionados = null)
        {
            List<ArticuloMedida> articulosMed = new List<ArticuloMedida>();
            articulosMed.AddRange(repArticuloMedida.Listar(new FiltroArticuloMedida(), out _));
            articuloMedidaBindingSource.DataSource = articulosMed;
        }
        private void CargarPosicionesO(List<Posicion> seleccionados = null)
        {
            List<Posicion> posicionesO = new List<Posicion>();
            posicionesO.AddRange(repPosicionO.Listar(new FiltroPosicion(), out _));
            posicionBindingSource.DataSource = posicionesO;
        }
        private void CargarPosicionesD(List<Posicion> seleccionados = null)
        {
            List<Posicion> posicionesD = new List<Posicion>();
            posicionesD.AddRange(repPosicionD.Listar(new FiltroPosicion(), out _));
            posicionBindingSource1.DataSource = posicionesD;
        }
        private void CargarProveedoresO(List<Proveedor> seleccionados = null)
        {
            List<Proveedor> proveedoresO = new List<Proveedor>();
            proveedoresO.AddRange(repProveedorO.Listar(new FiltroProveedor(), out _));
            proveedorBindingSource.DataSource = proveedoresO;
        }
        private void CargarProveedoresD(List<Proveedor> seleccionados = null)
        {
            List<Proveedor> proveedoresD = new List<Proveedor>();
            proveedoresD.AddRange(repProveedorD.Listar(new FiltroProveedor(), out _));
            proveedorBindingSource1.DataSource = proveedoresD;
        }
        private void CargarVentasO(List<Venta> seleccionados = null)
        {
            List<Venta> ventasO = new List<Venta>();
            ventasO.AddRange(repVentaO.Listar(new FiltroVenta(), out _));
            ventaBindingSource.DataSource = ventasO;
        }
        private void CargarVentasD(List<Venta> seleccionados = null)
        {
            List<Venta> ventasD = new List<Venta>();
            ventasD.AddRange(repVentaD.Listar(new FiltroVenta(), out _));
            ventaBindingSource1.DataSource = ventasD;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Editando = true;

            movimientoBindingSource1.DataSource = new Movimiento();

            try
            {
                cbTipoMovimiento.SelectedIndex = 0;
                cbArticuloMedida.SelectedIndex = 0;
                cbPosicionOrigen.SelectedIndex = 0;
                cbPosicionDestino.SelectedIndex = 0;
                cbProveedorOrigen.SelectedIndex = 0;
                cbProveedorDestino.SelectedIndex = 0;
                cbVentaOrigen.SelectedIndex = 0;
                cbVentaDestino.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existen proveedores, ventas, destinos o posiciones", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Movimiento actual = movimientoBindingSource1.DataSource as Movimiento;
            if (actual == null)
            {
                MessageBox.Show("No se esta editando una entidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (actual.Cantidad == 0)
            {
                MessageBox.Show("la canidad es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (actual.IdTipoMovimiento == 0)
            {
                MessageBox.Show("El tipo de movimiento es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (actual.IdArticuloMedida == 0)
            {
                MessageBox.Show("El id del articulo medida es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            Repositorio.Guardar(actual);
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            movimientoBindingSource1.DataSource = new Movimiento();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este movimiento?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Movimiento actual = movimientoBindingSource1.DataSource as Movimiento;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void movimientoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Movimiento actual = movimientoBindingSource.Current as Movimiento;
            if (Editando)
            {
                HabilitarControles(false, false);
                movimientoBindingSource1.DataSource = actual;
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Movimiento actual = movimientoBindingSource.Current as Movimiento;
            Editando = actual != null;
            if (Editando)
            {

                HabilitarControles(false, false);
                movimientoBindingSource1.DataSource = actual;

                var tipoMov=repTipoMovimiento.Listar(new FiltroTipoMovimiento() { IdTipoMovimiento = actual.IdTipoMovimiento }, out _).FirstOrDefault();
                var artmed = repArticuloMedida.Listar(new FiltroArticuloMedida() { IdArticuloMedida = actual.IdArticuloMedida }, out _).FirstOrDefault();
                var ventO = repVentaO.Listar(new FiltroVenta() { IdVenta = actual.IdVentaOrigen }, out _).FirstOrDefault();
                var ventD = repVentaD.Listar(new FiltroVenta() { IdVenta = actual.IdVentaDestino }, out _).FirstOrDefault();
                var posO = repPosicionO.Listar(new FiltroPosicion() { IdPosicion = actual.IdPosicionOrigen }, out _).FirstOrDefault();
                var posD = repPosicionD.Listar(new FiltroPosicion() { IdPosicion = actual.IdPosicionDestino }, out _).FirstOrDefault();
                var provO = repProveedorO.Listar(new FiltroProveedor() { IdProveedor = actual.IdProveedorOrigen }, out _).FirstOrDefault();
                var provD = repProveedorD.Listar(new FiltroProveedor() { IdProveedor = actual.IdProveedorDestino }, out _).FirstOrDefault();

                if (tipoMov != null)
                {
                    List<TipoMovimiento> tiposM = tipoMovimientoBindingSource.DataSource as List<TipoMovimiento>;


                    if (artmed != null)
                    {
                        cbTipoMovimiento.SelectedItem = tiposM.FirstOrDefault(x => x.IdTipoMovimiento == tipoMov.IdTipoMovimiento);

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
                if (ventO != null)
                {
                    List<Venta> ventasO = ventaBindingSource.DataSource as List<Venta>;


                    if (ventO != null)
                    {
                        cbVentaOrigen.SelectedItem = ventasO.FirstOrDefault(x => x.IdVenta == ventO.IdVenta);
                    }
                }
                if (ventD != null)
                {
                    List<Venta> ventasD = ventaBindingSource1.DataSource as List<Venta>;


                    if (ventD != null)
                    {
                        cbVentaDestino.SelectedItem = ventasD.FirstOrDefault(x => x.IdVenta == ventO.IdVenta);

                    }
                }
                if (posO != null)
                {
                    List<Posicion> posicionO = posicionBindingSource.DataSource as List<Posicion>;


                    if (posO != null)
                    {
                        cbPosicionOrigen.SelectedItem = posicionO.FirstOrDefault(x => x.IdPosicion == posO.IdPosicion);
                    }
                }
                if (posD != null)
                {
                    List<Posicion> posicionD = posicionBindingSource1.DataSource as List<Posicion>;


                    if (posD != null)
                    {
                        cbPosicionDestino.SelectedItem = posicionD.FirstOrDefault(x => x.IdPosicion == posD.IdPosicion);
                    }
                }
                if (provO != null)
                {
                    List<Proveedor> proveedorO = proveedorBindingSource.DataSource as List<Proveedor>;


                    if (provO != null)
                    {
                        cbProveedorOrigen.SelectedItem = proveedorO.FirstOrDefault(x => x.IdProveedor == provO.IdProveedor);
                    }
                }
                if (provD != null)
                {
                    List<Proveedor> proveedorD = proveedorBindingSource1.DataSource as List<Proveedor>;


                    if (provD != null)
                    {
                        cbProveedorDestino.SelectedItem = proveedorD.FirstOrDefault(x => x.IdProveedor == provO.IdProveedor);
                    }
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Movimiento actual = movimientoBindingSource1.DataSource as Movimiento;

            if (actual.IdMovimiento != 0)
            {
                Filtro.IdMovimiento = actual.IdMovimiento;
            }
            else
            {
                Filtro.IdMovimiento = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
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
