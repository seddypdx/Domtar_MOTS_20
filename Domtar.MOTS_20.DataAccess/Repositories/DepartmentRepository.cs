using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domtar.MOTS_20.DataAccess.Infrastructure;
using Domtar.MOTS_20.Models;

namespace Domtar.MOTS_20.DataAccess.Repositories
{
    public interface IDepartmentRepository : IRepository<Department>
    {
        Department GetNextItemToProcess(string processingServer, string proxy);

     }

    public class DepartmentRepository : RepositoryBase<Department>, IDepartmentRepository
    {
        public DepartmentRepository(IDbFactory dbFactory, IUnitOfWork unitOfWork) : base(dbFactory, unitOfWork)
        {

        }

        public Department GetNextItemToProcess(string processingServer, string proxy)
        {
            //var parameters = new object[]
            //{
            //    new SqlParameter("processingServer", processingServer),
            //    new SqlParameter("proxy", proxy)
            //};

            //return DbContext.Database.SqlQuery<AdWordQueueItem>("AdWord_Next @processingServer, @proxy", parameters)
            //    .SingleOrDefault();

            return null;
        }

      
    }
}
