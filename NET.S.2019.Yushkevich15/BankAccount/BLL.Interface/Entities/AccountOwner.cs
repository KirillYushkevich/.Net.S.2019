using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Entities
{
    class AccountOwner : IAccountOwner
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
