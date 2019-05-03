using BLL.Interface.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    public interface IAccount
    {
        int AccountNumber { get; set; }
        string Owner { get; set; }
        int Balance { get; set; }
        int Bonuses { get; set; }
        AccountType Type { get; set; }
    }

}
