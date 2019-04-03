using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HomeworkDay4
{
    public class Polynomial
    {
        public Polynomial(List<double> coefArray)
        {
            _coefficents = coefArray;
        }

        public Polynomial(int size)
        {
            _coefficents = new List<double>(size);
            for (int i = 0; i < size; i++)
            {
                _coefficents.Add(0);
            }
        }

        private List<double> _coefficents; 

        public double this[int i]
        {
            get
            {
                return _coefficents[i];
            }

            set
            {
                if(value>=double.MaxValue || value<=double.MinValue)
                {
                    throw new ArgumentNullException();
                }
                _coefficents[i] = value;
            }
        }

        public static bool operator ==(Polynomial pol1, Polynomial pol2)
        {
            if (pol1._coefficents.Count != pol2._coefficents.Count)
            {
                return false;
            }

            for (int i = 0; i < pol1._coefficents.Count - 1; i++)
            {
                if (pol1._coefficents[i] != pol2._coefficents[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool operator !=(Polynomial pol1, Polynomial pol2)
        {
            if (pol1._coefficents.Count != pol2._coefficents.Count)
            {
                return true;
            }

            for (int i = 0; i < pol1._coefficents.Count - 1; i++)
            {
                if (pol1._coefficents[i] != pol2._coefficents[i])
                {
                    return true;
                }
            }

            return false;
        }

        public static Polynomial operator +(Polynomial pol1, Polynomial pol2)
        {
            int maxSize;
            if (pol1._coefficents.Count > pol2._coefficents.Count)
            {
                maxSize = pol1._coefficents.Count;
            }
            else
            {
                maxSize = pol2._coefficents.Count;
            }

            Polynomial result = new Polynomial(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result._coefficents[i] = pol1[i] + pol2[i];
            }

            return result;
        }

        public static Polynomial operator -(Polynomial pol1, Polynomial pol2)
        {
            int maxSize;
            if (pol1._coefficents.Count > pol2._coefficents.Count)
            {
                maxSize = pol1._coefficents.Count;
            }
            else
            {
                maxSize = pol2._coefficents.Count;
            }

            Polynomial result = new Polynomial(maxSize);

            for (int i = 0; i < maxSize; i++)
            {
                result._coefficents[i] = pol1[i] - pol2[i];
            }

            return result;
        }

        public static Polynomial operator *(Polynomial pol1, int number)
        {
            Polynomial result = new Polynomial(pol1._coefficents.Count);
            for (int i = 0; i < pol1._coefficents.Count; i++)
            {
                result._coefficents[i] = pol1[i] * number;
            }

            return result;
        }

        public static Polynomial operator *(Polynomial pol1, Polynomial pol2)
        {
            Polynomial result = new Polynomial(pol1._coefficents.Count + pol2._coefficents.Count - 1);
            result._coefficents.Select(x => 0);

            for (int i = 0; i < pol1._coefficents.Count; i++)
            {
                for (int j = 0; j < pol2._coefficents.Count; j++)
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
            return _coefficents.Count;
        }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < _coefficents.Count; i++)
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
