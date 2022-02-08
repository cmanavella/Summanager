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

            this.suministros = DBSuministros.GetSuministros();
        }

        private void FrmStock_Shown(object sender, EventArgs e)
        {
            foreach(var suministro in this.suministros)
            {
                this.label1.Text += "'Código' = " + suministro.Codigo + "; 'Nombre' = " + suministro.Nombre + "\n";
            }
        }
    }
}
