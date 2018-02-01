using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domtar.MOTS_20.Models.ExceptionHandling
{
    public class ExceptionUtility
    {

        public static Exception GetInnermostException(Exception ex)
        {
            if (ex.InnerException == null)
                return ex;

            return GetInnermostException(ex.InnerException);
        }

       
    }
}
