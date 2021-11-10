using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDTO;
using LojaDAL;

namespace LojaBLL
{
    public class UsuarioBLL
    {
        /* Método cargaUsuario, retorna uma Lista de objetos usuarioDTO
         * (composta por vários atributos), vai até o BD e busca todos os usuários
         * Usamos o Try e Catch para caso de algum erro, retornar para a camada view
         * executar o método cargaUsuario (Será criado na camada DAL)*/


        public IList<UsuarioDTO> cargaUsuario()
        {
            try
            {
                return new UsuarioDAL().cargaUsuario();

            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        /* Método InserirUsuario, inseri uma Lista de objetos usuarioDTO
         * (composta por vários atributos), vai até o BD e inseri todos os dados dos usuários
         * Usamos o Try e Catch para caso de algum erro, retornar para a camada view
         * executar o método InserirUsuario (Será criado na camada DAL)*/

        public int InserirUsuario(UsuarioDTO Usuario)
        {
            try
            {
                return new UsuarioDAL().InserirUsuario(Usuario);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EditarUsuario(UsuarioDTO Usuario)
        {
            try
            {
                return new UsuarioDAL().EditarUsuario(Usuario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int ExcluirUsuario(UsuarioDTO Usuario)
        {
            try
            {
              return new UsuarioDAL().ExcluirUsuario(Usuario);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
