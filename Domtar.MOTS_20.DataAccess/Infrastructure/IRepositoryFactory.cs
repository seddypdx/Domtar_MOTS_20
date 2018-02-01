using Domtar.MOTS_20.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domtar.MOTS_20.DataAccess.Infrastructure
{
    public interface IRepositoryFactory
    {
        IRepository<T> GetRepositoryFromItemType<T>() where T : class;
        T GetRepository<T>() where T : class;
        I GetRepository<T, I>() where T : class where I : class, IRepository<T>;
    }
}
