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
    public partial class DetalleEstadistica : UserControl
    {
        private int l410;
        private int l610;
        private int l622;
        private int l812;
        private Size tamaño;

        public DetalleEstadistica()
        {
            InitializeComponent();

            this.l410 = 0;
            this.l610 = 0;
            this.l622 = 0;
            this.l812 = 0;
            this.tamaño = new Size(177, 127);
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Lex410
        {
            get
            {
                return this.l410;
            }
            set
            {
                this.l410 = value;
                this.lbl410.Text = this.l410.ToString();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Lex610
        {
            get
            {
                return this.l610;
            }
            set
            {
                this.l610 = value;
                this.lbl610.Text = this.l610.ToString();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Lex622
        {
            get
            {
                return this.l622;
            }
            set
            {
                this.l622 = value;
                this.lbl622.Text = this.l622.ToString();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Lex812
        {
            get
            {
                return this.l812;
            }
            set
            {
                this.l812 = value;
                this.lbl812.Text = this.l812.ToString();
            }
        }

        private void DetalleEstadistica_VisibleChanged(object sender, EventArgs e)
        {
            this.Size = this.tamaño;
        }
    }
}
