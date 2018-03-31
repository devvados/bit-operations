using System;

namespace Lab6
{
    class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание:
A) ""Склеить"" первые i битов с последними i битами из целого числа длиной len битов. 
B) Получить биты из целого числа длиной len битов, находящиеся между первыми i битами и последними i битами. 
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
            Console.Write("\nВведите число, битами которого мы будем оперировать: ");
            int value = InputData();
            Console.WriteLine("Ваше число в двоичном представлении: " + Convert.ToString(value,2));
            Console.Write("Введите кол-во битов в числе: ");
            int numBits;
            while((numBits = InputData()) > 32 || numBits < 2 )
            {
                Console.WriteLine("Введены неправельные данные, значение должно быть 2 <= int <= 32 повторите ввод:");
            }
            Console.Write("\nВведите количество первых i и последних i бит: ");
            int position;
            while ((position = InputData()) > numBits/2 || position < 1) //(numBits << 2) не работало!
            {
                Console.WriteLine("Введены неправельные данные, повторите ввод:");
            }
            value &= ((1 << numBits) - 1); // получить биты в соответсвии с введёной длиной
            int stBits = ((value >> numBits - position) << position); // получить старшие биты
            int mlBits = value & ((1 << position) - 1); // получить младшие биты
            Console.WriteLine("Старшие биты + младшие быты = {0} + {1} = {2}", stBits, mlBits, stBits|mlBits);
            Console.WriteLine("В двоичном представлении: {0} + {1} = {2}", Convert.ToString(stBits,2), Convert.ToString(mlBits, 2), Convert.ToString(stBits | mlBits, 2));
            int srBits = (value >> position) & ((1 << (numBits - position - position)) - 1); // получить средние биты
            Console.WriteLine("Промежутоные быты = " + srBits);
            Console.WriteLine("В двоичном представлении: " + Convert.ToString(srBits, 2));
        }
    }
}
