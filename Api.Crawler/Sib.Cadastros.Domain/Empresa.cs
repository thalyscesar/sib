using System;
using System.Collections.Generic;
using System.Text;

namespace Sib.Cadastros.Domain
{
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

        protected Empresa() { }

        public Empresa(string cnpj, string razaoSocial, string nomeFantasia, DateTime dataAbertura, string ativa, string naturezaJuridica, double capitalSocial,
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
        }

        public void FormateAtivo(string ativo)
        {
            this.Ativa = ativo.ToUpper().StartsWith("A");
        }
    }
}
