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
    public partial class frmMedida : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroMedida Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroMedida();
        private Repositorio<Medida> Repositorio = new Repositorio<Medida>(new MedidaIdentificador());
        private Repositorio<TipoMedida> repTipoMedida = new Repositorio<TipoMedida>(new TipoMedidaIdentificador());
        private bool Editando = false;
        public frmMedida()
        {
            InitializeComponent();
        }

        private void ActualizaGrilla()
        {
            MedidaBindingSource.DataSource = null;
            MedidaBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void CargarTipoMedidas()
        {
            List<TipoMedida> TMedidas = new List<TipoMedida>();
            TMedidas.AddRange(repTipoMedida.Listar(new FiltroTipoMedida(), out _));
            tipoMedidaBindingSource.DataSource = TMedidas;
        }

        private void frmMedida_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            MedidaBindingSource1.DataSource = new Medida();
            Editando = false;
            HabilitarControles(true);
            CargarTipoMedidas();
        }

        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de Medidas";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos de la nueva medida";
                }
                else
                {
                    grpFiltro.Text = "Datos de la medida"; 
                }
            }
            lblTMedida.Visible = !filtro;
            cbTipoMedida.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtMedida.Enabled = filtro;
            txtIdTipoMedida.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
            chkActivo.ThreeState = filtro;
            chkActivo.CheckState = filtro ? CheckState.Indeterminate : CheckState.Unchecked;
        }


        private void btnNuevo_Click(object sender, EventArgs e)
        {
            MedidaBindingSource1.DataSource = new Medida();
            Editando = true;
            HabilitarControles(false, true);
            try
            {
                cbTipoMedida.SelectedIndex = 0;
            }
            catch (Exception)
            {
                MessageBox.Show("No existen tipoes de medidas", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                this.Close();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Medida actual = MedidaBindingSource1.DataSource as Medida;
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
            
            bool nuevo = actual.IdMedida == 0;
            Repositorio.Guardar(actual);       
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            MedidaBindingSource1.DataSource  = new Medida();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este Medida?", "Eliminacion",MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                Medida actual = MedidaBindingSource1.DataSource as Medida;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void grvMedida_SelectionChanged(object sender, EventArgs e)
        {

        }

        private void MedidaBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Medida actual = MedidaBindingSource.Current as Medida;
            if (Editando)
            {
                HabilitarControles(false, false);
                MedidaBindingSource1.DataSource = actual;
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Medida actual = MedidaBindingSource1.DataSource as Medida;
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
            if (actual.IdMedida != 0)
            {
                Filtro.IdMedida = actual.IdMedida;
            }
            else
            {
                Filtro.IdMedida = null;
            }
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
            Medida actual = MedidaBindingSource.Current as Medida;
            Editando = actual != null;            
            if (Editando)            
            {
                HabilitarControles(false, false);
                MedidaBindingSource1.DataSource = actual;
                var TipoMedida = repTipoMedida.Listar(new FiltroTipoMedida() { IdTipoMedida = actual.IdTipoMedida }, out _).FirstOrDefault();
                if (TipoMedida != null)
                {
                    List<TipoMedida> tm = tipoMedidaBindingSource.DataSource as List<TipoMedida>;
                    if (TipoMedida != null)
                    {
                        cbTipoMedida.SelectedItem = tm.FirstOrDefault(x => x.IdTipoMedida == TipoMedida.IdTipoMedida);
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
                for (int i = 0; i < grvMedida.Columns.Count; i++)
                {
                    var columna = grvMedida.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }
        private void grvMedida_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = grvMedida.Columns[e.ColumnIndex];
            string nombrecampo = columna.DataPropertyName;            
            if (!string.IsNullOrWhiteSpace(nombrecampo) && nombrecampo != nameof(Medida.Codigo))
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
