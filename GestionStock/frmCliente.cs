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
    public partial class frmCliente : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroCliente Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroCliente();
        private Repositorio<Cliente> Repositorio = new Repositorio<Cliente>(new ClienteIdentificador());

        private bool Editando = false;
        public frmCliente()
        {
            InitializeComponent();
        }

        private void frmCliente_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            clienteBindingSource1.DataSource = new Cliente();
            Editando = false;
            HabilitarControles(true);
        }
        private void ActualizaGrilla()
        {
            clienteBindingSource.DataSource = null;
            clienteBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de Clientes";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nuevo cliente";
                }
                else
                {
                    grpFiltro.Text = "Datos del cliente";
                }
            }

            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtCliente.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            clienteBindingSource1.DataSource = new Cliente();
            Editando = true;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Cliente actual = clienteBindingSource1.DataSource as Cliente;
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
            if (string.IsNullOrWhiteSpace(actual.Apellido))
            {
                MessageBox.Show("El apellido es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(actual.Documento))
            {
                MessageBox.Show("El documento es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(actual.Calle))
            {
                MessageBox.Show("La calle es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(actual.Telefono))
            {
                MessageBox.Show("El telefono es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            if (string.IsNullOrWhiteSpace(actual.Observaciones))
            {
                MessageBox.Show("Observaciones es un campo requerido.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            
            Repositorio.Guardar(actual);
           
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            clienteBindingSource1.DataSource = new Cliente();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este cliente?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Cliente actual = clienteBindingSource1.DataSource as Cliente;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void clienteBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Cliente actual = clienteBindingSource.Current as Cliente;
            if (Editando)
            {
                HabilitarControles(false, false);
                clienteBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Cliente actual = clienteBindingSource1.DataSource as Cliente;

            if (actual.IdCliente != 0)
            {
                Filtro.IdCliente = actual.IdCliente;
            }
            else
            {
                Filtro.IdCliente = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Cliente actual = clienteBindingSource.Current as Cliente;
            Editando = actual != null;
            if (Editando)
            {
               
                HabilitarControles(false, false);
                clienteBindingSource1.DataSource = actual;
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
                for (int i = 0; i < dgvClientes.Columns.Count; i++)
                {
                    var columna = dgvClientes.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }

        private void dgvClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = dgvClientes.Columns[e.ColumnIndex];
            string nombrecampo = columna.DataPropertyName;
            if (!string.IsNullOrWhiteSpace(nombrecampo) && nombrecampo != nameof(Cliente.Observaciones))
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

