using System;
using System.Data;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Sistema_de_Gerenciamento_de_Alunos
{
    public class CRUD
    {
        SqlCommand cmd = new SqlCommand();
        Conexao_DB conn = new Conexao_DB();
        Comandos opt = new Comandos();

        public void cadastrar_Aluno(string nome_aluno)
        {
            string nome = nome_aluno;
            string query = opt.getInsert();
            int rowsAffected = 0;

            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nome", nome);

            try
            {
                cmd.Connection = conn.Conectar();
                rowsAffected = cmd.ExecuteNonQuery();

                if(rowsAffected > 0)
                {
                    Console.Write("\nRegistro(s) efetuado com sucesso!");
                }
            }
            catch(SqlException e)
            {
                Console.Write($"ERRO: {e.Message}");
            }
            finally
            {
                conn.Desconectar();
            }
            cmd.Parameters.Clear();
        }

        public void listar_Alunos()
        {
            SqlDataReader dReader;
            string query = opt.getSelect();

            cmd.CommandText = query;

            try
            {
                cmd.Connection = conn.Conectar();
                dReader = cmd.ExecuteReader();

                Console.Write("\n=-=-=-=Lista de Alunos=-=-=-=\n");
                while (dReader.Read())
                {
                    Console.Write($"\n{dReader.GetInt32(0)} - {dReader.GetString(1)}");
                }
                Console.Write("\n");
            }
            catch(Exception error)
            {
                Console.Write($"\n{error.Message}");
            }
            finally
            {
                conn.Desconectar();
            }
        }

        public void atualizar_Registro(string nomeAluno, string novoNome)
        {
            string query = opt.getUpdate();
            int rowsAffected = 0;

            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nomeAluno", nomeAluno);
            cmd.Parameters.AddWithValue("@novoNome", novoNome);

            try
            {

                cmd.Connection = conn.Conectar();
                rowsAffected = cmd.ExecuteNonQuery();

                if(rowsAffected > 0)
                {
                    Console.Write($"\nAtualização de registro efetuada com sucesso!\n");
                }

            }catch(Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            finally
            {
                conn.Desconectar();
            }
        }

        public void deletar_Registro(string nomeAluno)
        {
            string query = opt.getDelete();
            int rowsAffected = 0;

            cmd.CommandText = query;
            cmd.Parameters.AddWithValue("@nomeAluno", nomeAluno);

            try
            {
                cmd.Connection = conn.Conectar();
                rowsAffected = cmd.ExecuteNonQuery();

                if(rowsAffected > 0)
                {
                    Console.Write($"\nRegistro deletado com sucesso!\n");
                }
            }catch(Exception e)
            {
                Console.Write($"\n{e.Message}");
            }
            finally
            {
                conn.Desconectar();
            }
        }
    }
}
