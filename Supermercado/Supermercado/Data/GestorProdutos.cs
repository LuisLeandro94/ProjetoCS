using System;
using System.Collections.Generic;
using System.Data;
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

            try
            {
                FileStream fileStream = File.Create(fileName);
                BinaryFormatter f = new BinaryFormatter();

                f.Serialize(fileStream, GestorProdutos.listaProdutos);
                fileStream.Close();
            }
            catch(Exception a)
            {
                Console.WriteLine("Couldn't access the file! Reason:" + a.Message);
            }
        }
        #endregion

        #region Ler Produto
        public static void LerProduto()
        {
            string location = Directory.GetCurrentDirectory();
            string filename = "listaDeProdutos.txt";

            try
            {
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
            catch(Exception a)
            {
                Console.WriteLine("Couldn't access the file! Reason:" + a.Message);
            }
        }
        #endregion

        #region Listar na Console
        public static void EscreverListaConsola()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#           LISTA DE PRODUTOS             #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.ResetColor();

            try
            {
                foreach (Produtos p in GestorProdutos.listaProdutos)
                {
                    if (p.stock != 0)
                    {
                        DataTable dt = new DataTable();
                        dt.Clear();
                        dt.Columns.Add("ID");
                        dt.Columns.Add("NAME");
                        dt.Columns.Add("BARCODE NUMBER");
                        dt.Columns.Add("PRICE");
                        dt.Columns.Add("STOCK");
                        DataRow row = dt.NewRow();
                        row["ID"] = p.id;
                        row["NAME"] = p.productName;
                        row["BARCODE NUMBER"] = p.barcodeNumber;
                        row["PRICE"] = p.unitPrice;
                        row["STOCK"] = p.stock;
                        dt.Rows.Add(row);
                        Console.WriteLine("###########################################");
                        Console.ResetColor();
                    }  
                }
            }
            catch(Exception a)
            {
                Console.WriteLine("Couldn't list the products! Reason:" + a.Message);
            }
        }
        #endregion
    }
}
