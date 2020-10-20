using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace CrawlerEmpresa.Negocio
{
    public enum Tipo
    {
        Matriz,
        Filial
    }

    public class Empresa
    {
		public int Id { get; private set; }
        public string Cnpj { get; private set; }
        public string RazaoSocial { get; private set; }
        public string NomeFantasia { get; private set; }
        public DateTime DataAbertura { get; private set; }
        public bool Ativa { get; private set; }
        public string NaturezaJuridica { get; private set; }
        public double CapitalSocial { get; private set; }
        public string AtividadePrincial { get; private set; }
        public Endereco Endereco { get; private set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }


        public Empresa(int id,string cnpj, string razaoSocial, string nomeFantasia, DateTime dataAbertura, string ativa, string naturezaJuridica, double capitalSocial,
            string atividadePrincipal,
            Endereco endereco, string tipo, string telefone)
        {
            this.Cnpj = cnpj;
            this.RazaoSocial = razaoSocial;
            this.NomeFantasia = nomeFantasia;
            this.DataAbertura = dataAbertura;
            this.Endereco = endereco;
            this.CapitalSocial = capitalSocial;
            this.AtividadePrincial = atividadePrincipal;
            this.NaturezaJuridica = naturezaJuridica;
            this.FormateAtivo(ativa);
            this.Tipo = tipo;
            this.Telefone = telefone;
			this.Id = id;
        }

        public void FormateAtivo(string ativo)
        {
            this.Ativa = ativo.ToUpper().StartsWith("A");
        }
    }

    public class Endereco
    {
        public Endereco(int id, string cep, string logradouro, string numero, string complemento, string bairro, Cidade cidade)
        {
            this.Cep = cep;
            this.Logradouro = logradouro;
            this.Numero = numero;
            this.Complemento = complemento;
            this.Bairro = bairro;
            this.Cidade = cidade;
			this.Id = id;
        }
        public int Id { get; private set; }
        public string Cep { get; private set; }
        public string Logradouro { get; private set; }
        public string Numero { get; private set; }
        public string Complemento { get; private set; }
        public string Bairro { get; private set; }
        public Cidade Cidade { get; private set; }
    }

    public class Cidade
    {
		public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Uf { get; private set; }

        public Cidade(int id,string nome, string uf)
        {
            this.Nome = nome;
            this.Uf = uf;
			this.Id = id;
			
        }
    }
}
