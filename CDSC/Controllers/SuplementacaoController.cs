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
            return View(SuplementacaoModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(SuplementacaoModel modelObj)
        {
            SuplementacaoModel.Salvar(modelObj);
            return RedirectToAction("Index", "Suplementacao");
        }
        
        public ActionResult AddSuplementacaoFerro(String suplementacaoFerroData, String suplementacaoFerroLocal)
        {
            SuplementacaoModel.AdicionarSuplementacaoFerro(suplementacaoFerroData, suplementacaoFerroLocal);
            return Index();
        }

        public ActionResult AddSuplementacaoDeVitaminaA(String suplementacaoVitaminaAData, String suplementacaoVitaminaALocal)
        {
            SuplementacaoModel.AdicionarSuplementacaoVitaminaA(suplementacaoVitaminaAData, suplementacaoVitaminaALocal);
            return Index();
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