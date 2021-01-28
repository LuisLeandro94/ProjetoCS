using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Supermercado
{
    public class Repositor : Funcionário
    {
        public Repositor() : base()
        {

        }

        public string r_userName { get; set; }
        public string r_password { get; set; }
        public string r_cargo { get; set; }

        public Repositor(string r_userName, string r_password)
        {
            this.userName = r_userName;
            this.password = r_password;
            this.cargo = "Repositor";
        }

        public void MenuRepostior()
        {
            int escolha = 0;
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|--------------------------------|");
                Console.WriteLine("|        MENU - REPOSITOR        |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|    1- Adicionar Produtos       |");
                Console.WriteLine("|    2- Limpar Stock             |");
                Console.WriteLine("|    3- Remover Produto          |");
                Console.WriteLine("|    0-Sair                      |");
                Console.WriteLine("|--------------------------------|");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (escolha)
                {
                    case 1:
                        SaveProduct();
                        
                        break;
                    case 2:
                        //Produtos.productList.Clear();
                        limparLista();

                        break;
                    case 3:
                        Console.WriteLine("Remover Produto");
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

        #region Criar um Produto
        public void SaveProduct()
        {
            int op;
            
            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|-----------------------------------------|");
                Console.WriteLine("|                Adicionar Produto        |");
                Console.WriteLine("|-----------------------------------------|");
                Console.ResetColor();

                Random rnd = new Random();
                int id = rnd.Next(1, 1000);

                Console.WriteLine("Nome Produto:");
                
                ConsoleKeyInfo key;
                string productName = "";
                do
                {
                   
                    key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace)
                    {
                        productName += key.KeyChar;
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write("\b");
                    }
                } while (key.Key != ConsoleKey.Enter);
                Console.WriteLine("\nThe Password You entered is : " + productName);
                var nome = productName;

                Console.WriteLine("\nCódigo de Barras");
                var codigoBarras = Console.ReadLine();
                Console.WriteLine("\nPreço unitário: ");
                var unitPrice = Console.ReadLine();
                Console.WriteLine("\nStock");
                double stock = Convert.ToDouble(Console.ReadLine());
                bool active = true;

                Produtos.productList.Add(new Produtos(id, nome,codigoBarras,  unitPrice, stock, active));

                Console.WriteLine("Registado com sucesso!");

                //Validação

                string nomeficheiro = "produtosEmStock";
                string path = Directory.GetCurrentDirectory();
                string fileName = "/" + nomeficheiro + ".txt";

                StreamWriter streamWriter = File.AppendText(nomeficheiro);

                foreach (Produtos item in Produtos.productList)
                {
                    streamWriter.Write(item.id + " | " + item.productName + " | " + item.barcodeNumber  + " | " + item.unitPrice + " | " + item.stock + " | " + item.active + "\n");
                    ;
                }
                streamWriter.Close();


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nDeseja adicionar mais produtos?");
                Console.WriteLine("\n1- Sim");
                Console.WriteLine("2- Não");
                Console.ResetColor();
                op = Convert.ToInt32(Console.ReadLine());
            } while (op !=2 );


        }
        #endregion


        public void limparLista()
        {
            string nomeficheiro = "produtosEmStock";
            string path = Directory.GetCurrentDirectory();
            string fileName = nomeficheiro;

            if (File.Exists(fileName))
            {
                File.WriteAllText(fileName, "");
                Console.WriteLine("Stock Limpo");
            }
            else
            {
                Console.WriteLine(fileName);
                Console.WriteLine("Não encontrou stock");
            }
        }
    }

}
        

