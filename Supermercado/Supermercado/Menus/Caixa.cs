using Supermercado.Data;
using Supermercado.Menus;
using System;
using System.Collections.Generic;

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
                        //VendaAlt();
                        EscolhaEditar();
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

        public static void VendaAlt(string productName)
        {
            GestorProdutos.EscreverListaConsola();
            Console.Write("Cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("\nNome do Produto:");
            string nomeProduto = Console.ReadLine();

            Console.Write("\nQuantidade");
            int quantidade = Convert.ToInt32(Console.ReadLine());

           

            
            for (int i = 0; i < GestorProdutos.listaProdutos.Count; i++)
            {

                if (GestorProdutos.listaProdutos[i].productName.ToLower().Equals(nomeProduto.ToLower()))
                {

                    GestorProdutos.listaProdutos[i].stock = GestorProdutos.listaProdutos[i].stock - quantidade;
                }
                
            }
           

        }



        #region Vender Produto  ---ALTERAR--- 
        public static void EscolhaEditar()
        {
            GestorProdutos.EscreverListaConsola();
            Console.WriteLine("Cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.WriteLine("Produto para compra: ");
            string produtocompra = Console.ReadLine();

            Console.Write("Quantidade a comprar: ");
            double quantidade = Convert.ToDouble(Console.ReadLine());



            EditaaContact(nomeCliente, produtocompra, quantidade);
            //GravarProduto();
            int indexAremover;
            double valor;
            for (int i = 0; i < GestorProdutos.listaProdutos.Count; i++)
            {

                if (GestorProdutos.listaProdutos[i].productName.ToLower().Equals(produtocompra.ToLower()))
                {
                    indexAremover = i;
                    valor = Convert.ToDouble(GestorProdutos.listaProdutos[i].unitPrice) * quantidade;
                    Console.WriteLine("------------FATURA------------");
                    Console.WriteLine("Compra: {0} * Quantidade: {1} ", produtocompra, quantidade);
                    Console.WriteLine("Valor da compra: {0}",valor);
                }
            
            }
            Console.WriteLine("Pagamento: ");

            //A CONTINUAR
           

        }
        static public Produtos EditaaContact(string nomeCliente, string nome, double novoStock)
        {


            Produtos contactoAEditar = FindContact(nome);

            if (contactoAEditar != null)
            {
               
                if (!novoStock.Equals(""))
                {
                    contactoAEditar.stock = contactoAEditar.stock - novoStock;
                }

                return contactoAEditar;

            }

            return null;
        }
        static public Produtos FindContact(string productName)
        {
            foreach (Produtos p in GestorProdutos.listaProdutos)
            {
                if (p.productName.ToLower().Equals(productName.ToLower()))
                {

                    return p;
                }
            }

            return null;


        }

        static public void Pagamento()
        {
            

        }
        #endregion


    }
}
