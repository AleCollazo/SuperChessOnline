namespace Chess
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnCrearPartida = new System.Windows.Forms.Button();
            this.btnUnirsePartida = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCrearPartida
            // 
            this.btnCrearPartida.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrearPartida.Location = new System.Drawing.Point(56, 105);
            this.btnCrearPartida.Name = "btnCrearPartida";
            this.btnCrearPartida.Size = new System.Drawing.Size(250, 50);
            this.btnCrearPartida.TabIndex = 0;
            this.btnCrearPartida.Text = "CREAR PARTIDA NUEVA";
            this.btnCrearPartida.UseVisualStyleBackColor = true;
            this.btnCrearPartida.Click += new System.EventHandler(this.btnCrearPartida_Click);
            // 
            // btnUnirsePartida
            // 
            this.btnUnirsePartida.Font = new System.Drawing.Font("Jellee Roman", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnirsePartida.Location = new System.Drawing.Point(56, 254);
            this.btnUnirsePartida.Name = "btnUnirsePartida";
            this.btnUnirsePartida.Size = new System.Drawing.Size(250, 50);
            this.btnUnirsePartida.TabIndex = 1;
            this.btnUnirsePartida.Text = "UNIRSE A UNA PARTIDA";
            this.btnUnirsePartida.UseVisualStyleBackColor = true;
            this.btnUnirsePartida.Click += new System.EventHandler(this.btnUnirsePartida_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 450);
            this.Controls.Add(this.btnUnirsePartida);
            this.Controls.Add(this.btnCrearPartida);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SuperChessOnline";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCrearPartida;
        private System.Windows.Forms.Button btnUnirsePartida;
    }
}