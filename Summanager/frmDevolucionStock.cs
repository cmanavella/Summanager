using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Summanager
{
    public partial class frmDevolucionStock : Summanager.FrmAbmStock
    {
        public frmDevolucionStock()
        {
            InitializeComponent();

            this.lblTitulo.Text = "Devolución de Stock";
        }

        private void frmDevolucionStock_Shown(object sender, EventArgs e)
        {
            this.dgv.Columns["Nombre"].Width -= 12;
            this.dgv.Columns["Fallado"].Width += 12;
            this.dgv.Columns["Fallado"].Visible = true;
        }
    }
}
