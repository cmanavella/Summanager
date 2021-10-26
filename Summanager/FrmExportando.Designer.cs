
namespace Summanager
{
    partial class FrmExportando
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
            this.SuspendLayout();
            // 
            // btnDetener
            // 
            this.btnDetener.FlatAppearance.BorderSize = 0;
            this.btnDetener.Location = new System.Drawing.Point(152, 1);
            this.btnDetener.Visible = false;
            // 
            // lblMsge
            // 
            this.lblMsge.Size = new System.Drawing.Size(110, 19);
            this.lblMsge.Text = "Exportando...";
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_DoWork);
            this.worker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_RunWorkerCompleted);
            // 
            // FrmExportando
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(178, 69);
            this.Name = "FrmExportando";
            this.Shown += new System.EventHandler(this.FrmExportando_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
