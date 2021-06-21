
namespace Summanager
{
    partial class FrmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnMinimizar = new CustomControls.PanelButton();
            this.btnCerrar = new CustomControls.PanelButton();
            this.panelLateral = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnConfiguracion = new CustomControls.MenuButton();
            this.btnEstados = new CustomControls.MenuButton();
            this.btnStock = new CustomControls.MenuButton();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.logo = new System.Windows.Forms.PictureBox();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelSuperior.SuspendLayout();
            this.panelLateral.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Controls.Add(this.btnMinimizar);
            this.panelSuperior.Controls.Add(this.btnCerrar);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1000, 30);
            this.panelSuperior.TabIndex = 9;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(3, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(49, 16);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "label2";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.Location = new System.Drawing.Point(940, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 30);
            this.btnMinimizar.TabIndex = 12;
            this.btnMinimizar.Text = "_";
            this.btnMinimizar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnMinimizar_MouseClick);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Location = new System.Drawing.Point(970, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "X";
            this.btnCerrar.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnCerrar_MouseClick);
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.White;
            this.panelLateral.Controls.Add(this.panelMenu);
            this.panelLateral.Controls.Add(this.panelLogo);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(0, 30);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(200, 515);
            this.panelLateral.TabIndex = 10;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelMenu.Controls.Add(this.btnConfiguracion);
            this.panelMenu.Controls.Add(this.btnEstados);
            this.panelMenu.Controls.Add(this.btnStock);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 150);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(200, 370);
            this.panelMenu.TabIndex = 1;
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguracion.Image = global::Summanager.Properties.Resources.gear;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 90);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Selected = false;
            this.btnConfiguracion.Size = new System.Drawing.Size(200, 45);
            this.btnConfiguracion.TabIndex = 3;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnConfiguracion_MouseClick);
            // 
            // btnEstados
            // 
            this.btnEstados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstados.Image = global::Summanager.Properties.Resources.printing;
            this.btnEstados.Location = new System.Drawing.Point(0, 45);
            this.btnEstados.Name = "btnEstados";
            this.btnEstados.Selected = false;
            this.btnEstados.Size = new System.Drawing.Size(200, 45);
            this.btnEstados.TabIndex = 2;
            this.btnEstados.Text = "Estado Impresoras";
            this.btnEstados.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnEstados_MouseClick);
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.Image = global::Summanager.Properties.Resources.box;
            this.btnStock.Location = new System.Drawing.Point(0, 0);
            this.btnStock.Name = "btnStock";
            this.btnStock.Selected = false;
            this.btnStock.Size = new System.Drawing.Size(200, 45);
            this.btnStock.TabIndex = 1;
            this.btnStock.Text = "Stock";
            this.btnStock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnStock_MouseClick);
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.panel4);
            this.panelLogo.Controls.Add(this.panel3);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.logo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(200, 150);
            this.panelLogo.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(195, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 150);
            this.panel4.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(5, 150);
            this.panel3.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(162)))), ((int)(((byte)(160)))));
            this.label1.Location = new System.Drawing.Point(8, 101);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "SumManager";
            // 
            // logo
            // 
            this.logo.Image = global::Summanager.Properties.Resources.Logo;
            this.logo.Location = new System.Drawing.Point(58, 6);
            this.logo.Name = "logo";
            this.logo.Size = new System.Drawing.Size(84, 84);
            this.logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logo.TabIndex = 0;
            this.logo.TabStop = false;
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 545);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(995, 5);
            this.panelInferior.TabIndex = 11;
            // 
            // panelDerecho
            // 
            this.panelDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDerecho.Location = new System.Drawing.Point(995, 30);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(5, 520);
            this.panelDerecho.TabIndex = 12;
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(200, 30);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(795, 515);
            this.panelContenido.TabIndex = 13;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 550);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelLateral.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel panelSuperior;
        private System.Windows.Forms.Panel panelLateral;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox logo;
        private CustomControls.PanelButton btnCerrar;
        private CustomControls.PanelButton btnMinimizar;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelDerecho;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panelContenido;
        private CustomControls.MenuButton btnStock;
        private CustomControls.MenuButton btnEstados;
        private CustomControls.MenuButton btnConfiguracion;
    }
}