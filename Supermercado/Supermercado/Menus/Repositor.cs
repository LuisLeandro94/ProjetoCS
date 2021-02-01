using Supermercado.Data;
using Supermercado.Menus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Supermercado
{
    public class Repositor : Funcionario
    {
        public Repositor() : base()
        {

        }

        #region Menu Repositor
        public void MenuRepositor()
        {
            GestorProdutos.LerProduto();

            int escolha = 0;
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("####################################################");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#                 MENU - REPOSITOR                 #");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("####################################################");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#         1 - ADICIONAR PRODUTOS                   #");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#--------------------------------------------------#");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#         2 - LIMPAR STOCK                         #");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#--------------------------------------------------#");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#         3 - REMOVER PRODUTO                      #");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#--------------------------------------------------#");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#         4 - LISTAR PRODUTOS                      #");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#--------------------------------------------------#");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("#         0 - SAIR                                 #");
                Console.WriteLine("#                                                  #");
                Console.WriteLine("####################################################");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:
                        Produtos.CreateProduct();
                        break;
                    case 2:
                        GestorProdutos.LimparLista();
                        break;
                    case 3:
                        GestorProdutos.EscolhaRemover();
                        break;
                    case 4:
                        GestorProdutos.EscreverListaConsola();
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
    }
}
        

