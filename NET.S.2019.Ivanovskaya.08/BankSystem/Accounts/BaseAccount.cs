using System;

namespace BankSystem.Accounts
{
    [Serializable]
    public class BaseAccount : Account
    {
        const int Procent = 100; 

        public BaseAccount(string name, string lastname) : base(name, lastname) { }

        protected override void UpdateBonusPoints(int amount) => bPoints += amount / Procent;
    }
}
