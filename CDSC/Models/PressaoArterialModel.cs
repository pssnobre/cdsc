using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class PressaoArterialModel
    {
        public int idCrianca { get; set; }
        public string data { get; set; }
        public int idade { get; set; }
        public int sistolica { get; set; }
        public int distolica { get; set; }
        public string observacao { get; set; }
        public virtual List<PressaoArterialModel> listaAfericoes { get; set; }


        public static PressaoArterialModel Salvar(PressaoArterialModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            afericao_pressao_arterial objPressaoArterial = new afericao_pressao_arterial();
            objPressaoArterial.apa_id_crianca = objCrianca.cri_id_crianca;
            objPressaoArterial.apa_nr_idade = obj.idade;
            objPressaoArterial.apa_nr_pa_sistolica = obj.sistolica;
            objPressaoArterial.apa_nr_pa_distolica = obj.distolica;
            objPressaoArterial.apa_dt_data = DateTime.Now;
            objPressaoArterial.apa_ds_observacao = obj.observacao;

            objBd.afericao_pressao_arterial.Add(objPressaoArterial);
            bool result = objBd.SaveChanges() > 0;

            return new PressaoArterialModel();
        }

        public static PressaoArterialModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            PressaoArterialModel returnObj = new PressaoArterialModel();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            returnObj.listaAfericoes = ObterLista(objCrianca.cri_id_crianca);
            return returnObj;
        }

        public static List<PressaoArterialModel> ObterLista(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<PressaoArterialModel> lista = new List<PressaoArterialModel>();
            List<afericao_pressao_arterial> listBd = objBd.afericao_pressao_arterial.Where(x => x.apa_id_crianca == idCrianca).ToList();

            foreach (afericao_pressao_arterial item in listBd)
            {
                lista.Add(new PressaoArterialModel()
                {
                    idCrianca = item.apa_id_crianca ?? 0,
                    data = String.IsNullOrEmpty(item.apa_dt_data.ToString()) ? "" : item.apa_dt_data.ToString().Substring(0, 10),
                    idade = item.apa_nr_idade ?? 0,
                    sistolica = item.apa_nr_pa_sistolica ?? 0,
                    distolica = item.apa_nr_pa_distolica ?? 0,
                    observacao = item.apa_ds_observacao
                });
            }

            return lista;
        }


    }
}