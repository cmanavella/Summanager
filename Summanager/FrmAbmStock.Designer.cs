
namespace Summanager
{
    partial class FrmAbmStock
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
            this.panelSuperior = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.btnCerrar = new CustomControls.PanelButton();
            this.panelInferior = new System.Windows.Forms.Panel();
            this.panelIzquierdo = new System.Windows.Forms.Panel();
            this.panelDerecho = new System.Windows.Forms.Panel();
            this.txtBusqueda = new CustomControls.TextBox();
            this.txtCantidad = new CustomControls.TextBox();
            this.btnGuardar = new CustomControls.Button();
            this.btnCancelar = new CustomControls.Button();
            this.lblInfo = new System.Windows.Forms.Label();
            this.panelSuperior.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSuperior
            // 
            this.panelSuperior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelSuperior.Controls.Add(this.lblTitulo);
            this.panelSuperior.Controls.Add(this.btnCerrar);
            this.panelSuperior.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelSuperior.Location = new System.Drawing.Point(0, 0);
            this.panelSuperior.Name = "panelSuperior";
            this.panelSuperior.Size = new System.Drawing.Size(383, 30);
            this.panelSuperior.TabIndex = 11;
            this.panelSuperior.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelSuperior_MouseDown);
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(5, 7);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(49, 16);
            this.lblTitulo.TabIndex = 13;
            this.lblTitulo.Text = "label2";
            this.lblTitulo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblTitulo_MouseDown);
            // 
            // btnCerrar
            // 
            this.btnCerrar.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.btnCerrar.ButtonForeColor = System.Drawing.Color.White;
            this.btnCerrar.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnCerrar.Image = null;
            this.btnCerrar.Location = new System.Drawing.Point(353, 0);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(30, 30);
            this.btnCerrar.TabIndex = 11;
            this.btnCerrar.Text = "X";
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // panelInferior
            // 
            this.panelInferior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelInferior.Location = new System.Drawing.Point(0, 147);
            this.panelInferior.Name = "panelInferior";
            this.panelInferior.Size = new System.Drawing.Size(383, 1);
            this.panelInferior.TabIndex = 14;
            // 
            // panelIzquierdo
            // 
            this.panelIzquierdo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelIzquierdo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelIzquierdo.Location = new System.Drawing.Point(0, 30);
            this.panelIzquierdo.Name = "panelIzquierdo";
            this.panelIzquierdo.Size = new System.Drawing.Size(1, 117);
            this.panelIzquierdo.TabIndex = 15;
            // 
            // panelDerecho
            // 
            this.panelDerecho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panelDerecho.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelDerecho.Location = new System.Drawing.Point(382, 30);
            this.panelDerecho.Name = "panelDerecho";
            this.panelDerecho.Size = new System.Drawing.Size(1, 117);
            this.panelDerecho.TabIndex = 16;
            // 
            // txtBusqueda
            // 
            this.txtBusqueda.BackColor = System.Drawing.Color.White;
            this.txtBusqueda.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtBusqueda.IsMaskared = true;
            this.txtBusqueda.Location = new System.Drawing.Point(12, 36);
            this.txtBusqueda.MaskText = "Código, Nombre o Modelo de Impresora";
            this.txtBusqueda.Name = "txtBusqueda";
            this.txtBusqueda.SelectionLength = 0;
            this.txtBusqueda.SelectionStart = 0;
            this.txtBusqueda.Size = new System.Drawing.Size(276, 20);
            this.txtBusqueda.TabIndex = 17;
            this.txtBusqueda.Text = "Código, Nombre o Modelo de Impresora";
            this.txtBusqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtBusqueda_KeyUp);
            this.txtBusqueda.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.txtBusqueda_PreviewKeyDown);
            // 
            // txtCantidad
            // 
            this.txtCantidad.BackColor = System.Drawing.Color.White;
            this.txtCantidad.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.txtCantidad.IsMaskared = true;
            this.txtCantidad.Location = new System.Drawing.Point(307, 36);
            this.txtCantidad.MaskText = "Cantidad";
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.SelectionLength = 0;
            this.txtCantidad.SelectionStart = 0;
            this.txtCantidad.Size = new System.Drawing.Size(67, 20);
            this.txtCantidad.TabIndex = 18;
            this.txtCantidad.Text = "Cantidad";
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.ButtonBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.btnGuardar.ButtonForeColor = System.Drawing.Color.White;
            this.btnGuardar.Image = null;
            this.btnGuardar.Location = new System.Drawing.Point(291, 108);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(80, 28);
            this.btnGuardar.TabIndex = 20;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancelar.ButtonBackColor = System.Drawing.Color.Gray;
            this.btnCancelar.ButtonForeColor = System.Drawing.Color.White;
            this.btnCancelar.Image = null;
            this.btnCancelar.Location = new System.Drawing.Point(12, 108);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 28);
            this.btnCancelar.TabIndex = 19;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblInfo
            // 
            this.lblInfo.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.lblInfo.Location = new System.Drawing.Point(9, 59);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(362, 37);
            this.lblInfo.TabIndex = 21;
            this.lblInfo.Visible = false;
            // 
            // FrmAbmStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 148);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.txtCantidad);
            this.Controls.Add(this.txtBusqueda);
            this.Controls.Add(this.panelDerecho);
            this.Controls.Add(this.panelIzquierdo);
            this.Controls.Add(this.panelInferior);
            this.Controls.Add(this.panelSuperior);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmAbmStock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmAbmStock";
            this.panelSuperior.ResumeLayout(false);
            this.panelSuperior.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSuperior;
        protected System.Windows.Forms.Label lblTitulo;
        private CustomControls.PanelButton btnCerrar;
        private System.Windows.Forms.Panel panelInferior;
        private System.Windows.Forms.Panel panelIzquierdo;
        private System.Windows.Forms.Panel panelDerecho;
        private CustomControls.TextBox txtBusqueda;
        protected CustomControls.TextBox txtCantidad;
        protected CustomControls.Button btnGuardar;
        protected CustomControls.Button btnCancelar;
        private System.Windows.Forms.Label lblInfo;
    }
}