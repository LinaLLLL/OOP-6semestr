using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Microsoft.Exchange.WebServices.Data;
using System.Collections;
using System.Linq;
using System.Diagnostics;
using ClassLibrary14;



namespace ClassLibrary13
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            // Вуз: Dictionary, где ключ — название факультета, а значение — список студентов
            Dictionary<string, List<Student>> university = new Dictionary<string, List<Student>>();


            var students = new MyNewCollection<Student>("Студенты");
            int col = 10;
            for (int j = 0; j < col; j++)
            {
                Student s = new Student();
                s.RandomInit();
                students.Add(s);
            }

            foreach (var student in students)
            {
                if (!university.ContainsKey(student.placeStudy))
                    university[student.placeStudy] = new List<Student>();

                university[student.placeStudy].Add(student);
            }

            foreach (var uni in university)
            {
                Console.WriteLine($"Университет: {uni.Key}");
                foreach (var st in uni.Value)
                    Console.WriteLine($"  - {st}");
            }

            //запрос на выборку: имена всех лиц женского пола(linq)
            sw.Start();
            var fimaleNames = from student in students 
                              where student.gender == "Женщина" 
                              select student.name;
            sw.Stop();
            Console.WriteLine("\nЖенщины:");
            foreach (var f in fimaleNames)
                Console.WriteLine(f);
            Console.WriteLine("LINQ-запрос на выборку: " + sw.ElapsedTicks + " тиков");

            //метод расширения
            sw.Start();
            var fimaleNames2 = students.Where(s => s.gender == "Женщина");
            sw.Stop();
            Console.WriteLine("\nЖенщины:");
            foreach (var f in fimaleNames)
                Console.WriteLine(f);
            Console.WriteLine("Метод расширения на выборку: " + sw.ElapsedTicks + " тиков");

            //запрос на выборку студентов определенного курса(метод linq)
            sw.Start();
            var yearInUniversity = from student in students
                                   where student.yearUniversity == 3
                                   select student.name;
            sw.Stop();
            Console.WriteLine("\nСтуденты на 3 курсе: ");
            foreach (var student in yearInUniversity)
            {
                Console.WriteLine(student);
            }
            Console.WriteLine("Метод linq на выборку: " + sw.ElapsedTicks + " тиков");


            var persons = new MyNewCollection<Person>("Люди");
            for (int j = 0; j < col; j++)
            {
                Person p = new Person();
                p.RandomInit();
                persons.Add(p);
            }
            //запрос - использование операций над множествами(используются только как метод расширения)
            sw.Start();
            var unionResult = students.Union(persons);
            sw.Stop();
            Console.WriteLine("\nОперация Union(пересечение множест с удалением дубликатов)");
            foreach (var ur in unionResult)
                Console.WriteLine(ur);
            Console.WriteLine("Метод расширения union: " + sw.ElapsedTicks + " тиков");

            //агрегирование данных(используются только как метод расширения)
            sw.Start();
            var ageMax = (from student in students select student.age).Max();
            sw.Stop();
            Console.WriteLine("\nМаксимальный возраст " + ageMax.ToString());
            Console.WriteLine("Метод расширения на агрегирование: " + sw.ElapsedTicks + " тиков");

            sw.Start();
            var ageAvg = (from student in students select student.age).Average();
            sw.Stop();
            Console.WriteLine("\nСредний возраст " + ageAvg.ToString());
            Console.WriteLine("Метод расширения на агрегирование: " + sw.ElapsedTicks + " тиков");

            //группировка данных(метод расширения)
            sw.Start();
            var groupedByFaculty = students.GroupBy(s => s.faculty);
            sw.Stop();
            Console.WriteLine("\nГруппировка по факультетам (метод расширения)");
            foreach (var group in groupedByFaculty)
            {
                Console.WriteLine($"Факультет: {group.Key}");
                foreach(var student in group)
                {
                    Console.WriteLine($" - {student.name}, возраст: {student.age}");
                }
            }
            Console.WriteLine("Метод расширения на группировку: " + sw.ElapsedTicks + " тиков");

            //группировка данных(метод linq)
            sw.Start();
            var groupedByFaculty1 = from student in students
                                    group student by student.faculty into facultyGroup
                                    select facultyGroup;
            sw.Stop();
            Console.WriteLine("\nГруппировка по факультетам (метод linq)");
            foreach (var group in groupedByFaculty1)
            {
                Console.WriteLine($"Факультет: {group.Key}");
                foreach (var student in group)
                {
                    Console.WriteLine($" - {student.name}, возраст: {student.age}");
                }
            }
            Console.WriteLine("Метод linq на группировку: " + sw.ElapsedTicks + " тиков");

            // группировка данных linq метод
            //var groupedByUniversity = from student in students
            //                          group student by student.placeStudy into universityGroup
            //                          select universityGroup;
            //Console.WriteLine("\nГруппировка по университетам");
            //foreach (var group in groupedByUniversity)
            //{
            //    Console.WriteLine($"Университет: {group.Key}");
            //    foreach (var student in group)
            //    {
            //        Console.WriteLine($" - {student.name}, возраст: {student.age}");
            //    }
            //}


            // let запрос Linq(вывод студентов старше 50) - let есть только в linq
            Console.WriteLine("\nLet");
            var query = from student in students
                        let isOlder = student.age > 50
                        where isOlder
                        select student;

            foreach(var student in query)
                Console.WriteLine($"{student.name} - {student.age}");

            //запрос join(выводит пару студент-преподаватель по ключу университет) (linq)
            var teachers = new MyNewCollection<Teacher>("Преподаватели");
            for (int j = 0; j < col; j++)
            {
                Teacher t = new Teacher();
                t.RandomInit();
                teachers.Add(t);
            }
            sw.Start();
            var joinQyery = from student in students
                            join teacher in teachers
                            on student.placeStudy equals teacher.placeWork
                            select new
                            {
                                StudentName = student.name,
                                TeacherName = teacher.name,
                                University = student.placeStudy
                            };
            sw.Stop();
            Console.WriteLine("\nЗапрос join (запрос linq)");
            foreach (var item in joinQyery)
            {
                Console.WriteLine($"Университет: {item.University}");
                Console.WriteLine($"Студент: {item.StudentName}");
                Console.WriteLine($"Преподаватель: {item.TeacherName}\n");
            }
            Console.WriteLine("Метод linq join: " + sw.ElapsedTicks + " тиков");
            //запрос join с расширенным методом
            sw.Start();
            var joinQyery2 = students.Join(teachers,
                student => student.placeStudy,
                teachers => teachers.placeWork,
                (student, teacher) => new
                {
                    StudentName = student.name,
                    TeacherName = teacher.name,
                    University = student.placeStudy
                });
            sw.Stop();
            Console.WriteLine("\nЗапрос join (метод расширения)");
            foreach (var item in joinQyery2)
            {
                Console.WriteLine($"Университет: {item.University}");
                Console.WriteLine($"Студент: {item.StudentName}");
                Console.WriteLine($"Преподаватель: {item.TeacherName}\n");
            }
            Console.WriteLine("Метод linq join: " + sw.ElapsedTicks + " тиков");


            // 2 часть
            //выбор по условию
            Console.WriteLine("\n2 часть");
            Console.WriteLine("\nВыборка по условию");
            var adults = students.WhereCustom(s => s.age >= 40);
            foreach (var student in adults)
            {
                Console.WriteLine(student);
            }

            //агрегирование
            Console.WriteLine("\nАгрегирование");
            int totalAge = students.AggregateCustom(0, (acc, s) => acc + s.age);
            Console.WriteLine($"Сумма возрастов: {totalAge}");

            //сортировка
            Console.WriteLine("\nСортировка");
            var sorted = students.OrderByCustom(s => s.name);
            foreach (var student in sorted)
            {
                Console.WriteLine(student);
            }

            //группировка
            Console.WriteLine("\nГруппировка");
            var grouped = students.GroupByCustom(s => s.faculty);
            foreach (var group in grouped)
            {
                Console.WriteLine($"Факультет: {group.Key}");
                foreach (var student in group)
                {
                Console.WriteLine(" -" + student); 
                }
            }

        }

    }
}