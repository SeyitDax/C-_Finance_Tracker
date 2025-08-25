using System;
using AccountManagement;

namespace Program{
    class Program{
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello Welcome to our Finance Management System");
            Console.WriteLine("Please Choose an option");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
            Console.WriteLine("3.Exit");

            string? choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    Login();
                    break;
                case "2": 
                    Register();
                    break;
                case "3": 
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Login(){
            Console.WriteLine("May I please get your name?");
            string? name = Console.ReadLine();
            int _balance;
            int _debt;
            while(true)
            {
                Console.WriteLine("What is your current bank balance?");
                string? result = Console.ReadLine();

                if(result != null && int.TryParse(result, out int balance)) {_balance = balance; break;}
                else
                {
                    Console.WriteLine("Please enter a valid balance");
                }
            }
            while(true)
            {
                Console.WriteLine("What is your debt? (If none please enter 0)");
                string? result = Console.ReadLine();

                if(result != null && int.TryParse(result, out int debt)) {_debt = debt; break;}
                else
                {
                    Console.WriteLine("Please enter a valid debt");
                }
            }
            Account account = new Account(_balance, _debt);
        }

        private static void Register(){
            Console.WriteLine("May I please get your name?");
            string? name = Console.ReadLine();
            int _balance;
            int _debt;
            while(true)
            {
                Console.WriteLine("What is your current bank balance?");
                string? result = Console.ReadLine();

                if(result != null && int.TryParse(result, out int balance)) {_balance = balance; break;}
                else
                {
                    Console.WriteLine("Please enter a valid balance");
                }
            }
            while(true)
            {
                Console.WriteLine("What is your debt? (If none please enter 0)");
                string? result = Console.ReadLine();

                if(result != null && int.TryParse(result, out int debt)) {_debt = debt; break;}
                else
                {
                    Console.WriteLine("Please enter a valid debt");
                }
            }
            Account account = new Account(_balance, _debt);
            Console.WriteLine($"Your account ID is: {account.ID}");
        }
    }
}