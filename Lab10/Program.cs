using System;

namespace Lab10
{
    class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание:
Программа реализует циклический сдвиг в 2^p разрядном целом числе на n бит влево и вправо.
Программа написана студентом группы M8O - 112M - 17 Соломиновым Владиславом.");
        }
        static int shl(int value, int ss, int n)
        {
            return ((value & ((1 << ss - n) - 1)) << n) | (value >> ss - n);
        }
        static int shr(int value, int ss, int n)
        {
            return (value >> n) | ((value & ((1 << n) - 1)) << ss - n);
        }
        static int InputData()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.WriteLine("Вы ввели неверное значение! Повторите ввод: ");
            }
            return value;
        }
        static void Main()
        {
            About();
            Console.Write("Введите число: ");
            int value = InputData();
            Console.WriteLine("Ваше число в двоичном представлении: " + Convert.ToString(value, 2));
            int p, n;
            do
            {
                Console.Write("\nВведите основание системы счисления: ");
                p = InputData();
            }
          
            while (p > 5 || p < 1);
            do
            {
                Console.Write("\nВведите на сколько байт будем двигать: ");
                n = InputData();
            }
            while (n > (int)Math.Pow(2, p) || n < 1);

            Console.WriteLine("Ваше число сдвинуто циклически на {0} бит влево: {1}", value, shl(value, (int)Math.Pow(2,p), n));
            Console.WriteLine("В двоичном представлении: " + Convert.ToString(shl(value, (int)Math.Pow(2, p), n), 2));
            Console.WriteLine("Ваше число сдвинуто циклически на {0} бит вправо: {1}", value, shr(value, (int)Math.Pow(2, p), n));
            Console.WriteLine("В двоичном представлении: " + Convert.ToString(shr(value, (int)Math.Pow(2, p), n), 2));
        }
    }
}
