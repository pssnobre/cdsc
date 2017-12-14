using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class VigilanciaDesenvolvimentoController : ControllerLogado
    {
        public ActionResult Index()
        {
            ViewBag.Idade = new SelectList(new Dictionary<int, string>() { { 1, "1 Mês" }, { 2, "2 Meses" }, { 3, "3 Meses" }, { 4, "4 Meses" }, { 5, "5 Mês" }, { 6, "6 Meses" },
                                                                           { 7, "7 Meses" }, { 8, "8 Meses" }, { 9, "9 Meses" }, { 10, "10 Meses" }, { 11, "11 Meses" }, { 12, "12 Meses" } }, "key", "value");
            ViewBag.StatusMarcador = new SelectList(new Dictionary<int, string>() { { 1, "Presente" }, { 2, "Ausente" }, { 3, "Não Verificado" } }, "key", "value");
            ViewBag.ListaMarcadoresDrop = new SelectList(VigilanciaDesenvolvimentoModel.ListaMarcadores(), "mdv_id_marcador", "mdv_ds_marcador");
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            VigilanciaDesenvolvimentoModel objVigilanciaDesenvolvimentoModel = VigilanciaDesenvolvimentoModel.ObterRegistro(idUsuarioLogado);
            

            return View(objVigilanciaDesenvolvimentoModel);
        }

        public ActionResult Salvar(VigilanciaDesenvolvimentoModel modelObj)
        {
            VigilanciaDesenvolvimentoModel.Salvar(modelObj);
            return RedirectToAction("Index", "VigilanciaDesenvolvimento");

        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "ExamesTriagem");
        }
    }
}