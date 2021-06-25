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
        private bool desplegado;
        private Item itemSelected;
        private int firstHeight;
        private int itemButtonHeght;

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
            //Variable bandera que uso para saber si el Height del combo se agranda porque
            //se despliega o no.
            this.desplegado = false;

            //Creo el Objeto Items.
            this.Items = new List<Item>();

            //Uso esta variable para almacenar el Heigth original del combo a la hora de crearlo.
            this.firstHeight = this.Height;
            //Uso esta variable para setear el Heigth que van a tener los Items del combo.
            this.itemButtonHeght = 25;

            //Traslado los eventos de los elementos del combo a su respectivo evento en el combo.
            this.contenedorCombo.Enter += ComboBox_Enter;
            this.contenedorCombo.Leave += ComboBox_Leave;
            this.contenedorCombo.MouseClick += ComboBox_MouseClick;
            this.division.Enter += ComboBox_Enter;
            this.division.Leave += ComboBox_Leave;
            this.division.MouseClick += ComboBox_MouseClick;
            this.icon.Enter += ComboBox_Enter;
            this.icon.Leave += ComboBox_Leave;
            this.icon.MouseClick += ComboBox_MouseClick;
            this.lblItemText.Enter += ComboBox_Enter;
            this.lblItemText.Leave += ComboBox_Leave;
            this.lblItemText.MouseClick += ComboBox_MouseClick;
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
        /// <param name="esClic"></param>
        private void _desplegar(bool esClic)
        {
            //Pregunto si fue llamado por un Click. Hago esto porque también uso este método en el 
            //evento Leave del ComboBox.
            if (esClic)
            {
                //Pregunto si el ComboBox se encuentra desplegado o no.
                if (!desplegado)
                {
                    //Si no. Lo debo desplegar.

                    //Quito el Anchor con respecto al Bottom del contenedor para que no se modifique 
                    //cuando cambie el Heigth del combo.
                    this.contenedorCombo.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                    //Por las dudas lo vuelvo a pocisionar en las coordenadas 0,0.
                    this.contenedorCombo.Left = 0;
                    this.contenedorCombo.Top = 0;

                    //Debo calcular el alto que va a tener el contenedor de los Items.
                    int altoLista;
                    if (this.contain.Controls.Count > 0)
                    {
                        //Si hay items multiplico la altura de ellos por la cantidad que hay.
                        altoLista = this.itemButtonHeght * this.contain.Controls.Count;
                    }
                    else
                    {
                        //Si no hay items seteo el Heigth con el del combo a la hora de crearlo.
                        altoLista = this.firstHeight;
                    }

                    this.lista.Height = altoLista; //Asigno el alto al contenedor.
                    //Como la lista se encuentra abajo del combo debo moverla hacia arriba tanto como la 
                    //haya hecho crecer en alto.
                    this.lista.Top = this.lista.Top - this.lista.Height;
                    //Sumo a la altura del combo la altura de la lista.
                    this.Height = this.firstHeight + altoLista;

                    //Seteo la variable bandera para saber que está desplegado.
                    this.desplegado = true;
                }
                else
                {
                    //Si está desplegado lo debo replegar.
                    this.Height = this.firstHeight;
                    this.lista.Height = 0;
                    this.lista.Top = this.Height;
                    this.desplegado = false;
                }
            }else if (desplegado)
            {
                //Si no fue llamado por un evento click pregunto solamente si está desplegado.
                //En este caso solo repliego.
                this.Height = this.firstHeight;
                this.lista.Height = 0;
                this.lista.Top = this.Height;
                this.desplegado = false;
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
        public void SelectItem(int index)
        {
            this.lblItemText.Text = this.Items[index].Text; //Paso el texto al Label que lo muestra.
            this.itemSelected = this.Items[index]; //Guaro el item seleccionado.
            ComboBox_MouseClick(null, null); //Ejecuto el evento Clic del combo.
            if (this.ItemSelectedChange != null) this.ItemSelectedChange(null, null); //Disparo el Handler si este no es null.
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

            //Llamo al método desplegar. Le paso como parámetro 'false' para indicarle que no lo llamo
            //desde un evento clic. De esa manera me aseguro que solo si se encuentra desplegado, se va
            //a replegar.
            _desplegar(false);
        }

        private void ComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            //Cuando hago clic con el mouse, hago que el combo tome foco.
            this.Focus();
            //Llamo al método desplegar. Le indico por parámetro que se llama desde un evento clic.
            _desplegar(true);
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

    public class ItemButton : Button
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

            //Acomodo la fuente.
            this.Font = new Font("Century Gothic", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.FromArgb(0, 137, 132);
            this.TextAlign = ContentAlignment.MiddleLeft;

            //Le asigno el evento Mouse Click.
            this.MouseClick += ItemButton_MouseClick;
        }

        private void ItemButton_MouseClick(object sender, MouseEventArgs e)
        {
            //Selecciono el Item del Combo de acuerdo al Value del Combo.
            this.combo.SelectItem(this.Value);
        }
    }
}
