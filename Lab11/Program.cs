using System;

namespace Lab11
{
    class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание:
Дано n битовое данное. Задана перестановка бит (1, 8, 23, 0, 16, … ). Написать функцию, выполняющую эту перестановку
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
        //замена битов
        static int SwapBits(int value, int i, int j)
        {
            if (i > j)
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
        static void Main()
        {
            About();
            Console.Write("Введите число: ");
            int value = InputData();
            Console.WriteLine("Ваше число в двоичном представлении: " + Convert.ToString(value, 2));

            int p = InputData();
            if (p < 0 || p > 32)
            {
                Console.WriteLine("Не верное кол-во бит в числе!");
                return;
            }

            int[] pos = new int[p];

            for (int i = 0; i < p; i++)
            {
                pos[i] = InputData();
                if(pos[i]<0 || pos[i]>p)
                {
                    Console.WriteLine("Не верное введённая последовательность!");
                    return;
                }
            }

            int val2 = 0;
            for (int i = 0; i < p; i++)
            {
                if ((value & (1 << pos[i])) != 0)
                    val2 = val2 | (1 << p - 1 - i);
            }

            Console.WriteLine("Результат в двоичном представлении: " + Convert.ToString(val2, 2));
        }
    }
}
