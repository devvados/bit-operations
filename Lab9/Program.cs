using System;

namespace Lab9
{
    class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание:
Дано 2^p разрядное целое число. «Поксорить» все биты этого числа друг с другом.
Программа написана студентом группы M8O - 112M - 17 Соломиновым Владиславом.");
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
            int p;
            do
            {
                Console.Write("\nВведите кол-во разрядов: ");
                p = InputData();
            }
            while (p > 31 || p < 0);

            for(int i = 1; i <= p/2; i++) // p << 1 не работает!
            {
                int half = p / (2 * i); // (p << 1)/i
                int st = (value >> half);
                int ml = value & ((1 << half) - 1);
                value = st ^ ml;
                Console.WriteLine("ml = " + Convert.ToString(ml,2) + "\nst="+Convert.ToString(st,2)+"\nval="+Convert.ToString(value,2));
            }

        }
    }
}
