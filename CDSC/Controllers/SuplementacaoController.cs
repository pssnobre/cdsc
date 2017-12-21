using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class SuplementacaoController : ControllerLogado
    {
        public ActionResult Index()
        {
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(SuplementacaoModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(SuplementacaoModel modelObj)
        {
            try
            {
                SuplementacaoModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "Suplementacao");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "Suplementacao");
            }
        }
        
        public ActionResult AddSuplementacaoFerro(String suplementacaoFerroData, String suplementacaoFerroLocal)
        {
            try
            {
                SuplementacaoModel.AdicionarSuplementacaoFerro(suplementacaoFerroData, suplementacaoFerroLocal);
                TempData["mensagem"] = "sucesso";
                return Index();
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return Index();
            }
        }

        public ActionResult AddSuplementacaoDeVitaminaA(String suplementacaoVitaminaAData, String suplementacaoVitaminaALocal)
        {
            try
            {
                SuplementacaoModel.AdicionarSuplementacaoVitaminaA(suplementacaoVitaminaAData, suplementacaoVitaminaALocal);
                TempData["mensagem"] = "sucesso";
                return Index();
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return Index();
            }
        }

        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "PressaoArterial");
        }

        public ActionResult Avancar()
        {
            return RedirectToAction("Index", "Vacinas");
        }

        //public ActionResult AdicionarSuplementacaoFerro(string local)
        //{
        //    SuplementacaoModel.AdicionarSuplementacaoFerro(new SuplementacaoModel());
        //    return RedirectToAction("Index", "Suplementacao");
        //}
    }
}