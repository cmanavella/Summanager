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

        public void Desplegar()
        {
            if (!containerDesplegado)
            {
                this.container.Controls.Clear();

                foreach(ItemMenuButton button in this.items)
                {
                    this.container.Controls.Add(button);
                }

                this.container.Show();
                containerDesplegado = true;
            }
        }

        public void Plegar()
        {
            if (containerDesplegado)
            {
                this.container.Hide();
                this.containerDesplegado = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Desplegar();
        }
    }

    public class Container : Form
    {
        private MenuButton menu;
        public Container(MenuButton menu)
        {
            this.Size = new Size(200, 200);
            this.FormBorderStyle = FormBorderStyle.None;
            this.BackColor = Color.FromArgb(114, 159, 206);
            this.ShowInTaskbar = false;

            this.menu = menu;

            this.Deactivate += Container_Deactivate;
        }

        private void Container_Deactivate(object sender, EventArgs e)
        {
            this.menu.Plegar();
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
