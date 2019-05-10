using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interface.DTO
{
    public class AccountDTO
    {
       public int AccountNumber { get; set; }

       public string Owner { get; set; }

       public int Balance { get; set; }

       public int Bonuses { get; set; }

       public AccountType Type { get; set; }
    }
}
