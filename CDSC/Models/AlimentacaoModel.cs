using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class AlimentacaoModel
    {
        public int idCrianca { get; set; }
        public int idAlimentacao { get; set; }
        public string data { get; set; }
        public string descricao { get; set; }
        public virtual List<AlimentacaoModel> listaAlimenatcoes { get; set; }


        public static AlimentacaoModel Salvar(AlimentacaoModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            alimentacao_crianca objAlimentacaoCrianca = new alimentacao_crianca();
            objAlimentacaoCrianca.alc_id_crianca = objCrianca.cri_id_crianca;
            objAlimentacaoCrianca.alc_dt_data = Convert.ToDateTime(obj.data);
            objAlimentacaoCrianca.alc_ds_alimentacao = obj.descricao;

            objBd.alimentacao_crianca.Add(objAlimentacaoCrianca);
            bool result = objBd.SaveChanges() > 0;

            return new AlimentacaoModel();
        }

        public static AlimentacaoModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            AlimentacaoModel returnObj = new AlimentacaoModel();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            returnObj.listaAlimenatcoes = ListaAlimentacoesRegistradas(objCrianca.cri_id_crianca);
            return returnObj;
        }

        public static List<AlimentacaoModel> ListaAlimentacoesRegistradas(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<AlimentacaoModel> lista = new List<AlimentacaoModel>();
            List<alimentacao_crianca> listBd = objBd.alimentacao_crianca.Where(x => x.alc_id_crianca == idCrianca).ToList();

            foreach (alimentacao_crianca item in listBd)
            {
                lista.Add(new AlimentacaoModel()
                {
                    data = String.IsNullOrEmpty(item.alc_dt_data.ToString()) ? "" : item.alc_dt_data.ToString().Substring(0, 10),
                    descricao = item.alc_ds_alimentacao
                });
            }

            return lista.OrderBy(x => x.data).ToList();
        }
    }
}