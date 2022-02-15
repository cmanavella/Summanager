
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
            this.label1 = new System.Windows.Forms.Label();
            this.menuButton1 = new CustomControls.MenuButton();
            this.btnNuevo = new CustomControls.ButtonBlue();
            this.btnHola = new CustomControls.ItemMenuButton();
            this.btnMundo = new CustomControls.ItemMenuButton();
            this.panelTitulo.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(87, 32);
            this.lblTitulo.Text = "Stock";
            // 
            // panelMenu
            // 
            this.panelMenu.Controls.Add(this.menuButton1);
            this.panelMenu.Controls.Add(this.btnNuevo);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 2;
            // 
            // menuButton1
            // 
            this.menuButton1.Image = null;
            this.menuButton1.Items.Add(this.btnHola);
            this.menuButton1.Items.Add(this.btnMundo);
            this.menuButton1.Location = new System.Drawing.Point(106, 6);
            this.menuButton1.Name = "menuButton1";
            this.menuButton1.Size = new System.Drawing.Size(80, 28);
            this.menuButton1.TabIndex = 9;
            this.menuButton1.Text = "menuButton1";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Image = global::Summanager.Properties.Resources._new;
            this.btnNuevo.Location = new System.Drawing.Point(12, 6);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(76, 28);
            this.btnNuevo.TabIndex = 8;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnHola
            // 
            this.btnHola.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            this.btnHola.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHola.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnHola.FlatAppearance.BorderSize = 0;
            this.btnHola.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHola.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHola.ForeColor = System.Drawing.Color.White;
            this.btnHola.Location = new System.Drawing.Point(0, 0);
            this.btnHola.Name = "btnHola";
            this.btnHola.Size = new System.Drawing.Size(75, 23);
            this.btnHola.TabIndex = 0;
            this.btnHola.TabStop = false;
            this.btnHola.Text = "Hola";
            this.btnHola.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHola.UseVisualStyleBackColor = false;
            this.btnHola.Click += new System.EventHandler(this.btnHola_Click);
            // 
            // btnMundo
            // 
            this.btnMundo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(114)))), ((int)(((byte)(159)))), ((int)(((byte)(206)))));
            this.btnMundo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMundo.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMundo.FlatAppearance.BorderSize = 0;
            this.btnMundo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMundo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMundo.ForeColor = System.Drawing.Color.White;
            this.btnMundo.Location = new System.Drawing.Point(0, 0);
            this.btnMundo.Name = "btnMundo";
            this.btnMundo.Size = new System.Drawing.Size(75, 23);
            this.btnMundo.TabIndex = 0;
            this.btnMundo.TabStop = false;
            this.btnMundo.Text = "Mundo";
            this.btnMundo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMundo.UseVisualStyleBackColor = false;
            // 
            // FrmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1050, 690);
            this.Controls.Add(this.label1);
            this.Name = "FrmStock";
            this.Shown += new System.EventHandler(this.FrmStock_Shown);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private CustomControls.ButtonBlue btnNuevo;
        private CustomControls.MenuButton menuButton1;
        private CustomControls.ItemMenuButton btnHola;
        private CustomControls.ItemMenuButton btnMundo;
    }
}
