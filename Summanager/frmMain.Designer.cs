
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
            this.panelLateral = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.bordeInferiorIzquierdo = new System.Windows.Forms.Panel();
            this.bordeEsquinaIzquierda = new System.Windows.Forms.Panel();
            this.bordeDerecho = new System.Windows.Forms.Panel();
            this.bordeEsquinaDerecha = new System.Windows.Forms.Panel();
            this.panelContenido = new System.Windows.Forms.Panel();
            this.bordeIzquierdo = new System.Windows.Forms.Panel();
            this.btnMinimizar = new CustomControls.PanelButton();
            this.btnCerrar = new CustomControls.PanelButton();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.lblFooter = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bordeInferiorDerecho = new System.Windows.Forms.Panel();
            this.btnStock = new CustomControls.MenuButton();
            this.btnConfiguracion = new CustomControls.MenuButton();
            this.btnEstados = new CustomControls.MenuButton();
            this.logo = new System.Windows.Forms.PictureBox();
            this.appIcon = new System.Windows.Forms.PictureBox();
            this.btnMaximizar = new CustomControls.PanelButton();
            this.panelSuperior.SuspendLayout();
            this.panelLateral.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.panelLogo.SuspendLayout();
            this.bordeDerecho.SuspendLayout();
            this.bordeIzquierdo.SuspendLayout();
            this.panelFooter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelSuperior.Controls.Add(this.appIcon);
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Controls.Add(this.btnMinimizar);
            this.panelSuperior.Controls.Add(this.btnMaximizar);
            this.panelSuperior.Controls.Add(this.btnCerrar);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(1260, 30);
            this.panelSuperior.TabIndex = 9;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(29, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(49, 16);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "label2";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            // 
            // panelLateral
            // 
            this.panelLateral.BackColor = System.Drawing.Color.White;
            this.panelLateral.Controls.Add(this.panelMenu);
            this.panelLateral.Controls.Add(this.panelLogo);
            this.panelLateral.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLateral.Location = new System.Drawing.Point(5, 30);
            this.panelLateral.Name = "panelLateral";
            this.panelLateral.Size = new System.Drawing.Size(205, 695);
            this.panelLateral.TabIndex = 10;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelMenu.Controls.Add(this.bordeInferiorIzquierdo);
            this.panelMenu.Controls.Add(this.btnStock);
            this.panelMenu.Controls.Add(this.btnConfiguracion);
            this.panelMenu.Controls.Add(this.btnEstados);
            this.panelMenu.Location = new System.Drawing.Point(0, 150);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(205, 545);
            this.panelMenu.TabIndex = 1;
            // 
            // panelLogo
            // 
            this.panelLogo.Controls.Add(this.panel4);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Controls.Add(this.logo);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(205, 150);
            this.panelLogo.TabIndex = 0;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel4.Location = new System.Drawing.Point(200, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(5, 150);
            this.panel4.TabIndex = 3;
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
            // bordeInferiorIzquierdo
            // 
            this.bordeInferiorIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeInferiorIzquierdo.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.bordeInferiorIzquierdo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bordeInferiorIzquierdo.Location = new System.Drawing.Point(0, 540);
            this.bordeInferiorIzquierdo.Name = "bordeInferiorIzquierdo";
            this.bordeInferiorIzquierdo.Size = new System.Drawing.Size(205, 5);
            this.bordeInferiorIzquierdo.TabIndex = 11;
            this.bordeInferiorIzquierdo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bordeInferiorIzquierdo_MouseMove);
            // 
            // bordeEsquinaIzquierda
            // 
            this.bordeEsquinaIzquierda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeEsquinaIzquierda.Cursor = System.Windows.Forms.Cursors.SizeNESW;
            this.bordeEsquinaIzquierda.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bordeEsquinaIzquierda.Location = new System.Drawing.Point(0, 690);
            this.bordeEsquinaIzquierda.Name = "bordeEsquinaIzquierda";
            this.bordeEsquinaIzquierda.Size = new System.Drawing.Size(5, 5);
            this.bordeEsquinaIzquierda.TabIndex = 15;
            this.bordeEsquinaIzquierda.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bordeEsquinaIzquierda_MouseMove);
            this.bordeEsquinaIzquierda.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bordeEsquinaIzquierda_MouseUp);
            // 
            // bordeDerecho
            // 
            this.bordeDerecho.BackColor = System.Drawing.Color.White;
            this.bordeDerecho.Controls.Add(this.bordeEsquinaDerecha);
            this.bordeDerecho.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.bordeDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.bordeDerecho.Location = new System.Drawing.Point(1255, 30);
            this.bordeDerecho.Name = "bordeDerecho";
            this.bordeDerecho.Size = new System.Drawing.Size(5, 695);
            this.bordeDerecho.TabIndex = 12;
            this.bordeDerecho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bordeDerecho_MouseMove);
            this.bordeDerecho.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bordeDerecho_MouseUp);
            // 
            // bordeEsquinaDerecha
            // 
            this.bordeEsquinaDerecha.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.bordeEsquinaDerecha.BackColor = System.Drawing.Color.White;
            this.bordeEsquinaDerecha.Cursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.bordeEsquinaDerecha.Location = new System.Drawing.Point(0, 690);
            this.bordeEsquinaDerecha.Name = "bordeEsquinaDerecha";
            this.bordeEsquinaDerecha.Size = new System.Drawing.Size(5, 5);
            this.bordeEsquinaDerecha.TabIndex = 14;
            this.bordeEsquinaDerecha.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bordeEsquinaDerecha_MouseMove);
            this.bordeEsquinaDerecha.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bordeEsquinaDerecha_MouseUp);
            // 
            // panelContenido
            // 
            this.panelContenido.BackColor = System.Drawing.Color.White;
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.Location = new System.Drawing.Point(210, 30);
            this.panelContenido.Name = "panelContenido";
            this.panelContenido.Size = new System.Drawing.Size(1045, 695);
            this.panelContenido.TabIndex = 13;
            // 
            // bordeIzquierdo
            // 
            this.bordeIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeIzquierdo.Controls.Add(this.bordeEsquinaIzquierda);
            this.bordeIzquierdo.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.bordeIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.bordeIzquierdo.Location = new System.Drawing.Point(0, 30);
            this.bordeIzquierdo.Name = "bordeIzquierdo";
            this.bordeIzquierdo.Size = new System.Drawing.Size(5, 695);
            this.bordeIzquierdo.TabIndex = 4;
            this.bordeIzquierdo.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bordeIzquierdo_MouseMove);
            this.bordeIzquierdo.MouseUp += new System.Windows.Forms.MouseEventHandler(this.bordeIzquierdo_MouseUp);
            // 
            // btnMinimizar
            // 
            this.btnMinimizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMinimizar.Image = null;
            this.btnMinimizar.Location = new System.Drawing.Point(1170, 0);
            this.btnMinimizar.Name = "btnMinimizar";
            this.btnMinimizar.Size = new System.Drawing.Size(30, 30);
            this.btnMinimizar.TabIndex = 12;
            this.btnMinimizar.Text = "_";
            this.btnMinimizar.Click += new System.EventHandler(this.btnMinimizar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Image = null;
            this.btnCerrar.Location = new System.Drawing.Point(1230, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelFooter
            // 
            this.panelFooter.Controls.Add(this.lblFooter);
            this.panelFooter.Controls.Add(this.panel1);
            this.panelFooter.Controls.Add(this.panel2);
            this.panelFooter.Controls.Add(this.panel3);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(210, 695);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(1045, 25);
            this.panelFooter.TabIndex = 0;
            // 
            // lblFooter
            // 
            this.lblFooter.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblFooter.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFooter.ForeColor = System.Drawing.Color.Gray;
            this.lblFooter.Location = new System.Drawing.Point(70, 1);
            this.lblFooter.Name = "lblFooter";
            this.lblFooter.Size = new System.Drawing.Size(905, 24);
            this.lblFooter.TabIndex = 14;
            this.lblFooter.Text = "label2";
            this.lblFooter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkGray;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(70, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(905, 1);
            this.panel1.TabIndex = 15;
            // 
            // panel2
            // 
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(70, 25);
            this.panel2.TabIndex = 16;
            // 
            // panel3
            // 
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(975, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(70, 25);
            this.panel3.TabIndex = 17;
            // 
            // bordeInferiorDerecho
            // 
            this.bordeInferiorDerecho.BackColor = System.Drawing.Color.White;
            this.bordeInferiorDerecho.Cursor = System.Windows.Forms.Cursors.SizeNS;
            this.bordeInferiorDerecho.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bordeInferiorDerecho.Location = new System.Drawing.Point(210, 720);
            this.bordeInferiorDerecho.Name = "bordeInferiorDerecho";
            this.bordeInferiorDerecho.Size = new System.Drawing.Size(1045, 5);
            this.bordeInferiorDerecho.TabIndex = 12;
            this.bordeInferiorDerecho.MouseMove += new System.Windows.Forms.MouseEventHandler(this.bordeInferiorDerecho_MouseMove);
            // 
            // btnStock
            // 
            this.btnStock.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnStock.Image = global::Summanager.Properties.Resources.box;
            this.btnStock.Location = new System.Drawing.Point(0, 90);
            this.btnStock.Name = "btnStock";
            this.btnStock.Selected = false;
            this.btnStock.Size = new System.Drawing.Size(205, 45);
            this.btnStock.TabIndex = 1;
            this.btnStock.Text = "Stock";
            this.btnStock.Visible = false;
            this.btnStock.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnStock_MouseClick);
            // 
            // btnConfiguracion
            // 
            this.btnConfiguracion.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnConfiguracion.Image = global::Summanager.Properties.Resources.gear;
            this.btnConfiguracion.Location = new System.Drawing.Point(0, 45);
            this.btnConfiguracion.Name = "btnConfiguracion";
            this.btnConfiguracion.Selected = false;
            this.btnConfiguracion.Size = new System.Drawing.Size(205, 45);
            this.btnConfiguracion.TabIndex = 3;
            this.btnConfiguracion.Text = "Configuración";
            this.btnConfiguracion.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnConfiguracion_MouseClick);
            // 
            // btnEstados
            // 
            this.btnEstados.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnEstados.Image = global::Summanager.Properties.Resources.printing;
            this.btnEstados.Location = new System.Drawing.Point(0, 0);
            this.btnEstados.Name = "btnEstados";
            this.btnEstados.Selected = false;
            this.btnEstados.Size = new System.Drawing.Size(205, 45);
            this.btnEstados.TabIndex = 2;
            this.btnEstados.Text = "Estado Impresoras";
            this.btnEstados.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnEstados_MouseClick);
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
            // appIcon
            // 
            this.appIcon.Image = global::Summanager.Properties.Resources.icon_16x16;
            this.appIcon.Location = new System.Drawing.Point(8, 7);
            this.appIcon.Name = "appIcon";
            this.appIcon.Size = new System.Drawing.Size(16, 16);
            this.appIcon.TabIndex = 15;
            this.appIcon.TabStop = false;
            this.appIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.appIcon_MouseDown);
            // 
            // btnMaximizar
            // 
            this.btnMaximizar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnMaximizar.Image = ((System.Drawing.Image)(resources.GetObject("btnMaximizar.Image")));
            this.btnMaximizar.Location = new System.Drawing.Point(1200, 0);
            this.btnMaximizar.Name = "btnMaximizar";
            this.btnMaximizar.Size = new System.Drawing.Size(30, 30);
            this.btnMaximizar.TabIndex = 14;
            this.btnMaximizar.Click += new System.EventHandler(this.btnMaximizar_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 725);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.bordeInferiorDerecho);
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelLateral);
            this.Controls.Add(this.bordeIzquierdo);
            this.Controls.Add(this.bordeDerecho);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1260, 725);
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.panelLateral.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            this.bordeDerecho.ResumeLayout(false);
            this.bordeIzquierdo.ResumeLayout(false);
            this.panelFooter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appIcon)).EndInit();
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
        private System.Windows.Forms.Panel bordeInferiorIzquierdo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel bordeDerecho;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panelContenido;
        private CustomControls.MenuButton btnStock;
        private CustomControls.MenuButton btnEstados;
        private CustomControls.MenuButton btnConfiguracion;
        private System.Windows.Forms.Panel bordeEsquinaDerecha;
        private System.Windows.Forms.Panel bordeIzquierdo;
        private System.Windows.Forms.Panel bordeEsquinaIzquierda;
        private CustomControls.PanelButton btnMaximizar;
        private System.Windows.Forms.Panel panelFooter;
        private System.Windows.Forms.Label lblFooter;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel bordeInferiorDerecho;
        private System.Windows.Forms.PictureBox appIcon;
    }
}