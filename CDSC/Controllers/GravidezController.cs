using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDSC.Models;

namespace CDSC.Controllers
{
    public class GravidezController : ControllerLogado
    {
        // GET: Gravidez
        public ActionResult Index()
        {
            ViewBag.StatusSorologias = new SelectList(new Dictionary<int, string>() { { 1, "Não Realizada" }, { 2, "Normal" }, { 3, "Alterada" } }, "key", "value");
            ViewBag.PeriodoSorologias = new SelectList(new Dictionary<int, string>() { { 1, "1º Trimestre" }, { 2, "2º Trimestre" }, { 3, "3º Trimestre" } }, "key", "value");

            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            return View(GravidezModel.ObterRegistro(idUsuarioLogado));

            //return View();
        }

        public ActionResult Salvar(GravidezModel modelObj)
        {
            GravidezModel.Salvar(modelObj);
            return RedirectToAction("Index", "ExamesTriagem");

        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Gravidez");
        }
    }
}