using Entities;
using IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Summanager
{
	public partial class FrmCargando : Form
	{
		private int procesado;
		private string currentIp;
		private int seg;
		private int min;
		private int segEst;
		private int minEst;
		private int tiempo;
		private List<Printer> PrintersScrapped;
		private IWebDriver webDriver;

		public List<Printer> PrintersPassed { get; set; }

		public FrmCargando(): this(null) { }

		public FrmCargando(List<Printer> printers)
		{
			InitializeComponent();
			this.procesado = 0;
			this.PrintersPassed = printers.ToList();
			this.PrintersScrapped = new List<Printer>();
			this.tiempo = 1;
			this.segEst = 0;
			this.minEst = 0;
        }

		private void FrmCargando_Shown(object sender, EventArgs e)
		{
			//En esta parte cargo el driver de Chrome de Selenium con sus opciones de ejecución para luego pasarlo a la 
			//clase WebScrapping que los usa para analizar, de momento, a las impresoras Lexmark MS622.

			//Primero configuro el Chrome Browser, que se usa para revisar las impresoras, para que no se vea.
			ChromeOptions options = new ChromeOptions();
			options.AddArgument("--headless");
			//Luego configuro el CMD del Selenium para que tampoco se vea.
			var chromeDriverService = ChromeDriverService.CreateDefaultService();
			chromeDriverService.HideCommandPromptWindow = true;
			//Abro el driver y el browser y los dejo listos para ser usados.
			this.webDriver = new ChromeDriver(chromeDriverService, options);

			//Si el BackGround Worker no está ocupado lo pongo a funcionar.
			if (!worker.IsBusy) worker.RunWorkerAsync();
		}

        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
			//Dentro del BGW proceso cada uno de los ips de las impresoras pasadas al llamar al formulario.
			foreach (Printer printer in this.PrintersPassed)
			{
				//Pregunto en cada iteración si se ha llamado a la cancelación del BGW.
                if (worker.CancellationPending)
                {
					e.Cancel = true;
					break;
                }

				//Variable que uso para contar la cantidad de impresoras que ya llevo procesadas.
				//De esta manera puedo visualizarlas con el Timer y calcular tiempo estimado. Acá la aumento.
				this.procesado++; 
				this.currentIp = printer.Ip; //Almaceno la Ip que se está procesando para usarla también con el Timer.

				//Paso a la instancia del Objeto WebScrapping el driver de Selenium que necesita para analizar.
                WebScraping webScrap = new WebScraping(this.webDriver);

                try
                {
                    //Intento leer el Ip de la impresora. Si puedo, guardo esa Impresora para almacenarla
                    //posteriormente en una Lista.
                    Printer printerScrapped = webScrap.readIp(printer.Ip);

					//Como la técnica que uso no devuelve el Ip analizado y el estado de la impresora es una
					//concepción puramente mía, cargo estos dos datos de forma manual.
					printerScrapped.Ip = printer.Ip;
					printerScrapped.Estado = "Online";
					printerScrapped.Oficina = printer.Oficina;

					//Agrego la impresora a una Lista de Impresoras distinta a la que le pasé al Form.
					//De esta manera no altero la Lista original.
					this.PrintersScrapped.Add(printerScrapped);
                }
                catch (Exception)
                {
                    //Si no puede leer la Ip la Impresora está Offline. Asique seteo los valores manualmente.
                    Printer printerScrapped = new Printer();
                    printerScrapped.Ip = printer.Ip;
                    printerScrapped.Estado = "Offline";
                    printerScrapped.Modelo = null;
                    printerScrapped.Oficina = printer.Oficina;
                    printerScrapped.Toner = null;
                    printerScrapped.UImagen = null;
                    printerScrapped.KitMant = null;
                    this.PrintersScrapped.Add(printerScrapped);
				}

                //Le digo al BGW que reporte el progreso, pasándole el porcentaje de lo procesado con cada Impresora
                //analizada.
                this.worker.ReportProgress(this.procesado * 100 / this.PrintersPassed.Count);
			}
			this.webDriver.Close();
			this.webDriver.Quit();

			//Cargo a la Lista de Impresoras pasadas la Lista de Impresoras analizadas.
			PrintersPassed.Clear();
			PrintersPassed = PrintersScrapped;
		}

        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
			//Cada vez que se le avisa al BGW que el progreso ha cambiado cambio el valor del ProgressBar, de la
			//etiqueta que uso para mostrar lo analizado y de la etiqueta que uso para mostrar el porcentaje.
			this.progressBar1.Value = e.ProgressPercentage;
			this.lblAnalizando.Text = "Analizando Ip: " + this.currentIp + " (" + this.procesado + "/" + this.PrintersPassed.Count + ")";
			this.lblPorcentaje.Text = e.ProgressPercentage.ToString() + "%";
		}

        private void worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
			//Cuando el BGW termina, cierro el Form.
			this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
			//Con cada segundo que pasa hago todo lo siguiente.

			//Aumento la variable tiempo en 1. Esta variable la uso como tiempo transcurrido generar para calcular
			//la velocidad de procesamiento.
			this.tiempo++;
			this.seg++; //Aumento la variable segundos en 1.
			//Pregunto si ha llegado a 60. Si lo hace, la reinicio en 0 y aumento la variable minutos en 1.
            if (this.seg == 60)
            {
				this.min++;
				this.seg = 0;
            }
			//Muestro el tiempo transcurrido con las variables anteriores.
			this.lblTranscurrido.Text = "Tiempo Transcurrido: " + this.min.ToString("00") + ":" + this.seg.ToString("00");

			//Velocidad de procesamiento. La calculo en base a lo procesado sobre el tiempo transcurrido.
			double velocidad = (double)this.procesado / (double)this.tiempo;

			//Necesito saber cuántas impresoras me faltan de procesar para obtener un tiempo estimado.
			double restantes = this.PrintersPassed.Count - this.procesado;

			segEst = (int)(restantes / velocidad); //Almaceno los segundos totales estimados.
			minEst = segEst / 60; //En base a esos segundo calculo los minutos estimados.
			segEst = segEst - (minEst * 60); //Almaceno los segundos que sobran

			//Muestro el tiempo estimado-
			this.lblEstimado.Text = "Tiempo Estimado: " + this.minEst.ToString("00") + ":" + this.segEst.ToString("00");
		}

        private void btnDetener_Click(object sender, EventArgs e)
        {
			this.label1.Text = "Deteniendo...";
			//Detiene el análisis.
			worker.CancelAsync();
        }
    }
}
