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
            return View(AlimentacaoModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(AlimentacaoModel modelObj)
        {
            AlimentacaoModel.Salvar(modelObj);
            return RedirectToAction("Index", "Intercorrencias");
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Vacinas");
        }
    }
}