using System;

namespace Bank.Data.Models
{
    public class Account : IEquatable<Account>
    {
        public readonly string ID;
        public readonly string Name;
        public readonly string Surname;
        private int _balance;
       
        public Account(string id, string name, string surname, string status, int balance = 0, int bonuses = 0)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Status = (AccountStatus)Enum.Parse(typeof(AccountStatus), status);
            Balance = balance;
            Bonuses = bonuses;
        }

        public int Balance
        {
            get
            {
                return _balance;
            }

            set
            {
                if (value < 0)
                {
                    throw new Exception("Cant withdraw money");
                }

                if (_balance > value)
                {
                    Bonuses = Bonuses - BonusCalc(_balance - value);
                }
                else if (_balance < value)
                {
                    Bonuses += BonusCalc(value - _balance);
                }

                _balance = value;
            }
        }

        public int Bonuses { get; set; }

        public AccountStatus Status { get; set; }

        /// <summary>Check two Account for Equality</summary>
        /// <param name="other">Second Account</param>
        /// <return>bool</return>
        public bool Equals(Account other)
        {
            if (this.ID == other.ID)
            {
                return true;
            }

            return false;
        }

        public override string ToString()
        {
            return ID + " " + Balance.ToString() + " " + Bonuses.ToString() + " ";
        }

        /// <summary>Calculate bonuses</summary>
        /// <param name="balanceChange">Balance difference</param>
        /// <return>Bonuses change</return>
        private int BonusCalc(int balanceChange)
        {
            return (balanceChange / 1000) * (int)Status;
        }
    }
}
