
namespace Summanager
{
	partial class FrmCargando
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
            this.components = new System.ComponentModel.Container();
            this.lblAnalizando = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.lblTranscurrido = new System.Windows.Forms.Label();
            this.lblEstimado = new System.Windows.Forms.Label();
            this.btnDetener = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.progressBar1 = new CustomControls.ProgressBar();
            this.browser = new WebKit.WebKitBrowser();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAnalizando
            // 
            this.lblAnalizando.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAnalizando.AutoSize = true;
            this.lblAnalizando.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnalizando.Location = new System.Drawing.Point(6, 82);
            this.lblAnalizando.Name = "lblAnalizando";
            this.lblAnalizando.Size = new System.Drawing.Size(86, 16);
            this.lblAnalizando.TabIndex = 1;
            this.lblAnalizando.Text = "Analizando Ip:";
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentaje.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(315, 83);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(38, 16);
            this.lblPorcentaje.TabIndex = 2;
            this.lblPorcentaje.Text = "0%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // worker
            // 
            this.worker.WorkerReportsProgress = true;
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Window;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.label1.Location = new System.Drawing.Point(58, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "Analizando...";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // lblTranscurrido
            // 
            this.lblTranscurrido.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTranscurrido.AutoSize = true;
            this.lblTranscurrido.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTranscurrido.Location = new System.Drawing.Point(206, 67);
            this.lblTranscurrido.Name = "lblTranscurrido";
            this.lblTranscurrido.Size = new System.Drawing.Size(147, 16);
            this.lblTranscurrido.TabIndex = 6;
            this.lblTranscurrido.Text = "Tiempo Transcurrido: 00:00";
            this.lblTranscurrido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblEstimado
            // 
            this.lblEstimado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimado.Location = new System.Drawing.Point(189, 47);
            this.lblEstimado.Name = "lblEstimado";
            this.lblEstimado.Size = new System.Drawing.Size(164, 23);
            this.lblEstimado.TabIndex = 7;
            this.lblEstimado.Text = "Tiempo Estimado: 00:00";
            this.lblEstimado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDetener
            // 
            this.btnDetener.AccessibleDescription = "";
            this.btnDetener.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDetener.FlatAppearance.BorderSize = 0;
            this.btnDetener.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDetener.Image = global::Summanager.Properties.Resources.stop;
            this.btnDetener.Location = new System.Drawing.Point(330, 1);
            this.btnDetener.Name = "btnDetener";
            this.btnDetener.Size = new System.Drawing.Size(23, 24);
            this.btnDetener.TabIndex = 8;
            this.btnDetener.Tag = "";
            this.btnDetener.UseVisualStyleBackColor = true;
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Summanager.Properties.Resources.loading_6;
            this.pictureBox1.Location = new System.Drawing.Point(-8, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 69);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(356, 1);
            this.panel1.TabIndex = 9;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(355, 1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1, 115);
            this.panel2.TabIndex = 10;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 1);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1, 115);
            this.panel3.TabIndex = 11;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(1, 115);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(354, 1);
            this.panel4.TabIndex = 10;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(4, 101);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 10);
            this.progressBar1.TabIndex = 12;
            this.progressBar1.Value = 0;
            // 
            // browser
            // 
            this.browser.BackColor = System.Drawing.Color.White;
            this.browser.Location = new System.Drawing.Point(102, 12);
            this.browser.Name = "browser";
            this.browser.Size = new System.Drawing.Size(137, 83);
            this.browser.TabIndex = 13;
            this.browser.Url = null;
            this.browser.Visible = false;
            this.browser.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.browser_DocumentCompleted);
            // 
            // FrmCargando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(356, 116);
            this.Controls.Add(this.browser);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnDetener);
            this.Controls.Add(this.lblEstimado);
            this.Controls.Add(this.lblTranscurrido);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.lblAnalizando);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmCargando";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmCargando";
            this.Load += new System.EventHandler(this.frmCargando_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label lblAnalizando;
		private System.Windows.Forms.Label lblPorcentaje;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label lblTranscurrido;
        private System.Windows.Forms.Label lblEstimado;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private CustomControls.ProgressBar progressBar1;
        private WebKit.WebKitBrowser browser;
    }
}