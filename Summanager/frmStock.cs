using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Data;

namespace Summanager
{
    public partial class FrmStock : Summanager.FrmContenido
    {
        private List<Suministro> suministros;

        public FrmStock()
        {
            InitializeComponent();

            try
            {
                this.suministros = DBSuministros.GetSuministro();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmStock_Shown(object sender, EventArgs e)
        {
            foreach(var suministro in this.suministros)
            {
                this.label1.Text += "'Código' = " + suministro.Codigo + "; 'Nombre' = " + suministro.Nombre + "; 'Tipo' = " + suministro.Tipo.Nombre + 
                    "; 'Compatible con' = ";

                foreach(var modelo in suministro.Modelos)
                {
                    this.label1.Text += modelo.Nombre + ", ";
                }

                this.label1.Text += "\n";
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevoSuministro nuevoSuministro = new FrmNuevoSuministro("Nuevo Suministro");
            nuevoSuministro.ShowDialog();
        }

        private void btnHola_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hola");
        }
    }
}
