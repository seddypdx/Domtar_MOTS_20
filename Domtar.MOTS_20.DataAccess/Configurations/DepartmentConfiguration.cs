using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domtar.MOTS_20.Models;

namespace Domtar.MOTS_20.DataAccess.Configurations
{
    public class DepartmentConfiguration:EntityTypeConfiguration<Department>
    {
        public DepartmentConfiguration()
        {
            ToTable("Department");
            Property(d => d.Dept).IsRequired().HasMaxLength(200);
          //  HasOptional(d => d.RedirectsToDomain).WithMany().HasForeignKey(d => d.RedirectsToDomainId);
        }
    }
}
