using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Supermercado
{
    [Serializable]

    public class Gerente : Funcionário
    {
        
        public Gerente() : base()
        {
        }

        public void MenuGerente()
        {
            int escolha = 0;
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|--------------------------------|");
                Console.WriteLine("|        MENU - GERENTE          |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|    1-Apagar Funcionários       |");
                Console.WriteLine("|    2-Vender Produtos           |");
                Console.WriteLine("|    0-Sair                      |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:

                        int remover = 0;
                        Console.WriteLine(ToString());
                        Console.WriteLine("ID A REMOVER: ");
                        remover = int.Parse(Console.ReadLine());

                        GestorFuncionário.listaFuncionarios.RemoveAt(remover);

                        //CÓDIGO REMOVER NÃO ESTÁ A FUNCIONAR MAS TEM A FORMA ANTERIOR

                        /* string contactoAEliminarNome = Console.ReadLine();
                         Console.WriteLine(contactoAEliminarNome);
                         bool resultado = removeFromeEmployeeList(contactoAEliminarNome);
                         if (resultado)
                         {
                             Console.WriteLine("Eliminado com sucesso");
                         }
                         else
                         {
                             Console.WriteLine("Falhou");
                         }
                         Console.WriteLine("Clique Enter para voltar ao menu principal");*/
                        break;

                    case 2:
                        Console.WriteLine("Vender Produtos");
                        break;

                    case 0:
                   
                        LoginForm();
                        break;
                        
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }

        public override string ToString()
        {
            int i = 0;
            string result ="ID" + "   " + "Nome" + "          " + "UserName " + "      " + "PassWord" + "\n";
            foreach (Funcionário f in GestorFuncionário.listaFuncionarios)
            {
                result += i++ + f.firstName + " " + f.lastName + "     " + f.userName + "         " + f.password + " \n";
            }

            return result;



        }

        public bool removeFromeEmployeeList(string nome)
        {
            int indexAremover = -1;
            for (int i = 0; i < GestorFuncionário.listaFuncionarios.Count; i++)
            {
                if (GestorFuncionário.listaFuncionarios[i].userName.ToLower().Equals(nome.ToLower()))
                {
                    indexAremover = i;
                }
            }
            if (indexAremover != -1)
            {
                GestorFuncionário.listaFuncionarios.RemoveAt(indexAremover);
                return true;
            }
            return false;
        }
    }
}
