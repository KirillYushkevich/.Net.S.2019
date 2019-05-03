using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    internal interface IAccountOwner
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
