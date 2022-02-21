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
    public partial class FrmIngresoStock : Summanager.FrmAbmStock
    {
        public FrmIngresoStock()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Recorro el DataGridView si este no está vacío.
            if (this.dgv.Rows.Count > 0)
            {
                //Creo una Lista de Stocks para pasar por parámetro al Método Add de DBStocks.
                List<Stock> stocks = new List<Stock>();

                //Uso Try para capturar cualquier error que ocurra.
                try
                {
                    //Recorro el DataGridView fila por fila.
                    foreach (DataGridViewRow fila in this.dgv.Rows)
                    {
                        //Traigo de la Base de Datos un Suministro en base al Código de Suministro almacenado en la Fila actual.
                        Suministro suministro = DBSuministros.GetSuministro(Convert.ToInt64(fila.Cells["Codigo"].Value.ToString()));
                        //Paso del DataGridView la Cantidad de Alta del Stock en cuestión a una variable para su mejor manejo.
                        int alta = Convert.ToInt32(fila.Cells["Cantidad"].Value.ToString());
                        //Creo un elemento Stock y lo cargo con el Suministro y la Cantidad de Alta a pasar. Las demás cantidades las paso en 0.
                        Stock stock = new Stock(suministro, alta, 0, 0);

                        //Agrego ese Stock a la Lista de Stocks a pasar a la Base de Datos.
                        stocks.Add(stock);
                    }

                    //Una vez creada la Lista de Socks, la paso a la Base de Datos para que se actualice en ella. Paso como parámetro que esta Adición es para
                    //la Cantidad de Alta solamente.
                    DBStock.AddStock(stocks, Stock.ESTADO.ALTA);

                    //Muestro mensaje de éxito.
                    MessageBox.Show("Datos guardados con éxito.", Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Cierro el Formulario.
                    this.Close();
                }
                catch (Exception ex)
                {
                    //Si ocurrió algún error, lo muestro.
                    MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
