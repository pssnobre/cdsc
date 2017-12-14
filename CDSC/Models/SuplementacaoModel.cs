using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class SuplementacaoModel
    {
        public int idCrianca { get; set; }
        public string suplementacaoFerroData { get; set; }
        public string suplementacaoFerroLocal { get; set; }
        public string suplementacaoVitaminaAData { get; set; }
        public string suplementacaoVitaminaALocal { get; set; }

        public virtual List<SuplementacaoFerroViewModel> listaSuplementacaoFerro { get; set; }
        public virtual List<SuplementacaoVitaminaAViewModel> listaSuplementacaoVitaminaA { get; set; }

        public static SuplementacaoModel Salvar(SuplementacaoModel obj)
        {
            return new SuplementacaoModel();
        }

        public static SuplementacaoModel AdicionarSuplementacaoFerro(String suplementacaoFerroData, String suplementacaoFerroLocal)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            suplementacao_ferro objSuplementacaoFerro = new suplementacao_ferro();
            objSuplementacaoFerro.suf_id_crianca = objCrianca.cri_id_crianca;
            objSuplementacaoFerro.suf_dt_suplementacao = Convert.ToDateTime(suplementacaoFerroData);
            objSuplementacaoFerro.suf_ds_local = suplementacaoFerroLocal;
            objBd.suplementacao_ferro.Add(objSuplementacaoFerro);
            bool result = objBd.SaveChanges() > 0;

            return ObterRegistro(idUsuarioLogado);
        }

        public static SuplementacaoModel AdicionarSuplementacaoVitaminaA(String suplementacaoVitaminaAData, String suplementacaoVitaminaALocal)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            suplementacao_vitamina_a objSuplementacaoVitaminaA = new suplementacao_vitamina_a();
            objSuplementacaoVitaminaA.sva_id_crianca = objCrianca.cri_id_crianca;
            objSuplementacaoVitaminaA.sva_dt_data = Convert.ToDateTime(suplementacaoVitaminaAData);
            objSuplementacaoVitaminaA.sva_ds_local = suplementacaoVitaminaALocal;
            objBd.suplementacao_vitamina_a.Add(objSuplementacaoVitaminaA);
            bool result = objBd.SaveChanges() > 0;

            return ObterRegistro(idUsuarioLogado);
        }



        public static SuplementacaoModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            SuplementacaoModel returnObj = new SuplementacaoModel();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            returnObj.listaSuplementacaoFerro = ObterListaSuplementacoesFerro(objCrianca.cri_id_crianca);
            returnObj.listaSuplementacaoVitaminaA = ObterListaSuplementacoesVitaminaA(objCrianca.cri_id_crianca);
            return returnObj;
        }


        public static List<SuplementacaoFerroViewModel> ObterListaSuplementacoesFerro(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<SuplementacaoFerroViewModel> lista = new List<SuplementacaoFerroViewModel>();
            List<suplementacao_ferro> listBd = objBd.suplementacao_ferro.Where(x => x.suf_id_crianca == idCrianca).ToList();

            foreach (suplementacao_ferro item in listBd)
            {
                lista.Add(new SuplementacaoFerroViewModel()
                {
                    suplementacaoFerroLocal = item.suf_ds_local,
                    suplementacaoFerroData = String.IsNullOrEmpty(item.suf_dt_suplementacao.ToString()) ? "" : item.suf_dt_suplementacao.ToString().Substring(0, 10)
                });
            }

            return lista.OrderBy(x => x.suplementacaoFerroData).ToList();
        }

        public static List<SuplementacaoVitaminaAViewModel> ObterListaSuplementacoesVitaminaA(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<SuplementacaoVitaminaAViewModel> lista = new List<SuplementacaoVitaminaAViewModel>();
            List<suplementacao_vitamina_a> listBd = objBd.suplementacao_vitamina_a.Where(x => x.sva_id_crianca == idCrianca).ToList();

            foreach (suplementacao_vitamina_a item in listBd)
            {
                lista.Add(new SuplementacaoVitaminaAViewModel()
                {
                    suplementacaoVitaminaAData = item.sva_ds_local,
                    suplementacaoVitaminaALocal = String.IsNullOrEmpty(item.sva_dt_data.ToString()) ? "" : item.sva_dt_data.ToString().Substring(0, 10)
                });
            }

            return lista.OrderBy(x => x.suplementacaoVitaminaAData).ToList();
        }



    }

    public class SuplementacaoFerroViewModel
    {
        public string suplementacaoFerroData { get; set; }
        public string suplementacaoFerroLocal { get; set; }

    }

    public class SuplementacaoVitaminaAViewModel
    {
        public string suplementacaoVitaminaAData { get; set; }
        public string suplementacaoVitaminaALocal { get; set; }

    }


}