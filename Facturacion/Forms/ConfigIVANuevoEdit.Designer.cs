namespace Facturacion.Forms
{
    partial class ConfigIVANuevoEdit
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
            this.btnAplicar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblNombres = new System.Windows.Forms.Label();
            this.lblCedula = new System.Windows.Forms.Label();
            this.txtValorIVA = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIDIVA = new System.Windows.Forms.TextBox();
            this.dateRigedesde = new System.Windows.Forms.DateTimePicker();
            this.txtPorcentajeIVA = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnAplicar
            // 
            this.btnAplicar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAplicar.Location = new System.Drawing.Point(479, 60);
            this.btnAplicar.Name = "btnAplicar";
            this.btnAplicar.Size = new System.Drawing.Size(75, 23);
            this.btnAplicar.TabIndex = 21;
            this.btnAplicar.Text = "Aplicar";
            this.btnAplicar.UseVisualStyleBackColor = true;
            this.btnAplicar.Click += new System.EventHandler(this.btnAplicar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(479, 31);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 20;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblNombres
            // 
            this.lblNombres.AutoSize = true;
            this.lblNombres.Location = new System.Drawing.Point(21, 105);
            this.lblNombres.Name = "lblNombres";
            this.lblNombres.Size = new System.Drawing.Size(64, 13);
            this.lblNombres.TabIndex = 19;
            this.lblNombres.Text = "Rige desde:";
            // 
            // lblCedula
            // 
            this.lblCedula.AutoSize = true;
            this.lblCedula.Location = new System.Drawing.Point(58, 70);
            this.lblCedula.Name = "lblCedula";
            this.lblCedula.Size = new System.Drawing.Size(27, 13);
            this.lblCedula.TabIndex = 17;
            this.lblCedula.Text = "IVA:";
            // 
            // txtValorIVA
            // 
            this.txtValorIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValorIVA.Location = new System.Drawing.Point(91, 66);
            this.txtValorIVA.MaxLength = 10;
            this.txtValorIVA.Name = "txtValorIVA";
            this.txtValorIVA.Size = new System.Drawing.Size(189, 20);
            this.txtValorIVA.TabIndex = 16;
            this.txtValorIVA.TextChanged += new System.EventHandler(this.txtValorIVA_TextChanged);
            this.txtValorIVA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtValorIVA_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(44, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "ID IVA:";
            // 
            // txtIDIVA
            // 
            this.txtIDIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIDIVA.Enabled = false;
            this.txtIDIVA.Location = new System.Drawing.Point(91, 31);
            this.txtIDIVA.Name = "txtIDIVA";
            this.txtIDIVA.Size = new System.Drawing.Size(364, 20);
            this.txtIDIVA.TabIndex = 14;
            // 
            // dateRigedesde
            // 
            this.dateRigedesde.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dateRigedesde.Location = new System.Drawing.Point(91, 101);
            this.dateRigedesde.MinDate = new System.DateTime(1789, 1, 1, 0, 0, 0, 0);
            this.dateRigedesde.Name = "dateRigedesde";
            this.dateRigedesde.Size = new System.Drawing.Size(364, 20);
            this.dateRigedesde.TabIndex = 23;
            // 
            // txtPorcentajeIVA
            // 
            this.txtPorcentajeIVA.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPorcentajeIVA.Location = new System.Drawing.Point(286, 66);
            this.txtPorcentajeIVA.MaxLength = 10;
            this.txtPorcentajeIVA.Name = "txtPorcentajeIVA";
            this.txtPorcentajeIVA.ReadOnly = true;
            this.txtPorcentajeIVA.Size = new System.Drawing.Size(169, 20);
            this.txtPorcentajeIVA.TabIndex = 24;
            // 
            // ConfigIVANuevoEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 164);
            this.Controls.Add(this.txtPorcentajeIVA);
            this.Controls.Add(this.dateRigedesde);
            this.Controls.Add(this.btnAplicar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.lblNombres);
            this.Controls.Add(this.lblCedula);
            this.Controls.Add(this.txtValorIVA);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIDIVA);
            this.MaximumSize = new System.Drawing.Size(582, 203);
            this.MinimumSize = new System.Drawing.Size(582, 203);
            this.Name = "ConfigIVANuevoEdit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NuevoEditConfigIVAForm";
            this.Load += new System.EventHandler(this.ConfigIVANuevoEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnAplicar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblNombres;
        private System.Windows.Forms.Label lblCedula;
        private System.Windows.Forms.TextBox txtValorIVA;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIDIVA;
        private System.Windows.Forms.DateTimePicker dateRigedesde;
        private System.Windows.Forms.TextBox txtPorcentajeIVA;
    }
}