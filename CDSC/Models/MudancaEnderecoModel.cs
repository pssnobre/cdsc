using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MudancaEnderecoModel
    {
        public int idCrianca { get; set; }
        public string data { get; set; }
        public string endereco { get; set; }
        public string pontoReferencia { get; set; }
        public string unidadeBasicaQueFrequenta { get; set; }        
        public string telefone { get; set; }
        public string bairro { get; set; }
        public string cep { get; set; }
        public int idUf { get; set; }
        public int idMunicipio { get; set; }
        public string descricaoUfMunicipio { get; set; }
        public List<MudancaEnderecoModel> listaEnderecos { get; set; }

        List<municipio> listaMunicipios = new List<municipio>();
        List<uf> listaUfs = new List<uf>();


        public static MudancaEnderecoModel Salvar(MudancaEnderecoModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();


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
            bool result = objBd.SaveChanges() > 0;


            return ObterRegistro(idUsuarioLogado);
        }

        public static MudancaEnderecoModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            MudancaEnderecoModel obj = new MudancaEnderecoModel();
            obj.listaEnderecos = Lista(idUsuario);

            return obj;
        }

        public static List<MudancaEnderecoModel> Lista(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            List<MudancaEnderecoModel> lista = new List<MudancaEnderecoModel>();
            crianca objCrianca = objBd.crianca.FirstOrDefault(x => x.cri_id_usuario_responsavel == idUsuario) ?? new crianca();

            objBd.endereco.Where(x => x.end_id_crianca == objCrianca.cri_id_crianca).ToList().ForEach(x => lista.Add(new MudancaEnderecoModel {
                data = x.end_dt_data.ToString().Substring(0, 10),
                endereco = x.end_ds_endereco,
                unidadeBasicaQueFrequenta = x.end_ds_unidade_basica_frequenta,
                descricaoUfMunicipio = x.municipio == null ? "" : x.municipio.mun_ds_municipio + "-" + x.municipio.uf.uff_ds_sigla,
                cep = x.end_nr_cep,
                idCrianca = x.end_id_crianca,
                bairro = x.end_ds_bairro,
                idMunicipio = x.end_id_municipio ?? 0,

            }));


            return lista;
        }

    }
}