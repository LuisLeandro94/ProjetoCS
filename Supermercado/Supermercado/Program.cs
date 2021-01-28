using System;


namespace Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            Trabalhadores.LerFuncionario();
           
            Funcionário f = new Funcionário();
            //Funcionário.employeeList.Add(new Funcionário("luis", "Ribeiro", "967852669","Rua da Boavista",29/05/2002 , 384 , "funcionario", "teste"));
            //Funcionário.employeeList.Add(new Funcionário("Marco", "Oliveira", "S967852669", "gerente", "teste"));
            Funcionário.gerentList.Add(new Gerente("gerente", "teste"));
            Funcionário.repositorList.Add(new Repositor("repositor", "teste"));
           
           



            int escolha = 0;
           
            while (escolha != 7)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("|------------------------------------|");   
                Console.WriteLine("|        SUPERMERCADO                |");
                Console.WriteLine("|------------------------------------|");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("|    1-LISTA DE FUNCIONÁRIOS (TESTE) |");
                Console.WriteLine("|    2-REGISTAR                      |");
                Console.WriteLine("|    3-LOGIN                         |");
                Console.WriteLine("|    0-SAIR                          |");
                Console.WriteLine("|------------------------------------|");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();


                switch (escolha)
                {
                    case 1:

                        Trabalhadores.EscreverListaConsola();
                        break;

                    case 2:
                       
                        f.CreateEmployee();
                        //Funcionário.employeeList.Add(firstName, lastName, username, password);
                       break;

                    case 3:
                        f.LoginForm();
                      break;
                                
                    case 0:
                        Console.WriteLine("Escolheu sair");
                        break;
                    default:
                    Console.WriteLine("Opção Inválida");
                    break;
                }
                Console.ReadKey();
                Console.Clear();
            }

            //Quando sair
            Console.WriteLine("@SuperMercado)");

           

        }
}
}
