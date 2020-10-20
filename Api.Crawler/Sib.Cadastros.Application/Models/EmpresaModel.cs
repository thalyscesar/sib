using System;
using System.Collections.Generic;
using System.Text;

namespace Sib.Cadastros.Application.Models
{
    public class EmpresaModel
    {
        public int Id { get;  set; }
        public string Cnpj { get;  set; }
        public string RazaoSocial { get;  set; }
        public string NomeFantasia { get;  set; }
        public DateTime DataAbertura { get;  set; }
        public bool Ativa { get;  set; }
        public string NaturezaJuridica { get;  set; }
        public double CapitalSocial { get;  set; }
        public string AtividadePrincial { get;  set; }
        public EnderecoModel Endereco { get;  set; }
        public string Tipo { get; set; }
        public string Telefone { get; set; }
    }
}
