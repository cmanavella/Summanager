using Entities;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.ObjectModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace IO
{
    public class WebScraping
    {
        private HtmlWeb web;
        private HtmlDocument doc;
        private string url;
        private Printer printer;
        private IWebDriver driver;

        public WebScraping(IWebDriver driver)
        {
            this.web = new HtmlWeb();
            this.doc = new HtmlDocument();
            this.url = "http://";
            this.printer = new Printer();
            this.driver = driver;
        }

        /// <summary>
        /// Leo el Ip de una Impresora, ingresando en su página HTML.
        /// </summary>
        /// <param name="ip"></param>
        /// <returns>Printer</returns>
        public Printer readIp(string ip)
        {
            //La variable url ya contiene la cadena 'http://' por lo que le concateno el ip.
            this.url += ip;

            //Pongo un TimeOut de 4 segundos para que no se demore tanto cuando la impresora es inaccesible.
            this.web.PreRequest = delegate (HttpWebRequest webRequest)
            {
                webRequest.Timeout = 4000;
                return true;
            };

            //Cargo la página HTML de la Impresora.
            this.doc = this.web.Load(this.url);

            //Almaceno el Title de la página HTML y lo uso como modelo de la Impresora.
            var title = this.doc.DocumentNode.SelectNodes("//title").FirstOrDefault();
            this.printer.Modelo = title.InnerHtml;

            //Según el modelo de la Impresora, llamo al método encargado de leer el resto de la información.
            switch (this.printer.Modelo)
            {
                case "Lexmark MS812":
                    _Lex812();
                    break;
                case "Lexmark MS610dn":
                    _Lex610();
                    break;
                case "Lexmark MS410dn":
                    _Lex410();
                    break;
                case "Lexmark MS622de":
                    _Lex622();
                    break;
                default:
                    throw new Exception();
            }
            return this.printer;
        }

        /// <summary>
        /// Obtiene la información del Estado de Suministros de la página HTML de una Impresora Lexmark MS410
        /// </summary>
        private void _Lex410()
        {
            this.url += Printer.L410_AFTER_URL;
            this.doc = this.web.Load(this.url);

            int contTablas = 0;
            foreach (var tabla in doc.DocumentNode.SelectNodes(Printer.L410_TABLE))
            {
                contTablas++;

                if (contTablas == (int)Printer.L410_NUM_TABLA.TONER)
                {
                    int contTr = 0;
                    foreach (var nodo in tabla.ChildNodes)
                    {
                        if (nodo.Name == "tr") contTr++;
                        if (contTr == (int)Printer.L410_NUM_TR.TONER)
                        {
                            string[] valor = nodo.InnerText.Split('~');
                            if (valor.Length > 1)
                            {
                                valor[1] = valor[1].Remove(valor[1].Length - 1);
                                this.printer.Toner = Int32.Parse(valor[1]);
                            }
                            else
                            {
                                valor = nodo.InnerText.Split(' ');
                                if (valor.Length > 1)
                                {
                                    valor[4] = valor[4].Remove(valor[4].Length - 1);
                                    this.printer.Toner = Int32.Parse(valor[4]);
                                }
                                else
                                {
                                    this.printer.Toner = 0;
                                }
                            }
                        }
                    }
                }
                if (contTablas == (int)Printer.L410_NUM_TABLA.UNIDAD_IMAGEN)
                {
                    int contTr = 0;
                    foreach (var nodo in tabla.ChildNodes)
                    {
                        if (nodo.Name == "tr") contTr++;
                        if (contTr == (int)Printer.L410_NUM_TR.UNIDAD_IMAGEN && nodo.Name == "tr")
                        {
                            string[] valor = nodo.InnerText.Split(':');
                            valor[1] = valor[1].Remove(valor[1].Length - 3);

                            this.printer.UImagen = Int32.Parse(valor[1]);
                        }
                        this.printer.KitMant = null;
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene la información del Estado de Suministros de la página HTML de una Impresora Lexmark MS610
        /// </summary>
        private void _Lex610()
        {
            this.url += Printer.L610_AFTER_URL;
            this.doc = this.web.Load(this.url);

            int contTablas = 0;
            foreach (var tabla in doc.DocumentNode.SelectNodes(Printer.L610_TABLE))
            {
                contTablas++;
                if (contTablas == (int)Printer.L610_NUM_TABLA.TONER)
                {
                    int contTr = 0;
                    foreach (var nodo in tabla.ChildNodes)
                    {
                        if (nodo.Name == "tr") contTr++;
                        if (contTr == (int)Printer.L610_NUM_TR.TONER)
                        {
                            string[] valor = nodo.InnerText.Split('~');
                            if (valor.Length > 1)
                            {
                                valor[1] = valor[1].Remove(valor[1].Length - 1);
                                this.printer.Toner = Int32.Parse(valor[1]);
                            }
                            else
                            {
                                this.printer.Toner = 0;
                            }
                        }
                    }
                }
                if (contTablas == (int)Printer.L610_NUM_TABLA.UNIDAD_IMAGEN)
                {
                    int contTr = 0;
                    foreach (var nodo in tabla.ChildNodes)
                    {
                        if (nodo.Name == "tr") contTr++;
                        if (contTr == (int)Printer.L610_NUM_TR.KIT_MANTENIMIENTO && nodo.Name == "tr")
                        {
                            string[] valor = nodo.InnerText.Split(':');
                            valor[1] = valor[1].Remove(valor[1].Length - 3);

                            this.printer.KitMant = Int32.Parse(valor[1]);
                        }
                        if (contTr == (int)Printer.L610_NUM_TR.UNIDAD_IMAGEN && nodo.Name == "tr")
                        {
                            string[] valor = nodo.InnerText.Split(':');
                            valor[1] = valor[1].Remove(valor[1].Length - 3);

                            this.printer.UImagen = Int32.Parse(valor[1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene la información del Estado de Suministros de la página HTML de una Impresora Lexmark MS812
        /// </summary>
        private void _Lex812()
        {
            this.url += Printer.L812_AFTER_URL;
            this.doc = this.web.Load(this.url);

            int contTablas = 0;
            foreach (var tabla in doc.DocumentNode.SelectNodes(Printer.L812_TABLE))
            {
                contTablas++;
                if (contTablas == (int)Printer.L812_NUM_TABLA.TONER)
                {
                    int contTr = 0;
                    foreach (var nodo in tabla.ChildNodes)
                    {
                        if (nodo.Name == "tr") contTr++;
                        if (contTr == (int)Printer.L812_NUM_TR.TONER)
                        {
                            string[] valor = nodo.InnerText.Split('~');
                            if (valor.Length > 1)
                            {
                                valor[1] = valor[1].Remove(valor[1].Length - 1);
                                this.printer.Toner = Int32.Parse(valor[1]);
                            }
                            else
                            {
                                this.printer.Toner = 0;
                            }
                        }
                    }
                }
                if (contTablas == (int)Printer.L812_NUM_TABLA.UNIDAD_IMAGEN)
                {
                    int contTr = 0;
                    foreach (var nodo in tabla.ChildNodes)
                    {
                        if (nodo.Name == "tr") contTr++;
                        if (contTr == (int)Printer.L812_NUM_TR.KIT_MANTENIMIENTO && nodo.Name == "tr")
                        {
                            string[] valor = nodo.InnerText.Split(':');
                            valor[1] = valor[1].Remove(valor[1].Length - 3);

                            this.printer.KitMant = Int32.Parse(valor[1]);
                        }
                        if (contTr == (int)Printer.L812_NUM_TR.UNIDAD_IMAGEN && nodo.Name == "tr")
                        {
                            string[] valor = nodo.InnerText.Split(':');
                            valor[1] = valor[1].Remove(valor[1].Length - 3);

                            this.printer.UImagen = Int32.Parse(valor[1]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Obtiene la información del Estado de Suministros de la página HTML de una Impresora Lexmark MS622
        /// </summary>
        private void _Lex622()
        {
            //Primero seteo los valores de los suministros en 0, por si ocurre algun error.
            this.printer.Toner = 0;
            this.printer.UImagen = 0;
            this.printer.KitMant = 0;

            //Le indico a Selenium que vaya a la página de la impresora mediante su IP.
            this.driver.Navigate().GoToUrl(this.url);
            //Seteo el driver para que por cada búsqueda dentro de la pagina de la impresora, espere 5 segundos. 
            //De esa manera le doy tiempo a que analice correctamente.
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            /*Busco dentro de la pagina cada uno de los suministros. Primero busco el contenedor de cada uno de ellos (siempre es un li).
            Luego obtengo todos los elementos div del contenedor. Cuando tengo esos div los recorro uno a uno preguntándo por el que tiene
            la información del suministro. Le quito el símbolo % al string devuelto y lo convierto en un entero.
            Repito el proceso por cada uno de los suministros de la impresora.
             */
            IWebElement container = this.driver.FindElement(By.XPath("//li[@id='TonerSupplies']"));
            ReadOnlyCollection<IWebElement> containerElements = container.FindElements(By.TagName("div"));
            foreach(IWebElement div in containerElements)
            {
                if (div.GetAttribute("class") == "progress-inner BlackGauge")
                {
                    this.printer.Toner = Int32.Parse(div.GetAttribute("title").Substring(0, div.GetAttribute("title").Length - 1));
                }
            }

            container = this.driver.FindElement(By.XPath("//li[@id='PCDrumStatus']"));
            containerElements = container.FindElements(By.TagName("div"));
            foreach (IWebElement div in containerElements)
            {
                if (div.GetAttribute("class") == "progress-inner BlackGauge")
                {
                    this.printer.UImagen = Int32.Parse(div.GetAttribute("title").Substring(0, div.GetAttribute("title").Length - 1));
                }
            }

            container = this.driver.FindElement(By.XPath("//li[@id='FuserSuppliesStatus']"));
            containerElements = container.FindElements(By.TagName("div"));
            foreach (IWebElement div in containerElements)
            {
                if (div.GetAttribute("class") == "progress-inner BlackGauge")
                {
                    this.printer.KitMant = Int32.Parse(div.GetAttribute("title").Substring(0, div.GetAttribute("title").Length - 1));
                }
            }
        }
    }
}
