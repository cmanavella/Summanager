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
    public partial class Estadistica : UserControl
    {
        private int count;
        private int total;
        private int porcentaje;

        public Estadistica()
        {
            InitializeComponent();
            this.count = 0;
            this.total = 0;
            this.porcentaje = 0;
            progress.Value = this.porcentaje;
            progress.Refresh();
        }

        private int _getPorcentaje()
        {
            int retorno = 0;

            if ((this.count <= this.total) && this.total > 0)
            {
                retorno = this.count * 100 / this.total;
            }

            return retorno;
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return lblText.Text;
            }
            set
            {
                lblText.Text = value;
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Count
        {
            get
            {
                return this.count;
            }
            set
            {
                if (value < 0)
                {
                    this.count = 0;
                }
                else
                {
                    this.count = value;
                }
                this.lblCount.Text = this.count.ToString();
                this.porcentaje = _getPorcentaje();
                progress.Value = this.porcentaje;
                progress.Text = progress.Value.ToString() + "%";
                progress.Refresh();
            }
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int Total
        {
            get
            {
                return this.total;
            }
            set
            {
                if (value < 0)
                {
                    this.total = 0;
                }
                else
                {
                    this.total = value;
                }
                this.lblTotal.Text = this.total.ToString();
                this.porcentaje = _getPorcentaje();
                progress.Value = this.porcentaje;
                progress.Text = progress.Value.ToString() + "%";
                progress.Refresh();
            }
        }
    }
}
