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

namespace GestionStock
{
    public partial class frmTipoMovimiento : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroTipoMovimiento Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroTipoMovimiento();
        private Repositorio<TipoMovimiento> Repositorio = new Repositorio<TipoMovimiento>(new TipoMovimientoIdentificador());
        private bool Editando = false;
        public frmTipoMovimiento()
        {
            InitializeComponent();
        }
        private void ActualizaGrilla()
        {
            tipoMovimientoBindingSource.DataSource = null;
            tipoMovimientoBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de TipoMovimientos";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nueva TipoMovimiento";
                }
                else
                {
                    grpFiltro.Text = "Datos del TipoMovimiento";
                }
            }
            
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtTipoMovimiento.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
            
        }
        private void frmTipoMovimiento_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            tipoMovimientoBindingSource1.DataSource = new TipoMovimiento();
            Editando = false;
            HabilitarControles(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tipoMovimientoBindingSource1.DataSource = new TipoMovimiento();
            Editando = true;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoMovimiento actual = tipoMovimientoBindingSource1.DataSource as TipoMovimiento;
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
            tipoMovimientoBindingSource1.DataSource = new TipoMovimiento();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este TipoMovimiento?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                TipoMovimiento actual = tipoMovimientoBindingSource1.DataSource as TipoMovimiento;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TipoMovimiento actual = tipoMovimientoBindingSource1.DataSource as TipoMovimiento;
            
            Filtro.Codigo = actual.Codigo;
            Filtro.Nombre = actual.Nombre;
            if (actual.IdTipoMovimiento != 0)
            {
                Filtro.IdTipoMovimiento = actual.IdTipoMovimiento;
            }
            else
            {
                Filtro.IdTipoMovimiento = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            TipoMovimiento actual = tipoMovimientoBindingSource.Current as TipoMovimiento;
            Editando = actual != null;
            if (Editando)
            {
                HabilitarControles(false, false);
                tipoMovimientoBindingSource1.DataSource = actual;
            }
        }

        private void tipoMovimientoBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            TipoMovimiento actual = tipoMovimientoBindingSource.Current as TipoMovimiento;
            if (Editando)
            {
                HabilitarControles(false, false);
                tipoMovimientoBindingSource1.DataSource = actual;
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
                for (int i = 0; i < dgvTipoMovimiento.Columns.Count; i++)
                {
                    var columna = dgvTipoMovimiento.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }

        private void dgvTipoMovimiento_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = dgvTipoMovimiento.Columns[e.ColumnIndex];
            string nombrecampo = columna.DataPropertyName;
            if (!string.IsNullOrWhiteSpace(nombrecampo) && nombrecampo != nameof(TipoMovimiento.Nombre))
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
