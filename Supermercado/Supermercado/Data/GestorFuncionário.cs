using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado
{
    class GestorFuncionário
    {

        static public List<Funcionário> listaFuncionarios = new List<Funcionário>();

        public static void GravarFuncionario()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            string fileName = "listaDeFuncionarios.txt";


            FileStream fileStream = File.Create(fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, GestorFuncionário.listaFuncionarios);
            fileStream.Close();
        }

        public static void LerFuncionario()
        {
            string location = Directory.GetCurrentDirectory();
            string filename = "listaDeFuncionarios.txt";

            GestorFuncionário.listaFuncionarios.Clear();
            if (File.Exists(filename))
            {
                FileStream fileStream = File.OpenRead(filename);
                BinaryFormatter f = new BinaryFormatter();

              
                    List<Funcionário> g = f.Deserialize(fileStream) as List<Funcionário>;
                    GestorFuncionário.listaFuncionarios = g;
              
                fileStream.Close();
            }

        }

        public static void EscreverListaConsola()
        {
            string result = "";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#           LISTA DE FUNCIONARIOS         #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.ResetColor();

            foreach (Funcionário f in GestorFuncionário.listaFuncionarios)
            {

                Console.Write("Name: ");
                Console.WriteLine(f.firstName);
                Console.Write("Last Name: ");
                Console.Write(f.lastName);
                Console.Write("\nPhone Number: ");
                Console.Write(f.phoneNumber);
                Console.Write("\nAddress: ");
                Console.Write(f.address);
                Console.Write("\nSalary: ");
                Console.Write(f.salary);
                Console.Write("\nUsername: ");
                Console.Write(f.password);
                Console.Write("\nPosition: ");
                Console.Write(f.cargo);
                Console.Write("\nActive: ");
                Console.Write(f.active);

                Console.WriteLine("\n###########################################");
                Console.ResetColor();


                Console.WriteLine();
                result += "";

            }
        }
    }
}
