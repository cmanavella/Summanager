
namespace Summanager
{
    partial class frmEstados
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmEstados));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.btnActualizar = new CustomControls.menuChildButtom();
            this.btnExportar = new CustomControls.menuChildButtom();
            this.btnImportar = new CustomControls.menuChildButtom();
            this.btnGuardar = new CustomControls.menuChildButtom();
            this.btnAbrir = new CustomControls.menuChildButtom();
            this.panelTitulo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(255, 32);
            this.lblTitulo.Text = "Estado Impresoras";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnActualizar);
            this.panelMenu.Controls.Add(this.btnExportar);
            this.panelMenu.Controls.Add(this.btnImportar);
            this.panelMenu.Controls.Add(this.btnGuardar);
            this.panelMenu.Controls.Add(this.btnAbrir);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(12, 95);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.Size = new System.Drawing.Size(771, 408);
            this.dgv.TabIndex = 22;
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Image = ((System.Drawing.Image)(resources.GetObject("btnActualizar.Image")));
            this.btnActualizar.Location = new System.Drawing.Point(682, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(101, 28);
            this.btnActualizar.TabIndex = 4;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnActualizar_MouseClick);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = ((System.Drawing.Image)(resources.GetObject("btnExportar.Image")));
            this.btnExportar.Location = new System.Drawing.Point(285, 6);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(92, 28);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExportar_MouseClick);
            // 
            // btnImportar
            // 
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.Location = new System.Drawing.Point(187, 6);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(92, 28);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar";
            this.btnImportar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnImportar_MouseClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = ((System.Drawing.Image)(resources.GetObject("btnGuardar.Image")));
            this.btnGuardar.Location = new System.Drawing.Point(89, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 28);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGuardar_MouseClick);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.Location = new System.Drawing.Point(12, 6);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(71, 28);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAbrir_MouseClick);
            // 
            // frmEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(795, 515);
            this.Controls.Add(this.dgv);
            this.Name = "frmEstados";
            this.Load += new System.EventHandler(this.frmEstados_Load);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private CustomControls.menuChildButtom btnAbrir;
		private CustomControls.menuChildButtom btnGuardar;
		private CustomControls.menuChildButtom btnExportar;
		private CustomControls.menuChildButtom btnImportar;
		private CustomControls.menuChildButtom btnActualizar;
	}
}
