using CDSC.Class;
using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Models
{
    public class Autenticacao
    {
        private static string PaginaAlias { get { return HttpContext.Current.Request.Headers["PaginaAlias"]; } set { HttpContext.Current.Request.Headers.Add("PaginaAlias", value); } }

        public static void Autenticar(usuario usuario)
        {
            HttpContext.Current.Session.Add("UsuarioLogado", usuario);
            //HttpContext.Current.Session.Add("GrupoUsuarioLogado", usuario.GRUPO);
            //HttpContext.Current.Session.Add("ListMenuUsuario", MenuModel.ObterMenuUsuario(usuario));
        }

        //public static void Autenticar(usuario usuario, EMPRESA_USUARIO empresaUsuario)
        //{
        //    HttpContext.Current.Session.Add("UsuarioLogado", usuario);
        //    HttpContext.Current.Session.Add("EmpresaUsuarioLogado", empresaUsuario);
        //    HttpContext.Current.Session.Add("GrupoUsuarioLogado", empresaUsuario.GRUPO);
        //    //HttpContext.Current.Session.Add("ListMenuUsuario", MenuModel.ObterMenuUsuario(empresaUsuario));
        //}

        public static UsuarioModel UsuarioLogado()
        {
            UsuarioModel insUsuarioLogado = (UsuarioModel)HttpContext.Current.Session["UsuarioLogado"];

            if (insUsuarioLogado == null)
            {
                insUsuarioLogado = new UsuarioModel();
            }

            return insUsuarioLogado;
        }
        
        //public static EMPRESA_USUARIO EmpresaUsuarioLogado()
        //{
        //    EMPRESA_USUARIO insEmpresaUsuarioLogado = (EMPRESA_USUARIO)HttpContext.Current.Session["EmpresaUsuarioLogado"];

        //    if (insEmpresaUsuarioLogado == null)
        //    {
        //        insEmpresaUsuarioLogado = null;
        //    }

        //    return insEmpresaUsuarioLogado;
        //}
        
        //public static GRUPO GrupoUsuarioLogado()
        //{
        //    GRUPO insGrupoUsuario = (GRUPO)HttpContext.Current.Session["GrupoUsuarioLogado"];

        //    if (insGrupoUsuario == null)
        //    {
        //        insGrupoUsuario = new GRUPO();
        //    }

        //    return insGrupoUsuario;
        //}

        //public static bool EstaAutenticado()
        //{
        //    USUARIO insUsuarioLogado = Autenticacao.UsuarioLogado();
        //    if (insUsuarioLogado.USU_ID_USUARIO > 0)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public static void SetPaginaAlias(string pagAlias)
        //{
        //    Autenticacao.PaginaAlias = pagAlias;
        //}

        //public static bool UsuarioPodeAcessarPagina()
        //{
        //    return PaginaModel.UsuarioPodeAcessarPagina(Autenticacao.GrupoUsuarioLogado(), Autenticacao.PaginaAlias);
        //}

        //public static void Desautenticar()
        //{
        //    HttpContext.Current.Session.Add("UsuarioLogado", null);
        //    HttpContext.Current.Session.Add("EmpresaUsuarioLogado", null);
        //    HttpContext.Current.Session.Add("GrupoUsuarioLogado", null);
        //    HttpContext.Current.Session.Add("ListMenuUsuario", null);
        //}

        //public static List<MenuModel> ObterMenuUsuarioLogado()
        //{
        //    List<MenuModel> ListMenuUsuario = (List<MenuModel>)HttpContext.Current.Session["ListMenuUsuario"];
        //    if (ListMenuUsuario == null)
        //    {
        //        ListMenuUsuario = new List<MenuModel>();
        //    }
        //    return ListMenuUsuario;
        //}

        //public static PAGINA ObterPaginaAtual()
        //{
        //    PaginaModel model = new PaginaModel();
        //    return model.ObterPagina(Autenticacao.PaginaAlias);
        //}

        //public static bool AcaoEstaDisponivelUsuarioPagina(string acaoAlias)
        //{
        //    return Autenticacao.AcaoEstaDisponivelGrupoPagina(Autenticacao.GrupoUsuarioLogado(), acaoAlias, Autenticacao.PaginaAlias);
        //}

        //private static bool AcaoEstaDisponivelGrupoPagina(GRUPO grupo, string acaoAlias, string pagAlias)
        //{
        //    try
        //    {
        //        //if (grupo == null)
        //        //{
        //        //    return false;
        //        //}

        //        //List<GRUPO_PAGINA_ACAO> ListGrupoPaginaAcao = grupo.GRUPO_PAGINA_ACAO.ToList();
        //        //if (ListGrupoPaginaAcao.Where(gpa => gpa.PAGINA_ACAO.PAGINA.PAG_DS_ALIAS.ToLower() == pagAlias.ToLower() && gpa.PAGINA_ACAO.ACAO.ACA_DS_ALIAS.ToLower() == acaoAlias.ToLower()).Count() > 0)
        //        //{
        //        //    return true;
        //        //}
        //        return false;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}

    }
}
