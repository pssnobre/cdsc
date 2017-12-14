using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class VacinaModel
    {
        public int idCrianca { get; set; }
        public int idVacina { get; set; }
        public string descricaoVacina { get; set; }
        public string data { get; set; }
        public string dose { get; set; }
        public string lote { get; set; }
        public string unidade { get; set; }
        public virtual List<VacinaModel> listaVacinasRecebidas { get; set; }

        public static VacinaModel Salvar(VacinaModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            vacinas_crianca objVacinaCrianca = new vacinas_crianca();
            objVacinaCrianca.vcc_id_crianca = objCrianca.cri_id_crianca;
            objVacinaCrianca.vcc_id_vacina = obj.idVacina;
            objVacinaCrianca.vcc_dt_data = Convert.ToDateTime(obj.data);
            objVacinaCrianca.vcc_nr_dose = obj.dose;
            objVacinaCrianca.vcc_nr_lote = obj.lote;
            objVacinaCrianca.vcc_ds_unidade = obj.unidade;

            objBd.vacinas_crianca.Add(objVacinaCrianca);
            bool result = objBd.SaveChanges() > 0;

            return new VacinaModel();
        }

        public static VacinaModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            VacinaModel returnObj = new VacinaModel();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            returnObj.listaVacinasRecebidas = ObterVacinasRecebidas(objCrianca.cri_id_crianca);
            return returnObj;
        }

        public static List<vacina> ObterVacinas()
        {
            cdscEntities objBd = new cdscEntities();
            return objBd.vacina.ToList();
        }

        public static List<VacinaModel> ObterVacinasRecebidas(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<VacinaModel> lista = new List<VacinaModel>();
            List<vacinas_crianca> listBd = objBd.vacinas_crianca.Where(x => x.vcc_id_crianca == idCrianca).ToList();

            foreach (vacinas_crianca item in listBd)
            {
                lista.Add(new VacinaModel()
                {
                    idCrianca = item.vcc_id_crianca,
                    data = String.IsNullOrEmpty(item.vcc_dt_data.ToString()) ? "" : item.vcc_dt_data.ToString().Substring(0, 10),
                    descricaoVacina = item.vacina == null ? "" : item.vacina.vac_ds_vacina,
                    dose = item.vcc_nr_dose,
                    lote = item.vcc_nr_lote,
                    unidade = item.vcc_ds_unidade
                });
            }

            return lista.OrderBy(x => x.data).ToList();
        }


    }
}