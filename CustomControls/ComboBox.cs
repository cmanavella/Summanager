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

        public List<Item> Items { get; }

        public ComboBox()
        {
            InitializeComponent();
            this.colorFocused = Color.FromArgb(0, 137, 132);
            this.colorUnfocused = Color.Gray;
            this.desplegado = false;
            this.Items = new List<Item>();

            this.firstHeight = this.Height;
            this.itemButtonHeght = 25;

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

            //this.lista.MouseClick 
        }

        private void _addItemButton(Item item)
        {
            ItemButton boton = new ItemButton(this);
            boton.Value = item.Value;
            boton.Text = item.Text;

            boton.Width = this.contain.Width;
            boton.Height = this.itemButtonHeght;
            boton.Dock = DockStyle.Top;
            
            this.contain.Controls.Add(boton);
            this.contain.Controls.SetChildIndex(boton, 0);
        }

        private void _desplegar(bool esClic)
        {
            if (esClic)
            {
                if (!desplegado)
                {
                    this.contenedorCombo.Anchor = (AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right);
                    this.contenedorCombo.Left = 0;
                    this.contenedorCombo.Top = 0;

                    int altoLista;
                    if (this.contain.Controls.Count > 0)
                    {
                        altoLista = this.itemButtonHeght * this.contain.Controls.Count;
                    }
                    else
                    {
                        altoLista = this.firstHeight;
                    }

                    this.lista.Height = altoLista;
                    this.lista.Top = this.lista.Top - this.lista.Height;
                    this.Height = this.firstHeight + altoLista;

                    this.desplegado = true;
                }
                else
                {
                    this.Height = this.firstHeight;
                    this.lista.Height = 0;
                    this.lista.Top = this.Height;
                    this.desplegado = false;
                }
            }else if (desplegado)
            {
                this.Height = this.firstHeight;
                this.lista.Height = 0;
                this.lista.Top = this.Height;
                this.desplegado = false;
            }
        }

        public void Add(int value, string text)
        {
            Item item = new Item(value, text);
            this.Items.Add(item);
            _addItemButton(item);
            if (this.Items.Count > 0)
            {
                this.lblItemText.Text = this.Items[0].Text;
                this.itemSelected = this.Items[0];
            }
        }

        public Item SelectedItem()
        {
            return this.itemSelected;
        }

        public void SelectItem(int index)
        {
            this.lblItemText.Text = this.Items[index].Text;
            this.itemSelected = this.Items[index];
            ComboBox_MouseClick(null, null);
        }

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

        private void ComboBox_Enter(object sender, EventArgs e)
        {
            this.bordeInferior.BackColor = this.colorFocused;
            this.division.BackColor = this.colorFocused;
            this.icon.ForeColor = this.colorFocused;
            this.lblItemText.ForeColor = this.colorFocused;
        }

        private void ComboBox_Leave(object sender, EventArgs e)
        {
            this.bordeInferior.BackColor = this.colorUnfocused;
            this.division.BackColor = this.colorUnfocused;
            this.icon.ForeColor = this.colorUnfocused;
            this.lblItemText.ForeColor = this.colorUnfocused;
            _desplegar(false);
        }

        private void ComboBox_MouseClick(object sender, MouseEventArgs e)
        {
            this.Focus();
            _desplegar(true);
        }
    }

    public class Item
    {
        public int Value { get; }
        public string Text { get; }

        public Item():this(0, String.Empty) { } 

        public Item (int value, string text)
        {
            Value = value;
            Text = text;
        }

        public override string ToString()
        {
            return "{ Value: " + this.Value + "; Text: " + this.Text + " }";
        }
    }

    public class ItemButton : Button
    {
        private ComboBox combo;
        public int Value { get; set; }
        public ItemButton(ComboBox combo)
        {
            this.combo = combo;

            this.FlatStyle = FlatStyle.Flat;
            this.FlatAppearance.BorderSize = 0;
            this.Cursor = Cursors.Hand;

            this.Font = new Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = Color.FromArgb(0, 137, 132);
            this.TextAlign = ContentAlignment.MiddleLeft;

            this.MouseClick += ItemButton_MouseClick;
        }

        private void ItemButton_MouseClick(object sender, MouseEventArgs e)
        {
            this.combo.SelectItem(this.Value);
        }
    }
}
