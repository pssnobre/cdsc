using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class MedidasAntropometricasModel
    {
        public int idCrianca { get; set; }
        public string data { get; set; }
        public int idade { get; set; }
        public int peso { get; set; }
        public int estatura { get; set; }
        public int perimetroCefalico { get; set; }
        public double imc { get; set; }
        public virtual List<MedidasAntropometricasModel> listaMedidas { get; set; }


        public static MedidasAntropometricasModel Salvar(MedidasAntropometricasModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            registro_medidas_antropometricas objMedidasAntropometricas = new registro_medidas_antropometricas();
            objMedidasAntropometricas.rma_id_crianca = objCrianca.cri_id_crianca;
            objMedidasAntropometricas.rma_nr_idade = obj.idade;
            objMedidasAntropometricas.rma_nr_peso = obj.peso;
            objMedidasAntropometricas.rma_nr_estatura = obj.estatura;
            objMedidasAntropometricas.rma_dt_registro = DateTime.Now;
            objMedidasAntropometricas.rma_nr_perimetro_cefalico = obj.perimetroCefalico;

            objBd.registro_medidas_antropometricas.Add(objMedidasAntropometricas);
            bool result = objBd.SaveChanges() > 0;

            return new MedidasAntropometricasModel();
        }

        public static MedidasAntropometricasModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            MedidasAntropometricasModel returnObj = new MedidasAntropometricasModel();
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuario).FirstOrDefault() ?? new crianca();
            returnObj.listaMedidas = ObterLista(objCrianca.cri_id_crianca);
            return returnObj;
        }


        public static List<MedidasAntropometricasModel> ObterLista(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            List<MedidasAntropometricasModel> lista = new List<MedidasAntropometricasModel>();
            List<registro_medidas_antropometricas> listBd = objBd.registro_medidas_antropometricas.Where(x => x.rma_id_crianca == idCrianca).ToList();

            foreach (registro_medidas_antropometricas item in listBd)
            {
                double estaturaImc = ((double)item.rma_nr_estatura * 0.01) * ((double)item.rma_nr_estatura * 0.01);
                double pesoImc = ((double)item.rma_nr_peso * 0.001);
                estaturaImc = Math.Round(estaturaImc, 2);
                pesoImc = Math.Round(pesoImc, 2);
                double imc = (pesoImc / estaturaImc);
                imc = Math.Round(imc, 2);

                lista.Add(new MedidasAntropometricasModel() {
                    idCrianca = item.rma_id_crianca,
                    data = String.IsNullOrEmpty(item.rma_dt_registro.ToString()) ? "" : item.rma_dt_registro.ToString().Substring(0, 10),
                    idade = item.rma_nr_idade ?? 0,
                    peso = item.rma_nr_peso ?? 0,
                    estatura = item.rma_nr_estatura ?? 0,
                    perimetroCefalico = item.rma_nr_perimetro_cefalico ?? 0,
                    imc = imc
                });
            }

            return lista;
        }

    }
}