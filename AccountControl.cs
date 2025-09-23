using System;

namespace AccountControl{
    public interface IAccountControl{
        public CheckBalance(Account acc);
        public CheckDebt(Account acc);
        public AddMoney(Account acc, decimal amount);
        public Withdraw(Account acc, decimal amount);
        public PayDebt(Account acc, decimal amount);
    }

    public class ConsoleControl : IAccountControl{
        public CheckBalance(Account acc)
        {
            Console.WriteLine($"Your Current Balance is: {acc.Balance}");
        }       

        public CheckDebt(Account acc)
        {
            Console.WriteLine($"Your Current Debt is: {acc.Debt}");
        }

        public AddMoney(Account acc, decimal amount)
        {
            acc.Balance += amount;
            Console.WriteLine($"Successfuly Added {amount}");
            Console.WriteLine($"Your Current Balance is: {acc.Balance}");
        }
        
        public Withdraw(Account acc, decimal amount)
        {
            acc.Balance -= amount;
            Console.WriteLine($"Withdrawed {amount}");
            Console.WriteLine($"Your Current Balance is: {acc.Balance}");
        }

        public PayDebt(Account acc, decimal amount)
        {
            decimal Debt = acc.debt;

            if(Debt < amount) {amount = (amount - debt); acc.balance += amount;}
            else Debt -= amount;
            Console.WriteLine($"Successfuly Added {amount}");
            Console.WriteLine($"Your Current Debt is: {acc.Debt}");
        }
    }
}