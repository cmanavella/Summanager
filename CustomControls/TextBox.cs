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
        private Color botonHover;
        private Color botonNormal;
        private bool isMaskared;
        private string maskText;
        private string normalText;
        private CharacterCasing character;

        public TextBox()
        {
            InitializeComponent();
            //Color usado para colorear los elementos cuando el combo tiene foco.
            this.colorFocused = Color.FromArgb(0, 137, 132);
            //Color usado para colorear los elementos cuando el combo no tiene foco.
            this.colorUnfocused = Color.Gray;

            this.botonHover = Color.FromArgb(153, 0, 0);
            this.botonNormal = this.colorUnfocused;

            //Variable que uso para saber si el texto es mascarado o no.
            this.isMaskared = true;

            //Estas variables las uso para almacenar los textos mascarado y normal.
            //Para, posteriormente, alternarlos de acuerdo a lo que necesite.
            this.maskText = String.Empty;
            this.normalText = String.Empty;

            //Conecto los eventos del TextBox verdadero con los del Control.
            this.textBox1.Enter += this.TextBox_Enter;
            this.textBox1.Leave += this.TextBox_Leave;

            this.character = CharacterCasing.Normal;
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
                    this.textBox1.CharacterCasing = CharacterCasing.Normal;
                }
                else
                {
                    this.textBox1.Text = this.normalText;
                    this.textBox1.ForeColor = this.colorFocused;
                    this.textBox1.CharacterCasing = this.character;
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

        /// <summary>
        /// Indica si todos los caracteres deberían escribirse de forma libre o ser convertidos en mayúsculas o minúsculas.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public CharacterCasing CharacterCasing
        {
            get
            {
                return this.character;
            }
            set
            {
                this.character = value;
            }
        }

        /// <summary>
        /// Especifica el número máximo de caracteres que se pueden introducir en el control de edición.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int MaxLength
        {
            get
            {
                return this.textBox1.MaxLength;
            }
            set
            {
                this.textBox1.MaxLength = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el punto inicial del texto seleccionado en el cuadro de texto.
        /// </summary>
        /// <returns>La posición inicial del texto seleccionado en el cuadro de texto.</returns>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public int SelectionStart
        {
            get
            {
                return this.textBox1.SelectionStart;
            }
            set
            {
                this.textBox1.SelectionStart = value;
            }
        }

        /// <summary>
        /// Obtiene o establece el número de caracteres seleccionados en el cuadro de texto.
        /// </summary>
        /// <returns>El número de caracteres seleccionados en el cuadro de texto.</returns>
        /// <exception cref="ArgumentOutOfRangeException"/>
        public int SelectionLength
        {
            get
            {
                return this.textBox1.SelectionLength;
            }
            set
            {
                this.textBox1.SelectionLength = value;
            }
        }

        /*
         * EVENTOS
         * */
        private void TextBox_Enter(object sender, EventArgs e)
        {
            //Siempre que entro seteo los colores.
            this.bordeInferior.BackColor = this.colorFocused;
            this.textBox1.ForeColor = this.colorFocused;

            //Hago visible el botón para borrar.
            this.btnBorrar.Visible = true;

            //Si está mascarado, borro el texto y seteo los caracteres como los he seleccionado.
            if (this.isMaskared)
            {
                this.textBox1.Text = String.Empty;
            }
        }

        private void TextBox_Leave(object sender, EventArgs e)
        {
            //Cuando salgo del control, siempre cambio el color del borde.
            this.bordeInferior.BackColor = this.colorUnfocused;

            //Oculto el botón borrar.
            this.btnBorrar.Visible = false;

            //Si está mascarado, vuelvo a colocar el MaskText, cambio el color del Text.
            if (this.isMaskared) 
            {
                this.textBox1.Text = this.maskText;
                this.textBox1.ForeColor = this.colorUnfocused;
            }
        }

        private void TextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (this.textBox1.Text.Length > 0)
            {
                this.isMaskared = false;
            }
            else
            {   
                this.isMaskared = true;
            }

            //Pregunto si la tecla presionada ha sido la de borrar o suprimir y si el texto está vacío. Si esto es así, seteo los 
            //los caracteres a normal.
            //Antes pregunto si el KeyEventArg no es nulo, ya que cuando aprieto el botón Borrar del UserControl llamo a este evento pasándole
            //KeyEventArg como nulo.
            if (e != null)
            {
                if ((e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete) && this.textBox1.Text.Length == 0)
                {
                    this.textBox1.CharacterCasing = CharacterCasing.Normal;
                }
                //Si no se dan esas condiciones, pregunto si el texto tiene valor. Si lo tiene, seteo los cartacteres como los he configurado en la 
                //propiedad del UserControl.
                else if (this.textBox1.Text.Length > 0)
                {
                    this.textBox1.CharacterCasing = this.character;
                }
            }
        }

        private void textBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //En este paso capturo el presionar de la tecla Tab antes de que el UserControl pierda el foco.
            //En este caso pregunto si la tecla es Tab y a la vex el texto está vacío. En tal caso seteo los caracteres a Normal.
            if (e.KeyCode == Keys.Tab && this.textBox1.Text.Length == 0)
            {
                this.textBox1.CharacterCasing = CharacterCasing.Normal;
            }
            this.OnPreviewKeyDown(e);
        }

        public void Clear()
        {
            this.textBox1.Text = String.Empty;
            this.textBox1_KeyUp(null, null);
            this.textBox1.CharacterCasing = CharacterCasing.Normal; //Pongo los caracteres en Normal
            if (!this.textBox1.Focused) this.TextBox_Leave(null, null);
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            this.OnKeyUp(e);
        }

        private void btnBorrar_MouseEnter(object sender, EventArgs e)
        {
            this.btnBorrar.ForeColor = this.botonHover;
        }

        private void btnBorrar_MouseLeave(object sender, EventArgs e)
        {
            this.btnBorrar.ForeColor = this.botonNormal;
        }

        private void btnBorrar_MouseClick(object sender, MouseEventArgs e)
        {
            Clear();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.OnKeyPress(e);
        }
    }
}
