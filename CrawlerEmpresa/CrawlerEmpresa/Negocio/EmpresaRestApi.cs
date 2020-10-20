using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerEmpresa.Negocio
{
    public  class EmpresaRestApi
    {
        public HttpClient Client { get; private set; }


        public EmpresaRestApi(string UrlApi)
        {
            CriarRequisicao(UrlApi);
        }

        public async Task<string> SalvarEmpresa(Empresa empresa)
        {
            var json = JsonConvert.SerializeObject(empresa);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await Client.PostAsync("api/empresa", content);
            if (result.StatusCode == HttpStatusCode.Created)
                return await result.Content.ReadAsStringAsync();
            else
                LancarMensagem(result.StatusCode);

            return null;
        }

        private void CriarRequisicao(string url)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            Client = client;
        }

        public void LancarMensagem(HttpStatusCode status)
        {
            if (status == HttpStatusCode.NotFound)
            {
                Console.WriteLine("Controller não encontrado");
            }
            else if (status == HttpStatusCode.BadRequest)
            {
                Console.WriteLine("Revise o objeto ocorreu uma falha na validação");
            }
            else
                Console.WriteLine("Tente novamente fazer a operação StatusCode " + status.ToString());

        }
    }
}
