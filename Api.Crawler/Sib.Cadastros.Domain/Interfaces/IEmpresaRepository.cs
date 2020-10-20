using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sib.Cadastros.Domain.Interfaces
{
    public interface IEmpresaRepository: IRepository
    {
        Task<IEnumerable<Empresa>> ObterTodos();
        Task<Empresa> ObterPeloCnpj(string cnpj);

        void Adicionar(Empresa produto);
    }
}
