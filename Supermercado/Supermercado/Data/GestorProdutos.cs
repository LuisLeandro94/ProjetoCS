using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado.Data
{
    [Serializable]
    class GestorProdutos
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
            string result = "";
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
                    Console.Write("ID: ");
                    Console.Write(p.id);
                    Console.Write("\nBarcode Number: ");
                    Console.Write(p.barcodeNumber);
                    Console.Write("\nProduct Name: ");
                    Console.Write(p.productName);
                    Console.Write("\nUnit Price: ");
                    Console.Write(p.unitPrice);
                    Console.Write("\nStock: ");
                    Console.Write(p.stock);
                    Console.Write("\nProduct: ");
                    Console.Write(p.produto);
                    //Mostrar Apenas Os que estão ativos??
                    if (p.active == true)
                    {
                        Console.WriteLine("\nActive");
                        Console.Write(p.active);
                    }
                   
                    
                    Console.WriteLine("\n###########################################");
                    Console.ResetColor();


                    Console.WriteLine();
                    result += "";
                }
            }
            catch (Exception a)
            {
                Console.WriteLine(" Couldn't print list! Reason: " + a.Message);
            }
        }
        #endregion

        #region Remover Produto

        public static void EscolhaRemover()
        {
            EscreverListaConsola();
            Console.Write("Product Name do produto que pretende remover:");
            string contactoAEliminarNome = Console.ReadLine();
            bool resultado = removeFromContacs(contactoAEliminarNome);
            if (resultado)
            {
                Console.WriteLine("Produto eliminado com sucesso");
                GravarProduto();

            }
            else
            {
                Console.WriteLine("Falhou");
            }
        }

        public static bool removeFromContacs(string productName)
        {
            int indexAremover = -1;
            for (int i = 0; i < listaProdutos.Count; i++)
            {
                
                if (listaProdutos[i].productName.ToLower().Equals(productName.ToLower()))
                {
                    indexAremover = i;
                }
            }
            if (indexAremover != -1)
            {
                listaProdutos.RemoveAt(indexAremover);
                return true;
            }

            return false;
        }

        #endregion

        #region Editar Produto 
        public static void EscolhaEditar()
        {
            Console.WriteLine("Nome do Produto a Editar:");
            string nomeAProcurar = Console.ReadLine();
           
            Console.Write("Nome Produto: ");
            string novoProductName = Console.ReadLine();
            Console.Write("Barcode Produto: ");
            string novoBarcode = Console.ReadLine();
            Console.Write("Unit Price: ");
            string novoUnitPrice = Console.ReadLine();
            Console.Write("Stock: ");
            double novoStock = Convert.ToDouble(Console.ReadLine());

            

            EditaContact(nomeAProcurar, novoProductName, novoBarcode, novoUnitPrice, novoStock);
            GravarProduto();


        }
        static public Produtos EditaContact(string nome, string novoProductName, string novoBarcode, string novoUnitPrice, double novoStock)
        {


            Produtos contactoAEditar = FindContact(nome);

            if (contactoAEditar != null)
            {
                if (!novoProductName.Equals(""))
                {
                    contactoAEditar.productName = novoProductName;
                }
                if (!novoBarcode.Equals(""))
                {
                    contactoAEditar.barcodeNumber = novoBarcode;
                }
                if (!novoUnitPrice.Equals(""))
                {
                    contactoAEditar.unitPrice = novoUnitPrice;
                }
                if (!novoStock.Equals(""))
                {
                    contactoAEditar.stock = novoStock;
                }

                return contactoAEditar;

            }

            return null;
        }

        
        static public Produtos FindContact(string productName)
        {
            foreach (Produtos p in listaProdutos)
            {
                if (p.productName.ToLower().Equals(productName.ToLower()))
                {
                    
                    return p;
                }
            }

            return null;


        }


        #endregion

        #region Limpar Stock
        public static void LimparLista()
        {
            listaProdutos.Clear();
            string location = Directory.GetCurrentDirectory();
            string fileName = "listaDeProdutos.txt";

            if (File.Exists(fileName))
            {     
                File.Delete(fileName);

            }


        }
        #endregion

    }
}
