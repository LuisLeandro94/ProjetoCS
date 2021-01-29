using Supermercado.Data;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    [Serializable]
    public class Produtos
    {
        #region Properties
        public int id { get; set; }
        public string barcodeNumber { get; set; }
        public string productName { get; set; }
        public string unitPrice { get; set; }
        public double stock { get; set; }
        public EnumProductType produto { get; set; }
        public bool active { get; set; }
        #endregion

        #region Set Random ID
        public int RandomID()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 3000);
            return id;
        }
        #endregion

        static public List<Produtos> productList = new List<Produtos>();

        #region Constructors
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
        #endregion

        #region Inserir Produto
        public void CreateProduct()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("#############################################");
                Console.WriteLine("#                                           #");
                Console.WriteLine("#                  PRODUCT                  #");
                Console.WriteLine("#                                           #");
                Console.WriteLine("#############################################");
                Console.ResetColor();
                Console.WriteLine("Barcode Number:");
                var barcodeNumber = Console.ReadLine();
                while (string.IsNullOrEmpty(barcodeNumber))
                {
                    Console.WriteLine("Barcode must be filled!");
                    barcodeNumber = Console.ReadLine();
                }
                Console.WriteLine("Product Name:");
                var productName = Console.ReadLine();
                while (string.IsNullOrEmpty(productName))
                {
                    Console.WriteLine("Product name must be filled!");
                    productName = Console.ReadLine();
                }
                Console.WriteLine("Unit Price:");
                var unitPrice = Console.ReadLine();
                while (string.IsNullOrEmpty(unitPrice) || unitPrice.Any(char.IsLetter) || Convert.ToInt32(unitPrice) <= 0)
                {
                    Console.WriteLine("Who do you think we are? \"Madre Teresa de Calcutá?\"");
                    unitPrice = Console.ReadLine();
                }

                Console.WriteLine("Stock:");
                double stock = Convert.ToDouble(Console.ReadLine());
                while (stock <= 0)
                {
                    Console.WriteLine("You do know you are trying to *ADD* a product right? Try again.");
                    stock = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine("Product type:");
                Console.WriteLine("1 - Congelados");
                Console.WriteLine("2 - Prateleira");
                Console.WriteLine("3 - Enlatados");
                var produto = Convert.ToInt32(Console.ReadLine());
                var produto_ = (EnumProductType)produto;

                Produtos a = new Produtos(barcodeNumber, productName, unitPrice, stock, active, produto_);
                GestorProdutos.listaProdutos.Add(a);
                GestorProdutos.GravarProduto();


                Console.WriteLine("\nUser created successfully!");
            }
            catch(Exception a)
            {
                Console.WriteLine("Could not create this product. Reason: " + a.Message);
            }

        }
        #endregion

        #region Listar Produtos
        public void ListProduct()
        {
            string fileName = "produtosEmStock.txt";

            //Validação
            try
            { 
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
            catch(Exception a)
            {
                Console.WriteLine("File could not be read! Reason: " + a.Message);
            }
        }
        #endregion
    }
}
