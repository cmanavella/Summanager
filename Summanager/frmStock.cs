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
        }

        private void btnNuevoSuministro_Click(object sender, EventArgs e)
        {
            FrmNuevoSuministro nuevoSuministro = new FrmNuevoSuministro("Nuevo Suministro");
            nuevoSuministro.ShowDialog();
        }
    }
}
