using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class AccountNumberCreator : IAccountNumberCreateService
    {
        public int Last;
        public int GenerateNewAccountNumber()
        {
            Random random = new Random();
            Last= random.Next(100000000);
            return Last;
        }
    }
}
