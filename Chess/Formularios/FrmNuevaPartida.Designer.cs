namespace Chess
{
    partial class FrmNuevaPartida
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmNuevaPartida));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.rbtBlancas = new System.Windows.Forms.RadioButton();
            this.rbtNegras = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPuerto = new System.Windows.Forms.Label();
            this.tbxPuerto = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnAceptar.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(35, 230);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 30);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(200, 230);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // rbtBlancas
            // 
            this.rbtBlancas.AutoSize = true;
            this.rbtBlancas.Location = new System.Drawing.Point(26, 41);
            this.rbtBlancas.Name = "rbtBlancas";
            this.rbtBlancas.Size = new System.Drawing.Size(86, 21);
            this.rbtBlancas.TabIndex = 1;
            this.rbtBlancas.TabStop = true;
            this.rbtBlancas.Text = "Blancas";
            this.rbtBlancas.UseVisualStyleBackColor = true;
            // 
            // rbtNegras
            // 
            this.rbtNegras.AutoSize = true;
            this.rbtNegras.Location = new System.Drawing.Point(26, 76);
            this.rbtNegras.Name = "rbtNegras";
            this.rbtNegras.Size = new System.Drawing.Size(81, 21);
            this.rbtNegras.TabIndex = 2;
            this.rbtNegras.TabStop = true;
            this.rbtNegras.Text = "Negras";
            this.rbtNegras.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtNegras);
            this.groupBox1.Controls.Add(this.rbtBlancas);
            this.groupBox1.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(35, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 117);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Color piezas";
            // 
            // lblPuerto
            // 
            this.lblPuerto.AutoSize = true;
            this.lblPuerto.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPuerto.Location = new System.Drawing.Point(265, 35);
            this.lblPuerto.Name = "lblPuerto";
            this.lblPuerto.Size = new System.Drawing.Size(57, 17);
            this.lblPuerto.TabIndex = 3;
            this.lblPuerto.Text = "Puerto";
            // 
            // tbxPuerto
            // 
            this.tbxPuerto.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbxPuerto.Location = new System.Drawing.Point(268, 75);
            this.tbxPuerto.MaxLength = 5;
            this.tbxPuerto.Name = "tbxPuerto";
            this.tbxPuerto.Size = new System.Drawing.Size(104, 23);
            this.tbxPuerto.TabIndex = 4;
            this.tbxPuerto.Text = "31416";
            // 
            // FrmNuevaPartida
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(432, 303);
            this.Controls.Add(this.tbxPuerto);
            this.Controls.Add(this.lblPuerto);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmNuevaPartida";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Crear partida nueva";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        public System.Windows.Forms.RadioButton rbtBlancas;
        public System.Windows.Forms.RadioButton rbtNegras;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblPuerto;
        public System.Windows.Forms.TextBox tbxPuerto;
    }
}