using Supermercado.Data;
using Supermercado.Menus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Supermercado
{
    [Serializable]

    public class Gerente : Funcionario
    {
        
        public Gerente() : base()
        {
        }

        #region Menu Gerente
        public void MenuGerente(Funcionario funcionario)
        {
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
                Console.WriteLine("#         4 - LISTAR FATURAS                     #");
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
                        funcionario.CreateEmployee();
                        break;
                    case 2:
                        GestorFuncionario.EscolhaRemover();
                        break;
                    case 3:
                        Vendas.Venda(funcionario);
                        break;
                    case 4:
                        GestorFaturas.ListarFaturasConsole();
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
                foreach (Funcionario f in GestorFuncionario.listaFuncionarios)
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
                for (int i = 0; i < GestorFuncionario.listaFuncionarios.Count; i++)
                {
                    if (GestorFuncionario.listaFuncionarios[i].userName.ToLower().Equals(nome.ToLower()))
                    {
                        indexAremover = i;
                    }
                }
                if (indexAremover != -1)
                {
                    GestorFuncionario.listaFuncionarios.RemoveAt(indexAremover);
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

    }
}
