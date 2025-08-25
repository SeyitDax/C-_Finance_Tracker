using AccountManagement;
namespace ExpenseManagement{

    public class Expense{
        private static int _nextId; 
        public int ID {get; set;}
        public decimal Amount {get; set;}
        public DateTime Time{get; set;}
        public string? Note{get; set;}

        public Expense(Account account,decimal amount, string note = null)
        {
            ID = System.Threading.Interlocked.Increment(ref _nextId);
            Amount = amount;
            Note = note;

            if(account.Balance >= amount){
                account.Balance -= amount;
            }
            else{
                amount -= account.Balance; account.Balance = 0; account.Debt = amount;
            }
        }
    }   
}