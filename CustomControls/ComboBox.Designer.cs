
namespace CustomControls
{
    partial class ComboBox
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.bordeInferior = new System.Windows.Forms.Panel();
            this.division = new System.Windows.Forms.Panel();
            this.icon = new System.Windows.Forms.Button();
            this.contenedorCombo = new System.Windows.Forms.Panel();
            this.lblItemText = new System.Windows.Forms.Label();
            this.lista = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contain = new System.Windows.Forms.Panel();
            this.contenedorCombo.SuspendLayout();
            this.lista.SuspendLayout();
            this.SuspendLayout();
            // 
            // bordeInferior
            // 
            this.bordeInferior.BackColor = System.Drawing.Color.Gray;
            this.bordeInferior.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bordeInferior.Location = new System.Drawing.Point(0, 25);
            this.bordeInferior.Name = "bordeInferior";
            this.bordeInferior.Size = new System.Drawing.Size(136, 2);
            this.bordeInferior.TabIndex = 0;
            // 
            // division
            // 
            this.division.BackColor = System.Drawing.Color.Gray;
            this.division.Dock = System.Windows.Forms.DockStyle.Right;
            this.division.Location = new System.Drawing.Point(108, 0);
            this.division.Name = "division";
            this.division.Size = new System.Drawing.Size(2, 25);
            this.division.TabIndex = 1;
            this.division.Click += new System.EventHandler(this.division_Click);
            // 
            // icon
            // 
            this.icon.Dock = System.Windows.Forms.DockStyle.Right;
            this.icon.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.icon.FlatAppearance.BorderSize = 0;
            this.icon.FlatAppearance.MouseDownBackColor = System.Drawing.Color.White;
            this.icon.FlatAppearance.MouseOverBackColor = System.Drawing.Color.White;
            this.icon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.icon.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.icon.ForeColor = System.Drawing.Color.Gray;
            this.icon.Location = new System.Drawing.Point(110, 0);
            this.icon.Name = "icon";
            this.icon.Size = new System.Drawing.Size(26, 25);
            this.icon.TabIndex = 2;
            this.icon.TabStop = false;
            this.icon.Text = "V";
            this.icon.UseVisualStyleBackColor = true;
            this.icon.Click += new System.EventHandler(this.icon_Click);
            // 
            // contenedorCombo
            // 
            this.contenedorCombo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contenedorCombo.Controls.Add(this.lblItemText);
            this.contenedorCombo.Controls.Add(this.division);
            this.contenedorCombo.Controls.Add(this.icon);
            this.contenedorCombo.Controls.Add(this.bordeInferior);
            this.contenedorCombo.Location = new System.Drawing.Point(0, 0);
            this.contenedorCombo.MinimumSize = new System.Drawing.Size(136, 27);
            this.contenedorCombo.Name = "contenedorCombo";
            this.contenedorCombo.Size = new System.Drawing.Size(136, 27);
            this.contenedorCombo.TabIndex = 3;
            // 
            // lblItemText
            // 
            this.lblItemText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblItemText.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItemText.ForeColor = System.Drawing.Color.Gray;
            this.lblItemText.Location = new System.Drawing.Point(0, 0);
            this.lblItemText.Name = "lblItemText";
            this.lblItemText.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.lblItemText.Size = new System.Drawing.Size(108, 25);
            this.lblItemText.TabIndex = 3;
            this.lblItemText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblItemText.Click += new System.EventHandler(this.lblItemText_Click);
            // 
            // lista
            // 
            this.lista.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lista.Controls.Add(this.panel4);
            this.lista.Controls.Add(this.panel2);
            this.lista.Controls.Add(this.panel1);
            this.lista.Controls.Add(this.contain);
            this.lista.Location = new System.Drawing.Point(0, 27);
            this.lista.Name = "lista";
            this.lista.Size = new System.Drawing.Size(136, 0);
            this.lista.TabIndex = 3;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel4.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1, 0);
            this.panel4.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(135, 1);
            this.panel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(137)))), ((int)(((byte)(132)))));
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(135, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1, 0);
            this.panel1.TabIndex = 0;
            // 
            // contain
            // 
            this.contain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contain.Location = new System.Drawing.Point(0, 0);
            this.contain.Name = "contain";
            this.contain.Size = new System.Drawing.Size(136, 0);
            this.contain.TabIndex = 4;
            // 
            // ComboBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.lista);
            this.Controls.Add(this.contenedorCombo);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MinimumSize = new System.Drawing.Size(136, 27);
            this.Name = "ComboBox";
            this.Size = new System.Drawing.Size(136, 27);
            this.Enter += new System.EventHandler(this.ComboBox_Enter);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBox_KeyUp);
            this.Leave += new System.EventHandler(this.ComboBox_Leave);
            this.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.ComboBox_PreviewKeyDown);
            this.contenedorCombo.ResumeLayout(false);
            this.lista.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel bordeInferior;
        private System.Windows.Forms.Panel division;
        private System.Windows.Forms.Button icon;
        private System.Windows.Forms.Panel contenedorCombo;
        private System.Windows.Forms.Panel lista;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblItemText;
        private System.Windows.Forms.Panel contain;
    }
}
