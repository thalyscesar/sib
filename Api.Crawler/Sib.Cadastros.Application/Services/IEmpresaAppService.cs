using Sib.Cadastros.Application.Models;
using Sib.Cadastros.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sib.Cadastros.Application.Services
{
    public interface IEmpresaAppService
    {
        Task<EmpresaModel> ObterPeloCnpj(string cnpj);
        Task<IEnumerable<EmpresaModel>> ObterTodos();
        Task<int> Adicionar(EmpresaModel empresaModel);
    }
}
