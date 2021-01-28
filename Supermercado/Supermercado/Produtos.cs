using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    public class Produtos
    {
        public int id { get; set; }
        public string barcodeNumber { get; set; }
        public string productName { get; set; }
        public string unitPrice { get; set; }
        public double stock { get; set; }
        public bool active { get; set; }

        
        static public List<Produtos> productList = new List<Produtos>();
        public Produtos(int id, string barcodeNumber ,string productName, string unitPrice, double stock, bool active)
        {
            this.id = id;
            this.barcodeNumber = barcodeNumber;
            this.productName = productName;
            this.unitPrice = unitPrice;
            this.stock = stock;
            active = true;
        }


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
