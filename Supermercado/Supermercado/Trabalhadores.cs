using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado
{
    class Trabalhadores
    {

        static public List<Funcionário> trabalhadores = new List<Funcionário>();

        public static void GravarFuncionario()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            string fileName = "listaDeFuncionarios.txt";


            FileStream fileStream = File.Create(fileName);
            BinaryFormatter f = new BinaryFormatter();

            f.Serialize(fileStream, Trabalhadores.trabalhadores);
            fileStream.Close();
        }

        public static void LerFuncionario()
        {
            string location = Directory.GetCurrentDirectory();
            string filename = "listaDeFuncionarios.txt";

            Trabalhadores.trabalhadores.Clear();
            if (File.Exists(filename))
            {
                FileStream fileStream = File.OpenRead(filename);
                BinaryFormatter f = new BinaryFormatter();

              
                    List<Funcionário> g = f.Deserialize(fileStream) as List<Funcionário>;
                    Trabalhadores.trabalhadores=g;
              
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

            foreach (Funcionário f in Trabalhadores.trabalhadores)
            {

                Console.Write("Nome: ");
                Console.WriteLine(f.firstName);
                Console.Write("LastName: ");
                Console.Write(f.lastName);
                Console.Write("\nPhoneNumber: ");
                Console.Write(f.phoneNumber);
                Console.Write("\nAddress: ");
                Console.Write(f.address);
                Console.Write("\nBirthDate: ");
                Console.Write(f.birthDate.ToString("dd/MM/yyyy"));
                Console.Write("\nSalary: ");
                Console.Write(f.salary);
                Console.Write("\nUserName: ");
                Console.Write(f.userName);
                Console.Write("\nPassword: ");
                Console.Write(f.password);
                Console.Write("\nCargo: ");
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
