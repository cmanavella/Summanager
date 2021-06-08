
namespace Summanager
{
    partial class frmMain
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
            this.btnAnalizar = new System.Windows.Forms.Button();
            txtConsola = new System.Windows.Forms.TextBox();
            progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnDetener = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAnalizar
            // 
            this.btnAnalizar.Location = new System.Drawing.Point(12, 12);
            this.btnAnalizar.Name = "btnAnalizar";
            this.btnAnalizar.Size = new System.Drawing.Size(116, 37);
            this.btnAnalizar.TabIndex = 1;
            this.btnAnalizar.Text = "Analizar";
            this.btnAnalizar.UseVisualStyleBackColor = true;
            this.btnAnalizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAnalizar_Clic);
            // 
            // txtConsola
            // 
            txtConsola.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            txtConsola.ForeColor = System.Drawing.Color.Chartreuse;
            txtConsola.Location = new System.Drawing.Point(12, 279);
            txtConsola.Multiline = true;
            txtConsola.Name = "txtConsola";
            txtConsola.ReadOnly = true;
            txtConsola.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            txtConsola.Size = new System.Drawing.Size(776, 140);
            txtConsola.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new System.Drawing.Point(620, 425);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new System.Drawing.Size(168, 20);
            progressBar1.TabIndex = 2;
            // 
            // btnDetener
            // 
            this.btnDetener.Location = new System.Drawing.Point(134, 12);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(116, 37);
            this.btnDetener.TabIndex = 3;
            this.btnDetener.Text = "Detener";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(progressBar1);
            this.Controls.Add(txtConsola);
            this.Controls.Add(this.btnAnalizar);
            this.Name = "frmMain";
            this.Text = "frmMain";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnAnalizar;
        private System.Windows.Forms.Button btnDetener;
        private static System.Windows.Forms.TextBox txtConsola;
        private static System.Windows.Forms.ProgressBar progressBar1;
    }
}