using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDSC.Models;

namespace CDSC.Controllers
{
    public class MudancaEnderecoController : ControllerLogado
    {
        // GET: MudancaEndereco
        public ActionResult Index()
        {
            ViewBag.UF = new SelectList(UFModel.ObterUF(), "uff_id_uf", "uff_ds_uf");
            ViewBag.Municipio = new SelectList(MunicipioModel.ObterMunicipio(0), "mun_id_municipio", "mun_ds_municipio");
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(MudancaEnderecoModel.ObterRegistro(idUsuarioLogado));
        }

        public ActionResult Salvar(MudancaEnderecoModel modelObj)
        {
            try
            {
                MudancaEnderecoModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "MudancaEndereco");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "MudancaEndereco");
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
            return RedirectToAction("Index", "IdentificacaoCrianca");
        }
        

    }
}