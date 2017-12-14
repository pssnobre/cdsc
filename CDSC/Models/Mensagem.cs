using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CDSC.Models
{
    public static class Mensagem
    {
        public enum TipoMensagem
        {
            Sucesso,
            Erro,
            Aviso
        }

        public static void ShowMensagem(Controller self, TipoMensagem tipoMensagem, string mensagem, string confirmRoute = null)
        {
            switch (tipoMensagem)
            {
                case TipoMensagem.Sucesso:
                    self.ViewBag.Success = mensagem;
                    self.ViewBag.confirmRoute = confirmRoute;
                    break;
                case TipoMensagem.Aviso:
                    self.ViewBag.Aviso = mensagem;
                    self.ViewBag.confirmRoute = confirmRoute;
                    break;
                case TipoMensagem.Erro:
                    self.ViewBag.Erro = mensagem;
                    self.ViewBag.confirmRoute = confirmRoute;
                    break;
                default:
                    break;
            }
        }
    }
}
