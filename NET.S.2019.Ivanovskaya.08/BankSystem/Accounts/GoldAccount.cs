using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Accounts
{
    [Serializable]
    public class GoldAccount : Account
    {
        const int Procent = 50;

        public GoldAccount(string name, string lastname) : base(name, lastname) { }

        protected override void UpdateBonusPoints(int amount) => bPoints += amount / Procent;
    }
}
