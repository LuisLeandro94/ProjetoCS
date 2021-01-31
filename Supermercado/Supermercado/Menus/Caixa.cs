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
            Console.Write("Cliente: ");
            string nomeCliente = Console.ReadLine();

            Console.Write("\nBarcode do produto a comprar: ");
            string barcodecompra = Console.ReadLine();

            Console.Write("\nQuantidade a comprar: ");
            double quantidade = Convert.ToDouble(Console.ReadLine());



            EditaaContact(nomeCliente, barcodecompra, quantidade);
            //GravarProduto();
            
            double valor;

            foreach (Produtos p in GestorProdutos.listaProdutos)
            {
                if (p.barcodeNumber.ToLower().Equals(barcodecompra.ToLower()))              
                    {
           
                    if (p.stock <= 0)
                    {                  
                        Console.WriteLine("Não há stock suficiente para a venda!");
                    }
                    else
                    {
                        valor = Convert.ToDouble(p.unitPrice) * quantidade;
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("###########################################");
                        Console.WriteLine("#                                         #");
                        Console.WriteLine("#                 COMPRA                  #");
                        Console.WriteLine("#                                         #");
                        Console.WriteLine("###########################################");
                        Console.ResetColor();
                        Console.WriteLine("Compra: {0} ", barcodecompra);
                        Console.WriteLine("Quantidade: {0} ", quantidade);
                        Console.WriteLine("Valor da compra: {0} \u00A9 ", valor);
                        Console.WriteLine("\nPagamento: ");
                        double pagamento = Convert.ToDouble(Console.ReadLine());

                        do
                        {
                            Console.WriteLine("Está em falta: {0}", valor - pagamento);
                            Console.WriteLine("Receber mais dinheiro: ");
                            double novopagamento = Convert.ToDouble(Console.ReadLine());
                            pagamento = pagamento + novopagamento;
                        } while (pagamento < valor);




                        if (pagamento > valor)
                        {
                            Console.WriteLine("Troco: {0}", pagamento - valor);
                        }
                        int nif;
                        Console.Write("\nDeseja número de contribuinte?");
                        Console.Write("\n1 - SIM");
                        Console.WriteLine("\n2 - NÃO");
                        int op = Convert.ToInt32(Console.ReadLine());
                        if (op == 1)
                        {
                            Console.WriteLine("Número de contribuinte: ");
                            nif = Convert.ToInt32(Console.ReadLine());
                        }
                        else
                        {
                            nif = 000000000;
                        }
                        GestorProdutos.GravarProduto();
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("###########################################");
                        Console.WriteLine("#                                         #");
                        Console.WriteLine("#           DADOS DA COMPRA               #");
                        Console.WriteLine("#                                         #");
                        Console.WriteLine("###########################################");
                        Console.ResetColor();
                        Console.Write("Cliente: ");
                        Console.Write(nomeCliente);
                        Console.Write("\nBarcode Produto Compra: ");
                        Console.Write(barcodecompra);
                        Console.Write("\nQuantidade: ");
                        Console.Write(quantidade);
                        Console.Write("\nValor da Compra: ");
                        Console.Write(valor);
                        Console.Write("\nNúmero de Contribuinte: ");
                        Console.Write(nif);
                        Caixa d = new Caixa(nomeCliente, barcodecompra, quantidade, valor, nif);
                        
                        GestorProdutos.listaProdutos.Add(d);
                        GestorProdutos.GravarProduto();
                    }



                }
            }

                   


            


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
