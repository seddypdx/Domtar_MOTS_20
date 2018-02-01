using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domtar.MOTS_20.DataAccess.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        MOTS_20Entities dbContext;

        public MOTS_20Entities Init()
        {
            return dbContext ?? (dbContext = new MOTS_20Entities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
