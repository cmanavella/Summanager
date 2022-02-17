using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomControls
{
    public partial class MenuButton : UserControl
    {
        private List<ItemMenuButton> items;
        private Container container;
        private bool containerDesplegado;
        private Point containerLocation;

        public MenuButton()
        {
            InitializeComponent();

            //Esta es la Lista donde se cargan los botones embebidos en el Menú.
            this.items = new List<ItemMenuButton>();
            //Este es contenedor de los botones. Sería lo que se despliega.
            this.container = new Container(this);
            //Esta bandera la uso para saber si el Menú está desplegado o no.
            this.containerDesplegado = false;
        }

        /// <summary>
        /// Representa la colección de botones dentro del elemento.
        /// </summary>
        [EditorAttribute(typeof(CollectionEditor), typeof(UITypeEditor))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public List<ItemMenuButton> Items
        {
            get
            {
                return this.items;
            }
            set
            {
                this.items = value;
            }
        }

        /// <summary>
        /// Texto que mostrará el control.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text
        {
            get
            {
                return this.button1.Text;
            }
            set
            {
                this.button1.Text = value;
            }
        }

        /// <summary>
        /// Imagen que mostrará el control.
        /// </summary>
        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public Image Image
        {
            get
            {
                return this.button1.Image;
            }
            set
            {
                this.button1.Image = value;
            }
        }

        /// <summary>
        /// Bandera que identifica si el contenedor de los botones dentro del control se encuentra desplegado o no.
        /// </summary>
        public bool ContainerDesplegado
        {
            get
            {
                return this.containerDesplegado;
            }
            set
            {
                this.containerDesplegado = value;
            }
        }

        /// <summary>
        /// Despliega el contenedor de los botones del control.
        /// </summary>
        public void Desplegar()
        {
            //Primero me aseguro que haya Ítems (Botones) cargados en el Menú para desplegar su contenedor.
            if (this.items.Count > 0)
            {
                //Limpio todos los controles que ya tenga el contenedor.
                this.container.Controls.Clear();
                //Agrego el panel superior del contenedor, que tiene la funcionalidad de replegarlo. Lo agrego sí o sí ya que al quitar todos 
                //controles, también quito el panel superior y es menester para el correcto funcionamiento del contenedor.
                this.container.AgregarPanelSuperior();
                //Agrego los bordes.
                this.container.AgregarBordes();

                //Recorro todos los Ítems cargados en el Menú y los agrego al contenedor. Como por defecto tienen la propiedad Dock seteada en Top, debo
                //ponerlos al frente de todo a medida que los agrego.
                foreach (ItemMenuButton button in this.items)
                {
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
                //Pongo la bandera que me indica si el contenedor está desplegado en True.
                containerDesplegado = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Al hacer clic en el Menú necesito que se despliegue el contenedor. Pero antes debo calcular la pocisión exacta para ubicarlo.
            //Para ello, transformo el Objeto Sender en un Control.
            Control control = (Control)sender;
            //Luego calculo la posición del Contenedor en base a la posición relativa que ocupa el Menú en la pantalla.
            this.containerLocation = control.PointToScreen(control.Location);

            //Despliego el Contenedor.
            Desplegar();
        }
    }

    /// <summary>
    /// Control que contiene los botones de un control Menú. Por defecto está oculto pero se despliega y pliega al hacer clic en el Menú.
    /// </summary>
    public class Container : Form
    {
        private MenuButton menu;
        private Panel panelSuperior;
        private Panel panelHand;
        private Panel bordeDerecho;
        private Panel bordeInferior;

        /// <summary>
        /// Constructor de la clase Container.
        /// </summary>
        /// <param name="menu">Control Menú que lo contiene.</param>
        public Container(MenuButton menu)
        {
            //Paso el Menú del parámetro a la variable del contenedor.
            this.menu = menu;

            //Creo un panel superior.
            this.panelSuperior = new Panel();
            //Creo el panel Hand que se va a encontrar dentro del Panel Superior a su izquierda.
            //Tiene la función de simplemente modificar el cursor del mouse a hand.
            this.panelHand = new Panel();

            //Creo los Paneles Bordes.
            this.bordeDerecho = new Panel();
            this.bordeInferior = new Panel();

            //Al ser un Form necesito setearlo.
            //Le doy un ancho de 150px.
            this.Width = 150;
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

        }

        /// <summary>
        /// Devuelve la altura del contenedor en base a la cantidad de elementos que contenga.
        /// </summary>
        public void SetHeight()
        {
            //Ingreso la altura del Panel Superior.
            int height = this.panelSuperior.Height;

            //Recorro todos los controles cargados en el contenedor, que no sean del tipo Panel, y voy sumando su altura.
            foreach(Control control in this.Controls)
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
            this.panelSuperior.Height = this.menu.Height;
            this.panelSuperior.Dock = DockStyle.Top;
            this.Controls.Add(this.panelSuperior);
            this.panelSuperior.BringToFront();

            //Seteo el panel hand. Es importante que el ancho de este panel sea del ancho del Menú que lo contiene para simular, al pasar el mouse por
            //encima o al hacer clic, que uno está actuando sobre el Menú.
            this.panelHand.Width = this.menu.Width;
            this.panelHand.Dock = DockStyle.Left;
            this.panelHand.Cursor = Cursors.Hand;
            this.panelHand.BringToFront();

            //Agrego el Panel Hand al Panel Superior.
            this.panelSuperior.Controls.Add(this.panelHand);
        }

        /// <summary>
        /// Agrega los bordes al contenedor.
        /// </summary>
        public void AgregarBordes()
        {
            this.bordeDerecho.Width = 2;
            this.bordeDerecho.BackColor = Color.FromArgb(60, 113, 170);
            this.bordeDerecho.Dock = DockStyle.Right;
            this.Controls.Add(this.bordeDerecho);
            this.bordeDerecho.BringToFront();

            this.bordeInferior.Height = 2;
            this.bordeInferior.BackColor = Color.FromArgb(60, 113, 170);
            this.bordeInferior.Dock = DockStyle.Bottom;
            this.Controls.Add(this.bordeInferior);
            this.bordeInferior.BringToFront();
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
    }

    //Debo serializar la clase, para que al agregar un Item desde la vista de diseño no haya problemas con el constructor.
    [Serializable]
    public class ItemMenuButton : System.Windows.Forms.Button
    {
        public ItemMenuButton()
        {
            //Lo establesco como Flat sin bordes.
            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            //Seteo el cursor usado al pasar el mouse encima.
            this.Cursor = Cursors.Hand;

            this.TabStop = false;
            this.Dock = DockStyle.Top;

            //Acomodo la fuente.
            this.Font = new Font("Century Gothic", 9.75F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.White;
            this.BackColor = Color.FromArgb(114, 159, 206);
            this.TextAlign = ContentAlignment.MiddleLeft;
        }
    }
}
