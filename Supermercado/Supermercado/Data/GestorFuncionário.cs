using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado
{
    [Serializable]
    class GestorFuncionário
    {

        static public List<Funcionário> listaFuncionarios = new List<Funcionário>();

        #region Gravar Funcionário
        public static void GravarFuncionario()
        {
            string fileLocation = Directory.GetCurrentDirectory();
            string fileName = "listaDeFuncionarios.txt";

            try
            {
                FileStream fileStream = File.Create(fileName);
                BinaryFormatter f = new BinaryFormatter();

                f.Serialize(fileStream, GestorFuncionário.listaFuncionarios);
                fileStream.Close();
            }
            catch(Exception a)
            {
                Console.WriteLine("Couldn't access the file. Reason: " + a.Message);
            }
        }
        #endregion

        #region Ler Funcionário
        public static void LerFuncionario()
        {
            string location = Directory.GetCurrentDirectory();
            string filename = "listaDeFuncionarios.txt";

            try
            {
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
            catch(Exception a)
            {
                Console.WriteLine("Couldn't access the file! Reason: " + a.Message);
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
            Console.WriteLine("#           LISTA DE FUNCIONARIOS         #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.ResetColor();

            try
            {
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
                    Console.Write(f.userName);
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
            catch(Exception a)
            {
                Console.WriteLine(" Couldn't print list! Reason: " +a.Message);
            }
        }
        #endregion

        #region Remover Funcionario

        public static void EscolhaRemover()
        {
            EscreverListaConsola();
            Console.Write("Username do funcionário que pretende remover:");
            string contactoAEliminarNome = Console.ReadLine();
            bool resultado = removeFromContacs(contactoAEliminarNome);
            if (resultado)
            {
                Console.WriteLine("Funcionário eliminado com sucesso");
                GravarFuncionario();

            }
            else
            {
                Console.WriteLine("Falhou");
            }
        }

        public static bool removeFromContacs(string userName)
        {
            int indexAremover = -1;
            for (int i = 0; i < listaFuncionarios.Count; i++)
            {

                if (listaFuncionarios[i].userName.ToLower().Equals(userName.ToLower()))
                {
                    indexAremover = i;
                }
            }
            if (indexAremover != -1)
            {
                listaFuncionarios.RemoveAt(indexAremover);
                return true;
            }

            return false;
        }

        #endregion

    }
}
