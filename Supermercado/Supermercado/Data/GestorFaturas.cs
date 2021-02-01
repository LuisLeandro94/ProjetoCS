using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado.Data
{
    [Serializable]
    class GestorFaturas
    {
        static public List<Fatura> listaFaturas = new List<Fatura>();
        public static string path = ConfigurationManager.AppSettings["faturasPath"];

        #region Gravar Faturas
        public static void GravarFaturas()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            try
            {
                using(FileStream fileStream = File.Create(path))
                {
                    BinaryFormatter f = new BinaryFormatter();
                    f.Serialize(fileStream, GestorFaturas.listaFaturas);
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("Couldn't access the file. Reason: " + a.Message);
            }
        }
        #endregion

        #region Ler Faturas
        public static void LerFaturas()
        {
            string location = Directory.GetCurrentDirectory();
            try
            {
                GestorFaturas.listaFaturas.Clear();
                if (File.Exists(path))
                {
                    using(FileStream fileStream = File.OpenRead(path))
                    {
                        BinaryFormatter f = new BinaryFormatter();
                        List<Fatura> g = f.Deserialize(fileStream) as List<Fatura>;
                        GestorFaturas.listaFaturas = g;
                    }
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("Couldn't access the file! Reason: " + a.Message);
            }
        }
        #endregion

        #region Listar Faturas Console
        public static void ListarFaturasConsole()
        {
            LerFaturas();
            string result = "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#            LISTA DE FATURAS             #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.ResetColor();

            try
            {
                foreach (Fatura p in GestorFaturas.listaFaturas)
                {
                    Console.Write("Nome Funcionário: ");
                    Console.Write(p.nomeFuncionario);
                    Console.Write("\nNome Cliente: ");
                    Console.Write(p.nomeCliente);
                    Console.WriteLine();
                    Console.Write("\nNIF Cliente: ");
                    Console.Write(p.nif);
                    Console.WriteLine();
                    Console.Write("\nProduct Name: ");
                    Console.WriteLine();
                    double valor = 0;
                    Console.OutputEncoding = System.Text.Encoding.Unicode;
                    List<string> lista = new List<string>();
                    string row = "NOME PRODUTO|BARCODE|PREÇO UNITÁRIO|QUANTIDADE";
                    int size = 0;
                    lista.Add(row);
                    foreach (Vendas v in p.listaVendas)
                    {
                        row = $"{v.productName}|{v.barcodeCompra}|{v.unitPrice}|{v.quantity}";
                        if(row.Length > size)
                        {
                            size = row.Length;
                        }
                        lista.Add(row);
                        valor += Convert.ToDouble(v.unitPrice) * v.quantity;
                    }
                    ToolsTable.Print(size, lista);
                    Console.Write("\nVALOR TOTAL DA COMPRA: ");
                    Console.Write("{0}€", valor);

                    Console.WriteLine("\n###########################################");
                    Console.ResetColor();

                    Console.WriteLine();
                    result += "";
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("Couldn't print list! Reason: " + a.Message);
            }
        }
        #endregion

    }
}
