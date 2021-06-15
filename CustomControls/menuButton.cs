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
    public partial class menuButton : UserControl
    {
        private bool selected;
        private readonly Color panelNoSelected = Color.FromArgb(0, 137, 132);
        private readonly Color panelWhite = Color.White;
        private readonly Color panelSelected = Color.FromArgb(165, 217, 216);
        private readonly Color buttonSelected = Color.White;
        private readonly Color buttonNoSelected = Color.FromArgb(165, 217, 216);

        public menuButton()
        {
            InitializeComponent();
            this.button1.MouseClick += Button1_MouseClick;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool Selected
        {
            get
            {
                return this.selected;
            }
            set
            {
                this.selected = value;
                if (value)
                {
                    button1.BackColor = buttonSelected;
                    panelDerecho.BackColor = panelWhite;
                    panelIzquierdo.BackColor = panelSelected;
                }
                else
                {
                    button1.BackColor = buttonNoSelected;
                    panelIzquierdo.BackColor = panelNoSelected;
                    panelDerecho.BackColor = panelNoSelected;
                }
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

        private void Button1_MouseClick(object sender, MouseEventArgs e)
        {
            this.OnMouseClick(e);
        }
    }
}
