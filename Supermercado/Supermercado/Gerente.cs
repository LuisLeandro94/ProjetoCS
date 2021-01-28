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
           
            
            //this.gerenteList = new List<Gerente>();
            //this.repositorList = new List<Repositor>();
        }
        
        public string g_userName { get; set; }
        public string g_password { get; set; }
        public string g_cargo { get; set; }

        public Gerente(string g_userName, string g_password)
        {
            this.userName = g_userName;
            this.password = g_password;
            this.cargo = "Gerente";
        }

        /* public override string ToString()
         {
             string result = "Nome" + "       " + "Password " + "    " + "Cargo" + "\n";
             foreach (Gerente g in this.gerenteList)
             {
                 result += g.g_userName + " " + g.g_password + "     " + g.g_cargo + "   \n";
             }

             return result;
        }
        */

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

                        Trabalhadores.trabalhadores.RemoveAt(remover);

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
            foreach (Funcionário f in Trabalhadores.trabalhadores)
            {
                result += i++ + f.firstName + " " + f.lastName + "     " + f.userName + "         " + f.password + " \n";
            }

            return result;



        }

        public bool removeFromeEmployeeList(string nome)
        {
            int indexAremover = -1;
            for (int i = 0; i < Trabalhadores.trabalhadores.Count; i++)
            {
                if (Trabalhadores.trabalhadores[i].userName.ToLower().Equals(nome.ToLower()))
                {
                    indexAremover = i;
                }
            }
            if (indexAremover != -1)
            {
                Trabalhadores.trabalhadores.RemoveAt(indexAremover);
                return true;
            }
            return false;
        }
    }
}
