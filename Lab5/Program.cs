using System;

namespace Lab5
{
   public class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание: С клавиатуры вводится 32-х разрядное целое число a в двоичной системе счисления. 
    1. Вывести k-ый бит числа a. Номер бита предварительно запросить у пользователя. 
    2. Установить/снять k-ый бит числа a. 
    3. Поменять местами i-ый и j-ый биты в числе a. Числа i и j запросить у пользователя. 
    4. Обнулить младшие m бит.
Программа написана студентом группы M8O - 112M - 17 Соломиновым Владиславом.");
        }
        //функия проверяет установлен ли бит на нужной позиции
        static byte CheckBit(int value, int position)
        {
            if ((value & (1 << position)) == 0)  return 0;
            else return 1;
        }
        //включение-выключение бита
        static int OnOffBit(int value, int position)
        {
                return (value ^ (1 << position));   
        }
        //замена битов
        static int SwapBits(int value, int i, int j)
        {
            if(i>j)
            {
                int temp = i;
                i = j;
                j = temp;
            }

            int ii = (value & (1 << i)) >> i;
            int jj = (value & (1 << j)) >> j;

            value &= ~(1 << i);
            value &= ~(1 << j);

            value |= ii << j;
            value |= jj << ii;

            return value;
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

            Console.WriteLine("Введите число: ");
            int value = InputData();
           // int value = Convert.ToInt32(Console.ReadLine(), 2);
            Console.WriteLine("Ваше число в двоичном представлении: " + Convert.ToString(value, 2));
            Console.WriteLine("Введите позицию для проверки бита: ");
            int position;
            while(((position = InputData()) > 31) || (position < 0))
            {
                Console.Write("\nПозиция должна быть целым числом в интервале 0 - 31. Повторите ввод: ");
            }
            Console.WriteLine("{0} бит числа {1} равен {2}", position, value, CheckBit(value, position));
            Console.WriteLine("{0} бит числа {1} установлен/снят. Результат: {2}", position, value, OnOffBit(value, position));
            Console.WriteLine("Рузультат в двоичном представлении: " + Convert.ToString(OnOffBit(value, position), 2));
            Console.WriteLine("Введите, какие биты вы хотите поменять в числе: ");
            int i;
            int j;
            while(((i = InputData()) > 31 || i < 0) || ((j = InputData()) > 31 || j < 0))
            {
                Console.Write("\nПозиции должны быть целыми числами в интервале 0 - 31. Повторите ввод: ");
            }
            Console.WriteLine("Результат обмена битов: {0}", SwapBits(value, i, j));
            Console.WriteLine("Результат обмена битов в двоичном представлении: " + Convert.ToString(SwapBits(value, i, j), 2));
            Console.WriteLine("Сколько младших бит вы хотите обнулить: ");
            while ((position = InputData()) > 31 || position < 0)
            {
                Console.Write("\nКоличество бит должно быть целым числом в интервале 0 - 31. Повторите ввод: ");
            }
            Console.WriteLine("В числе {0} обнулены {1} бит. Результат: {2}", value, position, value &(~((1 << position) - 1)));
            Console.WriteLine("Результат обнуления в двоичном виде : " + Convert.ToString(value & (~((1 << position) - 1)), 2));


        }
    }
}
