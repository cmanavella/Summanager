using Entities;
using IO;
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
		private int procesado;
		private List<string> ips;
		private string currentIp;
		private int seg;
		private int min;
		private int segEst;
		private int minEst;
		private int tiempo;
		private int procesadoAnterior;

		public List<Printer> Printers { get; set; }

		public frmCargando(List<string> ips)
		{
			InitializeComponent();
			this.ips = ips;
			this.procesado = 0;
			this.Printers = new List<Printer>();
			this.tiempo = 0;
			this.segEst = 0;
			this.minEst = 0;
			this.procesadoAnterior = 0;
		}

        private void frmCargando_Load(object sender, EventArgs e)
        {
			if (!worker.IsBusy) worker.RunWorkerAsync();
        }

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
			foreach (string ip in this.ips)
			{
                if (worker.CancellationPending)
                {
					e.Cancel = true;
					break;
                }

				this.procesado++;
				this.currentIp = ip;

                WebScraping webScrap = new WebScraping();

				try
				{
					Printer printer = webScrap.readIp(ip);
					printer.Ip = ip;
					printer.Estado = "Online";
					this.Printers.Add(printer);
				}
				catch (Exception ex)
				{
					Printer printer = new Printer();
					printer.Ip = ip;
					printer.Estado = "Offline";
					printer.Modelo = null;
					printer.Toner = null;
					printer.UImagen = null;
					printer.KitMant = null;
					this.Printers.Add(printer);
				}
				this.worker.ReportProgress(this.procesado * 100 / this.ips.Count);
			}
		}

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
			this.progressBar1.Value = e.ProgressPercentage;
			this.lblAnalizando.Text = "Analizando Ip: " + this.currentIp + " (" + this.procesado + "/" + this.ips.Count + ")";
			this.lblPorcentaje.Text = e.ProgressPercentage.ToString() + "%";
		}

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
			this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
			this.seg++;
            if (this.seg == 60)
            {
				this.min++;
				this.seg = 0;
            }
			this.lblTranscurrido.Text = "Tiempo Transcurrido: " + this.min.ToString("00") + ":" + this.seg.ToString("00");

			double velocidad = this.procesado - this.procesadoAnterior;

            if (velocidad > 0)
            {
				this.tiempo = 0;
            }
            else
            {
				this.tiempo++;
				velocidad = 1d / this.tiempo;
            }

			double restantes = this.ips.Count - this.procesado;

			segEst = (int)(restantes * velocidad);
			minEst = segEst / 60;
			segEst = segEst - (minEst * 60);

			this.lblEstimado.Text = "Tiempo Estimado: " + this.minEst.ToString("00") + ":" + this.segEst.ToString("00");
			this.procesadoAnterior = this.procesado;
		}

        private void btnDetener_Click(object sender, EventArgs e)
        {
			worker.CancelAsync();
        }
    }
}
