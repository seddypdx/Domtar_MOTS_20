using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domtar.MOTS_20.Models
{
    public class Department
    {
        public Department()
        {
          
        }

        public int DepartmentNumber { get; set; }
        public string Dept { get; set; }
 
    }
}