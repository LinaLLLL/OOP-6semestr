//Решить указанные в варианте задачи, используя основные операторы языка С#.
//При решении задачи, использовать все типы циклов (for, while, do while).
//Вариант 5.	Дана последовательность из n целых чисел.
//Найти сумму элементов с нечетными номерами из этой последовательности.

using Microsoft.Win32;
using System;
using System.Diagnostics;

namespace _2laba
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество элементов n");
            int n = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Введите число:");
                int num = Convert.ToInt32(Console.ReadLine());
                if (i % 2 != 0)
                {
                    sum += num;
                }
            }
            Console.WriteLine($"Сумма элементов с нечетными номерами = {sum}");
        }
    }
}