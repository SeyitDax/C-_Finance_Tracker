using AccountManagement;
using ExpenseManagement;

namespace Program{
    class Program{
        private static void Main(string[] args)
        {
            Account myAccount = new Account(2000);
            Expense expense = new Expense(myAccount, 500);

            Console.WriteLine(myAccount.Balance);

        }
    }
}