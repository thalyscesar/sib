using Sib.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Sib.Cadastros.Data.Querys
{
    public class EmpresaQuery
    {
        public string Cnpj { get; set; }

        public EmpresaQuery(string cnpj)
        {
            this.Cnpj = cnpj;
        }

        public Expression<Func<Empresa, bool>> ObterPeloCnpj => empresa => empresa.Cnpj == Cnpj;
    }
}
