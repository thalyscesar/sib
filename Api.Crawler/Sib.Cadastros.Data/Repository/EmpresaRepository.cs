using Microsoft.EntityFrameworkCore;
using Sib.Cadastros.Data.Querys;
using Sib.Cadastros.Domain;
using Sib.Cadastros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sib.Cadastros.Data.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly CadastrosContext _context;

        public EmpresaRepository(CadastrosContext cadastrosContext) 
        {
            _context = cadastrosContext;
        }

        public IUnitOfWork UnitOfWork { get => _context; }

        public void Adicionar(Empresa empresa)
        {
            _context.Empresas.Add(empresa);
        }

        public async Task<Empresa> ObterPeloCnpj(string cnpj)
        {
            Empresa empresa = await _context.Empresas.AsNoTracking().FirstOrDefaultAsync(new EmpresaQuery(cnpj).ObterPeloCnpj);
            return empresa;
        }

        public async Task<IEnumerable<Empresa>> ObterTodos()
        {
            return await _context.Empresas.AsNoTracking().ToListAsync();
        }
    }
}
