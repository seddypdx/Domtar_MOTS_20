using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domtar.MOTS_20.DataAccess.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
    }
}
