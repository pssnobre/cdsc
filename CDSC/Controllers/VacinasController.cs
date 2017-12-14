using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class VacinasController : ControllerLogado
    {
        public ActionResult Index()
        {
            ViewBag.Doses = new SelectList(new Dictionary<int, string>() { { 1, "1ª Dose" }, { 2, "2ª Dose" }, { 3, "3ª Dose" } }, "key", "value");
            ViewBag.Vacinas = new SelectList(VacinaModel.ObterVacinas(), "vac_id_vacina", "vac_ds_vacina");
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            return View(VacinaModel.ObterRegistro(idUsuarioLogado));

        }

        public ActionResult Salvar(VacinaModel modelObj)
        {
            VacinaModel.Salvar(modelObj);
            return RedirectToAction("Index", "Alimentacao");
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Suplementacao");
        }
    }
}