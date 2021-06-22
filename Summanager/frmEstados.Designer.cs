
namespace Summanager
{
    partial class FrmEstados
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmEstados));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupEstadisticas = new CustomControls.CustomGroupBox();
            this.customGroupBox3 = new CustomControls.CustomGroupBox();
            this.estKitMantCritico = new CustomControls.Estadistica();
            this.estUnImgCritico = new CustomControls.Estadistica();
            this.estTonerCritico = new CustomControls.Estadistica();
            this.customGroupBox2 = new CustomControls.CustomGroupBox();
            this.estNoAna = new CustomControls.Estadistica();
            this.estOffline = new CustomControls.Estadistica();
            this.estOnline = new CustomControls.Estadistica();
            this.customGroupBox1 = new CustomControls.CustomGroupBox();
            this.estKitMantRiesgo = new CustomControls.Estadistica();
            this.estUnImgRiesgo = new CustomControls.Estadistica();
            this.estTonerRiesgo = new CustomControls.Estadistica();
            this.btnNuevo = new CustomControls.MenuChildButtom();
            this.btnGuardarComo = new CustomControls.MenuChildButtom();
            this.btnActualizar = new CustomControls.MenuChildButtom();
            this.btnExportar = new CustomControls.MenuChildButtom();
            this.btnImportar = new CustomControls.MenuChildButtom();
            this.btnGuardar = new CustomControls.MenuChildButtom();
            this.btnAbrir = new CustomControls.MenuChildButtom();
            this.panelTitulo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupEstadisticas.SuspendLayout();
            this.customGroupBox3.SuspendLayout();
            this.customGroupBox2.SuspendLayout();
            this.customGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(255, 32);
            this.lblTitulo.Text = "Estado Impresoras";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.btnNuevo);
            this.panelMenu.Controls.Add(this.btnGuardarComo);
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
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            this.dgv.Location = new System.Drawing.Point(12, 95);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShowCellErrors = false;
            this.dgv.ShowCellToolTips = false;
            this.dgv.ShowEditingIcon = false;
            this.dgv.ShowRowErrors = false;
            this.dgv.Size = new System.Drawing.Size(771, 227);
            this.dgv.TabIndex = 22;
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            // 
            // groupEstadisticas
            // 
            this.groupEstadisticas.Controls.Add(this.customGroupBox3);
            this.groupEstadisticas.Controls.Add(this.customGroupBox2);
            this.groupEstadisticas.Controls.Add(this.customGroupBox1);
            this.groupEstadisticas.Location = new System.Drawing.Point(12, 328);
            this.groupEstadisticas.Name = "groupEstadisticas";
            this.groupEstadisticas.Size = new System.Drawing.Size(771, 494);
            this.groupEstadisticas.TabIndex = 23;
            this.groupEstadisticas.Text = "Estadísticas";
            this.groupEstadisticas.Visible = false;
            // 
            // customGroupBox3
            // 
            this.customGroupBox3.Controls.Add(this.estKitMantCritico);
            this.customGroupBox3.Controls.Add(this.estUnImgCritico);
            this.customGroupBox3.Controls.Add(this.estTonerCritico);
            this.customGroupBox3.Location = new System.Drawing.Point(133, 334);
            this.customGroupBox3.Name = "customGroupBox3";
            this.customGroupBox3.Size = new System.Drawing.Size(498, 146);
            this.customGroupBox3.TabIndex = 11;
            this.customGroupBox3.Text = "Suministro Críticos";
            // 
            // estKitMantCritico
            // 
            this.estKitMantCritico.Count = 0;
            this.estKitMantCritico.Location = new System.Drawing.Point(328, 25);
            this.estKitMantCritico.Name = "estKitMantCritico";
            this.estKitMantCritico.Size = new System.Drawing.Size(150, 100);
            this.estKitMantCritico.TabIndex = 8;
            this.estKitMantCritico.Text = "Kit de Mantenimiento";
            this.estKitMantCritico.Total = 0;
            // 
            // estUnImgCritico
            // 
            this.estUnImgCritico.Count = 0;
            this.estUnImgCritico.Location = new System.Drawing.Point(172, 25);
            this.estUnImgCritico.Name = "estUnImgCritico";
            this.estUnImgCritico.Size = new System.Drawing.Size(150, 100);
            this.estUnImgCritico.TabIndex = 7;
            this.estUnImgCritico.Text = "Unidad de Imagen";
            this.estUnImgCritico.Total = 0;
            // 
            // estTonerCritico
            // 
            this.estTonerCritico.Count = 0;
            this.estTonerCritico.Location = new System.Drawing.Point(16, 25);
            this.estTonerCritico.Name = "estTonerCritico";
            this.estTonerCritico.Size = new System.Drawing.Size(150, 100);
            this.estTonerCritico.TabIndex = 6;
            this.estTonerCritico.Text = "Toner";
            this.estTonerCritico.Total = 0;
            // 
            // customGroupBox2
            // 
            this.customGroupBox2.Controls.Add(this.estNoAna);
            this.customGroupBox2.Controls.Add(this.estOffline);
            this.customGroupBox2.Controls.Add(this.estOnline);
            this.customGroupBox2.Location = new System.Drawing.Point(133, 30);
            this.customGroupBox2.Name = "customGroupBox2";
            this.customGroupBox2.Size = new System.Drawing.Size(498, 146);
            this.customGroupBox2.TabIndex = 10;
            this.customGroupBox2.Text = "Suministro en Riesgo";
            // 
            // estNoAna
            // 
            this.estNoAna.Count = 0;
            this.estNoAna.Location = new System.Drawing.Point(330, 23);
            this.estNoAna.Name = "estNoAna";
            this.estNoAna.Size = new System.Drawing.Size(150, 100);
            this.estNoAna.TabIndex = 11;
            this.estNoAna.Text = "No Analizadas";
            this.estNoAna.Total = 0;
            // 
            // estOffline
            // 
            this.estOffline.Count = 0;
            this.estOffline.Location = new System.Drawing.Point(174, 23);
            this.estOffline.Name = "estOffline";
            this.estOffline.Size = new System.Drawing.Size(150, 100);
            this.estOffline.TabIndex = 10;
            this.estOffline.Text = "Offline";
            this.estOffline.Total = 0;
            // 
            // estOnline
            // 
            this.estOnline.Count = 0;
            this.estOnline.Location = new System.Drawing.Point(18, 23);
            this.estOnline.Name = "estOnline";
            this.estOnline.Size = new System.Drawing.Size(150, 100);
            this.estOnline.TabIndex = 9;
            this.estOnline.Text = "Online";
            this.estOnline.Total = 0;
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.Controls.Add(this.estKitMantRiesgo);
            this.customGroupBox1.Controls.Add(this.estUnImgRiesgo);
            this.customGroupBox1.Controls.Add(this.estTonerRiesgo);
            this.customGroupBox1.Location = new System.Drawing.Point(133, 182);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(498, 146);
            this.customGroupBox1.TabIndex = 9;
            this.customGroupBox1.Text = "Suministro en Riesgo";
            // 
            // estKitMantRiesgo
            // 
            this.estKitMantRiesgo.Count = 0;
            this.estKitMantRiesgo.Location = new System.Drawing.Point(328, 25);
            this.estKitMantRiesgo.Name = "estKitMantRiesgo";
            this.estKitMantRiesgo.Size = new System.Drawing.Size(150, 100);
            this.estKitMantRiesgo.TabIndex = 8;
            this.estKitMantRiesgo.Text = "Kit de Mantenimiento";
            this.estKitMantRiesgo.Total = 0;
            // 
            // estUnImgRiesgo
            // 
            this.estUnImgRiesgo.Count = 0;
            this.estUnImgRiesgo.Location = new System.Drawing.Point(172, 25);
            this.estUnImgRiesgo.Name = "estUnImgRiesgo";
            this.estUnImgRiesgo.Size = new System.Drawing.Size(150, 100);
            this.estUnImgRiesgo.TabIndex = 7;
            this.estUnImgRiesgo.Text = "Unidad de Imagen";
            this.estUnImgRiesgo.Total = 0;
            // 
            // estTonerRiesgo
            // 
            this.estTonerRiesgo.Count = 0;
            this.estTonerRiesgo.Location = new System.Drawing.Point(16, 25);
            this.estTonerRiesgo.Name = "estTonerRiesgo";
            this.estTonerRiesgo.Size = new System.Drawing.Size(150, 100);
            this.estTonerRiesgo.TabIndex = 6;
            this.estTonerRiesgo.Text = "Toner";
            this.estTonerRiesgo.Total = 0;
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Summanager.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(12, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(76, 28);
            this.btnNuevo.TabIndex = 6;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnNuevo_MouseClick);
            // 
            // btnGuardarComo
            // 
            this.btnGuardarComo.Image = global::Summanager.Properties.Resources.save_file;
            this.btnGuardarComo.Location = new System.Drawing.Point(260, 6);
            this.btnGuardarComo.Name = "btnGuardarComo";
            this.btnGuardarComo.Size = new System.Drawing.Size(145, 28);
            this.btnGuardarComo.TabIndex = 5;
            this.btnGuardarComo.Text = "Guardar como...";
            this.btnGuardarComo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGuardarComo_MouseClick);
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
            this.btnExportar.Location = new System.Drawing.Point(509, 6);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(92, 28);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnExportar_MouseClick);
            // 
            // btnImportar
            // 
            this.btnImportar.Image = ((System.Drawing.Image)(resources.GetObject("btnImportar.Image")));
            this.btnImportar.Location = new System.Drawing.Point(411, 6);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(92, 28);
            this.btnImportar.TabIndex = 2;
            this.btnImportar.Text = "Importar";
            this.btnImportar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnImportar_MouseClick);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Summanager.Properties.Resources.save_file;
            this.btnGuardar.Location = new System.Drawing.Point(162, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 28);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnGuardar_MouseClick);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = ((System.Drawing.Image)(resources.GetObject("btnAbrir.Image")));
            this.btnAbrir.Location = new System.Drawing.Point(85, 6);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(71, 28);
            this.btnAbrir.TabIndex = 0;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnAbrir_MouseClick);
            // 
            // FrmEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(800, 837);
            this.Controls.Add(this.groupEstadisticas);
            this.Controls.Add(this.dgv);
            this.Name = "FrmEstados";
            this.Load += new System.EventHandler(this.frmEstados_Load);
            this.Shown += new System.EventHandler(this.FrmEstados_Shown);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.Controls.SetChildIndex(this.groupEstadisticas, 0);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupEstadisticas.ResumeLayout(false);
            this.groupEstadisticas.PerformLayout();
            this.customGroupBox3.ResumeLayout(false);
            this.customGroupBox3.PerformLayout();
            this.customGroupBox2.ResumeLayout(false);
            this.customGroupBox2.PerformLayout();
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private CustomControls.MenuChildButtom btnAbrir;
		private CustomControls.MenuChildButtom btnGuardar;
		private CustomControls.MenuChildButtom btnExportar;
		private CustomControls.MenuChildButtom btnImportar;
		private CustomControls.MenuChildButtom btnActualizar;
        private CustomControls.MenuChildButtom btnNuevo;
        private CustomControls.MenuChildButtom btnGuardarComo;
        private CustomControls.CustomGroupBox groupEstadisticas;
        private CustomControls.CustomGroupBox customGroupBox3;
        private CustomControls.Estadistica estKitMantCritico;
        private CustomControls.Estadistica estUnImgCritico;
        private CustomControls.Estadistica estTonerCritico;
        private CustomControls.CustomGroupBox customGroupBox2;
        private CustomControls.Estadistica estNoAna;
        private CustomControls.Estadistica estOffline;
        private CustomControls.Estadistica estOnline;
        private CustomControls.CustomGroupBox customGroupBox1;
        private CustomControls.Estadistica estKitMantRiesgo;
        private CustomControls.Estadistica estUnImgRiesgo;
        private CustomControls.Estadistica estTonerRiesgo;
    }
}
