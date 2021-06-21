using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner))]
    public partial class CustomGroupBox : UserControl
    {
        public CustomGroupBox()
        {
            InitializeComponent();
        }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        //[Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public override Color BackColor
        //{
        //    get
        //    {
        //        return this.BackColor;
        //    }
        //    set
        //    {
        //        this.BackColor = value;
        //        label1.BackColor = value;
        //    }
        //}

        //[Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        //public Color BorderColor
        //{
        //    get
        //    {
        //        return label1.ForeColor;
        //    }
        //    set
        //    {
        //        label1.ForeColor = value;
        //        bordeSuperior.BackColor = value;
        //        bordeDerecho.BackColor = value;
        //        bordeInferior.BackColor = value;
        //        bordeIzquierdo.BackColor = value;
        //    }
        //}
    }
}
