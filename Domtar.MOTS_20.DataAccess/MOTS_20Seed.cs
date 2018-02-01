using System;
using System.Collections.Generic;
using System.Linq;
using Domtar.MOTS_20.Models;
using System.Net;
using Newtonsoft.Json;

namespace Domtar.MOTS_20.DataAccess
{
    public class SalesSystemSeed
    {
        protected void Seed(MOTS_20Entities context)
        {
            //base.Seed(context);
            //context.Commit();
        }

        /// <summary>
        /// Utility method to seed the <see cref="MOTS_20Entities.TopLevelDomains"/> table.
        /// </summary>
        public void SeedDepartments(MOTS_20Entities context)
        {
            try
            {
                Console.WriteLine("Seeding");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            }


      

       
    }
}
