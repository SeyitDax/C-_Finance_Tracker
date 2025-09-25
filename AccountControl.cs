using System;
using AccountManagement;

namespace AccountControl{
    public interface IAccountControl{
        public void CheckBalance(Account acc);
        public void CheckDebt(Account acc);
        public void Deposit(Account acc, decimal amount);
        public void Withdraw(Account acc, decimal amount);
        public void PayDebt(Account acc, decimal amount);
    }

    public class ConsoleControl : IAccountControl{
        public void ControlPanel(Account acc)
        {
            Console.WriteLine("WELCOME! \n What would you like to do today? \n 1.CheckBalance \n 2.CheckDebt \n 3.Deposit \n 4.Withdraw \n 5.Pay Debt");

            string? choice = Console.ReadLine();

            switch(choice){
                case("1"):
                    CheckBalance(acc);
                    break;
                case("2"):
                    CheckDebt(acc);
                    break;
                case("3"):
                    Console.WriteLine("How much money would you like to deposit?");
                    string? result = Console.ReadLine();
                    decimal.TryParse(result, out decimal amount) ? Console.WriteLine("Please enter a valid amount!");
                    Deposit(acc, amount);
                    break;
                case("4"):
                    Console.WriteLine("How much money would you like to withdraw?");
                    result = Console.ReadLine();
                    decimal.TryParse(result, out amount) ? Console.WriteLine("Please enter a valid amount!");
                    Withdraw(acc, amount);
                    break;
                case("5"):
                    Console.WriteLine("How much money would you like to pay?");
                    result = Console.ReadLine();
                    decimal.TryParse(result, out amount) ? Console.WriteLine("Please enter a valid amount!");
                    PayDebt(acc, amount);
                    break;
            }
        }

        public void CheckBalance(Account acc)
        {
            Console.WriteLine($"Your Current Balance is: {acc.Balance}");
        }       

        public void CheckDebt(Account acc)
        {
            Console.WriteLine($"Your Current Debt is: {acc.Debt}");
        }

        public void Deposit(Account acc, decimal amount)
        {
            acc.Balance += amount;
            Console.WriteLine($"Successfuly Added {amount}");
            Console.WriteLine($"Your Current Balance is: {acc.Balance}");
        }
        
        public void Withdraw(Account acc, decimal amount)
        {
            acc.Balance -= amount;
            Console.WriteLine($"Withdrawed {amount}");
            Console.WriteLine($"Your Current Balance is: {acc.Balance}");
        }

        public void PayDebt(Account acc, decimal amount)
        {
            decimal Debt = acc.Debt;

            if(Debt < amount) {amount = (amount - Debt); acc.Balance += amount;}
            else Debt -= amount;
            Console.WriteLine($"Successfuly Added {amount}");
            Console.WriteLine($"Your Current Debt is: {acc.Debt}");
        }
    }
}