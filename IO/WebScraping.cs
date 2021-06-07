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
        public static Printer readIp(string ip)
        {
            //HtmlWeb oWeb = new HtmlWeb();
            ////HtmlDocument document = oWeb.Load("http://" + ip + "/cgi-bin/dynamic/printer/PrinterStatus.html");
            //HtmlDocument document = oWeb.Load("http://www.cooplalaguna.com.ar");

            //HtmlNode head = document.DocumentNode.CssSelect("body").FirstOrDefault();

            HtmlWeb web = new HtmlWeb();
            string url = "http://" + ip;
            HtmlDocument doc = web.Load(url);

            var title = doc.DocumentNode.SelectNodes("//title").FirstOrDefault();

            Printer printer = new Printer();
            printer.Modelo = title.InnerHtml;

            url += "/cgi-bin/dynamic/printer/PrinterStatus.html";
            doc = web.Load(url);

            if (printer.Modelo == "Lexmark MS812" || printer.Modelo == "Lexmark MS610dn")
            {
                int contTablas = 0;
                foreach (var tabla in doc.DocumentNode.SelectNodes("//table[@class='status_table']"))
                {
                    contTablas++;
                    if (contTablas == 1)
                    {
                        int contTr = 0;
                        foreach (var nodo in tabla.ChildNodes)
                        {
                            if (nodo.Name == "tr") contTr++;
                            if (contTr == 3)
                            {
                                string[] valor = nodo.InnerText.Split('~');
                                valor[1] = valor[1].Remove(valor[1].Length - 1);

                                printer.Toner = Int32.Parse(valor[1]);
                            }
                        }
                    }
                    if (contTablas == 4)
                    {
                        int contTr = 0;
                        foreach (var nodo in tabla.ChildNodes)
                        {
                            if (nodo.Name == "tr") contTr++;
                            if (contTr == 5)
                            {
                                string[] valor = nodo.InnerText.Split(':');
                                valor[1] = valor[1].Remove(valor[1].Length - 3);

                                printer.KitMant = Int32.Parse(valor[1]);
                            }
                            if (contTr == 6 && printer.Modelo == "Lexmark MS610dn")
                            {
                                string[] valor = nodo.InnerText.Split(':');
                                valor[1] = valor[1].Remove(valor[1].Length - 3);

                                printer.UImagen = Int32.Parse(valor[1]);
                                contTr = 7;
                            }
                            if (contTr == 7 && printer.Modelo == "Lexmark MS812")
                            {
                                string[] valor = nodo.InnerText.Split(':');
                                valor[1] = valor[1].Remove(valor[1].Length - 3);

                                printer.UImagen = Int32.Parse(valor[1]);
                                contTr = 8;
                            }
                        }
                    }
                }
            }
            return printer;
        }
    }
}
