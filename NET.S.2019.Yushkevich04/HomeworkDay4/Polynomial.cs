using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkDay4
{
    public class Polynomial
    {
        public Polynomial(List<double> coefArray)
        {
            Coefficents = coefArray;
        }

        public Polynomial(int size)
        {
            Coefficents = new List<double>(size);
            for (int i = 0; i < size; i++)
            {
                Coefficents.Add(0);
            }
        }

        public List<double> Coefficents { get; set; }

        public double this[int i]
        {
            get
            {
                return Coefficents[i];
            }

            set
            {
                Coefficents[i] = value;
            }
        }

        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (pol1.Coefficents.Count != pol2.Coefficents.Count)
            {
                return false;
            }

            for (int i = 0; i < pol1.Coefficents.Count - 1; i++)
            {
                if (pol1.Coefficents[i] != pol2.Coefficents[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            if (pol1.Coefficents.Count != pol2.Coefficents.Count)
            {
                return true;
            }

            for (int i = 0; i < pol1.Coefficents.Count - 1; i++)
            {
                if (pol1.Coefficents[i] != pol2.Coefficents[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            int maxSize;
            if (pol1.Coefficents.Count > pol2.Coefficents.Count)
            {
                maxSize = pol1.Coefficents.Count;
            }
            else
            {
                maxSize = pol2.Coefficents.Count;
            }

            Polynomial result = new Polynomial(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result.Coefficents[i] = pol1[i] + pol2[i];
            }

            return result;
        }

        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            int maxSize;
            if (pol1.Coefficents.Count > pol2.Coefficents.Count)
            {
                maxSize = pol1.Coefficents.Count;
            }
            else
            {
                maxSize = pol2.Coefficents.Count;
            }

            Polynomial result = new Polynomial(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result.Coefficents[i] = pol1[i] - pol2[i];
            }

            return result;
        }

        public static Polynomial operator *(Polynomial pol1, int number)
        {
            Polynomial result = new Polynomial(pol1.Coefficents.Count);
            for (int i = 0; i < pol1.Coefficents.Count; i++)
            {
                result.Coefficents[i] = pol1[i] * number;
            }

            return result;
        }

        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            Polynomial result = new Polynomial(pol1.Coefficents.Count + pol2.Coefficents.Count - 1);
            result.Coefficents.Select(x => 0);

            for (int i = 0; i < pol1.Coefficents.Count; i++)
            {
                for (int j = 0; j < pol2.Coefficents.Count; j++)
                {
                    result[i + j] += pol1[i] * pol2[j];
                }   
            }

            return result;
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Polynomial))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public override int GetHashCode()
        {
            return Coefficents.Count;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < Coefficents.Count; i++)
            {
                if (this[i] == 0 && i != 0)
                {
                    continue;
                }

                if (i == 0)
                {
                    builder.Append(this[i] + " ");
                    continue;
                }

                if (this[i] > 0)
                {
                    builder.Append("+");
                }

                if (i == 1)
                {
                    builder.Append(this[i] + "*a");
                }

                builder.Append(this[i] + "*a^" + i + " ");
            }

            return builder.ToString();
        }
    }
}
