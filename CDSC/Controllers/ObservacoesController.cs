using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class ObservacoesController : ControllerLogado
    {
        public ActionResult Index()
        {
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();

            return View(ObservacaoModel.ObterRegistro(idUsuarioLogado));

        }

        public ActionResult Salvar(ObservacaoModel modelObj)
        {
            try
            {
                ObservacaoModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "Observacoes");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "Observacoes");
            }
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Intercorrencias");
        }
    }
}