using Supermercado.Enums;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

        public Funcionário(string firstName, string lastName, string phoneNumber, string address, DateTime birthDate, decimal salary, string userName, string password, EnumCargo cargo)
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

        /*
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
        */

        #region Criar Funcionario
        public void CreateEmployee()
        {
            try
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
                while (string.IsNullOrEmpty(firstName) || firstName.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid name!");
                    firstName = Console.ReadLine();
                }
                Console.WriteLine("Your Last Name:");
                var lastName = Console.ReadLine();
                while (string.IsNullOrEmpty(lastName) || lastName.Any(char.IsDigit))
                {
                    Console.WriteLine("Invalid name!");
                    lastName = Console.ReadLine();
                }
                Console.WriteLine("Your contact information:");
                var phoneNumber = Console.ReadLine();
                while (string.IsNullOrEmpty(phoneNumber) || phoneNumber.Any(char.IsLetter) || phoneNumber.Length != 9)
                {
                    Console.WriteLine("Invalid phone number!");
                    phoneNumber = Console.ReadLine();
                }
                Console.WriteLine("Your address:");
                var address = Console.ReadLine();
                while (string.IsNullOrEmpty(address))
                {
                    Console.WriteLine("Please enter your address!");
                    address = Console.ReadLine();
                }
                Console.WriteLine("Your salary: ");
                decimal salary = Convert.ToDecimal(Console.ReadLine());
                while (salary < 600)
                {
                    Console.WriteLine("Don't be a liar!");
                    salary = Convert.ToDecimal(Console.ReadLine());
                }
                Console.WriteLine("Your birth date: (dd/MM/YYYY)");
                DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
                while(birthDate.Year <= 1950 || birthDate.Year >= 2006)
                if(birthDate.Year <= 1950)
                {
                    Console.WriteLine("Aren't you too old to work here?");
                    birthDate = Convert.ToDateTime(Console.ReadLine());
                }
                else
                {
                    if(birthDate.Year >= 2006)
                    {
                        Console.WriteLine("Aren't you too young to work here?");
                        birthDate = Convert.ToDateTime(Console.ReadLine());
                    }
                }
                Console.WriteLine("Wanted username:");
                var username = Console.ReadLine();
                foreach(Funcionário f in GestorFuncionário.listaFuncionarios)
                {
                    while (f.userName == username)
                    {
                        Console.WriteLine("Username already taken! Please try another one!");
                        username = Console.ReadLine();
                    }
                }
                Console.WriteLine("Wanted password(min. 8 char):");
                var password = Console.ReadLine();
                while (string.IsNullOrEmpty(password) || password.Length < 8)
                {
                    Console.WriteLine("Invalid password format! Please try another one!");
                        password = Console.ReadLine();
                }
                Console.WriteLine("What's your role in the company?");
                Console.WriteLine("1 - Gerente");
                Console.WriteLine("2 - Repositor");
                Console.WriteLine("3 - Caixa");
                var cargo = Convert.ToInt32(Console.ReadLine());
                var cargo_ = (EnumCargo)cargo;

                Funcionário a = new Funcionário(firstName, lastName, phoneNumber, address, birthDate, salary, username, password, cargo_);
                GestorFuncionário.listaFuncionarios.Add(a);
                GestorFuncionário.GravarFuncionario();


                Console.WriteLine("\nUser created successfully!");
            }
            catch(Exception a)
            {
                Console.WriteLine("Error creating user! Reason: " + a.Message);
            }
        }
        #endregion

        #region Login
        public static void LoginForm()
        {
            Gerente g = new Gerente();
            Repositor r = new Repositor();
            Caixa c = new Caixa();

            bool successfull = false;
            Console.Clear();
            try
            {
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
                                g.MenuGerente();
                            }
                            else if (EnumHelper.GetDescription(funcionario.cargo) == "Caixa")
                            {
                                c.MenuCaixa();
                            }
                            else if (EnumHelper.GetDescription(funcionario.cargo) == "Repositor")
                            {
                                r.MenuRepositor();
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
            catch(Exception a)
            {
                Console.WriteLine("Could not login! Reason:" + a.Message);
            }
        }
        #endregion

    }
}




