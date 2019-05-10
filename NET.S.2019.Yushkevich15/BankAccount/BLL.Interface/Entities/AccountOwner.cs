using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class AccountOwner : IAccountOwner
    {
        public AccountOwner(string name, string surname)
        {
            FirstName = name;
            LastName = surname;
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
