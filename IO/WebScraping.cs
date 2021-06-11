using Entities;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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

        public WebScraping()
        {
            this.web = new HtmlWeb();
            this.doc = new HtmlDocument();
            this.url = "http://";
            this.printer = new Printer();
        }

        /// <summary>
        /// Read a Printer IP.
        /// </summary>
        /// <remarks>
        /// Allow read all the information in the HTML Printer Page and returns an Object Printer.
        /// </remarks>
        /// <param name="ip"></param>
        /// <returns>Printer</returns>
        public Printer readIp(string ip)
        {
            //The url Variable has a String with http://, just it need the IP Address.
            this.url += ip;

            //Put a Timeout, set in 4000 miliseconds.
            this.web.PreRequest = delegate (HttpWebRequest webRequest)
            {
                webRequest.Timeout = 4000;
                return true;
            };

            //Load de HTML Printer Page.
            this.doc = this.web.Load(this.url);

            //Save the Page Title and then use it as Printer Model.
            var title = this.doc.DocumentNode.SelectNodes("//title").FirstOrDefault();
            this.printer.Modelo = title.InnerHtml;

            //According to the Printer Model, call its custom method to complete the information about.
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
            }
            return this.printer;
        }

        /// <summary>
        /// Lexmark MS410 Information
        /// </summary>
        /// <remarks>
        /// Find inside the Lexmark MS410 HTML Page all information needed.
        /// </remarks>
        private void _Lex410() {
            this.url += Printer.L410_AFTER_URL; 
            this.doc = this.web.Load(this.url); 

            int contTablas = 0;
            foreach (var tabla in doc.DocumentNode.SelectNodes(Printer.L410_TABLE))
            {
                contTablas++;

                if (contTablas == (int) Printer.L410_NUM_TABLA.TONER)
                {
                    int contTr = 0;
                    foreach (var nodo in tabla.ChildNodes)
                    {
                        if (nodo.Name == "tr") contTr++;
                        if (contTr == (int) Printer.L410_NUM_TR.TONER)
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
                if (contTablas == (int) Printer.L410_NUM_TABLA.UNIDAD_IMAGEN)
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
        /// Lexmark MS610 Information
        /// </summary>
        /// <remarks>
        /// Find inside the Lexmark MS610 HTML Page all information needed.
        /// </remarks>
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
        /// Lexmark MS812 Information
        /// </summary>
        /// <remarks>
        /// Find inside the Lexmark MS812 HTML Page all information needed.
        /// </remarks>
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
    }
}
