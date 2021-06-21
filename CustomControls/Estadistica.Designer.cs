
namespace CustomControls
{
    partial class Estadistica
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
            this.progress = new CircularProgressBar.CircularProgressBar();
            this.lblCount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblText = new System.Windows.Forms.Label();
            this.bordeIzquierdo = new System.Windows.Forms.Panel();
            this.bordeSuperior = new System.Windows.Forms.Panel();
            this.bordeInferior = new System.Windows.Forms.Panel();
            this.bordeDerecho = new System.Windows.Forms.Panel();
            this.panelEspacio = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // progress
            // 
            this.progress.AnimationFunction = WinFormAnimation.KnownAnimationFunctions.Liner;
            this.progress.AnimationSpeed = 500;
            this.progress.BackColor = System.Drawing.Color.Transparent;
            this.progress.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.progress.InnerColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.progress.InnerMargin = 0;
            this.progress.InnerWidth = -1;
            this.progress.Location = new System.Drawing.Point(3, 20);
            this.progress.MarqueeAnimationSpeed = 2000;
            this.progress.Name = "progress";
            this.progress.OuterColor = System.Drawing.Color.Gray;
            this.progress.OuterMargin = -25;
            this.progress.OuterWidth = 26;
            this.progress.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.progress.ProgressWidth = 7;
            this.progress.SecondaryFont = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.progress.Size = new System.Drawing.Size(75, 75);
            this.progress.StartAngle = 270;
            this.progress.Step = 1;
            this.progress.SubscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progress.SubscriptMargin = new System.Windows.Forms.Padding(10, -35, 0, 0);
            this.progress.SubscriptText = "";
            this.progress.SuperscriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.progress.SuperscriptMargin = new System.Windows.Forms.Padding(10, 35, 0, 0);
            this.progress.SuperscriptText = "";
            this.progress.TabIndex = 29;
            this.progress.Text = "0%";
            this.progress.TextMargin = new System.Windows.Forms.Padding(2, 2, 0, 0);
            // 
            // lblCount
            // 
            this.lblCount.Font = new System.Drawing.Font("Century Gothic", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblCount.Location = new System.Drawing.Point(69, 16);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(76, 46);
            this.lblCount.TabIndex = 30;
            this.lblCount.Text = "0";
            this.lblCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotal
            // 
            this.lblTotal.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.ForeColor = System.Drawing.Color.Gray;
            this.lblTotal.Location = new System.Drawing.Point(92, 62);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(53, 33);
            this.lblTotal.TabIndex = 31;
            this.lblTotal.Text = "0";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblText
            // 
            this.lblText.AutoSize = true;
            this.lblText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblText.Location = new System.Drawing.Point(6, 0);
            this.lblText.Name = "lblText";
            this.lblText.Size = new System.Drawing.Size(47, 17);
            this.lblText.TabIndex = 32;
            this.lblText.Text = "label3";
            // 
            // bordeIzquierdo
            // 
            this.bordeIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.bordeIzquierdo.Location = new System.Drawing.Point(0, 10);
            this.bordeIzquierdo.Name = "bordeIzquierdo";
            this.bordeIzquierdo.Size = new System.Drawing.Size(1, 90);
            this.bordeIzquierdo.TabIndex = 33;
            // 
            // bordeSuperior
            // 
            this.bordeSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.bordeSuperior.Location = new System.Drawing.Point(0, 9);
            this.bordeSuperior.Name = "bordeSuperior";
            this.bordeSuperior.Size = new System.Drawing.Size(150, 1);
            this.bordeSuperior.TabIndex = 34;
            // 
            // bordeInferior
            // 
            this.bordeInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bordeInferior.Location = new System.Drawing.Point(1, 99);
            this.bordeInferior.Name = "bordeInferior";
            this.bordeInferior.Size = new System.Drawing.Size(149, 1);
            this.bordeInferior.TabIndex = 35;
            // 
            // bordeDerecho
            // 
            this.bordeDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.bordeDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.bordeDerecho.Location = new System.Drawing.Point(149, 10);
            this.bordeDerecho.Name = "bordeDerecho";
            this.bordeDerecho.Size = new System.Drawing.Size(1, 89);
            this.bordeDerecho.TabIndex = 36;
            // 
            // panelEspacio
            // 
            this.panelEspacio.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEspacio.Location = new System.Drawing.Point(0, 0);
            this.panelEspacio.Name = "panelEspacio";
            this.panelEspacio.Size = new System.Drawing.Size(150, 9);
            this.panelEspacio.TabIndex = 37;
            // 
            // Estadistica
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bordeDerecho);
            this.Controls.Add(this.bordeInferior);
            this.Controls.Add(this.lblText);
            this.Controls.Add(this.bordeIzquierdo);
            this.Controls.Add(this.bordeSuperior);
            this.Controls.Add(this.panelEspacio);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.lblTotal);
            this.Name = "Estadistica";
            this.Size = new System.Drawing.Size(150, 100);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CircularProgressBar.CircularProgressBar progress;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblText;
        private System.Windows.Forms.Panel bordeIzquierdo;
        private System.Windows.Forms.Panel bordeSuperior;
        private System.Windows.Forms.Panel bordeInferior;
        private System.Windows.Forms.Panel bordeDerecho;
        private System.Windows.Forms.Panel panelEspacio;
    }
}
