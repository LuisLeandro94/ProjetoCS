using Supermercado.Menus;
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

        #region Menu Gerente
        public void MenuGerente()
        {
            Funcionário f = new Funcionário();
            Repositor r = new Repositor();
            int escolha = 0;
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("##################################################");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#                 MENU - GERENTE                 #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("##################################################");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#                                                #");
                Console.WriteLine("#         1 - CRIAR FUNCIONÁRIO                  #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#------------------------------------------------#");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#         2 - APAGAR FUNCIONÁRIO                 #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#------------------------------------------------#");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#         3 - VENDER PRODUTOS                    #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#------------------------------------------------#");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#         0 - SAIR                               #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("##################################################");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:
                        f.CreateEmployee();
                        break;
                    case 2:
                        //removeFromeEmployeeList();
                        break;
                    case 0:
                        MenuInicial.InitialMenu();
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
        #endregion

        #region Override do ToString
        public override string ToString()
        {
            int i = 0;
            string result ="ID" + "   " + "Nome" + "          " + "UserName " + "      " + "PassWord" + "\n";
            try
            {
                foreach (Funcionário f in GestorFuncionário.listaFuncionarios)
                {
                    result += i++ + f.firstName + " " + f.lastName + "     " + f.userName + "         " + f.password + " \n";
                }
            }
            catch(Exception a)
            {
                return a.Message;
            }
            return result;
        }
        #endregion

        #region Remove from Employee List
        public bool removeFromeEmployeeList(string nome)
        {
            int indexAremover = -1;
            try
            {
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
            }
            catch(Exception a)
            {
                return Convert.ToBoolean(a.Message);
            }
            return false;
        }
        #endregion

        /*
         * int remover = 0;
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
    }
}
