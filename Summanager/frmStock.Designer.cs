
namespace Summanager
{
    partial class FrmStock
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Alta = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Baja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Fallado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Compatible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblMsjeStock = new System.Windows.Forms.Label();
            this.btnEnviar = new CustomControls.Button();
            this.btnDevolucion = new CustomControls.Button();
            this.btnIngreso = new CustomControls.Button();
            this.menuNuevo = new CustomControls.MenuButton();
            this.btnNuevoSuministro = new CustomControls.ItemMenuButton();
            this.panelTitulo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(87, 32);
            this.lblTitulo.Text = "Stock";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuNuevo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Tipo,
            this.Nombre,
            this.Alta,
            this.Baja,
            this.Fallado,
            this.Compatible});
            this.dgv.EnableHeadersVisualStyles = false;
            this.dgv.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.dgv.Location = new System.Drawing.Point(12, 106);
            this.dgv.MultiSelect = false;
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.RowHeadersVisible = false;
            this.dgv.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgv.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Century Gothic", 9.75F);
            this.dgv.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.dgv.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv.ShowCellErrors = false;
            this.dgv.ShowCellToolTips = false;
            this.dgv.ShowEditingIcon = false;
            this.dgv.ShowRowErrors = false;
            this.dgv.Size = new System.Drawing.Size(1026, 184);
            this.dgv.TabIndex = 7;
            this.dgv.Resize += new System.EventHandler(this.dgv_Resize);
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            // 
            // Tipo
            // 
            this.Tipo.HeaderText = "Tipo";
            this.Tipo.Name = "Tipo";
            this.Tipo.ReadOnly = true;
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Descripción";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 150;
            // 
            // Alta
            // 
            this.Alta.HeaderText = "En Stock";
            this.Alta.Name = "Alta";
            this.Alta.ReadOnly = true;
            this.Alta.Width = 80;
            // 
            // Baja
            // 
            this.Baja.HeaderText = "De Baja";
            this.Baja.Name = "Baja";
            this.Baja.ReadOnly = true;
            this.Baja.Width = 80;
            // 
            // Fallado
            // 
            this.Fallado.HeaderText = "Fallados";
            this.Fallado.Name = "Fallado";
            this.Fallado.ReadOnly = true;
            this.Fallado.Width = 80;
            // 
            // Compatible
            // 
            this.Compatible.HeaderText = "Compatible con...";
            this.Compatible.Name = "Compatible";
            this.Compatible.ReadOnly = true;
            this.Compatible.Width = 436;
            // 
            // lblMsjeStock
            // 
            this.lblMsjeStock.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMsjeStock.Location = new System.Drawing.Point(9, 156);
            this.lblMsjeStock.Name = "lblMsjeStock";
            this.lblMsjeStock.Size = new System.Drawing.Size(1029, 19);
            this.lblMsjeStock.TabIndex = 8;
            this.lblMsjeStock.Text = "No hay stock cargado en la Base de Datos.";
            this.lblMsjeStock.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEnviar
            // 
            this.btnEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEnviar.ButtonBackColor = System.Drawing.Color.DarkRed;
            this.btnEnviar.ButtonForeColor = System.Drawing.Color.White;
            this.btnEnviar.Image = null;
            this.btnEnviar.Location = new System.Drawing.Point(980, 296);
            this.btnEnviar.Name = "btnEnviar";
            this.btnEnviar.Size = new System.Drawing.Size(58, 28);
            this.btnEnviar.TabIndex = 14;
            this.btnEnviar.Text = "Enviar";
            this.btnEnviar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDevolucion
            // 
            this.btnDevolucion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDevolucion.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            this.btnDevolucion.ButtonForeColor = System.Drawing.Color.White;
            this.btnDevolucion.Image = null;
            this.btnDevolucion.Location = new System.Drawing.Point(472, 296);
            this.btnDevolucion.Name = "btnDevolucion";
            this.btnDevolucion.Size = new System.Drawing.Size(89, 28);
            this.btnDevolucion.TabIndex = 13;
            this.btnDevolucion.Text = "Devolución";
            this.btnDevolucion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnDevolucion.Click += new System.EventHandler(this.btnDevolucion_Click);
            // 
            // btnIngreso
            // 
            this.btnIngreso.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.btnIngreso.ButtonForeColor = System.Drawing.Color.White;
            this.btnIngreso.Image = null;
            this.btnIngreso.Location = new System.Drawing.Point(12, 296);
            this.btnIngreso.Name = "btnIngreso";
            this.btnIngreso.Size = new System.Drawing.Size(64, 28);
            this.btnIngreso.TabIndex = 12;
            this.btnIngreso.Text = "Ingreso";
            this.btnIngreso.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnIngreso.Click += new System.EventHandler(this.btnIngreso_Click);
            // 
            // menuNuevo
            // 
            this.menuNuevo.ContainerDesplegado = false;
            this.menuNuevo.Image = global::Summanager.Properties.Resources._new;
            this.menuNuevo.Items.Add(this.btnNuevoSuministro);
            this.menuNuevo.Location = new System.Drawing.Point(12, 6);
            this.menuNuevo.Name = "menuNuevo";
            this.menuNuevo.Size = new System.Drawing.Size(80, 28);
            this.menuNuevo.TabIndex = 0;
            this.menuNuevo.Text = "Nuevo";
            // 
            // btnNuevoSuministro
            // 
            this.btnNuevoSuministro.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            this.btnNuevoSuministro.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNuevoSuministro.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNuevoSuministro.FlatAppearance.BorderSize = 0;
            this.btnNuevoSuministro.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevoSuministro.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevoSuministro.ForeColor = System.Drawing.Color.White;
            this.btnNuevoSuministro.Location = new System.Drawing.Point(0, 0);
            this.btnNuevoSuministro.Name = "btnNuevoSuministro";
            this.btnNuevoSuministro.Size = new System.Drawing.Size(75, 23);
            this.btnNuevoSuministro.TabIndex = 0;
            this.btnNuevoSuministro.TabStop = false;
            this.btnNuevoSuministro.Text = "Suministro";
            this.btnNuevoSuministro.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNuevoSuministro.UseVisualStyleBackColor = false;
            this.btnNuevoSuministro.Enter += new System.EventHandler(this.btnNuevoSuministro_Enter);
            // 
            // FrmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1050, 690);
            this.Controls.Add(this.btnEnviar);
            this.Controls.Add(this.btnDevolucion);
            this.Controls.Add(this.btnIngreso);
            this.Controls.Add(this.lblMsjeStock);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.label1);
            this.Name = "FrmStock";
            this.Shown += new System.EventHandler(this.FrmStock_Shown);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.Controls.SetChildIndex(this.dgv, 0);
            this.Controls.SetChildIndex(this.lblMsjeStock, 0);
            this.Controls.SetChildIndex(this.btnIngreso, 0);
            this.Controls.SetChildIndex(this.btnDevolucion, 0);
            this.Controls.SetChildIndex(this.btnEnviar, 0);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomControls.MenuButton menuNuevo;
        protected System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label lblMsjeStock;
        private CustomControls.Button btnEnviar;
        private CustomControls.Button btnDevolucion;
        private CustomControls.Button btnIngreso;
        private CustomControls.ItemMenuButton btnNuevoSuministro;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Alta;
        private System.Windows.Forms.DataGridViewTextBoxColumn Baja;
        private System.Windows.Forms.DataGridViewTextBoxColumn Fallado;
        private System.Windows.Forms.DataGridViewTextBoxColumn Compatible;
    }
}
