using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay11.ClockImitation
{
    public class ConsoleTesting
    {
        public static void Main()
        {
            Clock a = new Clock(12, (sender, e) => Console.WriteLine(e.FinishTime));
        }
    }
}
