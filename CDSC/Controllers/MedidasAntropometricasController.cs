using CDSC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace CDSC.Controllers
{
    public class MedidasAntropometricasController : ControllerLogado
    {
        public ActionResult Index()
        {
            ViewBag.Idade = new SelectList(new Dictionary<int, string>() { { 1, "1 Mês" }, { 2, "2 Meses" }, { 3, "3 Meses" }, { 4, "4 Meses" }, { 5, "5 Mês" }, { 6, "6 Meses" },
                                                                           { 7, "7 Meses" }, { 8, "8 Meses" }, { 9, "9 Meses" }, { 10, "10 Meses" }, { 11, "11 Meses" }, { 12, "12 Meses" } }, "key", "value");

            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            MedidasAntropometricasModel modelObj = MedidasAntropometricasModel.ObterRegistro(idUsuarioLogado);

            int i = 0;
            string arrayMeses = "[0,";

            foreach (var item in modelObj.listaMedidas)
            {
                arrayMeses += item.idade.ToString() + ",";
                i++;
            }
            arrayMeses = arrayMeses.Remove(arrayMeses.Length - 1);
            arrayMeses += "]";

            ViewBag.Meses = arrayMeses;



            int j = 0;
            string arrayMedidasEstatura = "[0,";


            foreach (var item in modelObj.listaMedidas)
            {
                arrayMedidasEstatura += item.estatura.ToString() + ",";
                j++;
            }
            arrayMedidasEstatura = arrayMedidasEstatura.Remove(arrayMedidasEstatura.Length - 1);
            arrayMedidasEstatura += "]";

            ViewBag.Medidas = arrayMedidasEstatura;

            int k = 0;
            string arrayPesosRegistrados = "[0,";


            foreach (var item in modelObj.listaMedidas)
            {
                arrayPesosRegistrados += item.peso.ToString() + ",";
                k++;
            }
            arrayPesosRegistrados = arrayPesosRegistrados.Remove(arrayPesosRegistrados.Length - 1);
            arrayPesosRegistrados += "]";

            ViewBag.Pesos = arrayPesosRegistrados;

            int l = 0;
            string arrayPerimetroEncefalico = "[0,";


            foreach (var item in modelObj.listaMedidas)
            {
                arrayPerimetroEncefalico += item.perimetroCefalico.ToString() + ",";
                l++;
            }
            arrayPerimetroEncefalico = arrayPerimetroEncefalico.Remove(arrayPerimetroEncefalico.Length - 1);
            arrayPerimetroEncefalico += "]";

            ViewBag.PerimetroEncefalico = arrayPerimetroEncefalico;




            ViewBag.Mensagem = TempData["mensagem"] == null ? "" : TempData["mensagem"].ToString();
            return View(modelObj);
        }

        public ActionResult Salvar(MedidasAntropometricasModel modelObj)
        {
            try
            {
                MedidasAntropometricasModel.Salvar(modelObj);
                TempData["mensagem"] = "sucesso";
                return RedirectToAction("Index", "MedidasAntropometricas");
            }
            catch (Exception)
            {
                TempData["mensagem"] = "erro";
                return RedirectToAction("Index", "MedidasAntropometricas");
            }
        }


        public ActionResult Voltar()
        {
            return RedirectToAction("Index", "VigilanciaDesenvolvimento");
        }
    }
}