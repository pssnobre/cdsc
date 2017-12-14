using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class ObservacaoModel
    {
        public int idCrianca { get; set; }
        public int idObservacao { get; set; }
        public string data { get; set; }
        public string descricaoObservacao { get; set; }
        public virtual List<ObservacaoModel> listaObservacoes { get; set; }


        public static ObservacaoModel Salvar(ObservacaoModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            outras_observacoes objObservacoes = new outras_observacoes();
            objObservacoes.obs_id_crianca = objCrianca.cri_id_crianca;
            objObservacoes.obs_dt_data = Convert.ToDateTime(obj.data);
            objObservacoes.obs_ds_anotacao = obj.descricaoObservacao;

            objBd.outras_observacoes.Add(objObservacoes);
            bool result = objBd.SaveChanges() > 0;

            return new ObservacaoModel();
        }

        public static ObservacaoModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            ObservacaoModel returnObj = new ObservacaoModel();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            returnObj.listaObservacoes = ListaOutrasObservacoes(objCrianca.cri_id_crianca);
            return returnObj;
        }

        public static List<ObservacaoModel> ListaOutrasObservacoes(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<ObservacaoModel> lista = new List<ObservacaoModel>();
            List<outras_observacoes> listBd = objBd.outras_observacoes.Where(x => x.obs_id_crianca == idCrianca).ToList();
            foreach (outras_observacoes item in listBd)
            {
                lista.Add(new ObservacaoModel()
                {
                    data = String.IsNullOrEmpty(item.obs_dt_data.ToString()) ? "" : item.obs_dt_data.ToString().Substring(0, 10),
                    descricaoObservacao = item.obs_ds_anotacao
                });
            }
            return lista;
        }

    }
}