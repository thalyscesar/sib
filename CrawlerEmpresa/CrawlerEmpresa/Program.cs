using CrawlerEmpresa.Config;
using CrawlerEmpresa.Negocio;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.IO;

namespace CrawlerEmpresa
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json");
            var configuration = builder.Build();

            Console.WriteLine("Iniciando a captura das informações da empresa pelo Cnpj...");

            var config = new SeleniumConfig();
            new ConfigureFromConfigurationOptions<SeleniumConfig>(
                configuration.GetSection("SeleniumConfig"))
                    .Configure(config);

            var pagina = new CrowlerCNPJ(config);
            pagina.PesquisarGooglePeloCnpj("29.881.714/0001-38");
            Empresa empresa = pagina.ObterEmpresaPeloCnpj();
            pagina.FecharPagina();

            var apiEmpresa = new EmpresaRestApi(configuration.GetSection("UrlApi").Value);
            var id =    apiEmpresa.SalvarEmpresa(empresa).Result;
            Console.WriteLine("Extração realizada com sucesso");
            Console.WriteLine("Uma Empresa inserida na base de dados: " + id);
            Console.Read();
        }
    }
}
