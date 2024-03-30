namespace GestionStock
{
    partial class frmProveedorArticulo
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
            this.grvProveedorArticulo = new System.Windows.Forms.DataGridView();
            this.idProveedorArticuloDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdProveedor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdArticuloMedida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdForma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaCompra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FechaPedido = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Entregado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PlazoPactado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.proveedorArticuloBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpFiltro = new System.Windows.Forms.GroupBox();
            this.chkEntregado = new System.Windows.Forms.CheckBox();
            this.proveedorArticuloBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.label11 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label10 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbForma = new System.Windows.Forms.ComboBox();
            this.proveedorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.cbProveedor = new System.Windows.Forms.ComboBox();
            this.lblArMedida = new System.Windows.Forms.Label();
            this.cbArticuloMedida = new System.Windows.Forms.ComboBox();
            this.articuloMedidaBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.txtIdProveedorArticulo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.formaBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grvProveedorArticulo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorArticuloBindingSource)).BeginInit();
            this.grpFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorArticuloBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTamanioPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPagina)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // grvProveedorArticulo
            // 
            this.grvProveedorArticulo.AllowUserToAddRows = false;
            this.grvProveedorArticulo.AllowUserToDeleteRows = false;
            this.grvProveedorArticulo.AutoGenerateColumns = false;
            this.grvProveedorArticulo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grvProveedorArticulo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idProveedorArticuloDataGridViewTextBoxColumn,
            this.IdProveedor,
            this.IdArticuloMedida,
            this.IdForma,
            this.Precio,
            this.Cantidad,
            this.FechaCompra,
            this.FechaPedido,
            this.Entregado,
            this.PlazoPactado});
            this.grvProveedorArticulo.DataSource = this.proveedorArticuloBindingSource;
            this.grvProveedorArticulo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grvProveedorArticulo.Location = new System.Drawing.Point(0, 231);
            this.grvProveedorArticulo.Name = "grvProveedorArticulo";
            this.grvProveedorArticulo.ReadOnly = true;
            this.grvProveedorArticulo.Size = new System.Drawing.Size(1015, 285);
            this.grvProveedorArticulo.TabIndex = 3;
            this.grvProveedorArticulo.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.grvProveedorArticulo_ColumnHeaderMouseClick);
            // 
            // idProveedorArticuloDataGridViewTextBoxColumn
            // 
            this.idProveedorArticuloDataGridViewTextBoxColumn.DataPropertyName = "IdProveedorArticulo";
            this.idProveedorArticuloDataGridViewTextBoxColumn.HeaderText = "IdProveedorArticulo";
            this.idProveedorArticuloDataGridViewTextBoxColumn.Name = "idProveedorArticuloDataGridViewTextBoxColumn";
            this.idProveedorArticuloDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // IdProveedor
            // 
            this.IdProveedor.DataPropertyName = "IdProveedor";
            this.IdProveedor.HeaderText = "IdProveedor";
            this.IdProveedor.Name = "IdProveedor";
            this.IdProveedor.ReadOnly = true;
            // 
            // IdArticuloMedida
            // 
            this.IdArticuloMedida.DataPropertyName = "IdArticuloMedida";
            this.IdArticuloMedida.HeaderText = "IdArticuloMedida";
            this.IdArticuloMedida.Name = "IdArticuloMedida";
            this.IdArticuloMedida.ReadOnly = true;
            // 
            // IdForma
            // 
            this.IdForma.DataPropertyName = "IdForma";
            this.IdForma.HeaderText = "IdForma";
            this.IdForma.Name = "IdForma";
            this.IdForma.ReadOnly = true;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            // 
            // Cantidad
            // 
            this.Cantidad.DataPropertyName = "Cantidad";
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.ReadOnly = true;
            // 
            // FechaCompra
            // 
            this.FechaCompra.DataPropertyName = "FechaCompra";
            this.FechaCompra.HeaderText = "FechaCompra";
            this.FechaCompra.Name = "FechaCompra";
            this.FechaCompra.ReadOnly = true;
            // 
            // FechaPedido
            // 
            this.FechaPedido.DataPropertyName = "FechaPedido";
            this.FechaPedido.HeaderText = "FechaPedido";
            this.FechaPedido.Name = "FechaPedido";
            this.FechaPedido.ReadOnly = true;
            // 
            // Entregado
            // 
            this.Entregado.DataPropertyName = "Entregado";
            this.Entregado.HeaderText = "Entregado";
            this.Entregado.Name = "Entregado";
            this.Entregado.ReadOnly = true;
            // 
            // PlazoPactado
            // 
            this.PlazoPactado.DataPropertyName = "PlazoPactado";
            this.PlazoPactado.HeaderText = "PlazoPactado";
            this.PlazoPactado.Name = "PlazoPactado";
            this.PlazoPactado.ReadOnly = true;
            // 
            // proveedorArticuloBindingSource
            // 
            this.proveedorArticuloBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.ProveedorArticulo);
            this.proveedorArticuloBindingSource.CurrentChanged += new System.EventHandler(this.ProveedorArticuloBindingSource_CurrentChanged);
            // 
            // grpFiltro
            // 
            this.grpFiltro.Controls.Add(this.chkEntregado);
            this.grpFiltro.Controls.Add(this.label11);
            this.grpFiltro.Controls.Add(this.numericUpDown1);
            this.grpFiltro.Controls.Add(this.dateTimePicker2);
            this.grpFiltro.Controls.Add(this.label10);
            this.grpFiltro.Controls.Add(this.dtpFecha);
            this.grpFiltro.Controls.Add(this.label8);
            this.grpFiltro.Controls.Add(this.txtPrecio);
            this.grpFiltro.Controls.Add(this.label9);
            this.grpFiltro.Controls.Add(this.label4);
            this.grpFiltro.Controls.Add(this.cbForma);
            this.grpFiltro.Controls.Add(this.label3);
            this.grpFiltro.Controls.Add(this.label2);
            this.grpFiltro.Controls.Add(this.nudCantidad);
            this.grpFiltro.Controls.Add(this.cbProveedor);
            this.grpFiltro.Controls.Add(this.lblArMedida);
            this.grpFiltro.Controls.Add(this.cbArticuloMedida);
            this.grpFiltro.Controls.Add(this.panel1);
            this.grpFiltro.Controls.Add(this.btnEditar);
            this.grpFiltro.Controls.Add(this.btnNuevo);
            this.grpFiltro.Controls.Add(this.btnGuardar);
            this.grpFiltro.Controls.Add(this.btnEliminar);
            this.grpFiltro.Controls.Add(this.btnCancelar);
            this.grpFiltro.Controls.Add(this.btnBuscar);
            this.grpFiltro.Controls.Add(this.txtIdProveedorArticulo);
            this.grpFiltro.Controls.Add(this.label1);
            this.grpFiltro.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFiltro.Location = new System.Drawing.Point(0, 0);
            this.grpFiltro.Name = "grpFiltro";
            this.grpFiltro.Size = new System.Drawing.Size(1015, 231);
            this.grpFiltro.TabIndex = 2;
            this.grpFiltro.TabStop = false;
            this.grpFiltro.Text = "Datos ProveedorArticulo";
            // 
            // chkEntregado
            // 
            this.chkEntregado.AutoSize = true;
            this.chkEntregado.Checked = true;
            this.chkEntregado.CheckState = System.Windows.Forms.CheckState.Indeterminate;
            this.chkEntregado.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.proveedorArticuloBindingSource1, "Entregado", true));
            this.chkEntregado.Location = new System.Drawing.Point(427, 96);
            this.chkEntregado.Name = "chkEntregado";
            this.chkEntregado.Size = new System.Drawing.Size(75, 17);
            this.chkEntregado.TabIndex = 45;
            this.chkEntregado.Text = "Entregado";
            this.chkEntregado.ThreeState = true;
            this.chkEntregado.UseVisualStyleBackColor = true;
            // 
            // proveedorArticuloBindingSource1
            // 
            this.proveedorArticuloBindingSource1.DataSource = typeof(GestionStock.Data.EntityFramework.ProveedorArticulo);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(334, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(75, 13);
            this.label11.TabIndex = 44;
            this.label11.Text = "Plazo pactado";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.proveedorArticuloBindingSource1, "PlazoPactado", true));
            this.numericUpDown1.Location = new System.Drawing.Point(427, 64);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 43;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(427, 38);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(205, 20);
            this.dateTimePicker2.TabIndex = 42;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(334, 45);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "Fecha pedido";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(427, 12);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.ShowCheckBox = true;
            this.dtpFecha.Size = new System.Drawing.Size(205, 20);
            this.dtpFecha.TabIndex = 38;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(334, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(75, 13);
            this.label8.TabIndex = 37;
            this.label8.Text = "Fecha compra";
            // 
            // txtPrecio
            // 
            this.txtPrecio.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorArticuloBindingSource1, "Precio", true));
            this.txtPrecio.Location = new System.Drawing.Point(115, 126);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(205, 20);
            this.txtPrecio.TabIndex = 36;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 126);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 100);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 32;
            this.label4.Text = "Forma de pago";
            // 
            // cbForma
            // 
            this.cbForma.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.proveedorArticuloBindingSource1, "IdForma", true));
            this.cbForma.DataSource = this.formaBindingSource;
            this.cbForma.FormattingEnabled = true;
            this.cbForma.Location = new System.Drawing.Point(115, 99);
            this.cbForma.Name = "cbForma";
            this.cbForma.Size = new System.Drawing.Size(205, 21);
            this.cbForma.TabIndex = 31;
            this.cbForma.ValueMember = "IdMedida";
            // 
            // proveedorBindingSource
            // 
            this.proveedorBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.Proveedor);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Proveedor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "cantidad";
            // 
            // nudCantidad
            // 
            this.nudCantidad.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.proveedorArticuloBindingSource1, "Precio", true));
            this.nudCantidad.Location = new System.Drawing.Point(115, 152);
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(120, 20);
            this.nudCantidad.TabIndex = 27;
            // 
            // cbProveedor
            // 
            this.cbProveedor.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.proveedorArticuloBindingSource1, "IdProveedor", true));
            this.cbProveedor.DataSource = this.proveedorBindingSource;
            this.cbProveedor.DisplayMember = "Nombre";
            this.cbProveedor.FormattingEnabled = true;
            this.cbProveedor.Location = new System.Drawing.Point(115, 72);
            this.cbProveedor.Name = "cbProveedor";
            this.cbProveedor.Size = new System.Drawing.Size(205, 21);
            this.cbProveedor.TabIndex = 26;
            this.cbProveedor.ValueMember = "IdMedida";
            // 
            // lblArMedida
            // 
            this.lblArMedida.AutoSize = true;
            this.lblArMedida.Location = new System.Drawing.Point(14, 48);
            this.lblArMedida.Name = "lblArMedida";
            this.lblArMedida.Size = new System.Drawing.Size(77, 13);
            this.lblArMedida.TabIndex = 24;
            this.lblArMedida.Text = "ArticuloMedida";
            // 
            // cbArticuloMedida
            // 
            this.cbArticuloMedida.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.proveedorArticuloBindingSource1, "IdArticuloMedida", true));
            this.cbArticuloMedida.DataSource = this.articuloMedidaBindingSource;
            this.cbArticuloMedida.DisplayMember = "Nombre";
            this.cbArticuloMedida.FormattingEnabled = true;
            this.cbArticuloMedida.Location = new System.Drawing.Point(115, 45);
            this.cbArticuloMedida.Name = "cbArticuloMedida";
            this.cbArticuloMedida.Size = new System.Drawing.Size(205, 21);
            this.cbArticuloMedida.TabIndex = 23;
            this.cbArticuloMedida.ValueMember = "IdArticulo";
            // 
            // articuloMedidaBindingSource
            // 
            this.articuloMedidaBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.ArticuloMedida);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.nupTamanioPagina);
            this.panel1.Controls.Add(this.lbltotalPaginas);
            this.panel1.Controls.Add(this.nupPagina);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(877, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(135, 212);
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
            this.btnEditar.Location = new System.Drawing.Point(103, 191);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 19;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(22, 192);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 15;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(250, 191);
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
            this.btnEliminar.Location = new System.Drawing.Point(412, 191);
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
            this.btnCancelar.Location = new System.Drawing.Point(331, 191);
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
            this.btnBuscar.Location = new System.Drawing.Point(183, 191);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(61, 23);
            this.btnBuscar.TabIndex = 14;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // txtIdProveedorArticulo
            // 
            this.txtIdProveedorArticulo.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.proveedorArticuloBindingSource1, "IdProveedorArticulo", true));
            this.txtIdProveedorArticulo.Location = new System.Drawing.Point(115, 19);
            this.txtIdProveedorArticulo.Name = "txtIdProveedorArticulo";
            this.txtIdProveedorArticulo.Size = new System.Drawing.Size(205, 20);
            this.txtIdProveedorArticulo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "IdProveedorArticulo";
            // 
            // formaBindingSource
            // 
            this.formaBindingSource.DataSource = typeof(GestionStock.Data.EntityFramework.FormaPago);
            // 
            // frmProveedorArticulo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 516);
            this.Controls.Add(this.grvProveedorArticulo);
            this.Controls.Add(this.grpFiltro);
            this.Name = "frmProveedorArticulo";
            this.Text = "frmProveedorArticulo";
            this.Load += new System.EventHandler(this.frmProveedorArticulo_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grvProveedorArticulo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorArticuloBindingSource)).EndInit();
            this.grpFiltro.ResumeLayout(false);
            this.grpFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorArticuloBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proveedorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.articuloMedidaBindingSource)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupTamanioPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupPagina)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.formaBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView grvProveedorArticulo;
        private System.Windows.Forms.GroupBox grpFiltro;
        private System.Windows.Forms.Label lblArMedida;
        private System.Windows.Forms.ComboBox cbArticuloMedida;
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
        private System.Windows.Forms.TextBox txtIdProveedorArticulo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource proveedorArticuloBindingSource;
        private System.Windows.Forms.BindingSource articuloMedidaBindingSource;
        private System.Windows.Forms.BindingSource proveedorBindingSource;
        private System.Windows.Forms.ComboBox cbProveedor;
        private System.Windows.Forms.BindingSource proveedorArticuloBindingSource1;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn idProveedorArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idMedidaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idArticuloDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidadMinimaDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbForma;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdProveedor;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdArticuloMedida;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdForma;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaCompra;
        private System.Windows.Forms.DataGridViewTextBoxColumn FechaPedido;
        private System.Windows.Forms.DataGridViewTextBoxColumn Entregado;
        private System.Windows.Forms.DataGridViewTextBoxColumn PlazoPactado;
        private System.Windows.Forms.CheckBox chkEntregado;
        private System.Windows.Forms.BindingSource formaBindingSource;
    }
}