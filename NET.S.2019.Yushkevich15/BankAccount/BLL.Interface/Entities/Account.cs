using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    public class Account : IAccount
    {
        public int AccountNumber { get; set; }        
        public int Bonuses
        {
            get => Bonuses;
            set
            {
                if(value<=0)
                {
                    Bonuses = 0;
                }
            }
        }
        public AccountType Type { get; set; }
        public string Owner { get ; set ; }
        public int Balance { get ; set ; }

        public Account(int id,string owner,AccountType type)
        {
            AccountNumber = id;
            Owner = owner;
            Balance = 0;
            Bonuses = 0;
            Type = type;
        }
        public override string ToString()
        {
            return "ID: "+AccountNumber+" Status: "+Balance;
        }
    }
}
