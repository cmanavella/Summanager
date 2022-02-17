﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class PanelButton : UserControl
    {
        private Color buttonBackColor;
        private Color buttonForeColor;

        public PanelButton()
        {
            InitializeComponent();
            this.buttonBackColor = Color.FromArgb(0, 137, 132);
            this.buttonForeColor = Color.White;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new bool Enabled
        {
            get
            {
                return this.button1.Enabled;
            }
            set
            {
                this.button1.Enabled = value;

                if (value)
                {
                    this.button1.BackColor = this.buttonBackColor;
                }
                else
                {
                    this.button1.BackColor = Color.Silver;
                }
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ButtonForeColor
        {
            get
            {
                return this.buttonForeColor;
            }
            set
            {
                this.buttonForeColor = value;
                this.button1.ForeColor = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Color ButtonBackColor
        {
            get
            {
                return this.buttonBackColor;
            }
            set
            {
                this.buttonBackColor = value;
                this.button1.BackColor = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return button1.Text;
            }
            set
            {
                button1.Text = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image
        {
            get
            {
                return button1.Image;
            }
            set
            {
                button1.Image = value;
            }
        }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new Color BackColor { get; set; }

        [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("just cast me to avoid all this hiding...", true)]
        public new Color ForeColor { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }
    }
}
