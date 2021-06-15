
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
			this.dgv = new System.Windows.Forms.DataGridView();
			this.btnDetener = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.btnActualizar = new CustomControls.menuChildButtom();
			this.btnExportar = new CustomControls.menuChildButtom();
			this.btnImportar = new CustomControls.menuChildButtom();
			this.btnGuardar = new CustomControls.menuChildButtom();
			this.btnAbrir = new CustomControls.menuChildButtom();
			this.progressBar1 = new System.Windows.Forms.ProgressBar();
			this.txtConsola = new System.Windows.Forms.TextBox();
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
			this.dgv.Location = new System.Drawing.Point(19, 187);
			this.dgv.MultiSelect = false;
			this.dgv.Name = "dgv";
			this.dgv.ReadOnly = true;
			this.dgv.RowHeadersVisible = false;
			this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgv.Size = new System.Drawing.Size(776, 202);
			this.dgv.TabIndex = 22;
			this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
			// 
			// btnDetener
			// 
			this.btnDetener.Enabled = false;
			this.btnDetener.Location = new System.Drawing.Point(381, 129);
			this.btnDetener.Name = "btnDetener";
			this.btnDetener.Size = new System.Drawing.Size(91, 37);
			this.btnDetener.TabIndex = 21;
			this.btnDetener.Text = "Detener";
			this.btnDetener.UseVisualStyleBackColor = true;
			this.btnDetener.Click += new System.EventHandler(this.btnDetener_Click);
			// 
			// btnActualizar
			// 
			this.btnActualizar.Image = global::Summanager.Properties.Resources.refresh_page_option;
			this.btnActualizar.Location = new System.Drawing.Point(682, 6);
			this.btnActualizar.Name = "btnActualizar";
			this.btnActualizar.Size = new System.Drawing.Size(101, 28);
			this.btnActualizar.TabIndex = 4;
			this.btnActualizar.Text = "Actualizar";
			this.btnActualizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnActualizar_MouseClick);
			// 
			// btnExportar
			// 
			this.btnExportar.Image = global::Summanager.Properties.Resources.excel;
			this.btnExportar.Location = new System.Drawing.Point(285, 6);
			this.btnExportar.Name = "btnExportar";
			this.btnExportar.Size = new System.Drawing.Size(92, 28);
			this.btnExportar.TabIndex = 3;
			this.btnExportar.Text = "Exportar";
			this.btnExportar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExportar_MouseClick);
			// 
			// btnImportar
			// 
			this.btnImportar.Image = global::Summanager.Properties.Resources.excel;
			this.btnImportar.Location = new System.Drawing.Point(187, 6);
			this.btnImportar.Name = "btnImportar";
			this.btnImportar.Size = new System.Drawing.Size(92, 28);
			this.btnImportar.TabIndex = 2;
			this.btnImportar.Text = "Importar";
			this.btnImportar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnImportar_MouseClick);
			// 
			// btnGuardar
			// 
			this.btnGuardar.Image = global::Summanager.Properties.Resources.save_file;
			this.btnGuardar.Location = new System.Drawing.Point(89, 6);
			this.btnGuardar.Name = "btnGuardar";
			this.btnGuardar.Size = new System.Drawing.Size(92, 28);
			this.btnGuardar.TabIndex = 1;
			this.btnGuardar.Text = "Guardar";
			this.btnGuardar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGuardar_MouseClick);
			// 
			// btnAbrir
			// 
			this.btnAbrir.Image = global::Summanager.Properties.Resources.open_folder;
			this.btnAbrir.Location = new System.Drawing.Point(12, 6);
			this.btnAbrir.Name = "btnAbrir";
			this.btnAbrir.Size = new System.Drawing.Size(71, 28);
			this.btnAbrir.TabIndex = 0;
			this.btnAbrir.Text = "Abrir";
			this.btnAbrir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAbrir_MouseClick);
			// 
			// progressBar1
			// 
			this.progressBar1.Location = new System.Drawing.Point(620, 474);
			this.progressBar1.Name = "progressBar1";
			this.progressBar1.Size = new System.Drawing.Size(168, 20);
			this.progressBar1.TabIndex = 20;
			// 
			// txtConsola
			// 
			this.txtConsola.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.txtConsola.ForeColor = System.Drawing.Color.Chartreuse;
			this.txtConsola.Location = new System.Drawing.Point(12, 376);
			this.txtConsola.Multiline = true;
			this.txtConsola.Name = "txtConsola";
			this.txtConsola.ReadOnly = true;
			this.txtConsola.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtConsola.Size = new System.Drawing.Size(776, 92);
			this.txtConsola.TabIndex = 18;
			// 
			// frmEstados
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(795, 515);
			this.Controls.Add(this.dgv);
			this.Controls.Add(this.btnDetener);
			this.Controls.Add(this.progressBar1);
			this.Controls.Add(this.txtConsola);
			this.Name = "frmEstados";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmEstados_FormClosed);
			this.Load += new System.EventHandler(this.frmEstados_Load);
			this.Controls.SetChildIndex(this.txtConsola, 0);
			this.Controls.SetChildIndex(this.progressBar1, 0);
			this.Controls.SetChildIndex(this.btnDetener, 0);
			this.Controls.SetChildIndex(this.dgv, 0);
			this.Controls.SetChildIndex(this.panelTitulo, 0);
			this.Controls.SetChildIndex(this.panelMenu, 0);
			this.panelTitulo.ResumeLayout(false);
			this.panelTitulo.PerformLayout();
			this.panelMenu.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnDetener;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private CustomControls.menuChildButtom btnAbrir;
		private CustomControls.menuChildButtom btnGuardar;
		private CustomControls.menuChildButtom btnExportar;
		private CustomControls.menuChildButtom btnImportar;
		private CustomControls.menuChildButtom btnActualizar;
		private System.Windows.Forms.ProgressBar progressBar1;
		private System.Windows.Forms.TextBox txtConsola;
	}
}
