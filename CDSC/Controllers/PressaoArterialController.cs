using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class PressaoArterialController : ControllerLogado
    {
        public ActionResult Index()
        {
            ViewBag.Idade = new SelectList(new Dictionary<int, string>() { { 1, "1 Mês" }, { 2, "2 Meses" }, { 3, "3 Meses" }, { 4, "4 Meses" }, { 5, "5 Mês" }, { 6, "6 Meses" },
                                                                           { 7, "7 Meses" }, { 8, "8 Meses" }, { 9, "9 Meses" }, { 10, "10 Meses" }, { 11, "11 Meses" }, { 12, "12 Meses" } }, "key", "value");

            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(PressaoArterialModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(PressaoArterialModel modelObj)
        {
            try
            {
                PressaoArterialModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "PressaoArterial");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "PressaoArterial");
            }
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "MedidasAntropometricas");
        }
    }
}