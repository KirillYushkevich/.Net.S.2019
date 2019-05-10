using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Interface.Interfaces;

namespace BLL.Interface.Entities
{
    public class BonusesCalculator : IBonusesCalculator
    { 
        public void UpdateBonuses(IAccount account, int sum)
        {
            account.Bonuses += sum / 10;    
        }
    }
}
