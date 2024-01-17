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
            this.BtnBuscar = new System.Windows.Forms.ToolStripButton();
            this.CampoSelecionado = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
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
            this.BtnBuscar,
            this.CampoSelecionado,
            this.toolStripLabel2,
            this.txtSearch,
            this.toolStripLabel1,
            this.toolStripSeparator1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8);
            this.toolStrip1.Size = new System.Drawing.Size(1311, 45);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripNuevoCliente
            // 
            this.toolStripNuevoCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripNuevoCliente.Image = ((System.Drawing.Image)(resources.GetObject("toolStripNuevoCliente.Image")));
            this.toolStripNuevoCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripNuevoCliente.Name = "toolStripNuevoCliente";
            this.toolStripNuevoCliente.Size = new System.Drawing.Size(125, 26);
            this.toolStripNuevoCliente.Text = "Nuevo cliente";
            this.toolStripNuevoCliente.Click += new System.EventHandler(this.toolStripNuevoCliente_Click);
            // 
            // toolStripDeleteCliente
            // 
            this.toolStripDeleteCliente.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripDeleteCliente.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDeleteCliente.Image")));
            this.toolStripDeleteCliente.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDeleteCliente.Name = "toolStripDeleteCliente";
            this.toolStripDeleteCliente.Size = new System.Drawing.Size(136, 26);
            this.toolStripDeleteCliente.Text = "Eliminar cliente";
            this.toolStripDeleteCliente.ToolTipText = "Eliminar cliente";
            this.toolStripDeleteCliente.Click += new System.EventHandler(this.toolStripDeleteCliente_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdateList.Image = ((System.Drawing.Image)(resources.GetObject("btnUpdateList.Image")));
            this.btnUpdateList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(207, 26);
            this.btnUpdateList.Text = "Actualizar lista de clientes";
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
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
            "ID_CLIENTE",
            "CEDULA",
            "NOMBRES",
            "APELLIDOS",
            "TELEFONO"});
            this.CampoSelecionado.Margin = new System.Windows.Forms.Padding(1, 0, 8, 0);
            this.CampoSelecionado.Name = "CampoSelecionado";
            this.CampoSelecionado.Size = new System.Drawing.Size(125, 29);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(156, 26);
            this.toolStripLabel2.Text = "Campo de búsqueda:";
            // 
            // txtSearch
            // 
            this.txtSearch.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Margin = new System.Windows.Forms.Padding(1, 0, 12, 0);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(250, 29);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(65, 26);
            this.toolStripLabel1.Text = "Buscar:";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 29);
            // 
            // dataUsuarios
            // 
            this.dataUsuarios.AllowUserToAddRows = false;
            this.dataUsuarios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataUsuarios.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataUsuarios.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataUsuarios.Location = new System.Drawing.Point(2, 2);
            this.dataUsuarios.Margin = new System.Windows.Forms.Padding(2);
            this.dataUsuarios.Name = "dataUsuarios";
            this.dataUsuarios.ReadOnly = true;
            this.dataUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataUsuarios.Size = new System.Drawing.Size(1307, 355);
            this.dataUsuarios.TabIndex = 2;
            this.dataUsuarios.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataUsuarios_CellDoubleClick);
            this.dataUsuarios.RowHeaderMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.Fila_DobleClick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressClientes,
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 359);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1311, 22);
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
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1311, 381);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // ClienteListaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1311, 426);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "ClienteListaForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "Lista de clientes";
            this.Load += new System.EventHandler(this.ListCustomers_Load);
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
        private System.Windows.Forms.ToolStripComboBox CampoSelecionado;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton BtnBuscar;
    }
}