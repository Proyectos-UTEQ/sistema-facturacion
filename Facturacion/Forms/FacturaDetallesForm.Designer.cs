namespace Facturacion.detallefacturas
{
    partial class FacturaDetallesForm
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
            this.lblPrecioUnit = new System.Windows.Forms.Label();
            this.TxtPrecUnit = new System.Windows.Forms.TextBox();
            this.lblNumero = new System.Windows.Forms.Label();
            this.TxtCantidad = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDDETFAC = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatusEdit = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtIDProd = new System.Windows.Forms.TextBox();
            this.txtIDFact = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblIDProducto = new System.Windows.Forms.Label();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtDescripcion = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnBuscarProducto = new System.Windows.Forms.Button();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCosto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.LbSubTotal = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRemover
            // 
            this.btnRemover.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemover.Location = new System.Drawing.Point(455, 82);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(100, 23);
            this.btnRemover.TabIndex = 6;
            this.btnRemover.Text = "Remover";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(455, 20);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(100, 23);
            this.btnCancelar.TabIndex = 5;
            this.btnCancelar.Text = "Cerrar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPrecioUnit
            // 
            this.lblPrecioUnit.AutoSize = true;
            this.lblPrecioUnit.Location = new System.Drawing.Point(27, 332);
            this.lblPrecioUnit.Name = "lblPrecioUnit";
            this.lblPrecioUnit.Size = new System.Drawing.Size(77, 13);
            this.lblPrecioUnit.TabIndex = 47;
            this.lblPrecioUnit.Text = "Precio unitario:";
            // 
            // TxtPrecUnit
            // 
            this.TxtPrecUnit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtPrecUnit.Location = new System.Drawing.Point(111, 327);
            this.TxtPrecUnit.MaxLength = 50;
            this.TxtPrecUnit.Name = "TxtPrecUnit";
            this.TxtPrecUnit.Size = new System.Drawing.Size(338, 20);
            this.TxtPrecUnit.TabIndex = 3;
            this.TxtPrecUnit.TextChanged += new System.EventHandler(this.txtPrecUnit_TextChanged);
            // 
            // lblNumero
            // 
            this.lblNumero.AutoSize = true;
            this.lblNumero.Location = new System.Drawing.Point(52, 303);
            this.lblNumero.Name = "lblNumero";
            this.lblNumero.Size = new System.Drawing.Size(52, 13);
            this.lblNumero.TabIndex = 43;
            this.lblNumero.Text = "Cantidad:";
            // 
            // TxtCantidad
            // 
            this.TxtCantidad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtCantidad.Location = new System.Drawing.Point(111, 299);
            this.TxtCantidad.MaxLength = 10;
            this.TxtCantidad.Name = "TxtCantidad";
            this.TxtCantidad.Size = new System.Drawing.Size(338, 20);
            this.TxtCantidad.TabIndex = 2;
            this.TxtCantidad.TextChanged += new System.EventHandler(this.txtNumero_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 41;
            this.label2.Text = "ID Detalle Factura:";
            // 
            // txtIDDETFAC
            // 
            this.txtIDDETFAC.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDDETFAC.Enabled = false;
            this.txtIDDETFAC.Location = new System.Drawing.Point(111, 21);
            this.txtIDDETFAC.Name = "txtIDDETFAC";
            this.txtIDDETFAC.Size = new System.Drawing.Size(315, 20);
            this.txtIDDETFAC.TabIndex = 40;
            this.txtIDDETFAC.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusEdit});
            this.statusStrip1.Location = new System.Drawing.Point(0, 375);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(567, 22);
            this.statusStrip1.TabIndex = 53;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatusEdit
            // 
            this.lblStatusEdit.Name = "lblStatusEdit";
            this.lblStatusEdit.Size = new System.Drawing.Size(101, 17);
            this.lblStatusEdit.Text = "Estado de editado";
            // 
            // txtIDProd
            // 
            this.txtIDProd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDProd.Location = new System.Drawing.Point(99, 20);
            this.txtIDProd.MaxLength = 50;
            this.txtIDProd.Name = "txtIDProd";
            this.txtIDProd.ReadOnly = true;
            this.txtIDProd.Size = new System.Drawing.Size(315, 20);
            this.txtIDProd.TabIndex = 55;
            this.txtIDProd.TabStop = false;
            this.txtIDProd.TextChanged += new System.EventHandler(this.txtIDProd_TextChanged);
            // 
            // txtIDFact
            // 
            this.txtIDFact.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDFact.Enabled = false;
            this.txtIDFact.Location = new System.Drawing.Point(111, 49);
            this.txtIDFact.MaxLength = 10;
            this.txtIDFact.Name = "txtIDFact";
            this.txtIDFact.Size = new System.Drawing.Size(315, 20);
            this.txtIDFact.TabIndex = 54;
            this.txtIDFact.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "ID Factura:";
            // 
            // lblIDProducto
            // 
            this.lblIDProducto.AutoSize = true;
            this.lblIDProducto.Location = new System.Drawing.Point(26, 23);
            this.lblIDProducto.Name = "lblIDProducto";
            this.lblIDProducto.Size = new System.Drawing.Size(67, 13);
            this.lblIDProducto.TabIndex = 57;
            this.lblIDProducto.Text = "ID Producto:";
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnGuardar.Location = new System.Drawing.Point(455, 51);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(100, 23);
            this.BtnGuardar.TabIndex = 4;
            this.BtnGuardar.Text = "Agregar a factura";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 274);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 13);
            this.label3.TabIndex = 60;
            this.label3.Text = "Descripción:";
            // 
            // TxtDescripcion
            // 
            this.TxtDescripcion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TxtDescripcion.Location = new System.Drawing.Point(111, 271);
            this.TxtDescripcion.MaxLength = 80;
            this.TxtDescripcion.Name = "TxtDescripcion";
            this.TxtDescripcion.Size = new System.Drawing.Size(338, 20);
            this.TxtDescripcion.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnBuscarProducto);
            this.groupBox1.Controls.Add(this.txtPrecio);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtCosto);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtNombre);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtIDProd);
            this.groupBox1.Controls.Add(this.lblIDProducto);
            this.groupBox1.Location = new System.Drawing.Point(12, 80);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(437, 158);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Producto";
            // 
            // BtnBuscarProducto
            // 
            this.BtnBuscarProducto.Location = new System.Drawing.Point(304, 124);
            this.BtnBuscarProducto.Name = "BtnBuscarProducto";
            this.BtnBuscarProducto.Size = new System.Drawing.Size(110, 23);
            this.BtnBuscarProducto.TabIndex = 1;
            this.BtnBuscarProducto.Text = "Buscar producto";
            this.BtnBuscarProducto.UseVisualStyleBackColor = true;
            this.BtnBuscarProducto.Click += new System.EventHandler(this.BtnBuscarProducto_Click);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPrecio.Location = new System.Drawing.Point(99, 98);
            this.txtPrecio.MaxLength = 50;
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(315, 20);
            this.txtPrecio.TabIndex = 62;
            this.txtPrecio.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(53, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 63;
            this.label6.Text = "Precio:";
            // 
            // txtCosto
            // 
            this.txtCosto.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCosto.Location = new System.Drawing.Point(99, 72);
            this.txtCosto.MaxLength = 50;
            this.txtCosto.Name = "txtCosto";
            this.txtCosto.ReadOnly = true;
            this.txtCosto.Size = new System.Drawing.Size(315, 20);
            this.txtCosto.TabIndex = 60;
            this.txtCosto.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(56, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 61;
            this.label5.Text = "Costo:";
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(99, 46);
            this.txtNombre.MaxLength = 50;
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.ReadOnly = true;
            this.txtNombre.Size = new System.Drawing.Size(315, 20);
            this.txtNombre.TabIndex = 58;
            this.txtNombre.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(46, 49);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 13);
            this.label4.TabIndex = 59;
            this.label4.Text = "Nombre:";
            // 
            // LbSubTotal
            // 
            this.LbSubTotal.AutoSize = true;
            this.LbSubTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LbSubTotal.Location = new System.Drawing.Point(389, 351);
            this.LbSubTotal.Name = "LbSubTotal";
            this.LbSubTotal.Size = new System.Drawing.Size(60, 24);
            this.LbSubTotal.TabIndex = 63;
            this.LbSubTotal.Text = "00,00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(307, 351);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 24);
            this.label7.TabIndex = 64;
            this.label7.Text = "Subtotal:";
            // 
            // FacturaDetallesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 397);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.LbSubTotal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TxtDescripcion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIDFact);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblPrecioUnit);
            this.Controls.Add(this.TxtPrecUnit);
            this.Controls.Add(this.lblNumero);
            this.Controls.Add(this.TxtCantidad);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDDETFAC);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FacturaDetallesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Detalle factura";
            this.Load += new System.EventHandler(this.DetalleFactura_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblPrecioUnit;
        private System.Windows.Forms.TextBox TxtPrecUnit;
        private System.Windows.Forms.Label lblNumero;
        private System.Windows.Forms.TextBox TxtCantidad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDDETFAC;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusEdit;
        private System.Windows.Forms.TextBox txtIDProd;
        private System.Windows.Forms.TextBox txtIDFact;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblIDProducto;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtDescripcion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnBuscarProducto;
        private System.Windows.Forms.Label LbSubTotal;
        private System.Windows.Forms.Label label7;
    }
}