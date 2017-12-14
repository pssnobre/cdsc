using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class IdentificacaoCriancaModel
    {
        public int idCrianca { get; set; }
        public string nomeCrianca { get; set; }
        public string dataNascimento { get; set; }
        public string municipioNascimento { get; set; }
        public string nomeMae { get; set; }
        public string nomePai { get; set; }
        public string endereco { get; set; }
        public string pontoReferencia { get; set; }
        public string sexo { get; set; }
        public string telefone { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public int idUf { get; set; }
        public int idMunicipio { get; set; }
        public string etnia { get; set; }
        public string unidadeBasicaQueFrequenta { get; set; }
        public string numeroProntuarioUbs { get; set; }
        public string numeroDeclaracaoNascidoVivo { get; set; }
        public string numeroRegistroCivilNascimento { get; set; }
        public string numeroCartaoSus { get; set; }


        List<municipio> listaMunicipios = new List<municipio>();
        List<uf> listaUfs = new List<uf>();


        public static IdentificacaoCriancaModel Salvar(IdentificacaoCriancaModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();


            objCrianca.cri_ds_nome = obj.nomeCrianca;
            objCrianca.cri_dt_nascimento = Convert.ToDateTime(obj.dataNascimento);
            objCrianca.cri_nm_mae = obj.nomeMae;
            objCrianca.cri_nm_pai = obj.nomePai;
            objCrianca.cri_ds_sexo = obj.sexo;
            objCrianca.cri_ds_etnia = obj.etnia;
            objCrianca.cri_nr_prontuario = obj.numeroProntuarioUbs;
            objCrianca.cri_nr_declaração_nascido_vivo = obj.numeroDeclaracaoNascidoVivo;
            objCrianca.cri_nr_registro_civil_nascimento = obj.numeroRegistroCivilNascimento;
            objCrianca.cri_nr_cartao_sus = obj.numeroCartaoSus;
            objCrianca.cri_id_municipio_nascimento = obj.idMunicipio;
            objCrianca.cri_id_usuario_responsavel = idUsuarioLogado;

            if (objCrianca.cri_id_crianca > 0)
            {
                objBd.crianca.Attach(objCrianca);
                objBd.Entry(objCrianca).State = EntityState.Modified;
            }
            else
            {
                objBd.crianca.Add(objCrianca);
            }

            bool result = objBd.SaveChanges() > 0;


            endereco objEndereco = new endereco();
            objEndereco.end_id_crianca = objCrianca.cri_id_crianca;
            objEndereco.end_ds_endereco = obj.endereco;
            objEndereco.end_ds_ponto_referencia = obj.pontoReferencia;
            objEndereco.end_nr_telefone = obj.telefone.Replace("-", "").Replace("(", "").Replace(")", "");
            objEndereco.end_ds_bairro = obj.bairro;
            objEndereco.end_nr_cep = obj.cep.Replace("-", "");
            objEndereco.end_id_municipio = obj.idMunicipio;
            objEndereco.end_ds_unidade_basica_frequenta = obj.unidadeBasicaQueFrequenta;
            objEndereco.end_dt_data = DateTime.Now;

            objBd.endereco.Add(objEndereco);
            result = objBd.SaveChanges() > 0;

            //objEndereco.municipioNascimento = obj.municipio == null ? "" : obj.municipio.mun_ds_municipio;
            //objEndereco.idUf = obj.endereco.Last() == null ? 0 : (obj.endereco.Last().municipio == null ? 0 : (int)obj.endereco.Last().municipio.mun_id_uf);

            return ObterRegistro(idUsuarioLogado);
        }

        public static IdentificacaoCriancaModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            crianca obj = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();


            IdentificacaoCriancaModel returnObj = new IdentificacaoCriancaModel();
            returnObj.nomeCrianca = obj.cri_ds_nome;
            returnObj.dataNascimento = String.IsNullOrEmpty(obj.cri_dt_nascimento.ToString()) ? "" : obj.cri_dt_nascimento.ToString().Substring(0, 10);
            returnObj.municipioNascimento = obj.municipio == null ? "" : obj.municipio.mun_ds_municipio;
            returnObj.nomeMae = obj.cri_nm_mae;
            returnObj.nomePai = obj.cri_nm_pai;
            returnObj.endereco = obj.endereco.Count == 0 ? "" : obj.endereco.Last().end_ds_endereco;
            returnObj.pontoReferencia = obj.endereco.Count == 0 ? "" : obj.endereco.Last().end_ds_ponto_referencia;
            returnObj.sexo = obj.cri_ds_sexo;
            returnObj.telefone = obj.endereco.Count == 0 ? "" : obj.endereco.Last().end_nr_telefone;
            returnObj.bairro = obj.endereco.Count == 0 ? "" : obj.endereco.Last().end_ds_bairro;
            returnObj.cep = obj.endereco.Count == 0 ? "" : obj.endereco.Last().end_nr_cep;
            returnObj.idUf = obj.endereco.Count == 0 ? 0 : (obj.endereco.Last().municipio == null ? 0 : (int)obj.endereco.Last().municipio.mun_id_uf);
            returnObj.idMunicipio = obj.endereco.Count == 0 ? 0 : (obj.endereco.Last().municipio == null ? 0 : (int)obj.endereco.Last().end_id_municipio);
            returnObj.etnia = obj.cri_ds_etnia;
            returnObj.unidadeBasicaQueFrequenta = obj.endereco.Count == 0 ? "" : obj.endereco.Last().end_ds_unidade_basica_frequenta;
            returnObj.numeroProntuarioUbs = obj.cri_nr_prontuario;
            returnObj.numeroDeclaracaoNascidoVivo = obj.cri_nr_declaração_nascido_vivo;
            returnObj.numeroRegistroCivilNascimento = obj.cri_nr_registro_civil_nascimento;
            returnObj.numeroCartaoSus = obj.cri_nr_cartao_sus;

            return returnObj;
        }



    }
}