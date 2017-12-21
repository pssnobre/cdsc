using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CDSC.Models;

namespace CDSC.Controllers
{
    public class IdentificacaoCriancaController : ControllerLogado
    {
        // GET: IdentificacaoCrianca
        public ActionResult Index()
        {
            //carregar o objeto com base no id do usuário logado (pode estar na sessão, classe autenticação)
            // direcionar para a view passando o objeto carregado (objeto IdentificacaoCriancaModel)

            //ViewBag.UF = new SelectList(new Dictionary<int, string>() { { 1, "BA" }, { 2, "SP" } }, "key", "value");
            //ViewBag.Municipio = new SelectList(new Dictionary<int, string>() { { 1, "Salvador" }, { 2, "Feira de Santana" } }, "key", "value");

            ViewBag.Etnia = new SelectList(new Dictionary<string, string>() { { "1", "Branca" }, { "2", "Amarela" }, { "3", "Parda" }, { "4", "Negra" }, { "5", "Indigena" } }, "key", "value");
            ViewBag.UF = new SelectList(UFModel.ObterUF(), "uff_id_uf", "uff_ds_uf");
            


            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            IdentificacaoCriancaModel identificacaoCrianca = IdentificacaoCriancaModel.ObterRegistro(idUsuarioLogado);
            identificacaoCrianca.dataNascimento = String.IsNullOrEmpty(identificacaoCrianca.dataNascimento)  ? "" : identificacaoCrianca.dataNascimento.ToString();
            ViewBag.Municipio = new SelectList(MunicipioModel.ObterMunicipio(identificacaoCrianca.idUf), "mun_id_municipio", "mun_ds_municipio");

            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(identificacaoCrianca);
        }

        public JsonResult CarregaMunicipios(int id)
        {
            SelectList municipios = new SelectList(MunicipioModel.ObterMunicipio(id), "mun_id_municipio", "mun_ds_municipio");
            ViewBag.Municipio = municipios;
            return Json(municipios);
        }

        public ActionResult Salvar(IdentificacaoCriancaModel modelObj)
        {
            try
            {
                IdentificacaoCriancaModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "IdentificacaoCrianca");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "IdentificacaoCrianca");
            }
        }
    }
}