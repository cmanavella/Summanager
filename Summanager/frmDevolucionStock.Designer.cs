
namespace Summanager
{
    partial class frmDevolucionStock
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
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(433, 239);
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(483, 203);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(483, 39);
            // 
            // dgv
            // 
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv.Size = new System.Drawing.Size(501, 76);
            // 
            // chkFallado
            // 
            this.chkFallado.Visible = true;
            // 
            // frmDevolucionStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(525, 279);
            this.Name = "frmDevolucionStock";
            this.Shown += new System.EventHandler(this.frmDevolucionStock_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}
