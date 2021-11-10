using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LojaDTO;

namespace LojaDAL
{
    public class UsuarioDAL
    {
        /* Método cargaUsuario, retorna uma Lista de objetos usuarioDTO
         * (composta por vários atributos), vai até o BD e busca todos os usuários
         * Usamos o Try e Catch para caso de algum erro, retornar para a camada view
         * executar o método cargaUsuario (Será criado na camada DAL)*/
        
        public IList<UsuarioDTO> cargaUsuario()
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "SELECT Usu.codigo_cliente AS Codigo, Usu.nome AS Nome, Usu.login AS Login, Usu.email AS Email, Usu.senha AS Senha, Usu.Cadastro AS Cadastro, Usu.situacao AS Situacao, Usu.perfil AS Perfil FROM[Loja].[dbo].[tb_usuarios] Usu WITH(NOLOCK)";
                command.Connection = sqlConnection;

                SqlDataReader dataReader;
                IList<UsuarioDTO> usuarioDTOs = new List<UsuarioDTO>();

                sqlConnection.Open();
                dataReader = command.ExecuteReader();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        UsuarioDTO usuario = new UsuarioDTO();
                        usuario.codigo_cliente = Convert.ToInt32(dataReader["Codigo"]);
                        usuario.perfil = Convert.ToInt32(dataReader["Perfil"]);
                        usuario.Cadastro = Convert.ToDateTime(dataReader["Cadastro"]);
                        usuario.nome = Convert.ToString(dataReader["Nome"]);
                        usuario.email = Convert.ToString(dataReader["Email"]);
                        usuario.senha = Convert.ToString(dataReader["Senha"]);
                        usuario.login = Convert.ToString(dataReader["Login"]);
                        usuario.situacao = Convert.ToString(dataReader["Situacao"]);
                        usuarioDTOs.Add(usuario);
                    }
                }
                return usuarioDTOs;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
        public int InserirUsuario (UsuarioDTO Usuario)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand command = new SqlCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "INSERT INTO tb_usuarios (nome, login, email, senha, Cadastro, situacao, perfil)" +
                    "VALUES(@NOME,@LOGIN,@EMAIL,@SENHA,@CADASTRO,@SITUACAO,@PERFIL)";

                /* Parameters irá Substituir os valores  dentro do campo */

                command.Parameters.Add("NOME", System.Data.SqlDbType.VarChar).Value = Usuario.nome;
                command.Parameters.Add("LOGIN", System.Data.SqlDbType.VarChar).Value = Usuario.login;
                command.Parameters.Add("EMAIL", System.Data.SqlDbType.VarChar).Value = Usuario.email;
                command.Parameters.Add("SENHA", System.Data.SqlDbType.VarChar).Value = Usuario.senha;
                command.Parameters.Add("CADASTRO", System.Data.SqlDbType.DateTime).Value = Usuario.Cadastro;
                command.Parameters.Add("SITUACAO", System.Data.SqlDbType.NVarChar).Value = Usuario.situacao;
                command.Parameters.Add("PERFIL", System.Data.SqlDbType.Int).Value = Usuario.perfil;

                command.Connection = sqlConnection;
                sqlConnection.Open();

                int qtd = command.ExecuteNonQuery();
                return qtd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public int EditarUsuario(UsuarioDTO Usuario)
        {
            try
            {
                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = "UPDATE tb_usuarios SET nome = @NOME, login = @LOGIN, email = @EMAIL, senha = @SENHA, Cadastro = @CADASTRO,situacao = @SITUACAO, perfil = @PERFIL " +
                    "WHERE codigo_cliente = @CODIGO";

                sqlCommand.Parameters.Add("NOME", System.Data.SqlDbType.VarChar).Value = Usuario.nome;
                sqlCommand.Parameters.Add("LOGIN", System.Data.SqlDbType.VarChar).Value = Usuario.login;
                sqlCommand.Parameters.Add("EMAIL", System.Data.SqlDbType.VarChar).Value = Usuario.email;
                sqlCommand.Parameters.Add("SENHA", System.Data.SqlDbType.VarChar).Value = Usuario.senha;
                sqlCommand.Parameters.Add("CADASTRO", System.Data.SqlDbType.DateTime).Value = Usuario.Cadastro;
                sqlCommand.Parameters.Add("SITUACAO", System.Data.SqlDbType.NVarChar).Value = Usuario.situacao;
                sqlCommand.Parameters.Add("PERFIL", System.Data.SqlDbType.Int).Value = Usuario.perfil;
                sqlCommand.Parameters.Add("CODIGO", System.Data.SqlDbType.Int).Value = Usuario.codigo_cliente;

                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();

                int qtd = sqlCommand.ExecuteNonQuery();
                return qtd;
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

                SqlConnection sqlConnection = new SqlConnection();
                sqlConnection.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.CommandText = "DELETE tb_usuarios WHERE codigo_cliente = @CODIGO";

                sqlCommand.Parameters.Add("CODIGO", System.Data.SqlDbType.Int).Value = Usuario.codigo_cliente;
            
                sqlCommand.Connection = sqlConnection;
                sqlConnection.Open();

                int qtd = sqlCommand.ExecuteNonQuery();
                return qtd;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
