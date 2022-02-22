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
            //Borro el DataGridView
            this.dgv.Rows.Clear();
            this.dgv.Refresh();

            //Uso el Try por si ocurre algún error.
            try
            {
                //Traigo los Stocks de la Base de Datos y los almaceno en una variable del Formulario.
                this.stock = DBStock.GetStock();

                //Si el resultado de la búsqueda no es Null, oculto el Mensaje de Falta de Stock y cargo los Stocks traidos de la Base de Datos en el
                //DataGridView. Caso contrario, lo muestro.
                if (this.stock != null)
                {
                    this.lblMsjeStock.Visible = false;

                    //Recorro los Stocks y los cargo en el DataGridView.
                    foreach (Stock stock in this.stock)
                    {
                        this.dgv.Rows.Add(stock.Suministro.Codigo.ToString(), stock.Suministro.Tipo.Nombre, stock.Suministro.Nombre, stock.Alta.ToString(),
                            stock.Baja.ToString(), stock.Fallado.ToString(), stock.Suministro.GetModelosToString());
                    }
                }
                else
                {
                    this.lblMsjeStock.Visible = true;
                }
            }
            catch (Exception ex)
            {
                //Si hubo un error lo muestro.
                MessageBox.Show(ex.Message, Application.ProductName + " " + Application.ProductVersion,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void FrmStock_Shown(object sender, EventArgs e)
        {
            //Actaulizo el DataGridView al mostrar el Formulario.
            ActualizarStock();
        }

        private void btnIngreso_Click(object sender, EventArgs e)
        {
            //Creo y muestro como Dialog un nuevo Formulario de Ingreso de Stock que me permite solo cargar la cantidad de Alta de los Stocks especificados.
            FrmIngresoStock frmIngreso = new FrmIngresoStock();
            frmIngreso.ShowDialog();

            //Una vez que el Formulario se cierra, actualizo el DataGridView.
            ActualizarStock();
        }

        private void btnNuevoSuministro_Enter(object sender, EventArgs e)
        {
            FrmNuevoSuministro nuevoSuministro = new FrmNuevoSuministro();
            nuevoSuministro.ShowDialog();
        }

        private void dgv_Resize(object sender, EventArgs e)
        {
            //Agrando la Columna Nombre del DataGridView cuando este cambia su tamaño.
            this.dgv.Columns["Nombre"].Width = this.dgv.Width - 836;

            //Debo colocar los Botones Entrega y Devolución en la mitad de la pantalla.
            //Almaceno la cantidad de Píxeles que separan a los botones. Para ello, substraigo a la Posición en X del Botón Devolución la suma de la 
            //Posición en X del Botón Entrega sumado a su Ancho.
            int separador = this.btnDevolucion.Location.X - (this.btnEntrega.Location.X + this.btnEntrega.Width);
            //Calculo el Ancho Total de los dos Botones y el espacio que lo separa.
            int widthTotal = this.btnEntrega.Width + separador + this.btnDevolucion.Width;
            //Calculo el Punto Medio del Formulario.
            int middleForm = this.Width / 2;
            //Seteo la Posición en X del Botón Entrega substrayendo al valor de la Mitad de Formulario el valor de la Mitad de los Botones.
            this.btnEntrega.Location = new Point((middleForm - widthTotal / 2), this.btnEntrega.Location.Y);
            //Seteo la Posición en X del Botón Devolución sumando la Posición en X del Botón Entrega, su Ancho y el Ancho del Espacio que los separa.
            this.btnDevolucion.Location = new Point((this.btnEntrega.Location.X + this.btnEntrega.Width + separador), this.btnDevolucion.Location.Y);
        }

        private void btnDevolucion_Click(object sender, EventArgs e)
        {
            frmDevolucionStock devolucionStock = new frmDevolucionStock();
            devolucionStock.ShowDialog();
            ActualizarStock();
        }

        private void btnEntrega_Click(object sender, EventArgs e)
        {
            FrmEntregarStock entregarStock = new FrmEntregarStock();
            entregarStock.ShowDialog();
            ActualizarStock();
        }
    }
}
