namespace Facturacion.facturas
{
    partial class FacturaForm
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
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblNumero = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblIDCliente = new System.Windows.Forms.Label();
            this.txtIDCliente = new System.Windows.Forms.TextBox();
            this.lblIDFactura = new System.Windows.Forms.Label();
            this.txtIDFactura = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusEdit = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripProgressDetalle = new System.Windows.Forms.ToolStripProgressBar();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.dataDetalleFact = new System.Windows.Forms.DataGridView();
            this.btnAplicar = new System.Windows.Forms.Button();
            this.groupBoxCliente = new System.Windows.Forms.GroupBox();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.txtApellidos = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNombres = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCedula = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.LbTotal = new System.Windows.Forms.Label();
            this.btnAddProducto = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalleFact)).BeginInit();
            this.groupBoxCliente.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.Location = new System.Drawing.Point(572, 76);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(75, 23);
            this.btnRemover.TabIndex = 99;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.BtnRemover_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(572, 14);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 4;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // lblTotal
            // 
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(482, 518);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(56, 24);
            this.lblTotal.TabIndex = 99;
            this.lblTotal.Text = "Total:";
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(23, 70);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(72, 13);
            this.lblNumero.TabIndex = 21;
            this.lblNumero.Text = "N. de factura:";
            // 
            // txtNumero
            // 
            this.txtNumero.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNumero.Location = new System.Drawing.Point(101, 66);
            this.txtNumero.MaxLength = 50;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.ReadOnly = true;
            this.txtNumero.Size = new System.Drawing.Size(450, 20);
            this.txtNumero.TabIndex = 51;
            this.txtNumero.TabStop = false;
            this.txtNumero.TextChanged += new System.EventHandler(this.TxtNumero_TextChanged);
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(55, 44);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(40, 13);
            this.lblFecha.TabIndex = 19;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblIDCliente
            // 
            this.lblIDCliente.AutoSize = true;
            this.lblIDCliente.Location = new System.Drawing.Point(9, 23);
            this.lblIDCliente.Name = "lblIDCliente";
            this.lblIDCliente.Size = new System.Drawing.Size(65, 13);
            this.lblIDCliente.TabIndex = 99;
            this.lblIDCliente.Text = "Identificador";
            // 
            // txtIDCliente
            // 
            this.txtIDCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDCliente.Location = new System.Drawing.Point(9, 39);
            this.txtIDCliente.MaxLength = 10;
            this.txtIDCliente.Name = "txtIDCliente";
            this.txtIDCliente.ReadOnly = true;
            this.txtIDCliente.Size = new System.Drawing.Size(269, 20);
            this.txtIDCliente.TabIndex = 99;
            this.txtIDCliente.TabStop = false;
            this.txtIDCliente.TextChanged += new System.EventHandler(this.TxtIDCliente_TextChanged);
            // 
            // lblIDFactura
            // 
            this.lblIDFactura.AutoSize = true;
            this.lblIDFactura.Location = new System.Drawing.Point(35, 18);
            this.lblIDFactura.Name = "lblIDFactura";
            this.lblIDFactura.Size = new System.Drawing.Size(60, 13);
            this.lblIDFactura.TabIndex = 15;
            this.lblIDFactura.Text = "ID Factura:";
            // 
            // txtIDFactura
            // 
            this.txtIDFactura.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDFactura.Location = new System.Drawing.Point(101, 14);
            this.txtIDFactura.Name = "txtIDFactura";
            this.txtIDFactura.ReadOnly = true;
            this.txtIDFactura.Size = new System.Drawing.Size(450, 20);
            this.txtIDFactura.TabIndex = 50;
            this.txtIDFactura.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusEdit,
            this.toolStripProgressDetalle});
            this.statusStrip1.Location = new System.Drawing.Point(0, 550);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(659, 22);
            this.statusStrip1.TabIndex = 27;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusEdit
            // 
            this.lblStatusEdit.Name = "lblStatusEdit";
            this.lblStatusEdit.Size = new System.Drawing.Size(101, 17);
            this.lblStatusEdit.Text = "Estado de editado";
            // 
            // toolStripProgressDetalle
            // 
            this.toolStripProgressDetalle.Name = "toolStripProgressDetalle";
            this.toolStripProgressDetalle.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressDetalle.Visible = false;
            // 
            // dtFecha
            // 
            this.dtFecha.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtFecha.Location = new System.Drawing.Point(101, 40);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(450, 20);
            this.dtFecha.TabIndex = 0;
            this.dtFecha.ValueChanged += new System.EventHandler(this.DataGridFecha_ValueChanged);
            // 
            // dataDetalleFact
            // 
            this.dataDetalleFact.BackgroundColor = System.Drawing.Color.White;
            this.dataDetalleFact.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDetalleFact.Location = new System.Drawing.Point(26, 308);
            this.dataDetalleFact.Name = "dataDetalleFact";
            this.dataDetalleFact.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataDetalleFact.Size = new System.Drawing.Size(621, 207);
            this.dataDetalleFact.TabIndex = 99;
            this.dataDetalleFact.TabStop = false;
            this.dataDetalleFact.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataDetalleFact_CellMouseClick);
            this.dataDetalleFact.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataDetalleFact_CellValueChanged);
            this.dataDetalleFact.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataDetalleFact_RowHeaderMouseDoubleClick);
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Location = new System.Drawing.Point(572, 45);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 3;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.BtnAplicar_Click);
            // 
            // groupBoxCliente
            // 
            this.groupBoxCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxCliente.Controls.Add(this.btnBuscarCliente);
            this.groupBoxCliente.Controls.Add(this.txtApellidos);
            this.groupBoxCliente.Controls.Add(this.label3);
            this.groupBoxCliente.Controls.Add(this.txtNombres);
            this.groupBoxCliente.Controls.Add(this.label2);
            this.groupBoxCliente.Controls.Add(this.txtCedula);
            this.groupBoxCliente.Controls.Add(this.label1);
            this.groupBoxCliente.Controls.Add(this.txtIDCliente);
            this.groupBoxCliente.Controls.Add(this.lblIDCliente);
            this.groupBoxCliente.Location = new System.Drawing.Point(26, 108);
            this.groupBoxCliente.Name = "groupBoxCliente";
            this.groupBoxCliente.Size = new System.Drawing.Size(535, 138);
            this.groupBoxCliente.TabIndex = 1;
            this.groupBoxCliente.TabStop = false;
            this.groupBoxCliente.Text = "Cliente";
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscarCliente.Location = new System.Drawing.Point(395, 109);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.btnBuscarCliente.Size = new System.Drawing.Size(130, 23);
            this.btnBuscarCliente.TabIndex = 1;
            this.btnBuscarCliente.Text = "Buscar cliente";
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.BtnBuscarCliente_Click);
            // 
            // txtApellidos
            // 
            this.txtApellidos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtApellidos.Location = new System.Drawing.Point(285, 83);
            this.txtApellidos.MaxLength = 10;
            this.txtApellidos.Name = "txtApellidos";
            this.txtApellidos.ReadOnly = true;
            this.txtApellidos.Size = new System.Drawing.Size(240, 20);
            this.txtApellidos.TabIndex = 99;
            this.txtApellidos.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(270, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 99;
            this.label3.Text = "Apellidos";
            // 
            // txtNombres
            // 
            this.txtNombres.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombres.Location = new System.Drawing.Point(285, 39);
            this.txtNombres.MaxLength = 10;
            this.txtNombres.Name = "txtNombres";
            this.txtNombres.ReadOnly = true;
            this.txtNombres.Size = new System.Drawing.Size(240, 20);
            this.txtNombres.TabIndex = 99;
            this.txtNombres.TabStop = false;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(270, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 99;
            this.label2.Text = "Nombres";
            // 
            // txtCedula
            // 
            this.txtCedula.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCedula.Location = new System.Drawing.Point(9, 83);
            this.txtCedula.MaxLength = 10;
            this.txtCedula.Name = "txtCedula";
            this.txtCedula.ReadOnly = true;
            this.txtCedula.Size = new System.Drawing.Size(269, 20);
            this.txtCedula.TabIndex = 99;
            this.txtCedula.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 99;
            this.label1.Text = "Cedula";
            // 
            // LbTotal
            // 
            this.LbTotal.AutoSize = true;
            this.LbTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbTotal.Location = new System.Drawing.Point(542, 518);
            this.LbTotal.Name = "LbTotal";
            this.LbTotal.Size = new System.Drawing.Size(55, 24);
            this.LbTotal.TabIndex = 999;
            this.LbTotal.Text = "00,00";
            // 
            // btnAddProducto
            // 
            this.btnAddProducto.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnAddProducto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAddProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddProducto.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnAddProducto.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnAddProducto.Location = new System.Drawing.Point(26, 252);
            this.btnAddProducto.Name = "btnAddProducto";
            this.btnAddProducto.Size = new System.Drawing.Size(249, 41);
            this.btnAddProducto.TabIndex = 2;
            this.btnAddProducto.Text = "Agregar producto";
            this.btnAddProducto.UseVisualStyleBackColor = false;
            this.btnAddProducto.Click += new System.EventHandler(this.btnAddProducto_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(572, 107);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(75, 23);
            this.btnReporte.TabIndex = 1000;
            this.btnReporte.Text = "Imprimir";
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.BtnReporte_Click);
            // 
            // FacturaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 572);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.dataDetalleFact);
            this.Controls.Add(this.btnAddProducto);
            this.Controls.Add(this.LbTotal);
            this.Controls.Add(this.groupBoxCliente);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.dtFecha);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.txtNumero);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.lblIDFactura);
            this.Controls.Add(this.txtIDFactura);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FacturaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Factura";
            this.Load += new System.EventHandler(this.FacturaDetails_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FacturaForm_KeyDown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDetalleFact)).EndInit();
            this.groupBoxCliente.ResumeLayout(false);
            this.groupBoxCliente.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblIDCliente;
        private System.Windows.Forms.TextBox txtIDCliente;
        private System.Windows.Forms.Label lblIDFactura;
        private System.Windows.Forms.TextBox txtIDFactura;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusEdit;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.DataGridView dataDetalleFact;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressDetalle;
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.GroupBox groupBoxCliente;
        private System.Windows.Forms.TextBox txtApellidos;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNombres;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCedula;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label LbTotal;
        private System.Windows.Forms.Button btnAddProducto;
        private System.Windows.Forms.Button btnReporte;
    }
}