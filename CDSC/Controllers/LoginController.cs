using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDSC.Models;

namespace CDSC.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View();
        }

        public ActionResult NovoUsuario()
        {
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View("NovoUsuario");
        }

        public ActionResult Logar(UsuarioModel usu)
        {
            try
            {
                if (UsuarioModel.Login(usu))
                {
                    return RedirectToAction("Index", "IdentificacaoCrianca");
                }
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "Login");
            }
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Logoff()
        {
            UsuarioModel.Logoff();
            return RedirectToAction("Index", "Login");
        }

        public ActionResult Salvar(UsuarioModel usu)
        {
            if (usu.senha != usu.confirmacaoSenha || String.IsNullOrEmpty(usu.email) || String.IsNullOrEmpty(usu.senha) || String.IsNullOrEmpty(usu.confirmacaoSenha))
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("NovoUsuario", "Login");
            }

            try
            {
                UsuarioModel.Salvar(usu);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "Login");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "NovoUsuario");
            }
        }
        

    }
}