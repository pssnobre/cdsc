using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class GravidezModel
    {
        //pre-natal
        public int idCrianca { get; set; }
        public int inicioPreNatal { get; set; }
        public int numeroConsultas { get; set; }
        public string statusZ21Prenatal { get; set; }
        public int periodoZ21Prenatal { get; set; }
        public string statusA53Prenatal { get; set; }
        public int periodoA53Prenatal { get; set; }
        public string statusB18 { get; set; }
        public int periodoB18 { get; set; }
        public string statusB58 { get; set; }
        public int periodoB58 { get; set; }
        public string statusImunizacaoDupla { get; set; }
        public string statusSuplementacaoFerro { get; set; }

        //parto
        public string local { get; set; }
        public string tipoParto { get; set; }
        public string indicacao { get; set; }
        public string statusZ21Parto { get; set; }
        public int periodoZ21Parto { get; set; }
        public string statusA53Parto { get; set; }
        public int periodoA53Parto { get; set; }
        public string megadoseVitaminaA { get; set; }
        public string intercorrenciasClinicas { get; set; }


        public static GravidezModel Salvar(GravidezModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();
            pre_natal objPreNatal = objBd.pre_natal.FirstOrDefault(x => x.prn_id_crianca == objCrianca.cri_id_crianca) ?? new pre_natal();

            GravidezModel returnObj = new GravidezModel();
            returnObj.idCrianca = objCrianca.cri_id_crianca;

            //pré-natal
            objPreNatal.prn_id_crianca = objCrianca.cri_id_crianca;
            objPreNatal.prn_nr_inicio_pre_natal = obj.inicioPreNatal;
            objPreNatal.prn_numero_consultas = obj.numeroConsultas;
            objPreNatal.prn_st_z21_status = obj.statusZ21Prenatal;
            objPreNatal.prn_nr_z21_periodo = obj.periodoZ21Prenatal;
            objPreNatal.prn_st_a53_status = obj.statusA53Prenatal;
            objPreNatal.prn_nr_a53_periodo = obj.periodoA53Prenatal;
            objPreNatal.prn_st_b18_status = obj.statusB18;
            objPreNatal.prn_nr_b18_periodo = obj.periodoB18;
            objPreNatal.prn_st_b18_status = obj.statusB18;
            objPreNatal.prn_nr_b18_periodo = obj.periodoB18;
            objPreNatal.prn_st_b58_status = obj.statusB58;
            objPreNatal.prn_nr_b58_periodo = obj.periodoB58;
            objPreNatal.prn_st_imunização_dupla_adulto = obj.statusImunizacaoDupla;
            objPreNatal.prn_st_suplementação_ferro = obj.statusSuplementacaoFerro;

            if (objPreNatal.prn_id_pre_natal > 0)
            {
                objBd.pre_natal.Attach(objPreNatal);
                objBd.Entry(objPreNatal).State = EntityState.Modified;
            }
            else
            {
                objBd.pre_natal.Add(objPreNatal);
            }

            bool result = objBd.SaveChanges() > 0;

            //parto e pós-parto
            parto objParto = objBd.parto.FirstOrDefault(x => x.par_id_crianca == objCrianca.cri_id_crianca) ?? new parto();

            objParto.par_id_crianca = objCrianca.cri_id_crianca;
            objParto.par_ds_local = obj.local;
            objParto.par_tp_parto = obj.tipoParto;
            objParto.par_ds_indicacao = obj.indicacao;
            objParto.par_st_z21_status = obj.statusZ21Parto;
            objParto.par_nr_z21_periodo = obj.periodoZ21Parto;
            objParto.par_st_a53_status = obj.statusA53Parto;
            objParto.par_st_a53_periodo = obj.periodoA53Parto;
            objParto.par_st_megadose_vitamina_a = obj.megadoseVitaminaA;
            objParto.par_ds_intercorrencias_clinicas = obj.intercorrenciasClinicas;


            if (objParto.par_id_parto > 0)
            {
                objBd.parto.Attach(objParto);
                objBd.Entry(objParto).State = EntityState.Modified;
            }
            else
            {
                objBd.parto.Add(objParto);
            }

            result = objBd.SaveChanges() > 0;


            return ObterRegistro(idUsuarioLogado);
        }

        public static GravidezModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            pre_natal objPreNatal = objBd.pre_natal.FirstOrDefault(x => x.prn_id_crianca == objCrianca.cri_id_crianca) ?? new pre_natal();

            GravidezModel returnObj = new GravidezModel();
            returnObj.idCrianca = objCrianca.cri_id_crianca;

            //pré-natal
            returnObj.inicioPreNatal = objPreNatal.prn_nr_inicio_pre_natal ?? 0;
            returnObj.numeroConsultas = objPreNatal.prn_numero_consultas ?? 0;
            returnObj.statusZ21Prenatal = objPreNatal.prn_st_z21_status;
            returnObj.periodoZ21Prenatal = objPreNatal.prn_nr_z21_periodo ?? 0;
            returnObj.statusA53Prenatal = objPreNatal.prn_st_a53_status;
            returnObj.periodoA53Prenatal = objPreNatal.prn_nr_a53_periodo ?? 0;
            returnObj.statusB18 = objPreNatal.prn_st_b18_status;
            returnObj.periodoB18 = objPreNatal.prn_nr_b18_periodo ?? 0;
            returnObj.statusB18 = objPreNatal.prn_st_b18_status;
            returnObj.periodoB18 = objPreNatal.prn_nr_b18_periodo ?? 0;
            returnObj.statusB58 = objPreNatal.prn_st_b58_status;
            returnObj.periodoB58 = objPreNatal.prn_nr_b58_periodo ?? 0;
            returnObj.statusImunizacaoDupla = objPreNatal.prn_st_imunização_dupla_adulto;
            returnObj.statusSuplementacaoFerro = objPreNatal.prn_st_suplementação_ferro;

            //parto e pós-parto
            parto objParto = objBd.parto.FirstOrDefault(x => x.par_id_crianca == objCrianca.cri_id_crianca) ?? new parto();
            returnObj.local = objParto.par_ds_local;
            returnObj.tipoParto = objParto.par_tp_parto;
            returnObj.indicacao = objParto.par_ds_indicacao;
            returnObj.statusZ21Parto = objParto.par_st_z21_status;
            returnObj.periodoZ21Parto = objParto.par_nr_z21_periodo ?? 0;
            returnObj.statusA53Parto = objParto.par_st_a53_status;
            returnObj.periodoA53Parto = objParto.par_st_a53_periodo ?? 0;
            returnObj.megadoseVitaminaA = objParto.par_st_megadose_vitamina_a;
            returnObj.intercorrenciasClinicas = objParto.par_ds_intercorrencias_clinicas;

            return returnObj;
        }


    }
}