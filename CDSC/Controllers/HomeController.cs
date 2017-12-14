using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class HomeController : ControllerLogado
    {
        // GET: Home
        public ActionResult Index()
        {
            HomeModel.Teste();
            return View();
        }
    }
}