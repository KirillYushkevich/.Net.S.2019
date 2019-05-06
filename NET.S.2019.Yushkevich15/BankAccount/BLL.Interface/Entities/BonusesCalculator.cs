﻿using BLL.Interface.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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