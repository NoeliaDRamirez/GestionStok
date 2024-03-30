namespace GestionStock
{
    partial class frmArticuloMedida
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.grvArticuloMedida = new System.Windows.Forms.DataGridView();
            this.idArticuloMedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idMedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadMinimaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articuloMedidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.chklbPosiciones = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.articuloMedidaBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.cbxMedida = new System.Windows.Forms.ComboBox();
            this.medidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cbxArticulo = new System.Windows.Forms.ComboBox();
            this.articuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.nupTamanioPagina = new System.Windows.Forms.NumericUpDown();
            this.lbltotalPaginas = new System.Windows.Forms.Label();
            this.nupPagina = new System.Windows.Forms.NumericUpDown();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtIdArticuloMedida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grvArticuloMedida)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource)).BeginInit();
            this.grpFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.medidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTamanioPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPagina)).BeginInit();
            this.SuspendLayout();
            // 
            // grvArticuloMedida
            // 
            this.grvArticuloMedida.AllowUserToAddRows = false;
            this.grvArticuloMedida.AllowUserToDeleteRows = false;
            this.grvArticuloMedida.AutoGenerateColumns = false;
            this.grvArticuloMedida.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvArticuloMedida.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idArticuloMedidaDataGridViewTextBoxColumn,
            this.idMedidaDataGridViewTextBoxColumn,
            this.idArticuloDataGridViewTextBoxColumn,
            this.cantidadMinimaDataGridViewTextBoxColumn});
            this.grvArticuloMedida.DataSource = this.articuloMedidaBindingSource;
            this.grvArticuloMedida.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvArticuloMedida.Location = new System.Drawing.Point(0, 218);
            this.grvArticuloMedida.Name = "grvArticuloMedida";
            this.grvArticuloMedida.ReadOnly = true;
            this.grvArticuloMedida.Size = new System.Drawing.Size(800, 232);
            this.grvArticuloMedida.TabIndex = 3;
            this.grvArticuloMedida.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvArticuloMedida_ColumnHeaderMouseClick);
            // 
            // idArticuloMedidaDataGridViewTextBoxColumn
            // 
            this.idArticuloMedidaDataGridViewTextBoxColumn.DataPropertyName = "IdArticuloMedida";
            this.idArticuloMedidaDataGridViewTextBoxColumn.HeaderText = "IdArticuloMedida";
            this.idArticuloMedidaDataGridViewTextBoxColumn.Name = "idArticuloMedidaDataGridViewTextBoxColumn";
            this.idArticuloMedidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idMedidaDataGridViewTextBoxColumn
            // 
            this.idMedidaDataGridViewTextBoxColumn.DataPropertyName = "IdMedida";
            this.idMedidaDataGridViewTextBoxColumn.HeaderText = "IdMedida";
            this.idMedidaDataGridViewTextBoxColumn.Name = "idMedidaDataGridViewTextBoxColumn";
            this.idMedidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idArticuloDataGridViewTextBoxColumn
            // 
            this.idArticuloDataGridViewTextBoxColumn.DataPropertyName = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.HeaderText = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.Name = "idArticuloDataGridViewTextBoxColumn";
            this.idArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadMinimaDataGridViewTextBoxColumn
            // 
            this.cantidadMinimaDataGridViewTextBoxColumn.DataPropertyName = "CantidadMinima";
            this.cantidadMinimaDataGridViewTextBoxColumn.HeaderText = "CantidadMinima";
            this.cantidadMinimaDataGridViewTextBoxColumn.Name = "cantidadMinimaDataGridViewTextBoxColumn";
            this.cantidadMinimaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // articuloMedidaBindingSource
            // 
            this.articuloMedidaBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.ArticuloMedida);
            this.articuloMedidaBindingSource.CurrentChanged += new System.EventHandler(this.articuloMedidaBindingSource_CurrentChanged_1);
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.chklbPosiciones);
            this.grpFiltro.Controls.Add(this.label3);
            this.grpFiltro.Controls.Add(this.label2);
            this.grpFiltro.Controls.Add(this.nudCantidad);
            this.grpFiltro.Controls.Add(this.cbxMedida);
            this.grpFiltro.Controls.Add(this.label4);
            this.grpFiltro.Controls.Add(this.cbxArticulo);
            this.grpFiltro.Controls.Add(this.panel1);
            this.grpFiltro.Controls.Add(this.btnEditar);
            this.grpFiltro.Controls.Add(this.btnNuevo);
            this.grpFiltro.Controls.Add(this.btnGuardar);
            this.grpFiltro.Controls.Add(this.btnEliminar);
            this.grpFiltro.Controls.Add(this.btnCancelar);
            this.grpFiltro.Controls.Add(this.btnBuscar);
            this.grpFiltro.Controls.Add(this.txtIdArticuloMedida);
            this.grpFiltro.Controls.Add(this.label1);
            this.grpFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltro.Location = new System.Drawing.Point(0, 0);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(800, 218);
            this.grpFiltro.TabIndex = 2;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Datos ArticuloMedida";
            // 
            // chklbPosiciones
            // 
            this.chklbPosiciones.FormattingEnabled = true;
            this.chklbPosiciones.Location = new System.Drawing.Point(407, 12);
            this.chklbPosiciones.Name = "chklbPosiciones";
            this.chklbPosiciones.Size = new System.Drawing.Size(120, 94);
            this.chklbPosiciones.TabIndex = 30;
            this.chklbPosiciones.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 80);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Medida";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "cantidad minima";
            // 
            // nudCantidad
            // 
            this.nudCantidad.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.articuloMedidaBindingSource1, "CantidadMinima", true));
            this.nudCantidad.Location = new System.Drawing.Point(115, 99);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 27;
            // 
            // articuloMedidaBindingSource1
            // 
            this.articuloMedidaBindingSource1.DataSource = typeof(GestionStock.Data.EntityFramework.ArticuloMedida);
            // 
            // cbxMedida
            // 
            this.cbxMedida.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.articuloMedidaBindingSource1, "IdMedida", true));
            this.cbxMedida.DataSource = this.medidaBindingSource;
            this.cbxMedida.DisplayMember = "Nombre";
            this.cbxMedida.FormattingEnabled = true;
            this.cbxMedida.Location = new System.Drawing.Point(115, 72);
            this.cbxMedida.Name = "cbxMedida";
            this.cbxMedida.Size = new System.Drawing.Size(205, 21);
            this.cbxMedida.TabIndex = 26;
            this.cbxMedida.ValueMember = "IdMedida";
            // 
            // medidaBindingSource
            // 
            this.medidaBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.Medida);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "Articulo";
            // 
            // cbxArticulo
            // 
            this.cbxArticulo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.articuloMedidaBindingSource1, "IdArticulo", true));
            this.cbxArticulo.DataSource = this.articuloBindingSource;
            this.cbxArticulo.DisplayMember = "Nombre";
            this.cbxArticulo.FormattingEnabled = true;
            this.cbxArticulo.Location = new System.Drawing.Point(115, 45);
            this.cbxArticulo.Name = "cbxArticulo";
            this.cbxArticulo.Size = new System.Drawing.Size(205, 21);
            this.cbxArticulo.TabIndex = 23;
            this.cbxArticulo.ValueMember = "IdArticulo";
            // 
            // articuloBindingSource
            // 
            this.articuloBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.Articulo);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nupTamanioPagina);
            this.panel1.Controls.Add(this.lbltotalPaginas);
            this.panel1.Controls.Add(this.nupPagina);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(662, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 199);
            this.panel1.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 120);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 24;
            this.label6.Text = "Pagina:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 13);
            this.label5.TabIndex = 23;
            this.label5.Text = "Elementos Por Pagina:";
            // 
            // nupTamanioPagina
            // 
            this.nupTamanioPagina.Location = new System.Drawing.Point(6, 93);
            this.nupTamanioPagina.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.nupTamanioPagina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupTamanioPagina.Name = "nupTamanioPagina";
            this.nupTamanioPagina.Size = new System.Drawing.Size(120, 20);
            this.nupTamanioPagina.TabIndex = 22;
            this.nupTamanioPagina.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nupTamanioPagina.ValueChanged += new System.EventHandler(this.nupTamanioPagina_ValueChanged);
            // 
            // lbltotalPaginas
            // 
            this.lbltotalPaginas.AutoSize = true;
            this.lbltotalPaginas.Location = new System.Drawing.Point(72, 140);
            this.lbltotalPaginas.Name = "lbltotalPaginas";
            this.lbltotalPaginas.Size = new System.Drawing.Size(21, 13);
            this.lbltotalPaginas.TabIndex = 21;
            this.lbltotalPaginas.Text = "/ 0";
            // 
            // nupPagina
            // 
            this.nupPagina.Location = new System.Drawing.Point(6, 139);
            this.nupPagina.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupPagina.Name = "nupPagina";
            this.nupPagina.Size = new System.Drawing.Size(60, 20);
            this.nupPagina.TabIndex = 20;
            this.nupPagina.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupPagina.ValueChanged += new System.EventHandler(this.nupPagina_ValueChanged);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(98, 150);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(17, 151);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 15;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(245, 150);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 16;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Visible = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(407, 150);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 18;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Visible = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(326, 150);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Visible = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(178, 150);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(61, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtIdArticuloMedida
            // 
            this.txtIdArticuloMedida.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.articuloMedidaBindingSource1, "IdArticuloMedida", true));
            this.txtIdArticuloMedida.Location = new System.Drawing.Point(115, 19);
            this.txtIdArticuloMedida.Name = "txtIdArticuloMedida";
            this.txtIdArticuloMedida.Size = new System.Drawing.Size(205, 20);
            this.txtIdArticuloMedida.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IdArticuloMedida";
            // 
            // frmArticuloMedida
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grvArticuloMedida);
            this.Controls.Add(this.grpFiltro);
            this.Name = "frmArticuloMedida";
            this.Text = "frmArticuloMedida";
            this.Load += new System.EventHandler(this.frmArticuloMedida_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvArticuloMedida)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource)).EndInit();
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.medidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTamanioPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPagina)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvArticuloMedida;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxArticulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nupTamanioPagina;
        private System.Windows.Forms.Label lbltotalPaginas;
        private System.Windows.Forms.NumericUpDown nupPagina;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtIdArticuloMedida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource articuloMedidaBindingSource;
        private System.Windows.Forms.BindingSource articuloBindingSource;
        private System.Windows.Forms.BindingSource medidaBindingSource;
        private System.Windows.Forms.ComboBox cbxMedida;
        private System.Windows.Forms.BindingSource articuloMedidaBindingSource1;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadMinimaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox chklbPosiciones;
    }
}