namespace GestionStock
{
    partial class frmVentaArticulo
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
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.ventaArticuloBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label9 = new System.Windows.Forms.Label();
            this.txtMontoUnitario = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbArticuloMedida = new System.Windows.Forms.ComboBox();
            this.articuloMedidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.cbArticulo = new System.Windows.Forms.ComboBox();
            this.articuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbVenta = new System.Windows.Forms.ComboBox();
            this.ventaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
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
            this.txtMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVentaArticulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvVentas = new System.Windows.Forms.DataGridView();
            this.idVentaArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idVentaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idArticuloMedidaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.montoUnitarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.articuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ventaArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaArticuloBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTamanioPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaArticuloBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.nudCantidad);
            this.grpFiltro.Controls.Add(this.label9);
            this.grpFiltro.Controls.Add(this.txtMontoUnitario);
            this.grpFiltro.Controls.Add(this.label8);
            this.grpFiltro.Controls.Add(this.cbArticuloMedida);
            this.grpFiltro.Controls.Add(this.label4);
            this.grpFiltro.Controls.Add(this.cbArticulo);
            this.grpFiltro.Controls.Add(this.cbVenta);
            this.grpFiltro.Controls.Add(this.label7);
            this.grpFiltro.Controls.Add(this.panel1);
            this.grpFiltro.Controls.Add(this.btnEditar);
            this.grpFiltro.Controls.Add(this.btnNuevo);
            this.grpFiltro.Controls.Add(this.btnGuardar);
            this.grpFiltro.Controls.Add(this.btnEliminar);
            this.grpFiltro.Controls.Add(this.btnCancelar);
            this.grpFiltro.Controls.Add(this.btnBuscar);
            this.grpFiltro.Controls.Add(this.txtMonto);
            this.grpFiltro.Controls.Add(this.label3);
            this.grpFiltro.Controls.Add(this.label2);
            this.grpFiltro.Controls.Add(this.txtVentaArticulo);
            this.grpFiltro.Controls.Add(this.label1);
            this.grpFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltro.Location = new System.Drawing.Point(0, 0);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(637, 232);
            this.grpFiltro.TabIndex = 3;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Datos ";
            // 
            // nudCantidad
            // 
            this.nudCantidad.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.ventaArticuloBindingSource1, "Cantidad", true));
            this.nudCantidad.Location = new System.Drawing.Point(113, 171);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(205, 20);
            this.nudCantidad.TabIndex = 32;
            // 
            // ventaArticuloBindingSource1
            // 
            this.ventaArticuloBindingSource1.DataSource = typeof(GestionStock.Data.EntityFramework.VentaArticulo);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 179);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(49, 13);
            this.label9.TabIndex = 31;
            this.label9.Text = "Cantidad";
            // 
            // txtMontoUnitario
            // 
            this.txtMontoUnitario.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ventaArticuloBindingSource1, "MontoUnitario", true));
            this.txtMontoUnitario.Location = new System.Drawing.Point(113, 146);
            this.txtMontoUnitario.Name = "txtMontoUnitario";
            this.txtMontoUnitario.Size = new System.Drawing.Size(205, 20);
            this.txtMontoUnitario.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 150);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(76, 13);
            this.label8.TabIndex = 29;
            this.label8.Text = "Monto Unitario";
            // 
            // cbArticuloMedida
            // 
            this.cbArticuloMedida.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ventaArticuloBindingSource1, "IdArticuloMedida", true));
            this.cbArticuloMedida.DataSource = this.articuloMedidaBindingSource;
            this.cbArticuloMedida.DisplayMember = "IdArticuloMedida";
            this.cbArticuloMedida.FormattingEnabled = true;
            this.cbArticuloMedida.Location = new System.Drawing.Point(113, 93);
            this.cbArticuloMedida.Name = "cbArticuloMedida";
            this.cbArticuloMedida.Size = new System.Drawing.Size(205, 21);
            this.cbArticuloMedida.TabIndex = 28;
            this.cbArticuloMedida.ValueMember = "IdArticuloMedida";
            // 
            // articuloMedidaBindingSource
            // 
            this.articuloMedidaBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.ArticuloMedida);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Id Articulo Medida";
            // 
            // cbArticulo
            // 
            this.cbArticulo.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ventaArticuloBindingSource1, "IdArticulo", true));
            this.cbArticulo.DataSource = this.articuloBindingSource;
            this.cbArticulo.DisplayMember = "Nombre";
            this.cbArticulo.FormattingEnabled = true;
            this.cbArticulo.Location = new System.Drawing.Point(113, 66);
            this.cbArticulo.Name = "cbArticulo";
            this.cbArticulo.Size = new System.Drawing.Size(205, 21);
            this.cbArticulo.TabIndex = 26;
            this.cbArticulo.ValueMember = "IdArticulo";
            // 
            // articuloBindingSource
            // 
            this.articuloBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.Articulo);
            // 
            // cbVenta
            // 
            this.cbVenta.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.ventaArticuloBindingSource1, "IdVenta", true));
            this.cbVenta.DataSource = this.ventaBindingSource;
            this.cbVenta.DisplayMember = "IdVenta";
            this.cbVenta.FormattingEnabled = true;
            this.cbVenta.Location = new System.Drawing.Point(113, 40);
            this.cbVenta.Name = "cbVenta";
            this.cbVenta.Size = new System.Drawing.Size(205, 21);
            this.cbVenta.TabIndex = 25;
            this.cbVenta.ValueMember = "IdVenta";
            // 
            // ventaBindingSource
            // 
            this.ventaBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.Venta);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 74);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 24;
            this.label7.Text = "Id Articulo";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nupTamanioPagina);
            this.panel1.Controls.Add(this.lbltotalPaginas);
            this.panel1.Controls.Add(this.nupPagina);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(499, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 213);
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
            this.btnEditar.Location = new System.Drawing.Point(96, 203);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(15, 204);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 15;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(243, 203);
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
            this.btnEliminar.Location = new System.Drawing.Point(405, 203);
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
            this.btnCancelar.Location = new System.Drawing.Point(324, 203);
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
            this.btnBuscar.Location = new System.Drawing.Point(176, 203);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(61, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtMonto
            // 
            this.txtMonto.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ventaArticuloBindingSource1, "Monto", true));
            this.txtMonto.Location = new System.Drawing.Point(113, 120);
            this.txtMonto.Name = "txtMonto";
            this.txtMonto.Size = new System.Drawing.Size(205, 20);
            this.txtMonto.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Id Venta";
            // 
            // txtVentaArticulo
            // 
            this.txtVentaArticulo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ventaArticuloBindingSource1, "IdVentaArticulo", true));
            this.txtVentaArticulo.Location = new System.Drawing.Point(113, 14);
            this.txtVentaArticulo.Name = "txtVentaArticulo";
            this.txtVentaArticulo.Size = new System.Drawing.Size(205, 20);
            this.txtVentaArticulo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Id Venta Articulo";
            // 
            // dgvVentas
            // 
            this.dgvVentas.AllowUserToAddRows = false;
            this.dgvVentas.AllowUserToDeleteRows = false;
            this.dgvVentas.AutoGenerateColumns = false;
            this.dgvVentas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvVentas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idVentaArticuloDataGridViewTextBoxColumn,
            this.idVentaDataGridViewTextBoxColumn,
            this.idArticuloDataGridViewTextBoxColumn,
            this.idArticuloMedidaDataGridViewTextBoxColumn,
            this.cantidadDataGridViewTextBoxColumn,
            this.montoDataGridViewTextBoxColumn,
            this.montoUnitarioDataGridViewTextBoxColumn,
            this.articuloDataGridViewTextBoxColumn});
            this.dgvVentas.DataSource = this.ventaArticuloBindingSource;
            this.dgvVentas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvVentas.Location = new System.Drawing.Point(0, 232);
            this.dgvVentas.Name = "dgvVentas";
            this.dgvVentas.ReadOnly = true;
            this.dgvVentas.Size = new System.Drawing.Size(637, 218);
            this.dgvVentas.TabIndex = 4;
            this.dgvVentas.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvVentas_ColumnHeaderMouseClick);
            // 
            // idVentaArticuloDataGridViewTextBoxColumn
            // 
            this.idVentaArticuloDataGridViewTextBoxColumn.DataPropertyName = "IdVentaArticulo";
            this.idVentaArticuloDataGridViewTextBoxColumn.HeaderText = "IdVentaArticulo";
            this.idVentaArticuloDataGridViewTextBoxColumn.Name = "idVentaArticuloDataGridViewTextBoxColumn";
            this.idVentaArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idVentaDataGridViewTextBoxColumn
            // 
            this.idVentaDataGridViewTextBoxColumn.DataPropertyName = "IdVenta";
            this.idVentaDataGridViewTextBoxColumn.HeaderText = "IdVenta";
            this.idVentaDataGridViewTextBoxColumn.Name = "idVentaDataGridViewTextBoxColumn";
            this.idVentaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idArticuloDataGridViewTextBoxColumn
            // 
            this.idArticuloDataGridViewTextBoxColumn.DataPropertyName = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.HeaderText = "IdArticulo";
            this.idArticuloDataGridViewTextBoxColumn.Name = "idArticuloDataGridViewTextBoxColumn";
            this.idArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idArticuloMedidaDataGridViewTextBoxColumn
            // 
            this.idArticuloMedidaDataGridViewTextBoxColumn.DataPropertyName = "IdArticuloMedida";
            this.idArticuloMedidaDataGridViewTextBoxColumn.HeaderText = "IdArticuloMedida";
            this.idArticuloMedidaDataGridViewTextBoxColumn.Name = "idArticuloMedidaDataGridViewTextBoxColumn";
            this.idArticuloMedidaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // cantidadDataGridViewTextBoxColumn
            // 
            this.cantidadDataGridViewTextBoxColumn.DataPropertyName = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.HeaderText = "Cantidad";
            this.cantidadDataGridViewTextBoxColumn.Name = "cantidadDataGridViewTextBoxColumn";
            this.cantidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoDataGridViewTextBoxColumn
            // 
            this.montoDataGridViewTextBoxColumn.DataPropertyName = "Monto";
            this.montoDataGridViewTextBoxColumn.HeaderText = "Monto";
            this.montoDataGridViewTextBoxColumn.Name = "montoDataGridViewTextBoxColumn";
            this.montoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // montoUnitarioDataGridViewTextBoxColumn
            // 
            this.montoUnitarioDataGridViewTextBoxColumn.DataPropertyName = "MontoUnitario";
            this.montoUnitarioDataGridViewTextBoxColumn.HeaderText = "MontoUnitario";
            this.montoUnitarioDataGridViewTextBoxColumn.Name = "montoUnitarioDataGridViewTextBoxColumn";
            this.montoUnitarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // articuloDataGridViewTextBoxColumn
            // 
            this.articuloDataGridViewTextBoxColumn.DataPropertyName = "Articulo";
            this.articuloDataGridViewTextBoxColumn.HeaderText = "Articulo";
            this.articuloDataGridViewTextBoxColumn.Name = "articuloDataGridViewTextBoxColumn";
            this.articuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ventaArticuloBindingSource
            // 
            this.ventaArticuloBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.VentaArticulo);
            this.ventaArticuloBindingSource.CurrentChanged += new System.EventHandler(this.ventaArticuloBindingSource_CurrentChanged);
            // 
            // frmVentaArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(637, 450);
            this.Controls.Add(this.dgvVentas);
            this.Controls.Add(this.grpFiltro);
            this.Name = "frmVentaArticulo";
            this.Text = "frmVentaArticulo";
            this.Load += new System.EventHandler(this.frmVentaArticulo_Load);
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaArticuloBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTamanioPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvVentas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ventaArticuloBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.ComboBox cbArticulo;
        private System.Windows.Forms.ComboBox cbVenta;
        private System.Windows.Forms.Label label7;
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
        private System.Windows.Forms.TextBox txtMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVentaArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvVentas;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVentaArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idVentaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn montoUnitarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn articuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource ventaArticuloBindingSource;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMontoUnitario;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbArticuloMedida;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.BindingSource ventaArticuloBindingSource1;
        private System.Windows.Forms.BindingSource articuloMedidaBindingSource;
        private System.Windows.Forms.BindingSource articuloBindingSource;
        private System.Windows.Forms.BindingSource ventaBindingSource;
    }
}