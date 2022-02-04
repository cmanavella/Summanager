
namespace Summanager
{
    partial class FrmActualizarChromeDriver
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
            this.lblEstado = new System.Windows.Forms.Label();
            this.progressBar1 = new CustomControls.ProgressBar();
            this.SuspendLayout();
            // 
            // btnDetener
            // 
            this.btnDetener.FlatAppearance.BorderSize = 0;
            this.btnDetener.Location = new System.Drawing.Point(374, 1);
            // 
            // lblMsge
            // 
            this.lblMsge.Size = new System.Drawing.Size(236, 19);
            this.lblMsge.Text = "Actualizando Chromedriver...";
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.worker_ProgressChanged);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.Location = new System.Drawing.Point(59, 54);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(68, 16);
            this.lblEstado.TabIndex = 17;
            this.lblEstado.Text = "Iniciando...";
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(28, 73);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(349, 10);
            this.progressBar1.TabIndex = 21;
            this.progressBar1.Value = 0;
            // 
            // FrmActualizarChromeDriver
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(400, 86);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.lblEstado);
            this.Name = "FrmActualizarChromeDriver";
            this.Shown += new System.EventHandler(this.FrmActualizarChromeDriver_Shown);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.lblMsge, 0);
            this.Controls.SetChildIndex(this.btnDetener, 0);
            this.Controls.SetChildIndex(this.progressBar1, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblEstado;
        private CustomControls.ProgressBar progressBar1;
    }
}
