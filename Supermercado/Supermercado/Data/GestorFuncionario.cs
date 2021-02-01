using Supermercado.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

namespace Supermercado
{
    [Serializable]
    class GestorFuncionario
    {

        static public List<Funcionario> listaFuncionarios = new List<Funcionario>();
        public static string path = ConfigurationManager.AppSettings["funcionariosPath"];

        #region Gravar Funcionário
        public static void GravarFuncionario()
        {
            string fileLocation = Directory.GetCurrentDirectory();

            try
            {
                using (FileStream fileStream = File.Create(path))
                {
                    BinaryFormatter f = new BinaryFormatter();
                    f.Serialize(fileStream, GestorFuncionario.listaFuncionarios);
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("Couldn't access the file. Reason: " + a.Message);
            }
        }
        #endregion

        #region Ler Funcionário
        public static void LerFuncionario()
        {
            string location = Directory.GetCurrentDirectory();

            try
            {
                GestorFuncionario.listaFuncionarios.Clear();
                if (File.Exists(path))
                {
                    using (FileStream fileStream = File.OpenRead(path))
                    {
                        BinaryFormatter f = new BinaryFormatter();
                        List<Funcionario> g = f.Deserialize(fileStream) as List<Funcionario>;
                        GestorFuncionario.listaFuncionarios = g;
                    }
                }
            }
            catch (Exception a)
            {
                Console.WriteLine("Couldn't access the file! Reason: " + a.Message);
            }
        }
        #endregion

        #region Listar na Console
        public static void EscreverListaConsola()
        {
            try
            {
                List<string> lista = new List<string>();
                string row = "PRIMEIRO NOME|APELIDO|CONTACTO|MORADA|SALÁRIO|USERNAME|CARGO";
                lista.Add(row);
                int size = 0;
                foreach (Funcionario f in GestorFuncionario.listaFuncionarios)
                {
                        row = $"{f.firstName}|{f.lastName}|{f.phoneNumber}|{f.address}|{f.salary}|{f.userName}|{f.cargo}";
                        if (row.Length > size)
                        {
                            size = row.Length;
                        }
                        lista.Add(row);
                }
                ToolsTable.Print(size, lista);
            }
            catch (Exception a)
            {
                Console.WriteLine(" Couldn't print list! Reason: " + a.Message);
            }
        }
        #endregion

        #region Remover Funcionario

        public static void EscolhaRemover()
        {
            try
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
            catch(Exception a)
            {
                Console.WriteLine("Couldn't eliminate employee. Reason: " + a.Message);
            }
        }

        public static bool removeFromContacs(string userName)
        {
            try
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
            catch(Exception a)
            {
                Console.WriteLine("Couldn't remove employee. Reason: " + a.Message);
            }
            return false;
        }

        #endregion
    }
}
