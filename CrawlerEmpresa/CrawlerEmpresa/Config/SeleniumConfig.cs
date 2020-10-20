using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerEmpresa.Config
{
    public class SeleniumConfig
    {
        public string CaminhoDriverChrome { get; set; }
        public string UrlPagina { get; set; }
        public int Timeout { get; set; }
    }
}
