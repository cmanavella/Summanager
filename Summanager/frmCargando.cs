using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summanager
{
	public partial class frmCargando : Form
	{
		private int total;
		private int porcentaje;
		private int procesado;

		public frmCargando(int total)
		{
			InitializeComponent();
			this.total = total;
			this.porcentaje = 0;
			this.procesado = 0;
		}

		public void Progress(string ip)
		{
			this.procesado++;
			//this.lblAnalizando.Invoke(new MethodInvoker(() =>
			//{
			//	this.lblAnalizando.Text = "Analizando Ip: " + ip + "(" + this.procesado.ToString() + "/" + this.total.ToString() + ")";
			//}));

			this.porcentaje = this.procesado * 100 / this.total;
			this.lblPorcentaje.Invoke(new MethodInvoker(() =>
			{
				this.lblPorcentaje.Text = this.porcentaje.ToString() + "%";
			}));
			
			this.progressBar1.Invoke(new MethodInvoker(() =>
			{
				this.progressBar1.Value = this.porcentaje;
			}));
		}
	}
}
