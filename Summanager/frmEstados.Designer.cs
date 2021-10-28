
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lblSuministro = new System.Windows.Forms.Label();
            this.lblEstado = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblActualizacion = new System.Windows.Forms.Label();
            this.timerContador = new System.Windows.Forms.Timer(this.components);
            this.btnAgregar = new CustomControls.ButtonGreen();
            this.btnLimpiar = new CustomControls.ButtonGreen();
            this.cmbSuministro = new CustomControls.ComboBox();
            this.cmbEstados = new CustomControls.ComboBox();
            this.txtFiltro = new CustomControls.TextBox();
            this.btnActualizar = new CustomControls.ButtonBlue();
            this.btnExportar = new CustomControls.ButtonBlue();
            this.btnImportar = new CustomControls.ButtonBlue();
            this.btnGuardarComo = new CustomControls.ButtonBlue();
            this.btnGuardar = new CustomControls.ButtonBlue();
            this.btnAbrir = new CustomControls.ButtonBlue();
            this.btnNuevo = new CustomControls.ButtonBlue();
            this.panelEstadisticas = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblEstTitle = new System.Windows.Forms.Label();
            this.btnCambiarEst = new CustomControls.ButtonGreen();
            this.panel3 = new System.Windows.Forms.Panel();
            this.customGroupBox3 = new CustomControls.CustomGroupBox();
            this.estKitMantCritico = new CustomControls.Estadistica();
            this.estUnImgCritico = new CustomControls.Estadistica();
            this.estTonerCritico = new CustomControls.Estadistica();
            this.customGroupBox1 = new CustomControls.CustomGroupBox();
            this.estKitMantRiesgo = new CustomControls.Estadistica();
            this.estUnImgRiesgo = new CustomControls.Estadistica();
            this.estTonerRiesgo = new CustomControls.Estadistica();
            this.panel4 = new System.Windows.Forms.Panel();
            this.estOnline = new CustomControls.Estadistica();
            this.estOffline = new CustomControls.Estadistica();
            this.estNoAna = new CustomControls.Estadistica();
            this.panelTitulo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.panelEstadisticas.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.customGroupBox3.SuspendLayout();
            this.customGroupBox1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelTitulo
            // 
            this.panelTitulo.Controls.Add(this.lblActualizacion);
            this.panelTitulo.Size = new System.Drawing.Size(1055, 49);
            this.panelTitulo.Controls.SetChildIndex(this.lblTitulo, 0);
            this.panelTitulo.Controls.SetChildIndex(this.lblActualizacion, 0);
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
            this.panelMenu.Controls.Add(this.btnGuardarComo);
            this.panelMenu.Controls.Add(this.btnGuardar);
            this.panelMenu.Controls.Add(this.btnAbrir);
            this.panelMenu.Controls.Add(this.btnNuevo);
            this.panelMenu.Size = new System.Drawing.Size(1055, 40);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.dgv.Location = new System.Drawing.Point(12, 130);
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
            this.dgv.Size = new System.Drawing.Size(1043, 220);
            this.dgv.TabIndex = 5;
            this.dgv.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgv_DataBindingComplete);
            this.dgv.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgv_MouseDoubleClick);
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // lblSuministro
            // 
            this.lblSuministro.AutoSize = true;
            this.lblSuministro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSuministro.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblSuministro.Location = new System.Drawing.Point(531, 104);
            this.lblSuministro.Name = "lblSuministro";
            this.lblSuministro.Size = new System.Drawing.Size(76, 17);
            this.lblSuministro.TabIndex = 27;
            this.lblSuministro.Text = "Suministro:";
            this.lblSuministro.Visible = false;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstado.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblEstado.Location = new System.Drawing.Point(294, 104);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(56, 17);
            this.lblEstado.TabIndex = 24;
            this.lblEstado.Text = "Estado:";
            this.lblEstado.Visible = false;
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.White;
            this.lblTotal.Location = new System.Drawing.Point(956, 353);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(87, 27);
            this.lblTotal.TabIndex = 28;
            this.lblTotal.Text = "label1";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblTotal.Visible = false;
            // 
            // lblActualizacion
            // 
            this.lblActualizacion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblActualizacion.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActualizacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblActualizacion.Location = new System.Drawing.Point(351, 22);
            this.lblActualizacion.Name = "lblActualizacion";
            this.lblActualizacion.Size = new System.Drawing.Size(689, 19);
            this.lblActualizacion.TabIndex = 25;
            this.lblActualizacion.Text = "Última actualización: 09 de septiembre de 2021 22:22:22";
            this.lblActualizacion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblActualizacion.Visible = false;
            // 
            // timerContador
            // 
            this.timerContador.Interval = 1000;
            this.timerContador.Tick += new System.EventHandler(this.timerContador_Tick);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::Summanager.Properties.Resources.add;
            this.btnAgregar.Location = new System.Drawing.Point(854, 96);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(88, 28);
            this.btnAgregar.TabIndex = 32;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.Visible = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Image = global::Summanager.Properties.Resources.clear;
            this.btnLimpiar.Location = new System.Drawing.Point(953, 96);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(90, 28);
            this.btnLimpiar.TabIndex = 31;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.Visible = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // cmbSuministro
            // 
            this.cmbSuministro.BackColor = System.Drawing.Color.White;
            this.cmbSuministro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbSuministro.Location = new System.Drawing.Point(613, 97);
            this.cmbSuministro.MinimumSize = new System.Drawing.Size(136, 27);
            this.cmbSuministro.Name = "cmbSuministro";
            this.cmbSuministro.Size = new System.Drawing.Size(169, 27);
            this.cmbSuministro.TabIndex = 4;
            this.cmbSuministro.Visible = false;
            this.cmbSuministro.ItemSelectedChange += new System.EventHandler(this.cmbSuministro_ItemSelectedChange);
            // 
            // cmbEstados
            // 
            this.cmbEstados.BackColor = System.Drawing.Color.White;
            this.cmbEstados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbEstados.Location = new System.Drawing.Point(356, 97);
            this.cmbEstados.MinimumSize = new System.Drawing.Size(136, 27);
            this.cmbEstados.Name = "cmbEstados";
            this.cmbEstados.Size = new System.Drawing.Size(169, 27);
            this.cmbEstados.TabIndex = 3;
            this.cmbEstados.Visible = false;
            this.cmbEstados.ItemSelectedChange += new System.EventHandler(this.cmbEstados_ItemSelectedChange);
            // 
            // txtFiltro
            // 
            this.txtFiltro.BackColor = System.Drawing.Color.White;
            this.txtFiltro.IsMaskared = true;
            this.txtFiltro.Location = new System.Drawing.Point(12, 104);
            this.txtFiltro.MaskText = "Filtrar por Ip, Modelo u Oficina";
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(270, 20);
            this.txtFiltro.TabIndex = 2;
            this.txtFiltro.Text = "Filtrar por Ip, Modelo u Oficina";
            this.txtFiltro.Visible = false;
            this.txtFiltro.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFiltro_KeyUp);
            // 
            // btnActualizar
            // 
            this.btnActualizar.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnActualizar.Image = global::Summanager.Properties.Resources.refresh_page_option;
            this.btnActualizar.Location = new System.Drawing.Point(947, 6);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(105, 28);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Image = global::Summanager.Properties.Resources.excel;
            this.btnExportar.Location = new System.Drawing.Point(531, 6);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(92, 28);
            this.btnExportar.TabIndex = 12;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Image = global::Summanager.Properties.Resources.excel;
            this.btnImportar.Location = new System.Drawing.Point(429, 6);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(96, 28);
            this.btnImportar.TabIndex = 11;
            this.btnImportar.Text = "Importar";
            this.btnImportar.Click += new System.EventHandler(this.btnImportar_Click);
            // 
            // btnGuardarComo
            // 
            this.btnGuardarComo.Image = global::Summanager.Properties.Resources.save_file;
            this.btnGuardarComo.Location = new System.Drawing.Point(273, 6);
            this.btnGuardarComo.Name = "btnGuardarComo";
            this.btnGuardarComo.Size = new System.Drawing.Size(150, 28);
            this.btnGuardarComo.TabIndex = 10;
            this.btnGuardarComo.Text = "Guardar como...";
            this.btnGuardarComo.Click += new System.EventHandler(this.btnGuardarComo_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Image = global::Summanager.Properties.Resources.save_file;
            this.btnGuardar.Location = new System.Drawing.Point(169, 6);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(98, 28);
            this.btnGuardar.TabIndex = 9;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.Image = global::Summanager.Properties.Resources.open_folder;
            this.btnAbrir.Location = new System.Drawing.Point(94, 6);
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(69, 28);
            this.btnAbrir.TabIndex = 8;
            this.btnAbrir.Text = "Abrir";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Summanager.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(12, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(76, 28);
            this.btnNuevo.TabIndex = 7;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // panelEstadisticas
            // 
            this.panelEstadisticas.Controls.Add(this.panel3);
            this.panelEstadisticas.Controls.Add(this.panel4);
            this.panelEstadisticas.Controls.Add(this.panel2);
            this.panelEstadisticas.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelEstadisticas.Location = new System.Drawing.Point(0, 392);
            this.panelEstadisticas.Name = "panelEstadisticas";
            this.panelEstadisticas.Size = new System.Drawing.Size(1055, 298);
            this.panelEstadisticas.TabIndex = 33;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblEstTitle);
            this.panel2.Controls.Add(this.btnCambiarEst);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1055, 44);
            this.panel2.TabIndex = 15;
            // 
            // lblEstTitle
            // 
            this.lblEstTitle.AutoSize = true;
            this.lblEstTitle.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblEstTitle.Location = new System.Drawing.Point(9, 10);
            this.lblEstTitle.Name = "lblEstTitle";
            this.lblEstTitle.Size = new System.Drawing.Size(154, 16);
            this.lblEstTitle.TabIndex = 25;
            this.lblEstTitle.Text = "Estadísticas Generales";
            // 
            // btnCambiarEst
            // 
            this.btnCambiarEst.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCambiarEst.Image = null;
            this.btnCambiarEst.Location = new System.Drawing.Point(959, 10);
            this.btnCambiarEst.Name = "btnCambiarEst";
            this.btnCambiarEst.Size = new System.Drawing.Size(84, 28);
            this.btnCambiarEst.TabIndex = 12;
            this.btnCambiarEst.Text = "Cambiar";
            this.btnCambiarEst.Visible = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.customGroupBox3);
            this.panel3.Controls.Add(this.customGroupBox1);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 44);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1055, 136);
            this.panel3.TabIndex = 17;
            // 
            // customGroupBox3
            // 
            this.customGroupBox3.Controls.Add(this.estKitMantCritico);
            this.customGroupBox3.Controls.Add(this.estUnImgCritico);
            this.customGroupBox3.Controls.Add(this.estTonerCritico);
            this.customGroupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.customGroupBox3.Location = new System.Drawing.Point(0, 0);
            this.customGroupBox3.Name = "customGroupBox3";
            this.customGroupBox3.Size = new System.Drawing.Size(522, 136);
            this.customGroupBox3.TabIndex = 12;
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
            // customGroupBox1
            // 
            this.customGroupBox1.Controls.Add(this.estKitMantRiesgo);
            this.customGroupBox1.Controls.Add(this.estUnImgRiesgo);
            this.customGroupBox1.Controls.Add(this.estTonerRiesgo);
            this.customGroupBox1.Dock = System.Windows.Forms.DockStyle.Right;
            this.customGroupBox1.Location = new System.Drawing.Point(539, 0);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(516, 136);
            this.customGroupBox1.TabIndex = 10;
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
            // panel4
            // 
            this.panel4.Controls.Add(this.estNoAna);
            this.panel4.Controls.Add(this.estOffline);
            this.panel4.Controls.Add(this.estOnline);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 186);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1055, 112);
            this.panel4.TabIndex = 18;
            // 
            // estOnline
            // 
            this.estOnline.Count = 0;
            this.estOnline.Location = new System.Drawing.Point(16, 6);
            this.estOnline.Name = "estOnline";
            this.estOnline.Size = new System.Drawing.Size(150, 100);
            this.estOnline.TabIndex = 10;
            this.estOnline.Text = "Online";
            this.estOnline.Total = 0;
            // 
            // estOffline
            // 
            this.estOffline.Count = 0;
            this.estOffline.Location = new System.Drawing.Point(172, 6);
            this.estOffline.Name = "estOffline";
            this.estOffline.Size = new System.Drawing.Size(150, 100);
            this.estOffline.TabIndex = 11;
            this.estOffline.Text = "Offline";
            this.estOffline.Total = 0;
            // 
            // estNoAna
            // 
            this.estNoAna.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.estNoAna.Count = 0;
            this.estNoAna.Location = new System.Drawing.Point(867, 6);
            this.estNoAna.Name = "estNoAna";
            this.estNoAna.Size = new System.Drawing.Size(150, 100);
            this.estNoAna.TabIndex = 12;
            this.estNoAna.Text = "No Analizadas";
            this.estNoAna.Total = 0;
            // 
            // FrmEstados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1055, 690);
            this.Controls.Add(this.panelEstadisticas);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.cmbSuministro);
            this.Controls.Add(this.lblSuministro);
            this.Controls.Add(this.cmbEstados);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.dgv);
            this.Name = "FrmEstados";
            this.Text = "";
            this.Load += new System.EventHandler(this.frmEstados_Load);
            this.Shown += new System.EventHandler(this.FrmEstados_Shown);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.Controls.SetChildIndex(this.lblEstado, 0);
            this.Controls.SetChildIndex(this.txtFiltro, 0);
            this.Controls.SetChildIndex(this.cmbEstados, 0);
            this.Controls.SetChildIndex(this.lblSuministro, 0);
            this.Controls.SetChildIndex(this.cmbSuministro, 0);
            this.Controls.SetChildIndex(this.btnLimpiar, 0);
            this.Controls.SetChildIndex(this.btnAgregar, 0);
            this.Controls.SetChildIndex(this.lblTotal, 0);
            this.Controls.SetChildIndex(this.panelEstadisticas, 0);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.panelEstadisticas.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.customGroupBox3.ResumeLayout(false);
            this.customGroupBox3.PerformLayout();
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private CustomControls.ComboBox cmbSuministro;
        private System.Windows.Forms.Label lblSuministro;
        private CustomControls.ComboBox cmbEstados;
        private CustomControls.TextBox txtFiltro;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblActualizacion;
        private System.Windows.Forms.Timer timerContador;
        private CustomControls.ButtonGreen btnLimpiar;
        private CustomControls.ButtonGreen btnAgregar;
        private CustomControls.ButtonBlue btnNuevo;
        private CustomControls.ButtonBlue btnGuardarComo;
        private CustomControls.ButtonBlue btnGuardar;
        private CustomControls.ButtonBlue btnAbrir;
        private CustomControls.ButtonBlue btnExportar;
        private CustomControls.ButtonBlue btnImportar;
        private CustomControls.ButtonBlue btnActualizar;
        private System.Windows.Forms.Panel panelEstadisticas;
        private System.Windows.Forms.Panel panel3;
        private CustomControls.CustomGroupBox customGroupBox3;
        private CustomControls.Estadistica estKitMantCritico;
        private CustomControls.Estadistica estUnImgCritico;
        private CustomControls.Estadistica estTonerCritico;
        private CustomControls.CustomGroupBox customGroupBox1;
        private CustomControls.Estadistica estKitMantRiesgo;
        private CustomControls.Estadistica estUnImgRiesgo;
        private CustomControls.Estadistica estTonerRiesgo;
        private CustomControls.ButtonGreen btnCambiarEst;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblEstTitle;
        private System.Windows.Forms.Panel panel4;
        private CustomControls.Estadistica estNoAna;
        private CustomControls.Estadistica estOffline;
        private CustomControls.Estadistica estOnline;
    }
}
