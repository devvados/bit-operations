using System;


namespace Lab8
{
    class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание:
Найти максимальную степень 2, на которую делится данное целое число.
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
            Console.WriteLine("Максимальная степень двойки на которую делится данное число: " + (value&-value));
            //Console.WriteLine(((value ^ (value-1))>>1)+1);
        }
    }
}
