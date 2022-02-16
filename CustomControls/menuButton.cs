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
        private bool clickOutBound;
        private bool clickOnMenu;
        private bool ejecutoClick;

        public MenuButton()
        {
            InitializeComponent();
            this.items = new List<ItemMenuButton>();
            this.container = new Container(this);
            this.containerDesplegado = false;
            this.clickOutBound = false;
            this.clickOnMenu = false;
            this.ejecutoClick = true;
        }

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

        public bool ClickOutBound
        {
            get
            {
                return this.clickOutBound;
            }
            set
            {
                this.clickOutBound = value;
            }
        }

        public void Desplegar()
        {
            this.container.Controls.Clear();

            foreach (ItemMenuButton button in this.items)
            {
                this.container.Controls.Add(button);
                button.BringToFront();
            }

            this.container.BringToFront();
            this.container.Show();
            this.container.Location = this.containerLocation;
            containerDesplegado = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            this.containerLocation = control.PointToScreen(control.Location);
            //this.containerLocation.Y += control.Height;

            Desplegar();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            
        }
    }

    public class Container : Form
    {
        private MenuButton menu;
        private Panel panelSuperior;
        private Panel panelHand;

        public Container(MenuButton menu)
        {
            this.menu = menu;

            this.panelSuperior = new Panel();
            this.panelHand = new Panel();

            this.Size = new Size(200, 200);
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;
            this.ShowInTaskbar = false;

            this.Deactivate += Container_Deactivate;
            this.Shown += Container_Shown;

            this.panelHand.Click += Panel_Hand_Click;
            this.panelSuperior.Click += Panel_Superior_Click;

        }

        private void Panel_Superior_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Panel_Hand_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Container_Shown(object sender, EventArgs e)
        {
            this.panelSuperior.Height = this.menu.Height;
            this.panelSuperior.Dock = DockStyle.Top;
            this.Controls.Add(panelSuperior);


            this.panelHand.Width = this.menu.Width;
            this.panelHand.Dock = DockStyle.Left;
            this.panelHand.Cursor = Cursors.Hand;

            this.panelSuperior.Controls.Add(panelHand);
        }

        private void Container_Deactivate(object sender, EventArgs e)
        {
            this.Hide();
        }
    }

    [Serializable]
    public class ItemMenuButton : Button
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

            //Le asigno el evento Mouse Click.
            //this.Click += ItemMenuButton_Click;
        }

        //private void ItemMenuButton_Click(object sender, EventArgs e)
        //{
        //    this.OnClick(e);
        //}
    }
}
