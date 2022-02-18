using System;
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
    [Serializable]
    public partial class Button : UserControl
    {
        private Color buttonBackColor;
        private Color buttonForeColor;

        public Button()
        {
            InitializeComponent();

            this.buttonBackColor = Color.FromArgb(114, 159, 206);
            this.buttonForeColor = Color.White;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public ContentAlignment TextAlign
        {
            get
            {
                return this.button1.TextAlign;
            }
            set
            {
                this.button1.TextAlign = value;
            }
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
