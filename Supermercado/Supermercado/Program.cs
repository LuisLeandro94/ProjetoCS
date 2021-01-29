using System;


namespace Supermercado
{
    class Program
    {
        static void Main(string[] args)
        {
            GestorFuncionário.LerFuncionario();
           
            Funcionário f = new Funcionário();
           
            int escolha = 0;
           
            while (escolha != 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("######################################");
                Console.WriteLine("#                                    #");
                Console.WriteLine("#            SUPERMERCADO            #");
                Console.WriteLine("#                                    #");
                Console.WriteLine("######################################");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("#                                    #");
                Console.WriteLine("#    1-LISTA DE FUNCIONÁRIOS (TESTE) #");
                Console.WriteLine("#                                    #");
                Console.WriteLine("#    2-REGISTAR                      #");
                Console.WriteLine("#                                    #");
                Console.WriteLine("#    3-LOGIN                         #");
                Console.WriteLine("#                                    #");
                Console.WriteLine("#    0-SAIR                          #");
                Console.WriteLine("#                                    #");
                Console.WriteLine("######################################");
                Console.ResetColor();

                escolha = int.Parse(Console.ReadLine());
                Console.Clear();


                switch (escolha)
                {
                    case 1:

                        GestorFuncionário.EscreverListaConsola();
                        break;

                    case 2:
                       
                        f.CreateEmployee();
                        //Funcionário.employeeList.Add(firstName, lastName, username, password);
                       break;

                    case 3:
                        Funcionário.LoginForm();
                      break;
                                
                    case 0:
                        Console.WriteLine("");
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
