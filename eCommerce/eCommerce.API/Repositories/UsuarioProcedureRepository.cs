using eCommerce.API.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace eCommerce.API.Repositories
{
    public class UsuarioProcedureRepository : IUsuarioRepository
    {
        private IDbConnection _connection;

        public UsuarioProcedureRepository()
        {
            _connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=eCommerce;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public List<Usuario> Get()
        {
            List<Usuario> usuarios = new List<Usuario>();
            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = (SqlConnection)_connection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SelecionarUsuarios";

                _connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                while (dataReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)dataReader["Id"];
                    usuario.Nome = (string)dataReader["Nome"];
                    usuario.Email = (string)dataReader["Email"];
                    usuario.Sexo = (string)dataReader["Sexo"];
                    usuario.RG = (string)dataReader["RG"];
                    usuario.CPF = (string)dataReader["CPF"];
                    usuario.NomeMae = (string)dataReader["NomeMae"];
                    usuario.SituacaoCadastro = (string)dataReader["SituacaoCadastro"];
                    usuario.DataCadastro = (DateTimeOffset)dataReader["DataCadastro"];

                    // Adicionar o usuário à lista de resultados
                    usuarios.Add(usuario);
                }
            }
            finally
            {
                _connection.Close();
            }

            return usuarios;

        }

        public Usuario Get(int id)
        {
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = "SelecionarUsuario";
                command.Parameters.AddWithValue("@id", id);
                command.Connection = (SqlConnection)_connection;

                _connection.Open();
                SqlDataReader dataReader = command.ExecuteReader();

                if (dataReader.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)dataReader["Id"];
                    usuario.Nome = (string)dataReader["Nome"];
                    usuario.Email = (string)dataReader["Email"];
                    usuario.Sexo = (string)dataReader["Sexo"];
                    usuario.RG = (string)dataReader["RG"];
                    usuario.CPF = (string)dataReader["CPF"];
                    usuario.NomeMae = (string)dataReader["NomeMae"];
                    usuario.SituacaoCadastro = (string)dataReader["SituacaoCadastro"];
                    usuario.DataCadastro = (DateTimeOffset)dataReader["DataCadastro"];
                    return usuario;
                }

            }
            finally
            {
                _connection.Close();
            }

            return null;
        }

        public void Insert(Usuario usuario)
        {
            _connection.Open();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = (SqlConnection)_connection; 
                command.CommandText = "CadastrarUsuario";
                command.CommandType = CommandType.StoredProcedure;

                command.Parameters.AddWithValue("@nome", usuario.Nome);
                command.Parameters.AddWithValue("@email", usuario.Email);
                command.Parameters.AddWithValue("@sexo", usuario.Sexo);
                command.Parameters.AddWithValue("@rg", usuario.RG);
                command.Parameters.AddWithValue("@cpf", usuario.CPF);   
                command.Parameters.AddWithValue("@nomeMae", usuario.NomeMae);
                command.Parameters.AddWithValue("@situacaoCadastro", usuario.SituacaoCadastro);
                command.Parameters.AddWithValue("@dataCadastro", usuario.DataCadastro);

                usuario.Id = (int)command.ExecuteScalar();
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Update(Usuario usuario)
        {
            _connection.Open();

            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "AtualizarUsuario";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = (SqlConnection)_connection;


                command.Parameters.AddWithValue("@nome", usuario.Nome);
                command.Parameters.AddWithValue("@email", usuario.Email);
                command.Parameters.AddWithValue("@sexo", usuario.Sexo);
                command.Parameters.AddWithValue("@rg", usuario.RG);
                command.Parameters.AddWithValue("@cpf", usuario.CPF);
                command.Parameters.AddWithValue("@nomeMae", usuario.NomeMae);
                command.Parameters.AddWithValue("@situacaoCadastro", usuario.SituacaoCadastro);
                command.Parameters.AddWithValue("@dataCadastro", usuario.DataCadastro);

                command.Parameters.AddWithValue("@id", usuario.Id);

                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
            
             
        }

        public void Delete(int id)
        {
            _connection.Open();
            try
            {
                SqlCommand command = new SqlCommand();
                command.CommandText = "DeletarUsuario";
                command.CommandType = CommandType.StoredProcedure;
                command.Connection = (SqlConnection)_connection;
                command.Parameters.AddWithValue("@id", id);

                command.ExecuteNonQuery();
            }
            finally
            {
                _connection.Close();
            }
        }
    }
}
