using CDSC.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class VigilanciaDesenvolvimentoModel
    {
        public VigilanciaDesenvolvimentoModel()
        {
            this.listaMarcadores = new HashSet<marcador_desenvolvimento>();
            //this.listaMarcadoresCrianca = new HashSet<marcador_desenvolvimento_crianca>();
        }

        public int idCrianca { get; set; }
        public int idMarcador { get; set; }
        public int idade { get; set; }
        public string statusMarcador { get; set; }
        public string descricaoMarcador { get; set; }
        public virtual ICollection<marcador_desenvolvimento> listaMarcadores { get; set; }
        public virtual List<MarcadorDeDesenvolvimentoCriancaViewModel> listaMarcadoresCrianca { get; set; }




        public static VigilanciaDesenvolvimentoModel Salvar(VigilanciaDesenvolvimentoModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            int idUsuarioLogado = UsuarioModel.ObterUsuarioSessao().idUsuario;
            crianca objCrianca = objBd.crianca.Where(x => x.cri_id_usuario_responsavel == idUsuarioLogado).FirstOrDefault() ?? new crianca();

            marcador_desenvolvimento_crianca objMarcadorCrianca = new marcador_desenvolvimento_crianca();
            objMarcadorCrianca.mdc_id_crianca = objCrianca.cri_id_crianca;
            objMarcadorCrianca.mdc_id_marcador = obj.idMarcador;
            objMarcadorCrianca.mdc_nr_idade = obj.idade;
            objMarcadorCrianca.mdc_ds_status = obj.statusMarcador;

            objBd.marcador_desenvolvimento_crianca.Add(objMarcadorCrianca);
            bool result = objBd.SaveChanges() > 0;


            return new VigilanciaDesenvolvimentoModel();
        }

        public static List<marcador_desenvolvimento> ListaMarcadores()
        {
            cdscEntities objBd = new cdscEntities();
            return objBd.marcador_desenvolvimento.ToList();
        }

        public static List<marcador_desenvolvimento_crianca> ListaMarcadoresCrianca(int idCrianca)
        {
            cdscEntities objBd = new cdscEntities();
            return objBd.marcador_desenvolvimento_crianca.Where(x => x.mdc_id_crianca == idCrianca).ToList();
        }

        private static MarcadorDeDesenvolvimentoCriancaViewModel PreencherStatusLinhaMarcador(MarcadorDeDesenvolvimentoCriancaViewModel linhaMarcador, int idade, string status)
        {
            if (status == "1")
            {
                status = "P";
            }
            else if (status == "2")
            {
                status = "A";
            }
            else
            {
                status = "NV";
            }


            if (idade == 1)
            {
                linhaMarcador.statusMarcadorMes1 = status;
            }
            else if (idade == 2)
            {
                linhaMarcador.statusMarcadorMes2 = status;
            }
            else if (idade == 3)
            {
                linhaMarcador.statusMarcadorMes3 = status;
            }
            else if (idade == 4)
            {
                linhaMarcador.statusMarcadorMes4 = status;
            }
            else if (idade == 5)
            {
                linhaMarcador.statusMarcadorMes5 = status;
            }
            else if (idade == 6)
            {
                linhaMarcador.statusMarcadorMes6 = status;
            }
            else if (idade == 7)
            {
                linhaMarcador.statusMarcadorMes7 = status;
            }
            else if (idade == 8)
            {
                linhaMarcador.statusMarcadorMes8 = status;
            }
            else if (idade == 9)
            {
                linhaMarcador.statusMarcadorMes9 = status;
            }
            else if (idade == 10)
            {
                linhaMarcador.statusMarcadorMes10 = status;
            }
            else if (idade == 11)
            {
                linhaMarcador.statusMarcadorMes11 = status;
            }
            else if (idade == 12)
            {
                linhaMarcador.statusMarcadorMes12 = status;
            }
            else
            {
                //linhaMarcador.statusMarcadorMes12 = "";
            }

            return linhaMarcador;
        }



        public static VigilanciaDesenvolvimentoModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();
            crianca cri = objBd.crianca.FirstOrDefault(x => x.cri_id_usuario_responsavel == idUsuario);
            VigilanciaDesenvolvimentoModel objVdm = new VigilanciaDesenvolvimentoModel();

            List<MarcadorDeDesenvolvimentoCriancaViewModel> listaMarcadores = new List<MarcadorDeDesenvolvimentoCriancaViewModel>();
            List<marcador_desenvolvimento_crianca> listaMarcadoresCricancaBd = ListaMarcadoresCrianca(cri.cri_id_crianca);


            foreach (marcador_desenvolvimento_crianca item in listaMarcadoresCricancaBd)
            {
                MarcadorDeDesenvolvimentoCriancaViewModel linhaMarcador = new MarcadorDeDesenvolvimentoCriancaViewModel();
                if (!listaMarcadores.Any(x => x.idMarcador == item.mdc_id_marcador))
                {
                    linhaMarcador.idMarcador = item.mdc_id_marcador;
                    linhaMarcador.idCrianca = item.mdc_id_crianca;
                    linhaMarcador.descricaoMarcador = item.marcador_desenvolvimento.mdv_ds_marcador;
                    listaMarcadores.Add(linhaMarcador);
                    int idade = item.mdc_nr_idade ?? 0;
                    PreencherStatusLinhaMarcador(linhaMarcador, idade, item.mdc_ds_status);
                }
                else
                {
                    linhaMarcador = listaMarcadores.FirstOrDefault(x => x.idMarcador == item.mdc_id_marcador);
                    int idade = item.mdc_nr_idade ?? 0;
                    PreencherStatusLinhaMarcador(linhaMarcador, idade, item.mdc_ds_status);
                }
            }

            objVdm.listaMarcadoresCrianca = listaMarcadores;



            //objVdm.listaMarcadores = new List<marcador_desenvolvimento>();
            //objVdm.listaMarcadores = objBd.marcador_desenvolvimento.ToList();
            //objVdm.listaMarcadoresCrianca = new List<marcador_desenvolvimento_crianca>();
            //objVdm.listaMarcadoresCrianca = objBd.marcador_desenvolvimento_crianca.Where(x => x.mdc_id_crianca == cri.cri_id_crianca).ToList();


            //agrupar as linhas no objeto do ViewModel

            // cada objeto marcador, objeto do ViewModel (linha da tabela), vai possuir diversas idades e um status para cada idade dessas

            //https://stackoverflow.com/questions/2243898/displaying-standard-datatables-in-mvc


            return objVdm;
        }

    }


    public class MarcadorDeDesenvolvimentoCriancaViewModel
    {
        
        public int idCrianca { get; set; }
        public int idMarcador { get; set; }
        public int idade { get; set; }
        public string statusMarcador { get; set; }
        public string descricaoMarcador { get; set; }


        public string statusMarcadorMes1 { get; set; }
        public string statusMarcadorMes2 { get; set; }
        public string statusMarcadorMes3 { get; set; }
        public string statusMarcadorMes4 { get; set; }
        public string statusMarcadorMes5 { get; set; }
        public string statusMarcadorMes6 { get; set; }
        public string statusMarcadorMes7 { get; set; }
        public string statusMarcadorMes8 { get; set; }
        public string statusMarcadorMes9 { get; set; }
        public string statusMarcadorMes10 { get; set; }
        public string statusMarcadorMes11 { get; set; }
        public string statusMarcadorMes12 { get; set; }


    }


}