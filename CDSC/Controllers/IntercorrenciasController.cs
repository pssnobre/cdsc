using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class IntercorrenciasController : ControllerLogado
    {
        public ActionResult Index()
        {
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            return View(IntercorrenciaModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(IntercorrenciaModel modelObj)
        {
            IntercorrenciaModel.Salvar(modelObj);
            return RedirectToAction("Index", "Observacoes");
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Alimentacao");
        }
    }
}