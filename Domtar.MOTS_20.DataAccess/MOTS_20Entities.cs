using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using Domtar.MOTS_20.DataAccess.Configurations;
using Domtar.MOTS_20.Models;
using System.Threading;
using System.Threading.Tasks;
using log4net;

namespace Domtar.MOTS_20.DataAccess
{
    public class MOTS_20Entities : DbContext
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public MOTS_20Entities() : base("MOTS_20Entities")
        {
        }

        public DbSet<Department> Deparmtnets { get; set; }
       
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    var mainLine =
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in " + 
                        $"state \"{eve.Entry.State}\" has the following validation errors:";

                    Console.WriteLine(mainLine);
                    _log.WarnFormat(mainLine);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var secondaryLine = $"\tProperty: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";

                        Console.WriteLine(secondaryLine);
                        _log.WarnFormat(secondaryLine);
                    }
                }
                throw;
            }
        }

        public override async Task<int> SaveChangesAsync()
        {
            return await SaveChangesAsync(CancellationToken.None);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            try
            {
                return await base.SaveChangesAsync(cancellationToken);
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    var mainLine =
                        $"Entity of type \"{eve.Entry.Entity.GetType().Name}\" in " +
                        $"state \"{eve.Entry.State}\" has the following validation errors:";

                    Console.WriteLine(mainLine);
                    _log.WarnFormat(mainLine);

                    foreach (var ve in eve.ValidationErrors)
                    {
                        var secondaryLine = $"\tProperty: \"{ve.PropertyName}\", Error: \"{ve.ErrorMessage}\"";

                        Console.WriteLine(secondaryLine);
                        _log.WarnFormat(secondaryLine);
                    }
                }
                throw;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new DepartmentConfiguration());
          
            Configuration.LazyLoadingEnabled = true;
        }
    }
}