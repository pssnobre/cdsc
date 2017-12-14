using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MunicipioModel
    {
        public static List<municipio> ObterMunicipio(int codigoUF)
        {
            if (codigoUF == 0)
            {
                return new List<municipio>();
            }

            cdscEntities objBd = new cdscEntities();
            return objBd.municipio.Where(x => x.mun_id_uf == codigoUF).OrderBy(x => x.mun_ds_municipio).ToList();
        }
    }
}