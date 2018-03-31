using System;

namespace Lab7
{
    class Program
    {
        static void About()
        {
            Console.WriteLine(@"Задание:
Поменять местами байты в заданном 32-х разрядном целом числе. Перестановка задается пользователем. 
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
            Console.WriteLine("Ваше число в двоичном представлении: " + Convert.ToString(value,2));
            int numByte1, numByte2;
            Console.Write("\nВведите номер первого байта для замены: ");
            do
            {
                numByte1 = InputData();
            }
            while (numByte1 > 4 || numByte1 < 1);
            Console.Write("\nВведите номер второго байта для замены: ");
            do
            {
                numByte2 = InputData();
            }
            while (numByte2 > 4 || numByte2 < 1);

            if (numByte1 > numByte2)
            {
                int dop = numByte1;
                numByte1 = numByte2;
                numByte2 = dop;
            }

            //получить байты из числа
            int tempByte1 = ((value >> ((numByte1 - 1) * 8)) & ((1 << 8) - 1)) << ((numByte1 - 1) * 8);
            int tempByte2 = ((value >> ((numByte2 - 1) * 8)) & ((1 << 8) - 1)) << ((numByte2 - 1) * 8);
            //обнулить байты в числе
            value &= (~(((1 << 8) - 1) << (numByte1 - 1) * 8));
            value &= (~(((1 << 8) - 1) << (numByte2 - 1) * 8));
            //поставить байты на свои позиции
            value |= tempByte1 << ((numByte2 - numByte1) * 8);;
            value |= tempByte2 >> ((numByte2 - numByte1) * 8);
            Console.WriteLine("Результат: " + value + "\nВ двоичном представлении: " + Convert.ToString(value, 2));
        }
    }
}
