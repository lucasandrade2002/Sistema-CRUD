using System;

namespace Sistema_de_Gerenciamento_de_Alunos
{
    class Program
    {
        static CRUD options = new CRUD();
        static void Main(string[] args)
        {
            int num = 0, decisao = 0;
            bool done = false;

            Console.Write("/* Bem-vindo(a) ao sistema! */\n");
            do
            {
                menu_opcoes:
                Console.Write("\nInforme sua opção:\n \n1-Cadastrar novo Aluno \n2-Listar Alunos \n3-Atualizar Registro \n4-Deletar Registro \n\n");
                    
                try {
                    num = Convert.ToInt32(Console.ReadLine());
                }catch(Exception e)
                {
                    Console.Write($"\nERRO: {e.Message}\n\n");
                    Console.ReadLine();
                }

                switch (num)
                {
                    case 1:
                        getNomeAluno();
                        break;
                    case 2:
                        options.listar_Alunos();
                        break;
                    case 3:
                        getInfoAboutAluno();  
                        break;
                    case 4:
                        DeletarAluno();
                        break;
                    default:
                        Console.Clear();
                        Console.Write("\nOpção Inválida!\n");
                        goto menu_opcoes;
                }

                Console.Write("\nDeseja efetuar uma nova operação? [1-SIM/2-NÃO] ");
                try {
                    decisao = Convert.ToInt32(Console.ReadLine());

                    if (decisao == 2)
                    {
                        done = true;
                    }
                }
                catch(Exception e)
                {
                    Console.Write($"\n{e.Message}");
                }
                Console.Clear();
            } while (done == false);

        }
        static void getNomeAluno()
        {
            string nome = "";
            int escolha = 0;
            bool stop = false;

            do
            {
                Console.Write($"\nInforme o nome do aluno: ");
                nome = Console.ReadLine();

                options.cadastrar_Aluno(nome);

                Console.Write("\n\nDeseja Cadastrar um novo aluno? [1-SIM/2-NÃO] ");
                escolha = Convert.ToInt32(Console.ReadLine());

                switch (escolha)
                {
                    case 1:
                        Console.Clear();
                        break;
                    case 2:
                        stop = true;
                        break;
                }
            } while (stop == false);
        }

        public static void getInfoAboutAluno()
        {
            string nomeAntigo = "";
            string nomeAtualizado = "";

            Console.Write("\nInforme o nome do registro: ");
            nomeAntigo = Console.ReadLine();

            Console.Write("\nAgora Informe o nome atualizado: ");
            nomeAtualizado = Console.ReadLine();

            options.atualizar_Registro(nomeAntigo, nomeAtualizado);
            return;
        }

        public static void DeletarAluno()
        {
            string nomeAluno = "";

            Console.Write("\nInforme o nome do aluno que quer apagar: ");
            nomeAluno = Console.ReadLine();

            options.deletar_Registro(nomeAluno);

            return;
        }
    }
}
