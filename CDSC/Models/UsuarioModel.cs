using CDSC.Class;
using System.Data;
using System.Linq;
using System.Web;

namespace CDSC.Models
{
    public class UsuarioModel
    {
        public int idUsuario { get; set; }
        public string cpf { get; set; }
        public string nome { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string confirmacaoSenha { get; set; }
        public int idPerfil { get; set; }


        public static UsuarioModel Salvar(UsuarioModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            string senhaEncrypt = Seguranca.EncryptTripleDES(obj.senha);
            usuario usu = objBd.usuario.FirstOrDefault(x => x.usu_ds_email == obj.email && x.usu_ds_senha == senhaEncrypt) ?? new usuario();

            usu.usu_ds_email = obj.email;
            usu.usu_ds_senha = Seguranca.EncryptTripleDES(obj.senha);
            usu.usu_id_perfil = 1;


            if (usu.usu_id_usuario > 0 )
            {
                objBd.usuario.Attach(usu);
                objBd.Entry(usu).State = EntityState.Modified;
            }
            
            else
            {
                objBd.usuario.Add(usu);
            }

            bool result = objBd.SaveChanges() > 0;

            obj.idUsuario = usu.usu_id_usuario;
            obj.nome = usu.usu_ds_nome;
            obj.cpf = usu.usu_nr_cpf;
            obj.email = usu.usu_ds_email;
            obj.idPerfil = usu.usu_id_perfil;

            return obj;


            //HttpContext.Current.Session.Add("SessaoCompra", objSessaoCompra);
            //(SessaoCompraModel)HttpContext.Current.Session["SessaoCompra"]
            //HttpContext.Current.Session["SessaoCompra"] = objSessaoCompra;
        }

        public static UsuarioModel ObterRegistro(int idUsuario)
        {
            cdscEntities objBd = new cdscEntities();

            return new UsuarioModel();
        }

        public static void ReegistrarUsuarioSessao(UsuarioModel objUsuario)
        {
            if (ObterUsuarioSessao() == null)
            {
                HttpContext.Current.Session.Add("UsuarioLogado", objUsuario);
            }
            else
            {
                HttpContext.Current.Session["UsuarioLogado"] = objUsuario;
            }
        }

        public static void Logoff()
        {
            HttpContext.Current.Session["UsuarioLogado"] = null;
        }

        public static UsuarioModel ObterUsuarioSessao()
        {
            return (UsuarioModel)HttpContext.Current.Session["UsuarioLogado"];
        }

        public static bool Login(UsuarioModel obj)
        {
            cdscEntities objBd = new cdscEntities();
            string senhaEncrypt = Seguranca.EncryptTripleDES(obj.senha);
            usuario usu = objBd.usuario.FirstOrDefault(x => x.usu_ds_email == obj.email && x.usu_ds_senha == senhaEncrypt) ?? new usuario();            

            if (usu.usu_id_usuario > 0)
            {
                obj.idUsuario = usu.usu_id_usuario;
                obj.nome = usu.usu_ds_nome;
                obj.cpf = usu.usu_nr_cpf;
                obj.email = usu.usu_ds_email;
                obj.idPerfil = usu.usu_id_perfil;
                ReegistrarUsuarioSessao(obj);
                return true;
            }
            else
            {
                return false;
                //throw new System.Exception("Usuário ou senha não existem");
            }
        }

        

    }
}