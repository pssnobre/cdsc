using System;
using System.Text;
using System.Web.Mvc;

namespace CDSC.Models
{
    public static class HtmlClass
    {
        public static MvcHtmlString ActionLinkButton(this HtmlHelper html, string texto, string href, string htmlclass, string acao)
        {
            //if (Autenticacao.AcaoEstaDisponivelUsuarioPagina(acao))
            //{
            //    return MvcHtmlString.Create(String.Format("<a href='{0}' class='{1}'>{2}</a>", href, htmlclass, texto));
            //}
            //return null;
            return MvcHtmlString.Create(String.Format("<a href='{0}' class='{1}'>{2}</a>", href, htmlclass, texto));
        }
        public static MvcHtmlString DeleteAnchor(this HtmlHelper helper, string texto, string controllerName, string actionName, object id, string textoConfirmacao, object htmlAttributes = null, bool personalizado = false)
        {
            StringBuilder attr = new StringBuilder();
            var attributes = helper.AttributeEncode(htmlAttributes);

            if (!string.IsNullOrEmpty(attributes))
            {
                attributes = attributes.Trim('{', '}');
                var attrValuePairs = attributes.Split(',');
                foreach (var attrValuePair in attrValuePairs)
                {
                    var equalIndex = attrValuePair.IndexOf('=');
                    string[] attrValue = attrValuePair.Split('=');
                    attr.AppendFormat("{0}='{1}' ", attrValuePair.Substring(0, equalIndex).Trim(), attrValuePair.Substring(equalIndex + 1).Trim());
                }
            }

            UrlHelper Url = new UrlHelper(helper.ViewContext.RequestContext);
            string route = Url.Content("~/" + controllerName + "/" + actionName + "/");
            route += id;

            if (personalizado)
            {
                return MvcHtmlString.Create(String.Format("<a onclick=\"excluirPersonalizado('{0}','{1}','{2}')\" href='#' {3}>{4}</a>", textoConfirmacao, id, route, attr, texto));
            }

            return MvcHtmlString.Create(String.Format("<a onclick=\"excluir('{0}','{1}','{2}')\" href='#' {3}>{4}</a>", textoConfirmacao, id, route, attr, texto));
        }

        public static MvcHtmlString SubmitButton(this HtmlHelper helper, string buttonText, string actionName, string controllerName, object htmlAttributes = null)
        {
            StringBuilder attr = new StringBuilder();
            var attributes = helper.AttributeEncode(htmlAttributes);
            string UrlParam = "";

            if (!string.IsNullOrEmpty(attributes))
            {
                attributes = attributes.Trim('{', '}');
                var attrValuePairs = attributes.Split(',');
                foreach (var attrValuePair in attrValuePairs)
                {
                    var equalIndex = attrValuePair.IndexOf('=');
                    string[] attrValue = attrValuePair.Split('=');
                    if (attrValuePair.Substring(0, equalIndex).Trim().ToLower() == "id")
                    {
                        UrlParam = attrValuePair.Substring(equalIndex + 1).Trim();
                    }
                    else
                    {
                        attr.AppendFormat("{0}='{1}' ", attrValuePair.Substring(0, equalIndex).Trim(), attrValuePair.Substring(equalIndex + 1).Trim());
                    }
                }
            }

            UrlHelper Url = new UrlHelper(helper.ViewContext.RequestContext);
            string route = Url.Content("~/" + controllerName + "/" + actionName + "/");
            if (!string.IsNullOrEmpty(UrlParam))
            {
                route += UrlParam;
            }

            StringBuilder html = new StringBuilder();
            html.AppendFormat("<button type='submit' formaction='{0}' {1}>{2}</button>", route, attr, buttonText);

            return new MvcHtmlString(html.ToString());
        }

        public static MvcHtmlString CheckAction(this HtmlHelper html, MvcHtmlString element, string action)
        {
            //if (Autenticacao.AcaoEstaDisponivelUsuarioPagina(action))
            //{
            //    return element;
            //}
            //return null;
            return element;
        }

    }
}
