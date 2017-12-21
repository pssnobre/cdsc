using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CDSC.Controllers
{
    public class ExamesTriagemController : ControllerLogado
    {
        public ActionResult Index()
        {
            ViewBag.UF = new SelectList(UFModel.ObterUF(), "uff_id_uf", "uff_ds_uf");
            ViewBag.Municipio = new SelectList(MunicipioModel.ObterMunicipio(0), "mun_id_municipio", "mun_ds_municipio");
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            DadosRecemNascidoModel obj = DadosRecemNascidoModel.ObterRegistro(idUsuarioLogado);
            if (obj.idUf > 0)
            {
                CarregaMunicipios(obj.idUf);
            }

            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(obj);
        }

        public ActionResult Salvar(DadosRecemNascidoModel modelObj)
        {
            try
            {
                DadosRecemNascidoModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "ExamesTriagem");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "ExamesTriagem");
            }
        }

        public JsonResult CarregaMunicipios(int id)
        {
            SelectList municipios = new SelectList(MunicipioModel.ObterMunicipio(id), "mun_id_municipio", "mun_ds_municipio");
            ViewBag.Municipio = municipios;
            return Json(municipios);
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "Gravidez");
        }
    }
}