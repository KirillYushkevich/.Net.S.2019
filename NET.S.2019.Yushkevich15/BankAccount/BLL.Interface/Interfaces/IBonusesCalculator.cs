using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interface.Interfaces
{
    interface IBonusesCalculator
    {
        void UpdateBonuses(IAccount account,int sum);
    }
}
