using System;
using System.Collections.Generic;
using System.Text;

namespace Sistema_de_Gerenciamento_de_Alunos
{
    class Comandos
    {
        private string INSERT;
        private string SELECT;
        private string UPDATE;
        private string DELETE;

        public Comandos()
        {
            this.INSERT = "INSERT INTO dbo.Alunos VALUES (@nome)";
            this.SELECT = "SELECT A.* FROM dbo.Alunos A";
            this.UPDATE = "UPDATE Alunos SET Nome = @novoNome WHERE Nome = @nomeAluno";
            this.DELETE = "DELETE FROM Alunos WHERE Nome = @nomeAluno";
        }

        public string getInsert()
        {
            return this.INSERT;
        }

        public string getSelect()
        {
            return this.SELECT;
        }

        public string getUpdate()
        {
            return this.UPDATE;
        }

        public string getDelete()
        {
            return this.DELETE;
        }
    }
}
