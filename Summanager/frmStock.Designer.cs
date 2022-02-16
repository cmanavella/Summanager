
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
            this.menuNuevo = new CustomControls.MenuButton();
            this.btnNuevoSuministro = new CustomControls.ItemMenuButton();
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
            // menuNuevo
            // 
            this.menuNuevo.ContainerDesplegado = false;
            this.menuNuevo.Image = null;
            this.menuNuevo.Items.Add(this.btnNuevoSuministro);
            this.menuNuevo.Location = new System.Drawing.Point(12, 6);
            this.menuNuevo.Name = "menuNuevo";
            this.menuNuevo.Size = new System.Drawing.Size(80, 28);
            this.menuNuevo.TabIndex = 9;
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
            this.btnNuevoSuministro.Click += new System.EventHandler(this.btnNuevoSuministro_Click);
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
        private CustomControls.MenuButton menuNuevo;
        private CustomControls.ItemMenuButton btnNuevoSuministro;
    }
}
