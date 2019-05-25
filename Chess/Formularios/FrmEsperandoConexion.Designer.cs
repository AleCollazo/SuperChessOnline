namespace Chess.Formularios
{
    partial class FrmEsperandoConexion
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEsperandoConexion));
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblBuscar = new System.Windows.Forms.Label();
            this.lblInfoTitulo = new System.Windows.Forms.Label();
            this.lblIPInfo = new System.Windows.Forms.Label();
            this.lblPuertoInfo = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(124, 219);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(149, 39);
            this.btnCancelar.TabIndex = 0;
            this.btnCancelar.Text = "Cancelar conexión";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // lblBuscar
            // 
            this.lblBuscar.AutoSize = true;
            this.lblBuscar.Font = new System.Drawing.Font("Jellee Roman", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBuscar.Location = new System.Drawing.Point(108, 161);
            this.lblBuscar.Name = "lblBuscar";
            this.lblBuscar.Size = new System.Drawing.Size(187, 18);
            this.lblBuscar.TabIndex = 1;
            this.lblBuscar.Text = "Buscando conexión . . .";
            // 
            // lblInfoTitulo
            // 
            this.lblInfoTitulo.AutoSize = true;
            this.lblInfoTitulo.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfoTitulo.Location = new System.Drawing.Point(27, 26);
            this.lblInfoTitulo.Name = "lblInfoTitulo";
            this.lblInfoTitulo.Size = new System.Drawing.Size(243, 17);
            this.lblInfoTitulo.TabIndex = 2;
            this.lblInfoTitulo.Text = "Información del servidor creado:";
            // 
            // lblIPInfo
            // 
            this.lblIPInfo.AutoSize = true;
            this.lblIPInfo.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIPInfo.Location = new System.Drawing.Point(27, 55);
            this.lblIPInfo.Name = "lblIPInfo";
            this.lblIPInfo.Size = new System.Drawing.Size(0, 17);
            this.lblIPInfo.TabIndex = 3;
            // 
            // lblPuertoInfo
            // 
            this.lblPuertoInfo.AutoSize = true;
            this.lblPuertoInfo.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuertoInfo.Location = new System.Drawing.Point(27, 82);
            this.lblPuertoInfo.Name = "lblPuertoInfo";
            this.lblPuertoInfo.Size = new System.Drawing.Size(0, 17);
            this.lblPuertoInfo.TabIndex = 4;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Location = new System.Drawing.Point(346, 251);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 5;
            this.btnOK.TabStop = false;
            this.btnOK.Text = "button1";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Visible = false;
            // 
            // FrmEsperandoConexion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(433, 300);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblPuertoInfo);
            this.Controls.Add(this.lblIPInfo);
            this.Controls.Add(this.lblInfoTitulo);
            this.Controls.Add(this.lblBuscar);
            this.Controls.Add(this.btnCancelar);
            this.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmEsperandoConexion";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Esperando conexión . . .";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lblBuscar;
        private System.Windows.Forms.Label lblInfoTitulo;
        public System.Windows.Forms.Label lblIPInfo;
        public System.Windows.Forms.Label lblPuertoInfo;
        public System.Windows.Forms.Button btnOK;
    }
}