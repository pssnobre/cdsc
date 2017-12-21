using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class AlimentacaoController : ControllerLogado
    {
        public ActionResult Index()
        {
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(AlimentacaoModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(AlimentacaoModel modelObj)
        {
            try
            {
                AlimentacaoModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "Alimentacao");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "Alimentacao");
            }
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Vacinas");
        }
    }
}