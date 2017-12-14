using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class UFModel
    {
        public static List<uf> ObterUF()
        {
            cdscEntities objBd = new cdscEntities();
            return objBd.uf.OrderBy(x => x.uff_ds_sigla).ToList();
        }
    }
}