using Data;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Summanager
{
    public partial class FrmEnviarStock : Summanager.FrmAbmStock
    {
        public FrmEnviarStock()
        {
            InitializeComponent();

            this.lblTitulo.Text = "Enviar Stock";

            //Seteo estas banderas del Form Padre para que este haga las validaciones correspondientes.
            base.ValidoCantidadBaja = true;
            base.ValidoCantidadFallado = true;
        }

        private void FrmEnviarStock_Shown(object sender, EventArgs e)
        {
            //Cuando se muestra el Form dimensiono el DataGridView.
            this.dgv.Columns["Nombre"].Width -= 12;
            this.dgv.Columns["Fallado"].Width += 12;
            this.dgv.Columns["Fallado"].Visible = true;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            //Debo instanciar dos Listas de Stocks para sustraer de la Base de Datos. Una para los Suministros De Baja y otra para los Fallados.
            List<Stock> stockDeBaja = new List<Stock>();
            List<Stock> stockFallados = new List<Stock>();

            //Me fijo que el DataGridView no esté vacío.
            if (this.dgv.Rows.Count > 0)
            {
                //Uso Try para capturar cualquier error que ocurra.
                try
                {
                    //Recorro el DataGridView fila por fila.
                    foreach (DataGridViewRow fila in this.dgv.Rows)
                    {
                        //Traigo de la Base de Datos un Suministro en base al Código de Suministro almacenado en la Fila actual.
                        Suministro suministro = DBSuministros.GetSuministro(Convert.ToInt64(fila.Cells["Codigo"].Value.ToString()));
                        //Paso del DataGridView la Cantidad a modificar del Stock en cuestión a una variable para su mejor manejo.
                        int cantidad = Convert.ToInt32(fila.Cells["Cantidad"].Value.ToString());

                        //Instancio un objeto Stock vacío.
                        Stock stock = new Stock();
                        //Le paso el Suministro a ese Stock.
                        stock.Suministro = suministro;

                        //Pregunto si ese Stock está fallado o no. En base a eso, cargo la instancia de Stock con la Cantidad. Si es Fallado, dicha cantidad
                        //la paso a Fallado del elemento Stock, sino paso esa cantidad a la Propiedad Baja del mismo.
                        if (fila.Cells["Fallado"].Value.ToString() == "No")
                        {
                            stock.Baja = cantidad;

                            //Agrego este Stock a la Lista de Stocks de Baja.
                            stockDeBaja.Add(stock);
                        }
                        else
                        {
                            stock.Fallado = cantidad;

                            //Agrego este Stock a la Lista de Stocks Fallados.
                            stockFallados.Add(stock);
                        }
                    }

                    //Una vez creadas las Listas las paso a la Base de Datos si no están vacías.
                    if (stockDeBaja.Count > 0) DBStock.SubstractStock(stockDeBaja, Stock.ESTADO.BAJA);
                    if (stockFallados.Count > 0) DBStock.SubstractStock(stockFallados, Stock.ESTADO.FALLADO);

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
