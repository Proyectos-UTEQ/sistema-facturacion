namespace Facturacion.facturas
{
    partial class FacturaListaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacturaListaForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripNuevaFactura = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeleteFactura = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateList = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressClientes = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataFacturas = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNuevaFactura,
            this.toolStripDeleteFactura,
            this.btnUpdateList,
            this.txtSearch,
            this.toolStripLabel1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(977, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripNuevaFactura
            // 
            this.toolStripNuevaFactura.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNuevaFactura.Image")));
            this.toolStripNuevaFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNuevaFactura.Name = "toolStripNuevaFactura";
            this.toolStripNuevaFactura.Size = new System.Drawing.Size(101, 22);
            this.toolStripNuevaFactura.Text = "Nueva factura";
            this.toolStripNuevaFactura.ToolTipText = "Nueva factura";
            this.toolStripNuevaFactura.Click += new System.EventHandler(this.toolStripNuevaFactura_Click);
            // 
            // toolStripDeleteFactura
            // 
            this.toolStripDeleteFactura.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteFactura.Image")));
            this.toolStripDeleteFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleteFactura.Name = "toolStripDeleteFactura";
            this.toolStripDeleteFactura.Size = new System.Drawing.Size(110, 22);
            this.toolStripDeleteFactura.Text = "Eliminar factura";
            this.toolStripDeleteFactura.ToolTipText = "Eliminar cliente";
            this.toolStripDeleteFactura.Click += new System.EventHandler(this.toolStripDeleteFactura_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateList.Image")));
            this.btnUpdateList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(164, 22);
            this.btnUpdateList.Text = "Actualizar lista de facturas";
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 25);
            this.txtSearch.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyUp);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Buscar:";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressClientes,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(977, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripProgressClientes
            // 
            this.toolStripProgressClientes.Name = "toolStripProgressClientes";
            this.toolStripProgressClientes.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressClientes.Visible = false;
            // 
            // lblStatus
            // 
            this.lblStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(93, 17);
            this.lblStatus.Text = "Lista actualizada";
            // 
            // dataFacturas
            // 
            this.dataFacturas.AllowUserToAddRows = false;
            this.dataFacturas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataFacturas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataFacturas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataFacturas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataFacturas.Location = new System.Drawing.Point(0, 25);
            this.dataFacturas.Margin = new System.Windows.Forms.Padding(2);
            this.dataFacturas.Name = "dataFacturas";
            this.dataFacturas.ReadOnly = true;
            this.dataFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataFacturas.Size = new System.Drawing.Size(977, 404);
            this.dataFacturas.TabIndex = 2;
            this.dataFacturas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Fila_DobleClick);
            // 
            // FacturaListaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(977, 451);
            this.Controls.Add(this.dataFacturas);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FacturaListaForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de facturas";
            this.Load += new System.EventHandler(this.ListFactura_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripNuevaFactura;
        private System.Windows.Forms.ToolStripButton toolStripDeleteFactura;
        private System.Windows.Forms.ToolStripButton btnUpdateList;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressClientes;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.DataGridView dataFacturas;
    }
}