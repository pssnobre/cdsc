﻿using CDSC.Models;
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
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(IntercorrenciaModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(IntercorrenciaModel modelObj)
        {
            try
            {
                IntercorrenciaModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "Intercorrencias");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "Intercorrencias");
            }
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Alimentacao");
        }
    }
}