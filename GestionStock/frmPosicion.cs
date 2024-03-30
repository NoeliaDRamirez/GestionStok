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
    public partial class frmPosicion : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroPosicion Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroPosicion();
        private Repositorio<Posicion> Repositorio = new Repositorio<Posicion>(new PosicionIdentificador());
        private bool Editando = false;
        public frmPosicion()
        {
            InitializeComponent();
        }
        private void ActualizaGrilla()
        {
            posicionBindingSource.DataSource = null;
            posicionBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }
        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de posiciones";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos de la nueva posicion";
                }
                else
                {
                    grpFiltro.Text = "Datos de la posicion";
                }
            }
            chklbArrticuloMedida.Visible = !filtro;
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtPosicion.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
            chkActivo.ThreeState = filtro;
            chkActivo.CheckState = filtro ? CheckState.Indeterminate : CheckState.Unchecked;
        }
        private void frmPosicion_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            posicionBindingSource1.DataSource = new Posicion();
            Editando = false;
            HabilitarControles(true);
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            posicionBindingSource1.DataSource = new Posicion();
            //CargarCategorias();
            Editando = true;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Posicion actual = posicionBindingSource1.DataSource as Posicion;
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
            posicionBindingSource1.DataSource = new Posicion();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar esta posicion?", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Posicion actual = posicionBindingSource1.DataSource as Posicion;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Posicion actual = posicionBindingSource1.DataSource as Posicion;
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
            if (actual.IdPosicion != 0)
            {
                Filtro.IdPosicion = actual.IdPosicion;
            }
            else
            {
                Filtro.IdPosicion = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Posicion actual = posicionBindingSource.Current as Posicion;
            Editando = actual != null;
            if (Editando)
            {
                HabilitarControles(false, false);
                posicionBindingSource1.DataSource = actual;
            }
        }

        private void posicionBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Posicion actual = posicionBindingSource.Current as Posicion;
            if (Editando)
            {
                HabilitarControles(false, false);
                posicionBindingSource1.DataSource = actual;
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
                for (int i = 0; i < dgvPosicion.Columns.Count; i++)
                {
                    var columna = dgvPosicion.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }
        private void dgvPosicion_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = dgvPosicion.Columns[e.ColumnIndex];
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
