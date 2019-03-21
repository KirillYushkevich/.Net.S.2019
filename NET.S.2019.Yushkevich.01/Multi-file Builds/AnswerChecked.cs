using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotaBeneAnketa.data
{
    public class AnswerChecked
    {
        public string Text { get; set; }
        public bool Checked { get; set; }
        public AnswerChecked (string text,bool cheked)
        {
            Text = text;
            Checked = cheked;
        }
    }
}
