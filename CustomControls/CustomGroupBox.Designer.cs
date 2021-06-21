
namespace CustomControls
{
    partial class CustomGroupBox
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.panelEspacio = new System.Windows.Forms.Panel();
            this.bordeSuperior = new System.Windows.Forms.Panel();
            this.bordeIzquierdo = new System.Windows.Forms.Panel();
            this.bordeDerecho = new System.Windows.Forms.Panel();
            this.bordeInferior = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.label1.Location = new System.Drawing.Point(6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panelEspacio
            // 
            this.panelEspacio.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEspacio.Location = new System.Drawing.Point(0, 0);
            this.panelEspacio.Name = "panelEspacio";
            this.panelEspacio.Size = new System.Drawing.Size(311, 9);
            this.panelEspacio.TabIndex = 1;
            // 
            // bordeSuperior
            // 
            this.bordeSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.bordeSuperior.Location = new System.Drawing.Point(0, 9);
            this.bordeSuperior.Name = "bordeSuperior";
            this.bordeSuperior.Size = new System.Drawing.Size(311, 1);
            this.bordeSuperior.TabIndex = 2;
            // 
            // bordeIzquierdo
            // 
            this.bordeIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.bordeIzquierdo.Location = new System.Drawing.Point(0, 10);
            this.bordeIzquierdo.Name = "bordeIzquierdo";
            this.bordeIzquierdo.Size = new System.Drawing.Size(1, 170);
            this.bordeIzquierdo.TabIndex = 3;
            // 
            // bordeDerecho
            // 
            this.bordeDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.bordeDerecho.Location = new System.Drawing.Point(310, 10);
            this.bordeDerecho.Name = "bordeDerecho";
            this.bordeDerecho.Size = new System.Drawing.Size(1, 170);
            this.bordeDerecho.TabIndex = 4;
            // 
            // bordeInferior
            // 
            this.bordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bordeInferior.Location = new System.Drawing.Point(1, 179);
            this.bordeInferior.Name = "bordeInferior";
            this.bordeInferior.Size = new System.Drawing.Size(309, 1);
            this.bordeInferior.TabIndex = 5;
            // 
            // GroupBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bordeInferior);
            this.Controls.Add(this.bordeDerecho);
            this.Controls.Add(this.bordeIzquierdo);
            this.Controls.Add(this.bordeSuperior);
            this.Controls.Add(this.panelEspacio);
            this.Name = "GroupBox";
            this.Size = new System.Drawing.Size(311, 180);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelEspacio;
        private System.Windows.Forms.Panel bordeSuperior;
        private System.Windows.Forms.Panel bordeIzquierdo;
        private System.Windows.Forms.Panel bordeDerecho;
        private System.Windows.Forms.Panel bordeInferior;
    }
}
