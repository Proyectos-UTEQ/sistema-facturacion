namespace Facturacion.clientes
{
    partial class ClienteListaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClienteListaForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripNuevoCliente = new System.Windows.Forms.ToolStripButton();
            this.toolStripDeleteCliente = new System.Windows.Forms.ToolStripButton();
            this.btnUpdateList = new System.Windows.Forms.ToolStripButton();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.btnSeleccionar = new System.Windows.Forms.ToolStripButton();
            this.dataUsuarios = new System.Windows.Forms.DataGridView();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressClientes = new System.Windows.Forms.ToolStripProgressBar();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripNuevoCliente,
            this.toolStripDeleteCliente,
            this.btnUpdateList,
            this.txtSearch,
            this.toolStripLabel1,
            this.btnSeleccionar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 8, 0);
            this.toolStrip1.Size = new System.Drawing.Size(804, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            this.toolStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip1_ItemClicked);
            // 
            // toolStripNuevoCliente
            // 
            this.toolStripNuevoCliente.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNuevoCliente.Image")));
            this.toolStripNuevoCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNuevoCliente.Name = "toolStripNuevoCliente";
            this.toolStripNuevoCliente.Size = new System.Drawing.Size(100, 22);
            this.toolStripNuevoCliente.Text = "Nuevo cliente";
            this.toolStripNuevoCliente.Click += new System.EventHandler(this.toolStripNuevoCliente_Click);
            // 
            // toolStripDeleteCliente
            // 
            this.toolStripDeleteCliente.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteCliente.Image")));
            this.toolStripDeleteCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleteCliente.Name = "toolStripDeleteCliente";
            this.toolStripDeleteCliente.Size = new System.Drawing.Size(108, 22);
            this.toolStripDeleteCliente.Text = "Eliminar cliente";
            this.toolStripDeleteCliente.ToolTipText = "Eliminar cliente";
            this.toolStripDeleteCliente.Click += new System.EventHandler(this.toolStripDeleteCliente_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateList.Image")));
            this.btnUpdateList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(162, 22);
            this.btnUpdateList.Text = "Actualizar lista de clientes";
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
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(45, 22);
            this.toolStripLabel1.Text = "Buscar:";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.btnSeleccionar.Image = global::Facturacion.Properties.Resources.touchscreen;
            this.btnSeleccionar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(87, 22);
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // dataUsuarios
            // 
            this.dataUsuarios.AllowUserToAddRows = false;
            this.dataUsuarios.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dataUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataUsuarios.Location = new System.Drawing.Point(2, 2);
            this.dataUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.dataUsuarios.Name = "dataUsuarios";
            this.dataUsuarios.ReadOnly = true;
            this.dataUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataUsuarios.Size = new System.Drawing.Size(800, 260);
            this.dataUsuarios.TabIndex = 2;
            this.dataUsuarios.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataUsuarios_CellContentClick);
            this.dataUsuarios.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Fila_DobleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressClientes,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 264);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(804, 22);
            this.statusStrip1.TabIndex = 2;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.statusStrip1, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dataUsuarios, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(804, 286);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ClienteListaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 311);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ClienteListaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Lista de clientes";
            this.Load += new System.EventHandler(this.ListCustomers_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ListCustomers_MouseDown);
            this.Resize += new System.EventHandler(this.ListCustomers_Resize);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataUsuarios)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dataUsuarios;
        private System.Windows.Forms.ToolStripButton toolStripNuevoCliente;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripButton btnUpdateList;
        private System.Windows.Forms.ToolStripButton toolStripDeleteCliente;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressClientes;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripButton btnSeleccionar;
    }
}