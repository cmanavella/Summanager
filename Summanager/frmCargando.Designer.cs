
namespace Summanager
{
	partial class frmCargando
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
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.lblAnalizando = new System.Windows.Forms.Label();
			this.lblPorcentaje = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// progressBar1
			// 
			this.progressBar1.BackColor = System.Drawing.Color.White;
			this.progressBar1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
			this.progressBar1.Location = new System.Drawing.Point(2, 47);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(298, 11);
			this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
			this.progressBar1.TabIndex = 0;
			// 
			// lblAnalizando
			// 
			this.lblAnalizando.AutoSize = true;
			this.lblAnalizando.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblAnalizando.Location = new System.Drawing.Point(5, 27);
			this.lblAnalizando.Name = "lblAnalizando";
			this.lblAnalizando.Size = new System.Drawing.Size(86, 16);
			this.lblAnalizando.TabIndex = 1;
			this.lblAnalizando.Text = "Analizando Ip:";
			// 
			// lblPorcentaje
			// 
			this.lblPorcentaje.AutoSize = true;
			this.lblPorcentaje.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.lblPorcentaje.Location = new System.Drawing.Point(274, 27);
			this.lblPorcentaje.Name = "lblPorcentaje";
			this.lblPorcentaje.Size = new System.Drawing.Size(23, 16);
			this.lblPorcentaje.TabIndex = 2;
			this.lblPorcentaje.Text = "0%";
			this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmCargando
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(304, 61);
			this.Controls.Add(this.lblPorcentaje);
			this.Controls.Add(this.lblAnalizando);
			this.Controls.Add(this.progressBar1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "frmCargando";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "frmCargando";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.Label lblAnalizando;
		private System.Windows.Forms.Label lblPorcentaje;
	}
}