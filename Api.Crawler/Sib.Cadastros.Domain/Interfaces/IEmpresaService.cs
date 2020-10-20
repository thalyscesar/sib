using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sib.Cadastros.Domain.Interfaces
{
    public interface IEmpresaService
    {
        Task<IEnumerable<Empresa>> ObterTodos();
        Task<Empresa> ObterPeloCnpj(string cnpj);

        Task<bool> Adicionar(Empresa produto);
    }
}
