using Microsoft.EntityFrameworkCore;
using Sib.Cadastros.Domain;
using Sib.Cadastros.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sib.Cadastros.Data
{
    public class CadastrosContext: DbContext, IUnitOfWork
    {
        public CadastrosContext(DbContextOptions<CadastrosContext> options) : base(options) { }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Cidade> Cidades { get; set; }

        public async Task<bool> Commit()
        {
            return await SaveChangesAsync() > 0;
        }
    }
}
