﻿
namespace Summanager
{
    partial class FrmConfiguracion
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
            this.chkAutomatico = new System.Windows.Forms.CheckBox();
            this.cmbPeriodo = new CustomControls.ComboBox();
            this.btnAceptar = new CustomControls.Button();
            this.btnCancelar = new CustomControls.Button();
            this.customGroupBox1 = new CustomControls.CustomGroupBox();
            this.btnIniciarCerrar = new CustomControls.Button();
            this.panelTitulo.SuspendLayout();
            this.customGroupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.Size = new System.Drawing.Size(200, 32);
            this.lblTitulo.Text = "Configuración";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 134);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 12;
            this.label1.Text = "Período:";
            // 
            // chkAutomatico
            // 
            this.chkAutomatico.AutoSize = true;
            this.chkAutomatico.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAutomatico.Location = new System.Drawing.Point(12, 95);
            this.chkAutomatico.Name = "chkAutomatico";
            this.chkAutomatico.Size = new System.Drawing.Size(405, 21);
            this.chkAutomatico.TabIndex = 11;
            this.chkAutomatico.Text = "Actualizar automáticamente los estados de las impresoras";
            this.chkAutomatico.UseVisualStyleBackColor = true;
            this.chkAutomatico.CheckedChanged += new System.EventHandler(this.chkAutomatico_CheckedChanged);
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.BackColor = System.Drawing.Color.White;
            this.cmbPeriodo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmbPeriodo.Enabled = false;
            this.cmbPeriodo.Location = new System.Drawing.Point(77, 124);
            this.cmbPeriodo.MinimumSize = new System.Drawing.Size(136, 27);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(146, 27);
            this.cmbPeriodo.TabIndex = 13;
            // 
            // btnAceptar
            // 
            this.btnAceptar.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.btnAceptar.ButtonForeColor = System.Drawing.Color.White;
            this.btnAceptar.Image = null;
            this.btnAceptar.Location = new System.Drawing.Point(252, 123);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(70, 28);
            this.btnAceptar.TabIndex = 14;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.ButtonBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.ButtonForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = null;
            this.btnCancelar.Location = new System.Drawing.Point(328, 123);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 28);
            this.btnCancelar.TabIndex = 15;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // customGroupBox1
            // 
            this.customGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.customGroupBox1.Controls.Add(this.btnIniciarCerrar);
            this.customGroupBox1.Location = new System.Drawing.Point(12, 169);
            this.customGroupBox1.Name = "customGroupBox1";
            this.customGroupBox1.Size = new System.Drawing.Size(1026, 73);
            this.customGroupBox1.TabIndex = 16;
            this.customGroupBox1.Text = "Panel Usuario";
            // 
            // btnIniciarCerrar
            // 
            this.btnIniciarCerrar.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.btnIniciarCerrar.ButtonForeColor = System.Drawing.Color.White;
            this.btnIniciarCerrar.Image = null;
            this.btnIniciarCerrar.Location = new System.Drawing.Point(17, 27);
            this.btnIniciarCerrar.Name = "btnIniciarCerrar";
            this.btnIniciarCerrar.Size = new System.Drawing.Size(80, 28);
            this.btnIniciarCerrar.TabIndex = 6;
            this.btnIniciarCerrar.Text = "Iniciar";
            this.btnIniciarCerrar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnIniciarCerrar.Click += new System.EventHandler(this.btnIniciarCerrar_Click);
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1050, 665);
            this.Controls.Add(this.customGroupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.cmbPeriodo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chkAutomatico);
            this.Name = "FrmConfiguracion";
            this.Controls.SetChildIndex(this.panelTitulo, 0);
            this.Controls.SetChildIndex(this.panelMenu, 0);
            this.Controls.SetChildIndex(this.chkAutomatico, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.cmbPeriodo, 0);
            this.Controls.SetChildIndex(this.btnAceptar, 0);
            this.Controls.SetChildIndex(this.btnCancelar, 0);
            this.Controls.SetChildIndex(this.customGroupBox1, 0);
            this.panelTitulo.ResumeLayout(false);
            this.panelTitulo.PerformLayout();
            this.customGroupBox1.ResumeLayout(false);
            this.customGroupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private CustomControls.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkAutomatico;
        private CustomControls.Button btnAceptar;
        private CustomControls.Button btnCancelar;
        private CustomControls.CustomGroupBox customGroupBox1;
        private CustomControls.Button btnIniciarCerrar;
    }
}
