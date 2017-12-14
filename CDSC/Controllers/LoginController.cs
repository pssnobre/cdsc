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
            return View();
        }

        public ActionResult NovoUsuario()
        {
            return View("NovoUsuario");
        }

        public ActionResult Logar(UsuarioModel usu)
        {
            if (UsuarioModel.Login(usu))
            {
                return RedirectToAction("Index", "IdentificacaoCrianca");
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
            if (usu.senha != usu.confirmacaoSenha)
            {
                // retornar mensagem de erro.
                return RedirectToAction("NovoUsuario", "Login");
            }

            UsuarioModel.Salvar(usu);
            return RedirectToAction("Index", "Login");
        }
        

    }
}