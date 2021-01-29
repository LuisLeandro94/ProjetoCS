using System;
using System.Collections.Generic;
using System.Text;

namespace Supermercado.Menus
{
    class MenuInicial
    {
        public static void InitialMenu()
        {
            GestorFuncionário.LerFuncionario();

            Produtos p = new Produtos();
            Funcionário f = new Funcionário();

            int escolha = -1;

            while (escolha != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("################################################");
                Console.WriteLine("#                                              #");
                Console.WriteLine("#                 SUPERMERCADO                 #");
                Console.WriteLine("#                                              #");
                Console.WriteLine("################################################");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#                                              #");
                Console.WriteLine("#         1 - LISTA DE FUNCIONÁRIOS            #");
                Console.WriteLine("#                                              #");
                Console.WriteLine("#----------------------------------------------#");
                Console.WriteLine("#                                              #");
                Console.WriteLine("#         2 - LOGIN                            #");
                Console.WriteLine("#                                              #");
                Console.WriteLine("#----------------------------------------------#");
                Console.WriteLine("#                                              #");
                Console.WriteLine("#         0 - SAIR                             #");
                Console.WriteLine("#                                              #");
                Console.WriteLine("################################################");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:
                        GestorFuncionário.EscreverListaConsola();
                        break;

                    case 2:
                        Funcionário.LoginForm();
                        break;
                    case 0:
                        Console.WriteLine("Luis & Marco Supermercado. Obrigado pela sua preferência.");
                        break;
                    default:
                        Console.WriteLine("Opção Inválida");
                        break;
                }
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}
