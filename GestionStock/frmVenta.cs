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
    public partial class frmVenta : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroVenta Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroVenta();
        private Repositorio<Venta> Repositorio = new Repositorio<Venta>(new VentaIdentificador());
        private Repositorio<Cliente> repCliente = new Repositorio<Cliente>(new ClienteIdentificador());
        private Repositorio<FormaPago> repFormaPago = new Repositorio<FormaPago>(new FormaPagoIdentificador());

        private bool Editando = false;
        public frmVenta()
        {
            InitializeComponent();
        }
        private void ActualizaGrilla()
        {
            ventaBindingSource.DataSource = null;
            ventaBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void frmVenta_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            
            ventaBindingSource1.DataSource = new Venta();
            Editando = false;

            ActualizaGrilla();
            HabilitarControles(true);
            CargarClientes();
            CargarFormas();
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
            cbClientes.Visible = !filtro;
            cbFormas.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtVenta.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
        }
        private void CargarClientes(List<Cliente> seleccionados = null)
        {
            List<Cliente> clientes = new List<Cliente>();
            clientes.AddRange(repCliente.Listar(new FiltroCliente(), out _));
            clienteBindingSource.DataSource = clientes;
        }
        private void CargarFormas(List<FormaPago> seleccionados = null)
        {
            List<FormaPago> formas = new List<FormaPago>();
            formas.AddRange(repFormaPago.Listar(new FiltroFormaPago(), out _));
            formaPagoBindingSource.DataSource = formas;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Venta actual = ventaBindingSource1.DataSource as Venta;
            if (actual == null)
            {
                MessageBox.Show("No se esta editando una entidad", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (actual.Monto== 0)
            {
                MessageBox.Show("El Monto es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
           
            Repositorio.Guardar(actual);
            ActualizaGrilla();    
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Editando = true;

            ventaBindingSource1.DataSource = new Venta();
            //CargarClientes();
            //CargarFormas();
            try
            {
                cbClientes.SelectedIndex = 0;
                cbFormas.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("No existen clientes o formas de pago", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
            HabilitarControles(false, true);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            ventaBindingSource1.DataSource = new Venta();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar esta venta?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Venta actual = ventaBindingSource1.DataSource as Venta;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void ventaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Venta actual = ventaBindingSource.Current as Venta;
            if (Editando)
            {
                HabilitarControles(false, false);
                ventaBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Venta actual = ventaBindingSource1.DataSource as Venta;
            
            //Filtro.IdCliente = actual.IdCliente;
            //Filtro.IdForma = actual.IdForma;
           // Filtro.Monto = actual.Monto;
            //Filtro.Fecha = actual.Fecha;
            if (actual.IdVenta != 0)
            {
                Filtro.IdVenta = actual.IdVenta;
            }
            else
            {
                Filtro.IdVenta = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Venta actual = ventaBindingSource.Current as Venta;
            Editando = actual != null;
            if (Editando)
            {
                
                HabilitarControles(false, false);
                ventaBindingSource1.DataSource = actual;

                var cliente = repCliente.Listar(new FiltroCliente() { IdCliente = actual.IdCliente }, out _).FirstOrDefault();
                var forma = repFormaPago.Listar(new FiltroFormaPago() { IdForma = actual.IdForma }, out _).FirstOrDefault();

                if (cliente != null )
                {
                    List<Cliente> clientes = clienteBindingSource.DataSource as List<Cliente>;

                    if (cliente != null)
                    {
                        cbClientes.SelectedItem = clientes.FirstOrDefault(x => x.IdCliente == cliente.IdCliente);

                    }
                }
                if ( forma != null)
                {
                    
                    List<FormaPago> formas = formaPagoBindingSource.DataSource as List<FormaPago>;

                    if ( forma != null)
                    {
                        
                        cbFormas.SelectedItem = formas.FirstOrDefault(x => x.IdForma == forma.IdForma);

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
