using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Connectors
{
    public interface IWebKitConnector
    {
        void BrowserNav(string url);
    }
}
