using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Exchange.WebServices.Data;
using System.Collections;



namespace ClassLibrary13
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new MyNewCollection<Person>("Люди");
            var list2 = new MyNewCollection<Person>("Люди2");

            var journal = new Journal();
            var journal2 = new Journal();

            list.CollectionCountChanged += OnCollectionChanged;
            list2.CollectionCountChanged += OnCollectionChanged;
            list.CollectionReferenceChanged += OnCollectionChanged;
            list2.CollectionReferenceChanged += OnCollectionChanged;

            list.CollectionCountChanged += journal.OnCollectionChanged;
            list.CollectionReferenceChanged += journal.OnCollectionReferenceChanged;
            list.CollectionCountChanged += journal2.OnCollectionChanged;
            list.CollectionReferenceChanged += journal2.OnCollectionReferenceChanged;

            list2.CollectionCountChanged += journal2.OnCollectionChanged;
            list2.CollectionReferenceChanged += journal2.OnCollectionReferenceChanged;

            Console.WriteLine("Коллекция 1\n");
            int col = 10;
            for (int j = 0; j < col; j++)
            {
                Person p = new Person();
                p.RandomInit();
                list.Add(p);
            }
            Console.WriteLine("\nКоллекция 2\n");
            for (int j = 0; j < col; j++)
            {
                Person p = new Person();
                p.RandomInit();
                list2.Add(p);
            }
            Console.WriteLine("\nИзменение по индексу\n");
            Person p1 = new Person();
            p1.RandomInit();
            list[3] = p1;

            int del = 2;
            Console.WriteLine("\nУдаление из коллекции 1\n");
            list.Remove(del);
            Console.WriteLine("\nУдаление из коллекции 2\n");
            list2.Remove(del);
            Console.WriteLine("\nЖурнал 1\n");
            journal.PrintAllEntries();
            Console.WriteLine("\nЖурнал 2\n");
            journal2.PrintAllEntries();

            static void OnCollectionChanged(object source, CollectionHandlerEventArgs<Person> args)
            {
                Console.WriteLine(args.ToString());
            }


        }

    }
}