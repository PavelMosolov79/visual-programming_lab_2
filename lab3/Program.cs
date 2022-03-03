

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