using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeworkDay11.Fibonacci
{
    public class Fibonacci
    {
        public int FibonachiFinder(int number)
        {
            int a = 0, b = 1;
            for (int i = 1; i < number; i++)
            {
                (a, b) = (b, a + b);
            }

            return a;
        }
    }
}
