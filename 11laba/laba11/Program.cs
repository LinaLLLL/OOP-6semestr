using System;
using System.Collections;
using System.Collections.Generic;

namespace Laba10part3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем экземпляр TestCollections
            TestCollections testCollections = new TestCollections(1000); // 1000 - количество элементов

            //поиск элементов
            testCollections.SearchTest();

            // добавление элемента
            Student student = new Student();
            student.RandomInit();

            testCollections.Add(student);
            testCollections.PrintLastElement();

            //удаление элемента
            testCollections.Remove(student);
            Console.WriteLine("Последний элемент был удален");
            testCollections.PrintLastElement();

        }

    }
}