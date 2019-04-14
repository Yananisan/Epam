using BankSystem.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static BankSystem.BankService;

namespace BankSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Account> accounts = new List<Account>();
            BankService accountService = new BankService();

            accountService.Create(AccountType.Base, "Yana", "Ivanovskaya");
            accountService.Create(AccountType.Gold, "Gerald", "Rivia");
            accountService.Create(AccountType.Platinum, "Thranduil", "Oropherion");

            Console.ReadKey();
        }
    }
}
