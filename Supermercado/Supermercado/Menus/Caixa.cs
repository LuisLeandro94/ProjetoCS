using Supermercado.Data;
using Supermercado.Menus;
using System;
namespace Supermercado
{
    public class Caixa : Funcionário
    {
        public Caixa() : base()
        {
        }

        public void MenuCaixa()
        {
            Funcionário f = new Funcionário();
            Caixa c = new Caixa();
            int escolha = 0;
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("##################################################");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#                 MENU - CAIXA                   #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("##################################################");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#                                                #");
                Console.WriteLine("#         1 - VENDER                             #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#------------------------------------------------#");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#         2 - LISTAR FATURAS                     #");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#------------------------------------------------#");
                Console.WriteLine("#                                                #");
                Console.WriteLine("#         3 - ANULAR FATURAS                     #");
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
                        GestorProdutos.EscreverListaConsola();
                        break;
                    case 2:
                        //LISTAR FATURA
                        break;
                    case 3:
                        //ANULAR FATURAS
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
    }
}
