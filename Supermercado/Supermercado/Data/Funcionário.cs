using Supermercado.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    [Serializable]

    public class Funcionário
    {
        #region Properties
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime birthDate { get; set; }
        public decimal salary { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public EnumCargo cargo { get; set; }
        #endregion


        static public List<Gerente> gerentList = new List<Gerente>();
        static public List<Repositor> repositorList = new List<Repositor>();

        #region Constructors
        public Funcionário()
        {
            active = true;
        }

        public Funcionário(long id, string firstName, string lastName, string phoneNumber, string address, DateTime birthDate, decimal salary, string userName, string password, bool active, EnumCargo cargo)
        {
            this.id = RandomID();
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.birthDate = birthDate;
            this.salary = salary;
            this.userName = userName;
            this.password = password;
            this.active = true;
            this.cargo = cargo;
        }
        #endregion

        #region Set Random ID
        public int RandomID()
        {
            Random rnd = new Random();
            int id = rnd.Next(1, 3000);
            return id;
        }
        #endregion

        #region Listar Funcionarios
        public override string ToString()
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

                Console.Write("Nome: ");
                Console.WriteLine(f.firstName);
                Console.Write("LastName: ");
                Console.Write(f.lastName);
                Console.Write("\nPhoneNumber: ");
                Console.Write(f.phoneNumber);
                Console.Write("\nAddress: ");
                Console.Write(f.address);
                Console.Write("\nSalary: ");
                Console.Write(f.salary);
                Console.Write("\nBirth Date: ");
                Console.Write(f.birthDate.ToString("dd / MM / yyyy"));
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
            return result;
        }


        #endregion

        #region Criar Funcionario
        public void CreateEmployee()
        {


            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("###########################################");
            Console.WriteLine("#                                         #");
            Console.WriteLine("#                REGISTAR                 #");
            Console.WriteLine("#                                         #");
            Console.WriteLine("###########################################");
            Console.ResetColor();
            Console.WriteLine("Your First Name:");
            var firstName = Console.ReadLine();
            Console.WriteLine("\n Your Last Name:");
            var lastName = Console.ReadLine();
            Console.WriteLine("\n Your contact information:");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("\n Your address:");
            var address = Console.ReadLine();
            Console.WriteLine("\n Your salary: ");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("\n Your birth date: (dd/MM/YYYY)");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine()); 
            Console.WriteLine("\n Wanted username:");
            var username = Console.ReadLine();
            Console.WriteLine("\n Wanted password(min. 8 char):");
            var password = Console.ReadLine();
            Console.WriteLine("\n What's your role in the company?");
            Console.WriteLine("\n 1 - Gerente");
            Console.WriteLine("\n 2 - Repositor");
            Console.WriteLine("\n 3 - Caixa");
            var cargo = Convert.ToInt32(Console.ReadLine());
            var cargo_ = (EnumCargo)cargo;

            Funcionário a = new Funcionário(id, firstName, lastName, phoneNumber, address, birthDate, salary, username, password, cargo_);
            GestorFuncionário.listaFuncionarios.Add(a);
            GestorFuncionário.GravarFuncionario();


            Console.WriteLine("\nRegistado com sucesso!");

        }
        #endregion

        #region Login
        public static void LoginForm()
        {
            bool successfull = false;
            Console.Clear();
            while (successfull != true)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("###########################################");
                Console.WriteLine("#                                         #");
                Console.WriteLine("#                   LOGIN                 #");
                Console.WriteLine("#                                         #");
                Console.WriteLine("###########################################");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Username:");
                var username = Console.ReadLine();
                Console.Write("Password:");
                var password = Console.ReadLine();
                Console.WriteLine("###########################################");
                Console.ResetColor();
                foreach (Funcionário funcionario in GestorFuncionário.listaFuncionarios)
                {
                    if (username == funcionario.userName && password == funcionario.password)
                    {
                        Console.WriteLine("Login bem sucedido!");
                        successfull = true;
                        Console.Clear();
                        if (EnumHelper.GetDescription(funcionario.cargo) == "Gerente")
                        {
                            //MENU GERENTE
                            Console.WriteLine("GERENTE");
                        }
                        else if (EnumHelper.GetDescription(funcionario.cargo) == "Caixa")
                        {
                            //MENU CAIXA
                            Console.WriteLine("CAIXA");
                        }
                        else if (EnumHelper.GetDescription(funcionario.cargo) == "Repositor")
                        {
                            //MENU REPOSITOR
                            Console.WriteLine("REPOSITOR");
                        }
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Username ou Password incorretos.");
                        Console.Clear();
                    }
                }
            }
            Console.ReadKey();
            Console.Clear();
        }
        #endregion


    }
}




