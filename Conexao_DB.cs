using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace Sistema_de_Gerenciamento_de_Alunos
{
    public class Conexao_DB
    {
        SqlConnection conn = new SqlConnection();
        public Conexao_DB()
        {
            conn.ConnectionString = "Data Source=DESKTOP-WINDOWS;Initial Catalog=Escola;Integrated Security=True";
        }

        public SqlConnection Conectar()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
            {
                conn.Open();
            }
            return conn;
        }

        public void Desconectar()
        {
            if(conn.State == System.Data.ConnectionState.Open)
            {
                conn.Close();
            }
        }
    }
}
