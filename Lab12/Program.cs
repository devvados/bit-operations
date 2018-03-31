using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab12
{
    class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание:
Пусть x целое число. Найти такое p, что 2^p <= x <= 2^(p+1).
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
            Console.Write("Введите число x: ");
            int x = InputData();
            Console.WriteLine("Ваше число в двоичном представлении: " + Convert.ToString(x, 2));
            int p = 0;

            while (!((1 << p) <= x && x <= 1 << (p + 1))) p++;

            Console.WriteLine("Число p = {0}", p);
        }
    }
}

