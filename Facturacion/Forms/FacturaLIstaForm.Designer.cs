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
            this.BtnBuscar = new System.Windows.Forms.ToolStripButton();
            this.CampoSelecionado = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripNuevaFactura = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeleteFactura = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateList = new System.Windows.Forms.ToolStripButton();
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
            this.BtnBuscar,
            this.CampoSelecionado,
            this.toolStripLabel1,
            this.txtSearch,
            this.toolStripLabel2,
            this.toolStripNuevaFactura,
            this.toolStripDeleteFactura,
            this.btnUpdateList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8);
            this.toolStrip1.Size = new System.Drawing.Size(1244, 45);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // BtnBuscar
            // 
            this.BtnBuscar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.BtnBuscar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnBuscar.Image = global::Facturacion.Properties.Resources.magnifier;
            this.BtnBuscar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.BtnBuscar.Name = "BtnBuscar";
            this.BtnBuscar.Size = new System.Drawing.Size(76, 26);
            this.BtnBuscar.Text = "Buscar";
            this.BtnBuscar.Click += new System.EventHandler(this.BtnBuscar_Click);
            // 
            // CampoSelecionado
            // 
            this.CampoSelecionado.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.CampoSelecionado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CampoSelecionado.DropDownWidth = 121;
            this.CampoSelecionado.FlatStyle = System.Windows.Forms.FlatStyle.Standard;
            this.CampoSelecionado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CampoSelecionado.Items.AddRange(new object[] {
            "ID_FACTURA",
            "NUMERO_FACTURA",
            "CLIENTE",
            "TOTAL_CON_IVA"});
            this.CampoSelecionado.Margin = new System.Windows.Forms.Padding(1, 0, 8, 0);
            this.CampoSelecionado.Name = "CampoSelecionado";
            this.CampoSelecionado.Size = new System.Drawing.Size(125, 29);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(156, 26);
            this.toolStripLabel1.Text = "Campo de búsqueda:";
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 29);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(65, 26);
            this.toolStripLabel2.Text = "Buscar:";
            // 
            // toolStripNuevaFactura
            // 
            this.toolStripNuevaFactura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNuevaFactura.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNuevaFactura.Image")));
            this.toolStripNuevaFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNuevaFactura.Name = "toolStripNuevaFactura";
            this.toolStripNuevaFactura.Size = new System.Drawing.Size(127, 26);
            this.toolStripNuevaFactura.Text = "Nueva factura";
            this.toolStripNuevaFactura.ToolTipText = "Nueva factura";
            this.toolStripNuevaFactura.Click += new System.EventHandler(this.ToolStripNuevaFactura_Click);
            // 
            // toolStripDeleteFactura
            // 
            this.toolStripDeleteFactura.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDeleteFactura.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteFactura.Image")));
            this.toolStripDeleteFactura.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleteFactura.Name = "toolStripDeleteFactura";
            this.toolStripDeleteFactura.Size = new System.Drawing.Size(139, 26);
            this.toolStripDeleteFactura.Text = "Eliminar factura";
            this.toolStripDeleteFactura.ToolTipText = "Eliminar cliente";
            this.toolStripDeleteFactura.Click += new System.EventHandler(this.ToolStripDeleteFactura_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateList.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateList.Image")));
            this.btnUpdateList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(98, 26);
            this.btnUpdateList.Text = "Actualizar";
            this.btnUpdateList.Click += new System.EventHandler(this.BtnUpdateList_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressClientes,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 429);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1244, 22);
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
            this.dataFacturas.Location = new System.Drawing.Point(0, 45);
            this.dataFacturas.Margin = new System.Windows.Forms.Padding(2);
            this.dataFacturas.Name = "dataFacturas";
            this.dataFacturas.ReadOnly = true;
            this.dataFacturas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataFacturas.Size = new System.Drawing.Size(1244, 384);
            this.dataFacturas.TabIndex = 2;
            this.dataFacturas.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Fila_DobleClick);
            // 
            // FacturaListaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1244, 451);
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
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressClientes;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.DataGridView dataFacturas;
        private System.Windows.Forms.ToolStripButton BtnBuscar;
        private System.Windows.Forms.ToolStripComboBox CampoSelecionado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}