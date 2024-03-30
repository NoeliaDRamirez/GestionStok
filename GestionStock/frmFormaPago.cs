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
    public partial class frmFormaPago : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroFormaPago Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroFormaPago();
        private Repositorio<FormaPago> Repositorio = new Repositorio<FormaPago>(new FormaPagoIdentificador());

        private bool Editando = false;

        public frmFormaPago()
        {
            InitializeComponent();
        }
        private void ActualizaGrilla()
        {
            formaPagoBindingSource.DataSource = null;
            formaPagoBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de formas de pago";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos de la nueva forma de pago";
                }
                else
                {
                    grpFiltro.Text = "Datos de la forma de pago";
                }
            }

            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtForma.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;

        }
        private void frmFormaPago_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            formaPagoBindingSource1.DataSource = new FormaPago();
            Editando = false;
            HabilitarControles(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            formaPagoBindingSource1.DataSource = new FormaPago();

            Editando = true;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            FormaPago actual = formaPagoBindingSource1.DataSource as FormaPago;
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

            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            formaPagoBindingSource1.DataSource = new FormaPago();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar esta forma de pago?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormaPago actual = formaPagoBindingSource1.DataSource as FormaPago;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void formaPagoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            FormaPago actual = formaPagoBindingSource1.Current as FormaPago;
            if (Editando)
            {
                HabilitarControles(false, false);
                formaPagoBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FormaPago actual = formaPagoBindingSource1.DataSource as FormaPago;

            Filtro.Codigo = actual.Codigo;
            Filtro.FechaCreacion = actual.FechaCreacion;
            Filtro.Nombre = actual.Nombre;
            if (actual.IdForma != 0)
            {
                Filtro.IdForma = actual.IdForma;
            }
            else
            {
                Filtro.IdForma = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            FormaPago actual = formaPagoBindingSource.Current as FormaPago;
            Editando = actual != null;
            

            if (Editando)
            {

                HabilitarControles(false, false);
                formaPagoBindingSource1.DataSource = actual;
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
                for (int i = 0; i < dgvFormaPago.Columns.Count; i++)
                {
                    var columna = dgvFormaPago.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }

        private void dgvFormaPago_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = dgvFormaPago.Columns[e.ColumnIndex];
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
