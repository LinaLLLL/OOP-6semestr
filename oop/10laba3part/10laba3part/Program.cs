using System;

namespace laba103part
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Конструктор без параметров");
            IInit p1 = new Person();
            if (p1 is Person person)
            {
                person.Show();
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("Конструктор с параметрами");
            IInit p2 = new Person("Петров Петр Петрович", "Мужчина", 23);
            if (p2 is Person person2)
            {
                person2.Show();
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("RandomInit");
            IInit p3 = new Person();
            if (p3 is Person person3)
            {
                person3.RandomInit();
                person3.Show();
            }
            Console.WriteLine("________________________________");
            Person p4 = new Person("Петров Петр Петрович", "Мужчина", 23);
            p4.Show();

            Console.WriteLine("Конструктор без параметров");
            IInit s1 = new Student();
            if (s1 is Student student)
            {
                student.Show();
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("Конструктор с параметрами");
            IInit s2 = new Student("Иванов Иван Иванович", "Мужчина", 23, "ПНИПУ", 3);
            if (s2 is Student student2)
            {
                student2.Show();
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("RandomInit");
            IInit s3 = new Student();
            if (s3 is Student student3)
            {
                student3.RandomInit();
                student3.Show();
            }
            Console.WriteLine("________________________________");
            Student s4 = new Student("Иванов Иван Иванович", "Мужчина", 23, "ПНИПУ", 3);
            s4.Show();

            Console.WriteLine("Конструктор без параметров");
            IInit t1 = new Teacher();
            if (t1 is Teacher teacher)
            {
                teacher.Show();
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("Конструктор с параметрами");
            IInit t2 = new Teacher("Иванов Иван Иванович", "Мужчина", 53, "Школа", 20);
            if (t2 is Teacher teacher2)
            {
                teacher2.Show();
            }
            Console.WriteLine("________________________________");
            Console.WriteLine("RandomInit");
            IInit t3 = new Teacher();
            if (t3 is Teacher teacher3)
            {
                teacher3.RandomInit();
                teacher3.Show();
            }
            Console.WriteLine("________________________________");

            Console.WriteLine("Конструктор без параметров");
            Employee e1 = new Employee();
            e1.Show();
            Console.WriteLine("________________________________");
            Employee e2 = new Employee("Норматова Галина Сергеевна", "Женщина", 35, "Ресторан", "Шеф-повар", 10);
            e2.Show();
            Console.WriteLine("________________________________");


            //Person p3 = new Person();
            //p3.RandomInit(p3);
            //Student s3 = new Student();
            //s3.RandomInit(s3);
            //Teacher t3 = new Teacher();
            //t3.RandomInit(t3);
            //Employee e3 = new Employee();
            //e3.RandomInit(e3);
            ////e3.Show();
            //Console.WriteLine("________________________________");
            //Console.WriteLine("ВЫВОД МАССИВА");
            //Console.WriteLine("________________________________");
            //Person[] arr = { p3, s3, t3, e3 };
            //foreach (Person p in arr)
            //{
            //    p.Show();
            //    Console.WriteLine("________________________________");
            //}
            if (p2 is Person person4)
            {
                Console.WriteLine($"Равны ли {person4.name} и {p4.name}: {person4.Equals(p4)}"); // проверка на равенство Person
            }
            if (s2 is Person student4)
            {
                Console.WriteLine($"Равны ли {student4.name} и {s4.name}: {student4.Equals(s4)}"); // проверка на равенство Student
            }
        }


    }
}