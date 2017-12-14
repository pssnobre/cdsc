using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class DadosRecemNascidoModel
    {
        //nascimento
        public int idCrianca { get; set; }
        public string horaNascimento { get; set; }
        public string dataNascimento { get; set; }
        public string maternidade { get; set; }
        public int idUf { get; set; }
        public int idMunicipio { get; set; }
        public float peso { get; set; }
        public float comprimento { get; set; }
        public float perimetroEncefalico { get; set; }
        public string sexo { get; set; }
        public string apagar1Minuto { get; set; }
        public string apagar5minuto { get; set; }
        public int idadeGestacionalSemanas { get; set; }
        public int idadeGestacionalDias { get; set; }
        public string metodoAvaliacaoIg { get; set; }
        public string tipoSanguineo { get; set; }
        public string tipoSanguineoMae { get; set; }
        public string aleitamentoPrimeiraHora { get; set; }
        public string profissionalAssistiu { get; set; }

        //exames

        public string statusManobraOrtolani { get; set; }
        public string condutaManobraOrtolani { get; set; }
        public string statusTesteReflexoVermelho { get; set; }
        public string condutaTesteReflexoVermelho { get; set; }
        public string statusTestePezinho { get; set; }
        public string dataTestePezinho { get; set; }
        public string statusFenilcitonuria { get; set; }
        public string statusHipotireoidismo { get; set; }
        public string statusAnemiaFalciforme { get; set; }
        public string descricaoOutros { get; set; }
        public string statusTriagemAuditiva { get; set; }
        public string dataTriagemAuditiva { get; set; }
        public string descricaoTestesAuditivos { get; set; }
        public string statusResultadoOd { get; set; }
        public string statusResultadoOe { get; set; }
        public string descricaoTriagemAuditiva { get; set; }
        public string statusReteste { get; set; }
        public string dataReteste { get; set; }
        public string descricaoTestesAuditivosReteste { get; set; }
        public string statusResultadoOdReteste { get; set; }
        public string statusResultadoOeReteste { get; set; }
        public string descricaoTriagemAuditivaReteste { get; set; }


        //dados na alta

        public string dataAlta { get; set; }
        public float pesoNaAlta { get; set; }
        public string descricaoAlimentacao { get; set; }
        public string descricaoAnotacoes { get; set; }

        public static DadosRecemNascidoModel Salvar(DadosRecemNascidoModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            DadosRecemNascidoModel returnObj = new DadosRecemNascidoModel();
            nascimento objNascimento = objBd.nascimento.FirstOrDefault(x => x.nas_id_crianca == objCrianca.cri_id_crianca) ?? new nascimento();
            objNascimento.nas_id_crianca = objCrianca.cri_id_crianca;

            //nascimento
            if (!String.IsNullOrEmpty(obj.dataNascimento) && !String.IsNullOrEmpty(obj.horaNascimento))
            {
                string dataNascimento = obj.dataNascimento;
                string anoNascimento = dataNascimento.Substring(6,4);
                string mesNascimento = dataNascimento.Substring(3,2);
                string diaNascimento = dataNascimento.Substring(0,2);
                string horaNascimento = obj.horaNascimento.Substring(0,2);
                string minutoNascimento = obj.horaNascimento.Substring(3,2);
                objNascimento.nas_dt_nascimento = new DateTime(Convert.ToInt32(anoNascimento), Convert.ToInt32(mesNascimento), Convert.ToInt32(diaNascimento), Convert.ToInt32(horaNascimento), Convert.ToInt32(minutoNascimento), 00);

            }

            objNascimento.nas_nr_hora_nascimento = obj.horaNascimento;
            objNascimento.nas_ds_maternidade = obj.maternidade;
            objNascimento.nas_id_municipio = obj.idMunicipio;
            objNascimento.nas_nr_peso = obj.peso;
            objNascimento.nas_nr_comprimento = obj.comprimento;
            objNascimento.nas_nr_perimetro_encefalico = obj.perimetroEncefalico;
            objNascimento.nas_ds_sexo = obj.sexo;
            objNascimento.nas_ds_apagar_1_min = obj.apagar1Minuto;
            objNascimento.nas_ds_apagar_5_min = obj.apagar5minuto;
            objNascimento.nas_nr_idade_gestacional_semanas = obj.idadeGestacionalSemanas;
            objNascimento.nas_nr_idade_gestacional_dias = obj.idadeGestacionalDias;
            objNascimento.nas_ds_metodo_avaliacao_ig = obj.metodoAvaliacaoIg;
            objNascimento.nas_ds_tipo_sanguineo = obj.tipoSanguineo;
            objNascimento.nas_ds_tipo_sanguineo_mae = obj.tipoSanguineoMae;
            objNascimento.nas_st_aleitamento_primeira_hora = obj.aleitamentoPrimeiraHora;
            objNascimento.nas_ds_profissional_assistiu = obj.profissionalAssistiu;
            objNascimento.nas_id_crianca = objCrianca.cri_id_crianca;

            if (objNascimento.nas_id_nascimento > 0)
            {
                objBd.nascimento.Attach(objNascimento);
                objBd.Entry(objNascimento).State = EntityState.Modified;
            }
            else
            {
                objBd.nascimento.Add(objNascimento);
            }

            bool result = objBd.SaveChanges() > 0;


            //exames e triagem neonatal
            exames_triagem_neonatal objExamesTriagem = objBd.exames_triagem_neonatal.FirstOrDefault(x => x.etni_id_crianca == objCrianca.cri_id_crianca) ?? new exames_triagem_neonatal();
            objExamesTriagem.etn_st_manobra_ortolani = obj.statusManobraOrtolani;
            objExamesTriagem.etn_ds_conduta_ortolani = obj.condutaManobraOrtolani;
            objExamesTriagem.etn_st_teste_reflexo_vermelho = obj.statusTesteReflexoVermelho;
            objExamesTriagem.etn_ds_conduta_reflexo_vermelho = obj.condutaTesteReflexoVermelho;
            objExamesTriagem.etn_st_teste_pezinho = obj.statusTestePezinho;
            objExamesTriagem.etn_dt_teste_pezinho = Convert.ToDateTime(obj.dataTestePezinho);
            objExamesTriagem.etn_st_fenilcitonuria = obj.statusFenilcitonuria;
            objExamesTriagem.etn_st_hipotireoidismo = obj.statusHipotireoidismo;
            objExamesTriagem.etn_st_anemia_falciforme = obj.statusAnemiaFalciforme;
            objExamesTriagem.etn_ds_outros = obj.descricaoOutros;
            objExamesTriagem.etn_st_triagem_auditiva = obj.statusTriagemAuditiva;
            objExamesTriagem.etn_dt_triagem_auditiva = Convert.ToDateTime(obj.dataTriagemAuditiva);
            objExamesTriagem.etn_ds_testes_realizados_auditivos = obj.descricaoTestesAuditivos;
            objExamesTriagem.etn_st_resultado_od = obj.statusResultadoOd;
            objExamesTriagem.etn_st_resultado_oe = obj.statusResultadoOe;
            objExamesTriagem.etn_ds_conduta_triagem_auditiva = obj.descricaoTriagemAuditiva;
            objExamesTriagem.etn_st_resultado_od_reteste = obj.statusResultadoOdReteste;
            objExamesTriagem.etn_st_resultado_oe_reteste = obj.statusResultadoOeReteste;
            objExamesTriagem.etn_ds_outros = obj.descricaoOutros;
            objExamesTriagem.etn_ds_conduta_triagem_auditiva_reteste = obj.descricaoTriagemAuditivaReteste;
            objExamesTriagem.etn_st_reteste = obj.statusReteste;
            objExamesTriagem.etn_dt_reteste = Convert.ToDateTime(obj.dataReteste);
            objExamesTriagem.etn_ds_testes_realizados_auditivos_reteste = obj.descricaoTestesAuditivosReteste;
            objExamesTriagem.etni_id_crianca = objCrianca.cri_id_crianca;

            if (objExamesTriagem.etn_id_exames_neonatal > 0)
            {
                objBd.exames_triagem_neonatal.Attach(objExamesTriagem);
                objBd.Entry(objExamesTriagem).State = EntityState.Modified;
            }
            else
            {
                objBd.exames_triagem_neonatal.Add(objExamesTriagem);
            }

            result = objBd.SaveChanges() > 0;


            //dados alta
            dados_alta objDadosAlta = objBd.dados_alta.FirstOrDefault(x => x.ddai_id_crianca == objCrianca.cri_id_crianca) ?? new dados_alta();
            objDadosAlta.dda_dt_alta = Convert.ToDateTime(obj.dataAlta);
            objDadosAlta.dda_nr_peso = obj.pesoNaAlta;
            objDadosAlta.dda_ds_alimentacao = obj.descricaoAlimentacao;
            objDadosAlta.dda_ds_anotacoes = obj.descricaoAnotacoes;
            objDadosAlta.ddai_id_crianca = objCrianca.cri_id_crianca;

            if (objDadosAlta.dda_id_alta > 0)
            {
                objBd.dados_alta.Attach(objDadosAlta);
                objBd.Entry(objDadosAlta).State = EntityState.Modified;
            }
            else
            {
                objBd.dados_alta.Add(objDadosAlta);
            }

            result = objBd.SaveChanges() > 0;

            return ObterRegistro(idUsuarioLogado);
        }

        public static DadosRecemNascidoModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();

            DadosRecemNascidoModel returnObj = new DadosRecemNascidoModel();
            nascimento objNascimento = objBd.nascimento.FirstOrDefault(x => x.nas_id_crianca == objCrianca.cri_id_crianca) ?? new nascimento();
            returnObj.idCrianca = objCrianca.cri_id_crianca;

            //nascimento
            //returnObj.horaNascimento = String.IsNullOrEmpty(objNascimento.nas_dt_nascimento.ToString()) ? "" : objNascimento.nas_dt_nascimento.ToString().Substring(10,5);
            returnObj.horaNascimento = String.IsNullOrEmpty(objNascimento.nas_nr_hora_nascimento) ? "" : objNascimento.nas_nr_hora_nascimento.ToString();
            returnObj.dataNascimento = String.IsNullOrEmpty(objNascimento.nas_dt_nascimento.ToString()) ? "" : objNascimento.nas_dt_nascimento.ToString().Substring(0,10);
            returnObj.maternidade = objNascimento.nas_ds_maternidade;
            returnObj.idUf = objNascimento.municipio == null ? 0 : objNascimento.municipio.mun_id_uf ?? 0;
            returnObj.idMunicipio = objNascimento.nas_id_municipio;
            returnObj.peso = objNascimento.nas_nr_peso ?? 0;
            returnObj.comprimento = objNascimento.nas_nr_comprimento ?? 0;
            returnObj.perimetroEncefalico = objNascimento.nas_nr_perimetro_encefalico ?? 0;
            returnObj.sexo = objNascimento.nas_ds_sexo;
            returnObj.apagar1Minuto = objNascimento.nas_ds_apagar_1_min;
            returnObj.apagar5minuto = objNascimento.nas_ds_apagar_5_min;
            returnObj.idadeGestacionalSemanas = objNascimento.nas_nr_idade_gestacional_semanas ?? 0;
            returnObj.idadeGestacionalDias = objNascimento.nas_nr_idade_gestacional_dias ?? 0;
            returnObj.metodoAvaliacaoIg = objNascimento.nas_ds_metodo_avaliacao_ig;
            returnObj.tipoSanguineo = objNascimento.nas_ds_tipo_sanguineo;
            returnObj.tipoSanguineoMae = objNascimento.nas_ds_tipo_sanguineo_mae;
            returnObj.aleitamentoPrimeiraHora = objNascimento.nas_st_aleitamento_primeira_hora;
            returnObj.profissionalAssistiu = objNascimento.nas_ds_profissional_assistiu;

            //exames e triagem neonatal
            exames_triagem_neonatal objExamesTriagem = objBd.exames_triagem_neonatal.FirstOrDefault(x => x.etni_id_crianca == objCrianca.cri_id_crianca) ?? new exames_triagem_neonatal();
            returnObj.statusManobraOrtolani = objExamesTriagem.etn_st_manobra_ortolani;
            returnObj.condutaManobraOrtolani = objExamesTriagem.etn_ds_conduta_ortolani;
            returnObj.statusTesteReflexoVermelho = objExamesTriagem.etn_st_teste_reflexo_vermelho;
            returnObj.condutaTesteReflexoVermelho = objExamesTriagem.etn_ds_conduta_reflexo_vermelho;
            returnObj.statusTestePezinho = objExamesTriagem.etn_st_teste_pezinho;
            returnObj.dataTestePezinho = String.IsNullOrEmpty(objExamesTriagem.etn_dt_teste_pezinho.ToString()) ? "" : objExamesTriagem.etn_dt_teste_pezinho.ToString().Substring(0,10);
            returnObj.statusFenilcitonuria = objExamesTriagem.etn_st_fenilcitonuria;
            returnObj.statusHipotireoidismo = objExamesTriagem.etn_st_hipotireoidismo;
            returnObj.statusAnemiaFalciforme = objExamesTriagem.etn_st_anemia_falciforme;
            returnObj.descricaoOutros = objExamesTriagem.etn_ds_outros;
            returnObj.statusTriagemAuditiva = objExamesTriagem.etn_st_triagem_auditiva;
            returnObj.dataTriagemAuditiva = String.IsNullOrEmpty(objExamesTriagem.etn_dt_triagem_auditiva.ToString()) ? "" : objExamesTriagem.etn_dt_triagem_auditiva.ToString().Substring(0, 10);
            returnObj.descricaoTestesAuditivos = objExamesTriagem.etn_ds_testes_realizados_auditivos;
            returnObj.statusResultadoOd = objExamesTriagem.etn_st_resultado_od;
            returnObj.statusResultadoOe = objExamesTriagem.etn_st_resultado_oe;
            returnObj.descricaoTriagemAuditiva = objExamesTriagem.etn_ds_conduta_triagem_auditiva;
            returnObj.statusResultadoOdReteste = objExamesTriagem.etn_st_resultado_od_reteste;
            returnObj.statusResultadoOeReteste = objExamesTriagem.etn_st_resultado_oe_reteste;
            returnObj.descricaoOutros = objExamesTriagem.etn_ds_outros;
            returnObj.descricaoTriagemAuditivaReteste = objExamesTriagem.etn_ds_conduta_triagem_auditiva_reteste;

            returnObj.statusReteste = objExamesTriagem.etn_st_reteste;
            returnObj.dataReteste = String.IsNullOrEmpty(objExamesTriagem.etn_dt_reteste.ToString()) ? "" : objExamesTriagem.etn_dt_reteste.ToString().Substring(0, 10);
            returnObj.descricaoTestesAuditivosReteste = objExamesTriagem.etn_ds_testes_realizados_auditivos_reteste;

            //dados alta
            dados_alta objDadosAlta = objBd.dados_alta.FirstOrDefault(x => x.ddai_id_crianca == objCrianca.cri_id_crianca) ?? new dados_alta();
            returnObj.dataAlta = String.IsNullOrEmpty(objDadosAlta.dda_dt_alta.ToString()) ? "" : objDadosAlta.dda_dt_alta.ToString().Substring(0, 10);
            returnObj.pesoNaAlta = objDadosAlta.dda_nr_peso ?? 0;
            returnObj.descricaoAlimentacao = objDadosAlta.dda_ds_alimentacao;
            returnObj.descricaoAnotacoes = objDadosAlta.dda_ds_anotacoes;

            return returnObj;

        }


    }
}