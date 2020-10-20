using CrawlerEmpresa.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Resources;
using System.Text;

namespace CrawlerEmpresa.Negocio
{
    public class CrowlerCNPJ
    {
        public SeleniumConfig ConfiguracoesSelenium { get; private set; }
        private IWebDriver _driver;
        public CrowlerCNPJ(SeleniumConfig config)
        {
            ConfiguracoesSelenium = config;
            _driver = WebDriverFactory();

        }

        private IWebDriver WebDriverFactory()
        {
            ChromeOptions optionsFF = new ChromeOptions();
            optionsFF.AddArgument("--headless");

            return new ChromeDriver( Directory.GetCurrentDirectory() +  "\\" + ConfiguracoesSelenium.CaminhoDriverChrome , optionsFF);
        }

        public void PesquisarGooglePeloCnpj(string cnpj)
        {

            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _driver.Navigate().GoToUrl(ConfiguracoesSelenium.UrlPagina);
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);
            _driver.FindElement(By.CssSelector("input.gLFyf.gsfi")).SendKeys(cnpj);

            _driver.FindElement(By.Id("tsf")).Submit();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

            var divRc = _driver.FindElement(By.ClassName("rc"));
            var divTituloLink = divRc.FindElement(By.ClassName("yuRUbf"));
            divTituloLink.FindElement(By.TagName("a")).Click();
            _driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(60);

        }

        public void FecharPagina()
        {
            _driver.Quit();
            _driver = null;
        }

        public Empresa ObterEmpresaPeloCnpj()
        {
            var ul = _driver.FindElement(By.XPath("/html/body/div/div[2]/ul"));

            var cnpj = ul.FindElement(By.XPath("li[1]/strong")).Text;
            var razaoSocial = ul.FindElement(By.XPath("li[2]/strong")).Text;
            var nomeFantasia = ul.FindElement(By.XPath("li[3]/strong")).Text;
            var dataAbertura = ul.FindElement(By.XPath("li[4]/strong")).Text;
            var tipo = ul.FindElement(By.XPath("li[5]/strong")).Text;
            var situacao = ul.FindElement(By.XPath("li[6]/strong")).Text;
            var naturezaJuridica = ul.FindElement(By.XPath("li[7]/strong")).Text;
            var capitalSocial = ul.FindElement(By.XPath("li[8]/strong")).Text.Replace(".", ",");

            var ulAtividadePrincipal = _driver.FindElement(By.XPath("/html/body/div/div[2]/ul[2]"));
            var atividadePrincipal = ulAtividadePrincipal.FindElement(By.XPath("li[1]/strong")).Text;

            string telefone = _driver.FindElement(By.XPath("/html/body/div/div[2]/ul[5]/li[1]/strong")).Text;

            Empresa empresa = new Empresa(0, cnpj, razaoSocial, nomeFantasia, DateTime.Parse(dataAbertura), situacao, naturezaJuridica, double.Parse(capitalSocial), atividadePrincipal, CarregarEndereco(), tipo, telefone);

            return empresa;
        }

        private Endereco CarregarEndereco()
        {
            var ulEndereco = _driver.FindElement(By.XPath("/html/body/div/div[2]/ul[4]"));

            var cep = "";
            if (ulEndereco.FindElement(By.XPath("li[1]")).Text.Contains("CEP"))
            {
                cep = ulEndereco.FindElement(By.XPath("li[1]/strong")).Text;
            }
            var logradouro = "";
            if (ulEndereco.FindElement(By.XPath("li[2]")).Text.Contains("Logradouro"))
            {
                logradouro = ulEndereco.FindElement(By.XPath("li[2]/strong")).Text;
            }
            var numero = "";
            if (ulEndereco.FindElement(By.XPath("li[3]")).Text.Contains("Número"))
            {
                numero = ulEndereco.FindElement(By.XPath("li[3]/strong")).Text;
            }
            var complemento = "";
            if (ulEndereco.FindElement(By.XPath("li[4]")).Text.Contains("Complemento:"))
            {
                complemento = ulEndereco.FindElement(By.XPath("li[4]/strong")).Text;
            }
            var bairro = "";
            if (ulEndereco.FindElement(By.XPath("li[5]")).Text.Contains("Bairro"))
            {
                bairro = ulEndereco.FindElement(By.XPath("li[5]/strong")).Text;
            }
            var municipio = "";
            if (ulEndereco.FindElement(By.XPath("li[6]")).Text.Contains("Município"))
            {
                municipio = ulEndereco.FindElement(By.XPath("li[6]/strong")).Text;
            }
            var uf = "";
            try
            {
                if (ulEndereco.FindElement(By.XPath("li[7]")).Text.Contains("UF"))
                {
                    uf = ulEndereco.FindElement(By.XPath("li[7]/strong")).Text;
                }
            }
            catch 
            {
            }
            return new Endereco(0, cep, logradouro, numero, complemento, bairro, new Cidade(0, municipio, uf));
        }
    }
}
