
namespace Summanager
{
    partial class FrmCargando
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.progressBar1 = new CustomControls.ProgressBar();
            this.lblEstimado = new System.Windows.Forms.Label();
            this.lblTranscurrido = new System.Windows.Forms.Label();
            this.lblPorcentaje = new System.Windows.Forms.Label();
            this.lblAnalizando = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btnDetener
            // 
            this.btnDetener.FlatAppearance.BorderSize = 0;
            this.btnDetener.Location = new System.Drawing.Point(330, 1);
            this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(4, 101);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 10);
            this.progressBar1.TabIndex = 20;
            this.progressBar1.Value = 0;
            // 
            // lblEstimado
            // 
            this.lblEstimado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimado.Location = new System.Drawing.Point(189, 47);
            this.lblEstimado.Name = "lblEstimado";
            this.lblEstimado.Size = new System.Drawing.Size(164, 23);
            this.lblEstimado.TabIndex = 19;
            this.lblEstimado.Text = "Tiempo Estimado: 00:00";
            this.lblEstimado.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblTranscurrido.TabIndex = 18;
            this.lblTranscurrido.Text = "Tiempo Transcurrido: 00:00";
            this.lblTranscurrido.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPorcentaje
            // 
            this.lblPorcentaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPorcentaje.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPorcentaje.Location = new System.Drawing.Point(315, 83);
            this.lblPorcentaje.Name = "lblPorcentaje";
            this.lblPorcentaje.Size = new System.Drawing.Size(38, 16);
            this.lblPorcentaje.TabIndex = 17;
            this.lblPorcentaje.Text = "0%";
            this.lblPorcentaje.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lblAnalizando.TabIndex = 16;
            this.lblAnalizando.Text = "Analizando Ip:";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmCargando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(356, 116);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblEstimado);
            this.Controls.Add(this.lblTranscurrido);
            this.Controls.Add(this.lblPorcentaje);
            this.Controls.Add(this.lblAnalizando);
            this.Name = "FrmCargando";
            this.Shown += new System.EventHandler(this.FrmCargando_Shown);
            this.Controls.SetChildIndex(this.lblMsge, 0);
            this.Controls.SetChildIndex(this.btnDetener, 0);
            this.Controls.SetChildIndex(this.lblAnalizando, 0);
            this.Controls.SetChildIndex(this.lblPorcentaje, 0);
            this.Controls.SetChildIndex(this.lblTranscurrido, 0);
            this.Controls.SetChildIndex(this.lblEstimado, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomControls.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblEstimado;
        private System.Windows.Forms.Label lblTranscurrido;
        private System.Windows.Forms.Label lblPorcentaje;
        private System.Windows.Forms.Label lblAnalizando;
        private System.Windows.Forms.Timer timer1;
    }
}
