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
            return View(ObservacaoModel.ObterRegistro(idUsuarioLogado));


            //ViewBag.Script = "$('.btn-toastr').click();";

        }

        public ActionResult Salvar(ObservacaoModel modelObj)
        {
            ObservacaoModel.Salvar(modelObj);
            return RedirectToAction("Index", "Observacoes");
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Intercorrencias");
        }
    }
}