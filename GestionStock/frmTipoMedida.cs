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
    public partial class frmTipoMedida : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroTipoMedida Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroTipoMedida();
        private Repositorio<TipoMedida> Repositorio = new Repositorio<TipoMedida>(new TipoMedidaIdentificador());
        private bool Editando = false;
        public frmTipoMedida()
        {
            InitializeComponent();
        }

        private void ActualizaGrilla()
        {
            tipoMedidaBindingSource.DataSource = null;
            tipoMedidaBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }

        private void frmTipoMedida_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            tipoMedidaBindingSource1.DataSource = new TipoMedida();
            Editando = false;
            HabilitarControles(true);
        }

        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de TipoMedidas";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nuevo TipoMedida";
                }
                else
                {
                    grpFiltro.Text = "Datos del TipoMedida"; 
                }
            }
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txttipoMedida.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
        }

        

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            tipoMedidaBindingSource1.DataSource = new TipoMedida(); 
            Editando = true;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            TipoMedida actual = tipoMedidaBindingSource1.DataSource as TipoMedida;
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
            bool nuevo = actual.IdTipoMedida == 0;
            Repositorio.Guardar(actual);          
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            tipoMedidaBindingSource1.DataSource  = new TipoMedida();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este TipoMedida?", "Eliminacion",MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                TipoMedida actual = tipoMedidaBindingSource1.DataSource as TipoMedida;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void grvTipoMedida_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void tipoMedidaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            TipoMedida actual = tipoMedidaBindingSource.Current as TipoMedida;
            if (Editando)
            {
                HabilitarControles(false, false);
                tipoMedidaBindingSource1.DataSource = actual;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            TipoMedida actual = tipoMedidaBindingSource1.DataSource as TipoMedida;
            Filtro.Codigo = actual.Codigo;
            Filtro.Nombre = actual.Nombre;
            if (actual.IdTipoMedida != 0)
            {
                Filtro.IdTipoMedida = actual.IdTipoMedida;
            }
            else
            {
                Filtro.IdTipoMedida = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            TipoMedida actual = tipoMedidaBindingSource.Current as TipoMedida;
            Editando = actual != null;            
            if (Editando)            
            {             
                HabilitarControles(false, false);
               tipoMedidaBindingSource1.DataSource = actual;
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
                for (int i = 0; i < grvtipoMedida.Columns.Count; i++)
                {
                    var columna = grvtipoMedida.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }
        private void grvTipoMedida_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = grvtipoMedida.Columns[e.ColumnIndex];
            string nombrecampo = columna.DataPropertyName;            
            if (!string.IsNullOrWhiteSpace(nombrecampo) && nombrecampo != nameof(TipoMedida.Codigo))
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
