using Sib.Cadastros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sib.Cadastros.Domain.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaService(IEmpresaRepository empresaRepository)
        {
            this._empresaRepository = empresaRepository;
        }

        public Task<bool> Adicionar(Empresa empresa)
        {
            _empresaRepository.Adicionar(empresa);
            return _empresaRepository.UnitOfWork.Commit();
        }

        public async Task<Empresa> ObterPeloCnpj(string cnpj)
        {
            return await _empresaRepository.ObterPeloCnpj(cnpj);
        }

        public async Task<IEnumerable<Empresa>> ObterTodos()
        {
            return await _empresaRepository.ObterTodos();
        }
    }
}
