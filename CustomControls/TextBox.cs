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
    public partial class TextBox : UserControl
    {
        private Color colorFocused;
        private Color colorUnfocused;
        private bool isMaskared;
        private string maskText;
        private string normalText;

        public TextBox()
        {
            InitializeComponent();
            //Color usado para colorear los elementos cuando el combo tiene foco.
            this.colorFocused = Color.FromArgb(0, 137, 132);
            //Color usado para colorear los elementos cuando el combo no tiene foco.
            this.colorUnfocused = Color.Gray;

            //Variable que uso para saber si el texto es mascarado o no.
            this.isMaskared = true;

            //Estas variables las uso para almacenar los textos mascarado y normal.
            //Para, posteriormente, alternarlos de acuerdo a lo que necesite.
            this.maskText = String.Empty;
            this.normalText = String.Empty;
        }

        /// <summary>
        /// Devuelve o establece si el Objeto TextBox es Mascarado o no.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool IsMaskared 
        {
            get 
            {
                return isMaskared;
            }
            set
            {
                this.isMaskared = value;
                if (this.isMaskared)
                {
                    this.textBox1.Text = this.maskText;
                    this.textBox1.ForeColor = this.colorUnfocused;
                }
                else
                {
                    this.textBox1.Text = this.normalText;
                    this.textBox1.ForeColor = this.colorFocused;
                }
            }
        }

        /// <summary>
        /// Obtiene el Texto del Objeto Textbox y lo establece si el Objeto TextBox no 
        /// es Mascarado.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return this.textBox1.Text;
            }
            set
            {
                this.normalText = value;
                if (!this.isMaskared) this.textBox1.Text = this.normalText;
            }
        }

        /// <summary>
        /// Obtiene el Texto Mascarado del Objeto TextBox y lo establece si es Mascarado.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string MaskText
        {
            get
            {
                return this.maskText;
            }
            set
            {
                this.maskText = value;
                if (this.isMaskared) this.textBox1.Text = this.maskText;
            }
        }
    }
}
