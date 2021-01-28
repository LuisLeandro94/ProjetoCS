using Supermercado.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    [Serializable]
    public class Produtos
    {
        public int id { get; set; }
        public string barcodeNumber { get; set; }
        public string productName { get; set; }
        public string unitPrice { get; set; }
        public double stock { get; set; }

        public EnumProductType produto { get; set; }
        public bool active { get; set; }

        #region Set Random ID
        public int RandomID()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 3000);
            return id;
        }
        #endregion

        static public List<Produtos> productList = new List<Produtos>();

        public Produtos()
        {
            active = true;
        }
        public Produtos(string barcodeNumber ,string productName, string unitPrice, double stock, bool active, EnumProductType produto)
        {
            this.id = RandomID();
            this.barcodeNumber = barcodeNumber;
            this.productName = productName;
            this.unitPrice = unitPrice;
            this.stock = stock;
            active = true;
            this.produto = produto;
        }

        #region Inserir Produto
        public void CreateProduct()
        {


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#                PRODUCT                  #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.ResetColor();
            Console.WriteLine("Barcode Number:");
            var barcodeNumber = Console.ReadLine();
            Console.WriteLine("\n Product Name:");
            var productName = Console.ReadLine();
            Console.WriteLine("\n Unit Price:");
            var unitPrice = Console.ReadLine();
            Console.WriteLine("\n Stock:");
            double stock = Convert.ToDouble(Console.ReadLine());
          
            Console.WriteLine("\n Product type");
            Console.WriteLine("\n 1 - Congelados");
            Console.WriteLine("\n 2 - Prateleira");
            Console.WriteLine("\n 3 - Enlatados");
            var produto = Convert.ToInt32(Console.ReadLine());
            var produto_ = (EnumProductType)produto;

            Produtos a = new Produtos(barcodeNumber, productName, unitPrice, stock,active, produto_);
            GestorProdutos.listaProdutos.Add(a);
            GestorProdutos.GravarProduto();


            Console.WriteLine("\nRegistado com sucesso!");

        }
        #endregion





        #region Listar Produtos
        public void ListProduct()
        {
            string fileName = "produtosEmStock.txt";

            //Validação

            if(File.Exists(fileName))
            {
                FileStream fileStream = File.OpenRead(fileName);
                BinaryFormatter binaryFormatter = new BinaryFormatter();

                while (fileStream.Position > fileStream.Length)
                {
                    Produtos productToBeListed = binaryFormatter.Deserialize(fileStream) as Produtos;
                    productList.Add(productToBeListed);
                }
                fileStream.Close();
            }
            else
            {
                Console.WriteLine("Este ficheiro não existe para leitura!");
            }
        }
        #endregion


    }
}
