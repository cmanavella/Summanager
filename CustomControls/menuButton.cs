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
            this.items = new List<ItemMenuButton>();
            this.container = new Container(this);
            this.containerDesplegado = false;
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

        public void Desplegar()
        {
            this.container.Controls.Clear();
            this.container.AgregarPanelSuperior();

            foreach (ItemMenuButton button in this.items)
            {
                this.container.Controls.Add(button);
                button.BringToFront();
            }

            this.container.SetHeight();
            this.container.BringToFront();
            this.container.Show();
            this.container.Location = this.containerLocation;
            containerDesplegado = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Control control = (Control)sender;
            this.containerLocation = control.PointToScreen(control.Location);

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

            this.Width = 150;
            this.FormBorderStyle = FormBorderStyle.None;
            this.TransparencyKey = Color.Red;
            this.BackColor = Color.Red;
            this.ShowInTaskbar = false;

            this.Deactivate += Container_Deactivate;

            this.panelHand.Click += Panel_Hand_Click;
            this.panelSuperior.Click += Panel_Superior_Click;

        }

        public void SetHeight()
        {
            int height = 0;

            foreach(Control control in this.Controls)
            {
                height += control.Height;
            }

            this.Height = height;
        }

        public void AgregarPanelSuperior()
        {
            this.panelSuperior.Height = this.menu.Height;
            this.panelSuperior.Dock = DockStyle.Top;
            this.Controls.Add(panelSuperior);
            this.panelSuperior.BringToFront();

            this.panelHand.Width = this.menu.Width;
            this.panelHand.Dock = DockStyle.Left;
            this.panelHand.Cursor = Cursors.Hand;
            this.panelHand.BringToFront();

            this.panelSuperior.Controls.Add(panelHand);
        }

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
        }
    }
}
