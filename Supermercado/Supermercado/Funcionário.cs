using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Supermercado
{
    [Serializable]

    public class Funcionário
    {
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string phoneNumber { get; set; }
        public string address { get; set; }
        public DateTime birthDate { get; set; }
        public decimal salary { get; set; }
        public DateTime entryTime { get; set; }
        public int authorityId { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public bool active { get; set; }
        public string cargo { get; set; }


       
        static public List<Gerente> gerentList = new List<Gerente>();
        static public List<Repositor> repositorList = new List<Repositor>();
        //public List<Gerente> gerenteList;
        //public List<Repositor> repositorList;
        public Funcionário()
        {
            active = true;
            entryTime = DateTime.Now;
        }

        public Funcionário(string firstName, string lastName, string phoneNumber, string address, DateTime birthDate, decimal salary, string userName, string password, bool active, string cargo)
        {
            //this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.address = address;
            this.birthDate = birthDate;
            this.salary = salary;
            this.entryTime = entryTime;
            this.userName = userName;
            this.password = password;
            this.active = active;
            this.cargo = "Funcionario";
        }

       
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
            return result;
        }


        #endregion

        #region Criar Funcionario
        public void CreateEmployee()
        {
            
          
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|                REGISTAR                 |");
            Console.WriteLine("|-----------------------------------------|");
            Console.ResetColor();
            Console.WriteLine("FirstName:");
            var firstName = Console.ReadLine();
            Console.WriteLine("\nLastName:");
            var lastName = Console.ReadLine();
            Console.WriteLine("\nPhoneNumber");
            var phoneNumber = Console.ReadLine();
            Console.WriteLine("\nAddress");
            var address = Console.ReadLine();
            Console.WriteLine("\nData de Aniversário");
            DateTime birthDate = Convert.ToDateTime(Console.ReadLine());
            //string data = Console.ReadLine("dd/MM/yyyy");
            //DateTime dateAndTime = DateTime.Now;
            //Console.WriteLine(dateAndTime.ToString("dd/MM/yyyy"));
            Console.WriteLine("\nSalary");
            decimal salary = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("\nUserName:");
            var username = Console.ReadLine();
            Console.WriteLine("\nPassword:");
            var password = Console.ReadLine();

            Funcionário a = new Funcionário(firstName, lastName, phoneNumber, address, birthDate, salary, username, password,active, cargo);
            Trabalhadores.trabalhadores.Add(a);
            Trabalhadores.GravarFuncionario();
           

            Console.WriteLine("\nRegistado com sucesso!");

        }

      


        #endregion

        #region Login
        public virtual void LoginForm()
        {
            bool successfull = false;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("|-----------------------------------------|");
            Console.WriteLine("|                   LOGIN                 |");
            Console.WriteLine("|-----------------------------------------|");
            Console.ResetColor();
            Console.WriteLine("1- Funcionário ");
            Console.WriteLine("2- Gerente ");
            Console.WriteLine("3- Repositor ");
            int escolha = int.Parse(Console.ReadLine());
            Console.Clear();

            switch (escolha)
            {
                case 1:

                    do
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|---------------------------------------|");
                        Console.WriteLine("|          LOGIN - FUNCIONARIO          |");
                        Console.WriteLine("|---------------------------------------|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Username:");
                        var username = Console.ReadLine();
                        Console.Write("Password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ResetColor();
                        foreach (Funcionário funcionario in Trabalhadores.trabalhadores)
                        {
                            if (username == funcionario.userName && password == funcionario.password && escolha == 1)
                            {
                                Console.WriteLine("Login bem sucedido!");
                                successfull = true;
                                Console.Clear();
                                Console.WriteLine("FUNCIONARIO");
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Username ou Password incorretos.");
                                Console.Clear();

                            }
                        }

                    } while (successfull == false);
                    break;

                case 2:
                    do
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|-----------------------------------------|");
                        Console.WriteLine("|             LOGIN - GERENTE             |");
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Username:");
                        var username = Console.ReadLine();
                        Console.Write("Password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ResetColor();
                        foreach (Gerente gerente in gerentList)
                        {
                            if (username == gerente.userName && password == gerente.password && escolha == 2)
                            {
                                Console.WriteLine("Login bem sucedido!");
                                successfull = true;
                                Console.Clear();
                                Gerente gr = new Gerente();
                                gr.MenuGerente();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Username ou Password incorretos.");
                                Console.Clear();
                            }
                        }

                    } while (successfull == false);
                    break;

                case 3:
                    do
                    {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("|-----------------------------------------|");
                        Console.WriteLine("|             LOGIN - REPOSITOR           |");
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("Username:");
                        var username = Console.ReadLine();
                        Console.Write("Password:");
                        var password = Console.ReadLine();
                        Console.WriteLine("|-----------------------------------------|");
                        Console.ResetColor();
                        foreach (Repositor repositor in repositorList)
                        {
                            if (username == repositor.userName && password == repositor.password && escolha == 3)
                            {
                                Console.WriteLine("Login bem sucedido!");
                                successfull = true;
                                Console.Clear();
                                Repositor rep = new Repositor();
                                rep.MenuRepostior();
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Username ou Password incorretos.");
                                Console.Clear();
                            }
                        }

                    } while (successfull == false);
                    break;


                default:
                    Console.WriteLine("Opção Inválida");
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }

    }
    #endregion


}




