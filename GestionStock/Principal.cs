using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionStock
{
    public partial class Principal : Form
    {
        private int childFormNumber = 0;

        public Principal()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void ToolBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStrip.Visible = toolBarToolStripMenuItem.Checked;
        }

        private void StatusBarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            statusStrip.Visible = statusBarToolStripMenuItem.Checked;
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticulo frm = new frmArticulo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCatergoria frm = new frmCatergoria();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void formaDePagoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFormaPago frm = new frmFormaPago();
            frm.MdiParent = this;
            frm.Show();
        }

        private void medidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMedida frm= new frmMedida();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tiposDeMedidasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoMedida frm= new frmTipoMedida();
            frm.MdiParent = this;
            frm.Show();
        }

        private void posicionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPosicion frm = new frmPosicion();
            frm.MdiParent = this;
            frm.Show();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmCliente frm = new frmCliente();
            frm.MdiParent = this;
            frm.Show();
        }

        private void Principal_Load(object sender, EventArgs e)
        {

        }

        private void ventaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVenta frm = new frmVenta();
            frm.MdiParent = this;
            frm.Show();
        }

        private void ventaDeArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmVentaArticulo frm = new frmVentaArticulo();
            frm.MdiParent = this;
            frm.Show();
        }

        private void tipoMovimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTipoMovimiento frm = new frmTipoMovimiento();
            frm.MdiParent = this;
            frm.Show();
        }

        
        private void articuloMedidaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmArticuloMedida frm = new frmArticuloMedida();
            frm.MdiParent = this;
            frm.Show();
        }

        private void movimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMovimiento frm = new frmMovimiento();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedoresToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmProveedor frm = new frmProveedor();
            frm.MdiParent = this;
            frm.Show();
        }

        private void proveedorArticuloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProveedorArticulo frm = new frmProveedorArticulo();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
