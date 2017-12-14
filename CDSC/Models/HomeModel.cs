using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class HomeModel
    {
        public static void Teste()
        {
            cdscEntities entities = new cdscEntities();
            List<menu> listMenu = entities.menu.ToList();


        }
    }
}