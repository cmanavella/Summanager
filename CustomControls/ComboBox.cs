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
    public partial class ComboBox : UserControl
    {
        private Color colorFocused;
        private Color colorUnfocused;
        private ContainerCombo container;
        private Item itemSelected;
        private int itemButtonHeght;
        private Point containerLocation;

        /// <summary>
        /// Devuelve los Items cargados en el Objeto ComboBox
        /// </summary>
        public List<Item> Items { get; }

        [Browsable(true)]
        public event EventHandler ItemSelectedChange;

        public ComboBox()
        {
            InitializeComponent();
            //Color usado para colorear los elementos cuando el combo tiene foco.
            this.colorFocused = Color.FromArgb(0, 137, 132);
            //Color usado para colorear los elementos cuando el combo no tiene foco.
            this.colorUnfocused = Color.Gray;

            //Creo el Objeto Items.
            this.Items = new List<Item>();

            //Uso esta variable para setear el Heigth que van a tener los Items del combo.
            this.itemButtonHeght = 25;

            //Este es contenedor de los botones. Sería lo que se despliega.
            this.container = new ContainerCombo(this);

            //Traslado los eventos de los elementos del combo a su respectivo evento en el combo.
            this.contenedorCombo.Enter += ComboBox_Enter;
            this.contenedorCombo.Leave += ComboBox_Leave;
            this.division.Enter += ComboBox_Enter;
            this.division.Leave += ComboBox_Leave;
            //this.division.MouseClick += ComboBox_MouseClick;
            this.icon.Enter += ComboBox_Enter;
            this.icon.Leave += ComboBox_Leave;
            //this.icon.MouseClick += ComboBox_MouseClick;
            this.lblItemText.Enter += ComboBox_Enter;
            this.lblItemText.Leave += ComboBox_Leave;
            //this.lblItemText.MouseClick += ComboBox_MouseClick;
        }

        /// <summary>
        /// Agrega un elemento ItemButton con la información de un Item pasado por parámetro.
        /// </summary>
        /// <param name="item"></param>
        private void _addItemButton(Item item)
        {
            ItemButton boton = new ItemButton(this);
            boton.Value = item.Value;
            boton.Text = item.Text;

            boton.Width = this.contain.Width;
            boton.Height = this.itemButtonHeght;
            boton.Dock = DockStyle.Top;
            
            this.contain.Controls.Add(boton);
            this.contain.Controls.SetChildIndex(boton, 0); //Hago esto para enviar el botón abajo.
        }

        /// <summary>
        /// Permite desplegar o replegar el ComboBox, determinando si fue llamado por un evento Click o
        /// no.
        /// </summary>
        private void _desplegar()
        {
            //Primero me aseguro que haya Ítems (Botones) cargados en el Combo para desplegar su contenedor.
            if (this.Items.Count > 0)
            {
                //Limpio todos los controles que ya tenga el contenedor.
                this.container.Controls.Clear();
                //Agrego el panel superior del contenedor, que tiene la funcionalidad de replegarlo. Lo agrego sí o sí ya que al quitar todos 
                //controles, también quito el panel superior y es menester para el correcto funcionamiento del contenedor.
                this.container.AgregarPanelSuperior();

                //Recorro todos los Ítems cargados en el Menú y los agrego al contenedor. Como por defecto tienen la propiedad Dock seteada en Top, debo
                //ponerlos al frente de todo a medida que los agrego.
                foreach (Item item in this.Items)
                {
                    ItemButton button = new ItemButton(this);
                    button.Value = item.Value;
                    button.Text = item.Text;
                    this.container.Controls.Add(button);
                    button.BringToFront();
                }

                //Seteo la altura del contenedor que la calcula el método de él mismo.
                this.container.SetHeight();
                //Lo pongo al frente para que no se oculte detrás de otro elemento.
                this.container.BringToFront();
                //Como el contenedor básicamente es un Form modificado, lo muestro.
                this.container.Show();
                //Seteo la posición del contenedor en la pantalla para que quede exactamente debajo del Menú.
                this.container.Location = this.containerLocation;
            }
        }

        /// <summary>
        /// Agrega un Item al Objeto ComboBox.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="text"></param>
        public void Add(int value, string text)
        {
            Item item = new Item(value, text); //Creo el objeto item con los parámetros.
            this.Items.Add(item); //Cargo el item a la Lista de Items.
            _addItemButton(item); //Agrego un ItemButtom con el Item creado.
            if (this.Items.Count > 0)
            {
                //Si la cantidad de Items es mayor que 0, muestro el texto del mismo y lo 
                //guardo en la variable itemSelected para saber cuál tengo seleccionado.
                this.lblItemText.Text = this.Items[0].Text;
                this.itemSelected = this.Items[0];
            }
        }

        /// <summary>
        /// Devuelve el Item que se encuentra seleccionado.
        /// </summary>
        /// <returns></returns>
        public Item SelectedItem()
        {
            return this.itemSelected;
        }

        /// <summary>
        /// Permite seleccionar un Ítem específico.
        /// </summary>
        /// <param name="index"></param>
        public void SelectItem(int index, bool esCodigo)
        {
            this.lblItemText.Text = this.Items[index].Text; //Paso el texto al Label que lo muestra.
            this.itemSelected = this.Items[index]; //Guaro el item seleccionado.
            if (this.ItemSelectedChange != null) this.ItemSelectedChange(null, null); //Disparo el Handler si este no es null.

            this.container.Hide();
        }

        /// <summary>
        /// Devuelve una cadena con la información de los Ítems almacenados.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string retorno = String.Empty;
            if (this.Items.Count > 0)
            {
                bool primero = true;
                foreach(Item item in Items)
                {
                    if (primero)
                    {
                        retorno = item.ToString();
                        primero = false;
                    }
                    else
                    {
                        retorno += "\n" + item.ToString();
                    }
                }
            }
            return retorno;
        }

        private void _nextItem()
        {
            int index = this.itemSelected.Value;
            //Compruebo que el Index no sea el último así hago el Next
            if (index < this.Items.Count - 1)
            {
                this.lblItemText.Text = this.Items[index + 1].Text; //Paso el texto al Label que lo muestra.
                this.itemSelected = this.Items[index + 1]; //Guaro el item seleccionado.
                if (this.ItemSelectedChange != null) this.ItemSelectedChange(null, null); //Disparo el Handler si este no es null.
            }
        }

        private void _beforeItem()
        {
            int index = this.itemSelected.Value;
            //Compruebo que el Index no sea el primero así hago el Before
            if (index > 0)
            {
                this.lblItemText.Text = this.Items[index - 1].Text; //Paso el texto al Label que lo muestra.
                this.itemSelected = this.Items[index - 1]; //Guaro el item seleccionado.
                if (this.ItemSelectedChange != null) this.ItemSelectedChange(null, null); //Disparo el Handler si este no es null.
            }
        }

        private void _clickEnCombo()
        {
            //Cuando hago clic con el mouse, hago que el combo tome foco.
            this.Focus();

            //Al hacer clic en el Menú necesito que se despliegue el contenedor. Pero antes debo calcular la pocisión exacta para ubicarlo.
            //Para ello, transformo el Objeto Sender en un Control.
            Control control = this.lblItemText;
            //Luego calculo la posición del Contenedor en base a la posición relativa que ocupa el Menú en la pantalla.
            this.containerLocation = control.PointToScreen(control.Location);

            //Llamo al método desplegar. Le indico por parámetro que se llama desde un evento clic.
            _desplegar();
        }

        /*
         * EVENTOS.
         */
        private void ComboBox_Enter(object sender, EventArgs e)
        {
            //Cuando el combo toma foco pinto sus elementos con el color definido en el constructor.
            this.bordeInferior.BackColor = this.colorFocused;
            this.division.BackColor = this.colorFocused;
            this.icon.ForeColor = this.colorFocused;
            this.lblItemText.ForeColor = this.colorFocused;
        }

        private void ComboBox_Leave(object sender, EventArgs e)
        {
            //Cuando el combo pierde el foco, repinto los elementos a su color original,
            this.bordeInferior.BackColor = this.colorUnfocused;
            this.division.BackColor = this.colorUnfocused;
            this.icon.ForeColor = this.colorUnfocused;
            this.lblItemText.ForeColor = this.colorUnfocused;
        }

        private void ComboBox_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            //Cancelo las teclas de flechas para que no se ejecute el Leave al presionarlas, tomándolas como input.
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Left || e.KeyCode == Keys.Up || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = true;
            }
        }

        private void ComboBox_KeyUp(object sender, KeyEventArgs e)
        {
            //Si la tecla presionada es la Flecha Abajo, selecciono el siguiente Item.
            if (e.KeyCode == Keys.Down)
            {
                _nextItem();
            }
            //Si la tecla presionada es la Flecha Arriba, selecciono el Item anterior.
            if (e.KeyCode == Keys.Up)
            {
                _beforeItem();
            }
        }

        private void lblItemText_Click(object sender, EventArgs e)
        {
            _clickEnCombo();
        }

        private void division_Click(object sender, EventArgs e)
        {
            _clickEnCombo();
        }

        private void icon_Click(object sender, EventArgs e)
        {
            _clickEnCombo();
        }
    }

    /// <summary>
    /// Control que contiene los botones de un control Menú. Por defecto está oculto pero se despliega y pliega al hacer clic en el Menú.
    /// </summary>
    public class ContainerCombo : Form
    {
        private ComboBox combo;
        private Panel panelSuperior;
        private Panel panelHand;

        /// <summary>
        /// Constructor de la clase Container.
        /// </summary>
        /// <param name="menu">Control Menú que lo contiene.</param>
        public ContainerCombo(ComboBox combo)
        {
            //Paso el Menú del parámetro a la variable del contenedor.
            this.combo = combo;

            //Creo un panel superior.
            this.panelSuperior = new Panel();
            //Creo el panel Hand que se va a encontrar dentro del Panel Superior a su izquierda.
            //Tiene la función de simplemente modificar el cursor del mouse a hand.
            this.panelHand = new Panel();

            //Al ser un Form necesito setearlo.
            this.Width = 300;
            //Le quito los bordes.
            this.FormBorderStyle = FormBorderStyle.None;
            //El TransparencyKey y el BackColor seteados con el mismo color me permiten que el Form sea transparente.
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;
            //Hago que no se muestre en la Barra de Tareas.
            this.ShowInTaskbar = false;

            //Asigno los Eventos con los que voy a trabajar.
            //Evento que tiene lugar cuando el Form se desactiva.
            this.Deactivate += Container_Deactivate;
            this.panelHand.Click += Panel_Hand_Click;
            this.panelSuperior.Click += Panel_Superior_Click;
            this.Shown += new System.EventHandler(this.ContainerCombo_Shown);
        }

        /// <summary>
        /// Devuelve la altura del contenedor en base a la cantidad de elementos que contenga.
        /// </summary>
        public void SetHeight()
        {
            //Ingreso la altura del Panel Superior.
            int height = this.panelSuperior.Height;

            //Recorro todos los controles cargados en el contenedor, que no sean del tipo Panel, y voy sumando su altura.
            foreach (Control control in this.Controls)
            {
                if (control.GetType().Name != "Panel")
                {
                    height += control.Height;
                }
            }

            //Seteo la altura del contenedor en base a lo calculado sumándole 2px del Borde Inferior.
            this.Height = height + 2;
        }

        /// <summary>
        /// Agrega el panel superior dentro del contenedor.
        /// </summary>
        public void AgregarPanelSuperior()
        {
            //Seteo el panel superior
            this.panelSuperior.Height = this.combo.Height;
            this.panelSuperior.Dock = DockStyle.Top;
            this.Controls.Add(this.panelSuperior);
            this.panelSuperior.BringToFront();

            //Seteo el panel hand. Es importante que el ancho de este panel sea del ancho del Menú que lo contiene para simular, al pasar el mouse por
            //encima o al hacer clic, que uno está actuando sobre el Menú.
            this.panelHand.Width = this.combo.Width;
            this.panelHand.Dock = DockStyle.Left;
            this.panelHand.Cursor = Cursors.Hand;
            this.panelHand.BringToFront();

            //Agrego el Panel Hand al Panel Superior.
            this.panelSuperior.Controls.Add(this.panelHand);
        }

        //En los eventos clic de los dos paneles y en el evento deactive del contenedor, simplemente oculto el mismo (lo pliego).
        private void Panel_Superior_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Panel_Hand_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Container_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ContainerCombo_Shown(object sender, EventArgs e)
        {
            this.Width = this.combo.Width;
        }
    }

    public class Item
    {
        /// <summary>
        /// Devuelve un valor de tipo 'int' del Ítem.
        /// </summary>
        public int Value { get; }
        /// <summary>
        /// Devuelve el Texto asignado al Ítem.
        /// </summary>
        public string Text { get; }

        public Item():this(0, String.Empty) { } 

        public Item (int value, string text)
        {
            Value = value;
            Text = text;
        }

        /// <summary>
        /// Devuelve una cadena con los datos del Ítem.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "{ Value: " + this.Value + "; Text: " + this.Text + " }";
        }
    }

    [Serializable]
    public class ItemButton : System.Windows.Forms.Button
    {
        private ComboBox combo;
        /// <summary>
        /// Obtiene o establece el valor numérico del elemento.
        /// </summary>
        public int Value { get; set; }
        public ItemButton(ComboBox combo)
        {
            this.combo = combo; //Le paso por parámetro el Combo que lo contiene.

            //Lo establesco como Flat sin bordes.
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            //Seteo el cursor usado al pasar el mouse encima.
            this.Cursor = Cursors.Hand;

            this.TabStop = false;
            this.Dock = DockStyle.Top;

            //Acomodo la fuente.
            this.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(0, 137, 132);
            this.TextAlign = ContentAlignment.MiddleLeft;

            //Le asigno el evento Mouse Click.
            this.MouseClick += ItemButton_MouseClick;
        }

        private void ItemButton_MouseClick(object sender, MouseEventArgs e)
        {
            //Selecciono el Item del Combo de acuerdo al Value del Combo.
            this.combo.SelectItem(this.Value, false);
        }
    }
}
