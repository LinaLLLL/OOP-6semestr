using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba10part3
{
    public class TestCollections
    {
        private List<Student> list1;
        private List<string> list2;
        private Dictionary<Person, Student> dict1;
        private Dictionary<string, Student> dict2;

        private int size;

        public TestCollections(int size)
        {
            this.size = size;
            list1 = new List<Student>();
            list2 = new List<string>();
            dict1 = new Dictionary<Person, Student>();
            dict2 = new Dictionary<string, Student>();
            
            // Генерация и добавление одинаковых объектов с помощью RandomInit
            for (int i = 0; i < size; i++)
            {
                // Создаём объект Student и инициализируем его случайными значениями
                Student s = new Student();
                s.RandomInit(); // Инициализируем объект случайными значениями

                // Генерируем ключ для словаря
                Person basePerson = s.BasePerson;
                string strKey = s.ToString();

                // Добавляем элементы в коллекции
                list1.Add(s);
                list2.Add(s.ToString());
                dict1.Add(new Person(s.id.number, s.name,s.gender, s.age), s);
                dict2.Add(s.ToString(), s);
            }
        }
        public void Add(Student s)
        {
            list1.Add(s);
            list2.Add(s.ToString());
            dict1[s.BasePerson] = s;
            dict2[s.ToString()] = s;
        }
        public bool Remove(Student s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));

            // Создаем ключи один раз
            var personKey = new Person(s.id.number, s.name, s.gender, s.age);
            string stringKey = s.ToString();

            // Проверяем наличие элемента в первой коллекции (предполагая, что во всех одинаково)
            bool exists = list1.Contains(s);
            if (!exists)
            {
                return false; // элемента нет ни в одной коллекции
            }

            // Удаляем из всех коллекций
            bool removedFromList1 = list1.Remove(s);
            bool removedFromList2 = list2.Remove(stringKey);
            bool removedFromDict1 = dict1.Remove(personKey);
            bool removedFromDict2 = dict2.Remove(stringKey);
            return true;
        }
        public void SearchTest()
        {
            if (list1.Count == 0) return; // Проверка на пустую коллекцию

            // Получаем тестовые элементы
            var first = list1[0];               // Первый элемент
            var middle = list1[list1.Count / 2]; // Центральный элемент
            var last = list1[list1.Count - 1];   // Последний элемент

            // Создаем несуществующий элемент
            var missing = new Student();
            missing.RandomInit();
            var missingPerson = missing.BasePerson;

            var originalKeys = dict1.Keys.ToList();
            var missingKey = Guid.NewGuid().ToString();


            var tests = new (string name, Student student, Person personKey)[]
            {
            ("Первый", first, originalKeys[0]),
            ("Центральный", middle, originalKeys[list1.Count/2]),
            ("Последний", last, originalKeys[list1.Count-1]),
            ("Отсутствующий", missing, missingPerson)
            };

            foreach (var (name, student, personKey) in tests)
            {
                string key = student.ToString(); //ключ в словаре dict2

                Console.WriteLine($"\nПоиск: {name} элемент");

                Stopwatch sw = Stopwatch.StartNew(); //запуск таймера
                bool found1 = list1.Contains(student); // метод Contains
                sw.Stop();
                Console.WriteLine($"list1<Student>.Contains: {found1} за {sw.ElapsedTicks} тиков");

                sw.Restart();
                bool found2 = list2.Contains(key); // метод Contains
                sw.Stop();
                Console.WriteLine($"list2<string>.Contains: {found2} за {sw.ElapsedTicks} тиков");

                sw.Restart();
                bool found3 = dict1.ContainsKey(personKey); // метод ContainsKey
                sw.Stop();
                Console.WriteLine($"Dictionary<Person, Student>.ContainsKey: {found3} за {sw.ElapsedTicks} тиков");

                sw.Restart();
                bool found4 = dict2.ContainsKey(key); // метод ContainsKey
                sw.Stop(); 
                Console.WriteLine($"Dictionary<string, Student>.ContainsKey: {found4} за {sw.ElapsedTicks} тиков");

                sw.Restart();
                bool found5 = dict1.ContainsValue(student); // метод ContainsValue
                sw.Stop();
                Console.WriteLine($"Dictionary<Person, Student>.ContainsValue: {found5} за {sw.ElapsedTicks} тиков");
            }
        }
        public void PrintLastElement()
        {
            if (list1.Count > 0)
            {
                Student last = list1[list1.Count - 1];
                Console.WriteLine("Последний элемент:");
                Console.WriteLine(last); // или last.ToString(), если метод переопределён
            }
            else
            {
                Console.WriteLine("Список пуст. Элементов нет.");
            }
        }
    }
}
