using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba_2
{
    public class RomanNumber : ICloneable, IComparable
    {
        private ushort value;
        private string romanVal;
        private string EROR = "Число вышло за границы (0 - 3,999)";

        public string Conversion_to_Roman(ushort n)
        {
            if (n < 0 || n > 3999)
                return EROR;

            if (n == 0) return "N";

            ushort[] values = new ushort[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            string[] num = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };


            StringBuilder result = new StringBuilder();


            for (int i = 0; i < 13; i++)
            {
                while (n >= values[i])
                {
                    n -= values[i];
                    result.Append(num[i]);
                }
            }

            return result.ToString();
        }
        
        public RomanNumber(ushort n)
        {
            value = n;
            romanVal = Conversion_to_Roman(n);
        }

        public static RomanNumber Add(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                return null;
            else
                return new RomanNumber((ushort)(n1.value + n2.value));
        }

        public static RomanNumber Sub(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                return null;
            else
                return new RomanNumber((ushort)(n1.value - n2.value));
        }

        public static RomanNumber Mul(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                return null;
            else
                return new RomanNumber((ushort)(n1.value * n2.value));
        }

        public static RomanNumber Div(RomanNumber? n1, RomanNumber? n2)
        {
            if (n1 == null || n2 == null)
                return null;
            else
                return new RomanNumber((ushort)(n1.value / n2.value));
        }

        public override string ToString()
        {
            return romanVal;
        }

        public object Clone()
        {
            return new RomanNumber(value);
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            RomanNumber another = obj as RomanNumber;
            if (another == null) throw new ArgumentException("Объект не является римским числом");
            return value.CompareTo(another.value);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int n = 10;
            Random rand = new Random();
            RomanNumber[] b = new RomanNumber[n];
            for (int i = 0; i < n; i++)
            {
                ushort x = (ushort)(rand.NextDouble() * 1000);
                b[i] = new RomanNumber(x);
                Console.WriteLine("Исходное число: " + x + " Римское число: " + b[i].ToString());
                Console.WriteLine("Сложение исходного числа и такого же числа: " + RomanNumber.Add(b[i], b[i]));
                Console.WriteLine("Вычитание из исходного числа такого же числа: " + RomanNumber.Sub(b[i], b[i]));
                Console.WriteLine("Умножение исходного числа на такое же число: " + RomanNumber.Mul(b[i], b[i]));
                Console.WriteLine("Деление исходного числа на такое же число: " + RomanNumber.Div(b[i], b[i]));
            }

            Array.Sort<RomanNumber>(b);
            Console.WriteLine();
            Console.WriteLine("Сортировка: ");
            foreach (RomanNumber a in b)
            {
                Console.WriteLine(a.ToString());
            }
        }
    }
}