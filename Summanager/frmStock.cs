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
        private List<Stock> stock;

        public FrmStock()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Busca en la Base de Datos el Stock de todos los Suministros y lo muestra en el DataGridView.
        /// </summary>
        private void ActualizarStock()
        {
            try
            {
                this.stock = DBStock.GetStock();

                if (this.stock != null)
                {
                    this.lblMsjeStock.Visible = false;
                }
                else
                {
                    this.lblMsjeStock.Visible = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void FrmStock_Shown(object sender, EventArgs e)
        {
            ActualizarStock();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            FrmIngresoStock frmIngreso = new FrmIngresoStock();
            frmIngreso.ShowDialog();
        }

        private void btnNuevoSuministro_Enter(object sender, EventArgs e)
        {
            FrmNuevoSuministro nuevoSuministro = new FrmNuevoSuministro("Nuevo Suministro");
            nuevoSuministro.ShowDialog();
        }
    }
}
