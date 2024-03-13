namespace Facturacion.Forms
{
    partial class ConfigIVAListaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigIVAListaForm));
            this.dgvConfigIVA = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.bntNuevoIVA = new System.Windows.Forms.ToolStripButton();
            this.btnEliminarIVA = new System.Windows.Forms.ToolStripButton();
            this.btnActualizarLista = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigIVA)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvConfigIVA
            // 
            this.dgvConfigIVA.AllowUserToAddRows = false;
            this.dgvConfigIVA.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConfigIVA.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvConfigIVA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvConfigIVA.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfigIVA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvConfigIVA.Location = new System.Drawing.Point(0, 44);
            this.dgvConfigIVA.Margin = new System.Windows.Forms.Padding(2);
            this.dgvConfigIVA.Name = "dgvConfigIVA";
            this.dgvConfigIVA.ReadOnly = true;
            this.dgvConfigIVA.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfigIVA.Size = new System.Drawing.Size(1217, 370);
            this.dgvConfigIVA.TabIndex = 4;
            this.dgvConfigIVA.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvConfigIVA_CellDoubleClick);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bntNuevoIVA,
            this.btnEliminarIVA,
            this.btnActualizarLista,
            this.toolStripButton1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8);
            this.toolStrip1.Size = new System.Drawing.Size(1217, 44);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // bntNuevoIVA
            // 
            this.bntNuevoIVA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntNuevoIVA.Image = ((System.Drawing.Image)(resources.GetObject("bntNuevoIVA.Image")));
            this.bntNuevoIVA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bntNuevoIVA.Name = "bntNuevoIVA";
            this.bntNuevoIVA.Size = new System.Drawing.Size(103, 25);
            this.bntNuevoIVA.Text = "Nuevo IVA";
            this.bntNuevoIVA.ToolTipText = "Nuevo IVA";
            this.bntNuevoIVA.Click += new System.EventHandler(this.bntNuevoIVA_Click);
            // 
            // btnEliminarIVA
            // 
            this.btnEliminarIVA.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarIVA.Image = ((System.Drawing.Image)(resources.GetObject("btnEliminarIVA.Image")));
            this.btnEliminarIVA.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEliminarIVA.Name = "btnEliminarIVA";
            this.btnEliminarIVA.Size = new System.Drawing.Size(114, 25);
            this.btnEliminarIVA.Text = "Eliminar IVA";
            this.btnEliminarIVA.ToolTipText = "Eliminar cliente";
            this.btnEliminarIVA.Click += new System.EventHandler(this.btnEliminarIVA_Click);
            // 
            // btnActualizarLista
            // 
            this.btnActualizarLista.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizarLista.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizarLista.Image")));
            this.btnActualizarLista.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnActualizarLista.Name = "btnActualizarLista";
            this.btnActualizarLista.Size = new System.Drawing.Size(130, 25);
            this.btnActualizarLista.Text = "Actualizar lista";
            this.btnActualizarLista.Click += new System.EventHandler(this.btnActualizarLista_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripButton1.Image = global::Facturacion.Properties.Resources.deduccion;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(150, 25);
            this.toolStripButton1.Text = "Simulador de IVA";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // ConfigIVAListaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1217, 414);
            this.Controls.Add(this.dgvConfigIVA);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ConfigIVAListaForm";
            this.Text = "Configuración del IVA";
            this.Load += new System.EventHandler(this.ConfigIVAListaForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfigIVA)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvConfigIVA;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton bntNuevoIVA;
        private System.Windows.Forms.ToolStripButton btnEliminarIVA;
        private System.Windows.Forms.ToolStripButton btnActualizarLista;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
    }
}