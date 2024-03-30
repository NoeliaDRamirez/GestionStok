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
    public partial class frmProveedor : Form
    {
        GestionStock.Data.EntityFramework.Filtros.FiltroProveedor Filtro = new GestionStock.Data.EntityFramework.Filtros.FiltroProveedor();
        private Repositorio<Proveedor> Repositorio = new Repositorio<Proveedor>(new ProveedorIdentificador());
       
        
        private bool Editando = false;
        public frmProveedor()
        {
            InitializeComponent();
        }

        private void ActualizaGrilla()
        {
            ProveedorBindingSource.DataSource = null;
            ProveedorBindingSource.DataSource = Repositorio.Listar(Filtro, out var total);
            int cantidadpaginas = (int)Math.Ceiling(total / nupTamanioPagina.Value);
            nupPagina.Maximum = cantidadpaginas > 0 ? cantidadpaginas : 1;
            lbltotalPaginas.Text = "/ " + nupPagina.Maximum.ToString();
            nupPagina.Minimum = 1;
        }

        private void frmProveedor_Load(object sender, EventArgs e)
        {
            Filtro.TamanioPagina = (int)nupTamanioPagina.Value;
            Filtro.NumeroPagina = (int)(nupPagina.Value - 1);
            ActualizaGrilla();
            ProveedorBindingSource1.DataSource = new Proveedor();
            Editando = false;
            HabilitarControles(true);
        }

        private void HabilitarControles(bool filtro, bool nuevo = false)
        {
            if (filtro)
            {
                grpFiltro.Text = "Busqueda de Proveedors";
            }
            else
            {
                if (nuevo)
                {
                    grpFiltro.Text = "Datos del nuevo Proveedor";
                }
                else
                {
                    grpFiltro.Text = "Datos del Proveedor"; 
                }
            }
            btnEditar.Visible = filtro;
            btnBuscar.Visible = filtro;
            btnNuevo.Visible = filtro;
            txtProveedor.Enabled = filtro;
            btnEliminar.Visible = !filtro && !nuevo;
            btnGuardar.Visible = !filtro;
            btnCancelar.Visible = !filtro;
            chkActivo.ThreeState = filtro;
            chkActivo.CheckState = filtro ? CheckState.Indeterminate : CheckState.Unchecked;
        }
      

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ProveedorBindingSource1.DataSource = new Proveedor();
            Editando = true;
            HabilitarControles(false, true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Proveedor actual = ProveedorBindingSource1.DataSource as Proveedor;
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
            bool nuevo = actual.IdProveedor == 0;
            Repositorio.Guardar(actual);
          
            ActualizaGrilla();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Editando = false;
            ProveedorBindingSource1.DataSource  = new Proveedor();
            ActualizaGrilla();
            HabilitarControles(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Esta seguro que desea eliminar este Proveedor?", "Eliminacion",MessageBoxButtons.YesNo, MessageBoxIcon.Question ) == DialogResult.Yes)
            {
                Proveedor actual = ProveedorBindingSource1.DataSource as Proveedor;
                Repositorio.Eliminar(actual);
                Editando = false;
                ActualizaGrilla();
                HabilitarControles(true);
            }
        }

        private void ProveedorBindingSource_CurrentChanged(object sender, EventArgs e)
        {
            Proveedor actual = ProveedorBindingSource.Current as Proveedor;
            if (Editando)
            {
                HabilitarControles(false, false);
                ProveedorBindingSource1.DataSource = actual;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Proveedor actual = ProveedorBindingSource1.DataSource as Proveedor;
            if (chkActivo.CheckState != CheckState.Indeterminate)
            {
                Filtro.Activo = actual.Activo;
            }
            else
            {
                Filtro.Activo = null;
            }
            Filtro.Codigo = actual.Codigo;
            Filtro.Email = actual.Email;
            Filtro.Nombre = actual.Nombre;
            if (actual.IdProveedor != 0)
            {
                Filtro.IdProveedor = actual.IdProveedor;
            }
            else
            {
                Filtro.IdProveedor = null;
            }
            nupPagina.Value = 1;
            Filtro.NumeroPagina = 0;
            ActualizaGrilla();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Proveedor actual = ProveedorBindingSource.Current as Proveedor;
            Editando = actual != null;            
            if (Editando)            
            {        
                HabilitarControles(false, false);
                ProveedorBindingSource1.DataSource = actual;
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
                for (int i = 0; i < grvProveedor.Columns.Count; i++)
                {
                    var columna = grvProveedor.Columns[i];
                    if (columna.DataPropertyName == Filtro.Orden)
                    {
                        columna.HeaderText = LimpiarNombre(columna.HeaderText);
                    }
                }
            }
        }
        private void grvProveedor_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var columna = grvProveedor.Columns[e.ColumnIndex];
            string nombrecampo = columna.DataPropertyName;            
            if (!string.IsNullOrWhiteSpace(nombrecampo) && nombrecampo != nameof(Proveedor.Email))
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
