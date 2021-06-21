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
    public partial class ProgressBar : UserControl
    {
        private int value;
        public ProgressBar()
        {
            InitializeComponent();
            this.value = 0;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                int maxWidth = this.Width - 2;
                if (value <= 0)
                {
                    this.value = 0;
                    this.barra.Width = 0;
                }else if (value >= 100)
                {
                    this.value = 100;
                    this.barra.Width = maxWidth;
                }
                else
                {
                    this.value = value;
                    this.barra.Width = value * maxWidth / 100;
                }
            }
        }
    }
}
