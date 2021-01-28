using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado.Data
{
    [Serializable]
    static class GestorProdutos
    {
        static public List<Produtos> listaProdutos = new List<Produtos>();

        #region Gravar Produto
        public static void GravarProduto()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            string fileName = "listaDeProdutos.txt";


            FileStream fileStream = File.Create(fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, GestorProdutos.listaProdutos);
            fileStream.Close();
        }
        #endregion

        #region Ler Funcionário
        public static void LerProduto()
        {
            string location = Directory.GetCurrentDirectory();
            string filename = "listaDeProdutos.txt";

            GestorProdutos.listaProdutos.Clear();
            if (File.Exists(filename))
            {
                FileStream fileStream = File.OpenRead(filename);
                BinaryFormatter f = new BinaryFormatter();


                List<Produtos> g = f.Deserialize(fileStream) as List<Produtos>;
                GestorProdutos.listaProdutos = g;

                fileStream.Close();
            }
        }
        #endregion

        #region Listar na Console
        public static void EscreverListaConsola()
        {
            string result = "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#           LISTA DE PRODUTOS             #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.ResetColor();

            foreach (Produtos p in GestorProdutos.listaProdutos)
            {
                Console.Write("ID");
                Console.WriteLine(p.id);
                Console.Write("Barcode Number: ");
                Console.Write(p.barcodeNumber);
                Console.Write("Product Name: ");
                Console.Write(p.productName);
                Console.Write("\nUnit Price: ");
                Console.Write(p.unitPrice);
                Console.Write("\nStock: ");
                Console.Write(p.stock);
                Console.Write("\nActive: ");
                Console.Write(p.active);
              

                Console.WriteLine("\n###########################################");
                Console.ResetColor();


                Console.WriteLine();
                result += "";
            }
        }
        #endregion
    }
}
