using AccountManagement;
using AccountControl;

namespace Program{
    class Program{
        private static void Main(string[] args)
        {
            var baseDir = AppContext.BaseDirectory;
            var savesDir = Path.Combine(baseDir, "save");
            Directory.CreateDirectory(savesDir);
            var accountsPath = Path.Combine(savesDir, "accounts.json");
            
            JsonAccountRepository jsonAccount = new JsonAccountRepository(accountsPath);
          
            Console.WriteLine("Hello Welcome to our Finance Management System");
            Console.WriteLine("Please Choose an option");
            Console.WriteLine("1.Login");
            Console.WriteLine("2.Register");
            Console.WriteLine("3.Exit");

            string? choice = Console.ReadLine();

            switch(choice){
                case "1": 
                    Login(jsonAccount);
                    break;
                case "2": 
                    Register(jsonAccount);
                    break;
                case "3": 
                    Environment.Exit(0);
                    break;
            }
        }

        private static void Login(JsonAccountRepository jsonAccount){
            Console.WriteLine("Please enter your account ID");
            string? _id = Console.ReadLine();

            Console.WriteLine("Password:");
            string? _password = Console.ReadLine();
            
            Account ?account;

            if(_id != null && _password != null && int.TryParse(_id, out int ID)) {account = jsonAccount.GetByCreds(ID, _password);} 
            else {Console.WriteLine("Invalid Credentials"); account = null;}

            if(account != null) {
                ConsoleControl consoleControl = new ConsoleControl();
                consoleControl.ControlPanel(account);
            } 
        }

        private static void Register(JsonAccountRepository jsonAccount){
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
            string? password;
            while(true)
            {
                Console.WriteLine("Please enter your password (must be > 6 chars and include a symbol)");
                string? result = Console.ReadLine();

                if(result != null && IsValidPassword(result)) { password = result; break; }
                else
                {
                    Console.WriteLine("Invalid password. It must be longer than 6 characters and include at least one symbol.");
                }
            }
            Account account = new Account(_balance, password, _debt);

            jsonAccount.Add(account);

            Console.WriteLine($"Your account ID is: {account.ID}");
        }
        private static bool IsValidPassword(string password)
        {
            if (password.Length <= 6) return false;
            bool hasSymbol = password.Any(ch => char.IsPunctuation(ch) || char.IsSymbol(ch));
            return hasSymbol;
        }
    }
}