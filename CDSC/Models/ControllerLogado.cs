using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CDSC.Models
{
    public class ControllerLogado : Controller
    {
        public virtual string PaginaAlias { get; }

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);

            if (UsuarioModel.ObterUsuarioSessao() == null)
            {
                Response.Redirect(Url.Content("~/Login"), true);
            }
        }

        //public void CheckAction(string acao)
        //{
        //    if (!Autenticacao.AcaoEstaDisponivelUsuarioPagina(acao))
        //    {
        //        Response.Redirect(Url.Content("~/Default/PermissionDenied"), true);
        //    }
        //}

        //public void InitalizeDefaultViewBag()
        //{
        //    ViewBag.DropDownStatus = new SelectList(new Dictionary<bool, string>() { { true, "Ativo" }, { false, "Inativo" } }, "key", "value");
        //}

    }

    public class AuthorizeUserAttribute : AuthorizeAttribute
    {
        // Custom property
        public string Acao { get; set; }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            List<string> Acoes = new List<string>();
            bool retorno = false;

            //if (!string.IsNullOrEmpty(Acao))
            //{
            //    Acoes = Acao.Split('|').ToList();
            //}

            //foreach (string a in Acoes)
            //{
            //    if (Autenticacao.AcaoEstaDisponivelUsuarioPagina(a))
            //    {
            //        return true;
            //    }
            //}

            //if (!retorno)
            //{
            //    if (!HttpContext.Current.Response.HeadersWritten)
            //    {
            //        httpContext.Response.Redirect(new UrlHelper(httpContext.Request.RequestContext).Content("~/Default/PermissionDenied"), true);
            //    }
            //}
            //return retorno;
            return true;
        }
    }
}
