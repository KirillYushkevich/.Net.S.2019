using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaBeneAnketa.data
{
   
    public class Question
    {
        public string Problem { get; set; }
        public bool Answerd { get; set; }
        public string Answer { get; set; }
        public Question(string text)
        {
            Problem = text;
        }
    }
}
