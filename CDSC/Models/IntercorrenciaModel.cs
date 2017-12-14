using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class IntercorrenciaModel
    {
        public int idCrianca { get; set; }
        public int idIntercorrencia { get; set; }
        public string data { get; set; }
        public string descricaoIntercorrencia { get; set; }
        public string observacaoIntercorrencia { get; set; }
        public virtual List<IntercorrenciaModel> listaIntercorrencias { get; set; }


        public static IntercorrenciaModel Salvar(IntercorrenciaModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            intercorrencias objIntercorrencias = new intercorrencias();
            objIntercorrencias.int_id_crianca = objCrianca.cri_id_crianca;
            objIntercorrencias.int_dt_data = Convert.ToDateTime(obj.data);
            objIntercorrencias.int_ds_intercorrencia = obj.descricaoIntercorrencia;
            objIntercorrencias.int_ds_observacoes = obj.observacaoIntercorrencia;

            objBd.intercorrencias.Add(objIntercorrencias);
            bool result = objBd.SaveChanges() > 0;

            return new IntercorrenciaModel();
        }

        public static IntercorrenciaModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            IntercorrenciaModel returnObj = new IntercorrenciaModel();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            returnObj.listaIntercorrencias = ListaIntercrrenciasCrianca(objCrianca.cri_id_crianca);
            return returnObj;
        }

        public static List<IntercorrenciaModel> ListaIntercrrenciasCrianca(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<IntercorrenciaModel> lista = new List<IntercorrenciaModel>();
            List<intercorrencias> listBd = objBd.intercorrencias.Where(x => x.int_id_crianca == idCrianca).ToList();

            foreach (intercorrencias item in listBd)
            {
                lista.Add(new IntercorrenciaModel()
                {
                    data = String.IsNullOrEmpty(item.int_dt_data.ToString()) ? "" : item.int_dt_data.ToString().Substring(0, 10),
                    descricaoIntercorrencia = item.int_ds_intercorrencia,
                    observacaoIntercorrencia = item.int_ds_observacoes
                });
            }

            return lista.OrderBy(x => x.data).ToList();
        }

    }
}