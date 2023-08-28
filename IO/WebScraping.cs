using Entities;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using CustomExceptions;

namespace IO
{
    public class WebScraping
    {
        private string url;
        private Printer printer;
        private IWebDriver driver;

        public WebScraping(IWebDriver driver)
        {
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

            //Le indico a Selenium que vaya a la página de la impresora mediante su IP.
            this.driver.Navigate().GoToUrl(this.url);
            //Seteo el driver para que por cada búsqueda dentro de la pagina de la impresora, espere 5 segundos. 
            //De esa manera le doy tiempo a que analice correctamente.
            this.driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(7);

            //Almaceno el Title de la página HTML y lo uso como modelo de la Impresora.
            this.printer.Modelo = this.driver.Title;

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
            try
            {
                //Accedo a la página que contiene la info de los suministros.
                this.url += Printer.L410_AFTER_URL;
                this.driver.Navigate().GoToUrl(this.url);

                //Traigo el contenedor que contiene el toner. En este caso, es un elemento b dentro de un td
                IWebElement container = this.driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr[3]/td/b"));
                //Corto el texto del contenedor y lo paso a la variable toner de la impresora.
                this.printer.Toner = Int32.Parse(container.Text.Substring(16, (container.Text.Length - 17)));

                //Traigo el contenedor que contiene la unidad de imagen.
                container = this.driver.FindElement(By.XPath("/html/body/table[4]/tbody/tr[5]/td[2]"));
                //Corto el texto del contenedor y lo paso a la variable unidad de imagen de la impresora.
                this.printer.UImagen = Int32.Parse(container.Text.Substring(0, (container.Text.Length - 1)));
            }
            catch (Exception ex)
            {
                //Si se ejecuta una excepción por StartIndex en uno de los suministros quiere decir que la impresora no lo está mostrando.
                if (ex.Source == "mscorlib")
                {
                    throw new SuministroException();
                }
                else
                {
                    throw ex;
                }
            }
        }

        /// <summary>
        /// Obtiene la información del Estado de Suministros de la página HTML de una Impresora Lexmark MS610
        /// </summary>
        private void _Lex610()
        {
            //Accedo a la página que contiene la info de los suministros.
            this.url += Printer.L610_AFTER_URL;
            this.driver.Navigate().GoToUrl(this.url);

            //Traigo el contenedor que contiene el toner. En este caso, es un elemento b dentro de un td
            IWebElement container = this.driver.FindElement(By.XPath("/html/body/table[1]/tbody/tr[3]/td/b"));
            //Corto el texto del contenedor y lo paso a la variable toner de la impresora.
            this.printer.Toner = Int32.Parse(container.Text.Substring(16, (container.Text.Length - 17)));

            //Traigo el contenedor que contiene la unidad de imagen.
            container = this.driver.FindElement(By.XPath("/html/body/table[4]/tbody/tr[6]/td[2]"));
            //Corto el texto del contenedor y lo paso a la variable unidad de imagen de la impresora.
            this.printer.UImagen = Int32.Parse(container.Text.Substring(0, (container.Text.Length - 1)));

            //Traigo el contenedor que contiene el kit de mantenimiento.
            container = this.driver.FindElement(By.XPath("/html/body/table[4]/tbody/tr[5]/td[2]"));
            //Corto el texto del contenedor y lo paso a la variable kit de mantenimiento de la impresora.
            this.printer.KitMant = Int32.Parse(container.Text.Substring(0, (container.Text.Length - 1)));
        }

        /// <summary>
        /// Obtiene la información del Estado de Suministros de la página HTML de una Impresora Lexmark MS812
        /// </summary>
        private void _Lex812()
        {
            //Accedo a la página que contiene la info de los suministros.
            this.url += Printer.L812_AFTER_URL;
            this.driver.Navigate().GoToUrl(this.url);

            //Traigo el contenedor que contiene el toner. En este caso, es un elemento b dentro de un td
            IWebElement container = this.driver.FindElement(By.XPath("/html/body/table[2]/tbody/tr[3]/td/b"));
            //Corto el texto del contenedor y lo paso a la variable toner de la impresora.
            this.printer.Toner = Int32.Parse(container.Text.Substring(16, (container.Text.Length - 17)));

            //Traigo el contenedor que contiene la unidad de imagen.
            container = this.driver.FindElement(By.XPath("/html/body/table[5]/tbody/tr[5]/td[2]"));
            //Corto el texto del contenedor y lo paso a la variable unidad de imagen de la impresora.
            this.printer.UImagen = Int32.Parse(container.Text.Substring(0, (container.Text.Length - 1)));

            //Traigo el contenedor que contiene el kit de mantenimiento.
            container = this.driver.FindElement(By.XPath("/html/body/table[5]/tbody/tr[7]/td[2]"));
            //Corto el texto del contenedor y lo paso a la variable kit de mantenimiento de la impresora.
            this.printer.KitMant = Int32.Parse(container.Text.Substring(0, (container.Text.Length - 1)));
        }

        /// <summary>
        /// Obtiene la información del Estado de Suministros de la página HTML de una Impresora Lexmark MS622
        /// </summary>
        private void _Lex622()
        {
            //Accedo a la página que contiene la info de los suministros.
            this.driver.Navigate().GoToUrl(this.url);

            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            /*Busco dentro de la pagina cada uno de los suministros. Primero busco el contenedor de cada uno de ellos (siempre es un li).
            Luego obtengo todos los elementos div del contenedor. Cuando tengo esos div los recorro uno a uno preguntándo por el que tiene
            la información del suministro. Le quito el símbolo % al string devuelto y lo convierto en un entero.
            Repito el proceso por cada uno de los suministros de la impresora.
             */
            IWebElement container = this.driver.FindElement(By.XPath("//li[@id='TonerSupplies']"));
            ReadOnlyCollection<IWebElement> containerElements = container.FindElements(By.TagName("div"));
            foreach (IWebElement div in containerElements)
            {
                if (div.GetAttribute("class") == "progress-inner BlackGauge")
                {
                    this.printer.Toner = Int32.Parse(div.GetAttribute("title").Substring(0, div.GetAttribute("title").Length - 1));
                    break;
                }
            }

            container = this.driver.FindElement(By.XPath("//li[@id='PCDrumStatus']"));
            containerElements = container.FindElements(By.TagName("div"));
            foreach (IWebElement div in containerElements)
            {
                if (div.GetAttribute("class") == "progress-inner BlackGauge")
                {
                    this.printer.UImagen = Int32.Parse(div.GetAttribute("title").Substring(0, div.GetAttribute("title").Length - 1));
                    break;
                }
            }

            container = this.driver.FindElement(By.XPath("//li[@id='FuserSuppliesStatus']"));
            containerElements = container.FindElements(By.TagName("div"));
            foreach (IWebElement div in containerElements)
            {
                if (div.GetAttribute("class") == "progress-inner BlackGauge")
                {
                    this.printer.KitMant = Int32.Parse(div.GetAttribute("title").Substring(0, div.GetAttribute("title").Length - 1));
                    break;
                }
            }
        }
    }
}
