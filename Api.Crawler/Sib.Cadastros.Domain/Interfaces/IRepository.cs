using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sib.Cadastros.Domain.Interfaces
{
    public interface IRepository 
    {
        public IUnitOfWork UnitOfWork { get;}
    }

    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}
