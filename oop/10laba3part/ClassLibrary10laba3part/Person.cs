using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace laba103part
{
    public class Person : IInit
    {
        public string name;
        public string gender;
        public int age;

        // конструктор без параметров
        public Person()
        {
            name = "No Name";
            gender = "No gender";
            age = 0;
            Console.WriteLine("Конструктор без параметров");
        }

        // конструктор с параметрами
        public Person(string _name, string _gender, int _age)
        {
            name = _name;
            gender = _gender;
            age = _age;
            
        }

        // конструктор копирования
        public Person(Person p)
        {
            this.name = p.name;
            this.gender = p.gender;
            this.age = p.age;
        }
        //метод show для вывода результата
        public virtual void Show()
        {
            Console.WriteLine(name);
            Console.WriteLine($"Пол: {gender}");
            Console.WriteLine($"Возраст: {age}");
        }

        //метод show для вывода Имени
        public virtual void ShowName()
        {
            Console.WriteLine(name);
            
        } 

        // метод init для ввода информации с клавиатуры
        public void Init()
        {
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите пол: ");
            gender = Console.ReadLine();
            Console.WriteLine("Введите возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
        }

        // метод random init для заполнения данных с помощью ДСЧ
        public void RandomInit()
        {
            Random rnd = new Random();
            int value1 = rnd.Next(21, 80);
            age = (int)value1;
            int value2 = rnd.Next(1, 3);
            int value = rnd.Next(1, 6);
            if (value2 == 1)
            {
                gender = "Мужчина";
                if (value == 1)
                {
                    name = "Журавлев Денис Данильевич";
                }
                if (value == 2)
                {
                    name = "Матвеев Фёдор Лукич ";
                }
                if (value == 3)
                {
                    name = "Поляков Михаил Дмитриевич";
                }
                if (value == 4)
                {
                    name = "Плотников Константин Глебович";
                }
                if (value == 5)
                {
                    name = "Анисимов Руслан Дмитриевич";
                }
            }
            else
            {
                gender = "Женщина";
                if (value == 1)
                {
                    name = "Кудрявцева Амалия Артёмовна";
                }
                if (value == 2)
                {
                    name = "Лебедева Арина Данииловна";
                }
                if (value == 3)
                {
                    name = "Нечаева Лилия Антоновна";
                }
                if (value == 4)
                {
                    name = "Зайцева Дарья Родионовна";
                }
                if (value == 5)
                {
                    name = "Егорова Елизавета Михайловна";
                }
            }
        }
        // метод random init для заполнения данных с помощью ДСЧ
        public void RandomInit(Person p1)
        {
            Random rnd = new Random();
            int value1 = rnd.Next(21, 80);
            age = (int)value1;
            int value2 = rnd.Next(1, 3);
            int value = rnd.Next(1, 6);
            if (value2 == 1)
            {
                gender = "Мужчина";
                if (value == 1)
                {
                    name = "Журавлев Денис Данильевич";
                }
                if (value == 2)
                {
                    name = "Матвеев Фёдор Лукич ";
                }
                if (value == 3)
                {
                    name = "Поляков Михаил Дмитриевич";
                }
                if (value == 4)
                {
                    name = "Плотников Константин Глебович";
                }
                if (value == 5)
                {
                    name = "Анисимов Руслан Дмитриевич";
                }
            }
            else
            {
                gender = "Женщина";
                if (value == 1)
                {
                    name = "Кудрявцева Амалия Артёмовна";
                }
                if (value == 2)
                {
                    name = "Лебедева Арина Данииловна";
                }
                if (value == 3)
                {
                    name = "Нечаева Лилия Антоновна";
                }
                if (value == 4)
                {
                    name = "Зайцева Дарья Родионовна";
                }
                if (value == 5)
                {
                    name = "Егорова Елизавета Михайловна";
                }
            }
        }
        //Метод Equals для сравнения объектов
        public virtual bool Equals(object obj)
        {
            // Проверка на null и соответствие типов
            if (obj == null || GetType() != obj.GetType())
                return false;

            // Преобразуем объект в тип Person
            Person other = (Person)obj;

            // Сравниваем значения полей
            return name == other.name && gender == other.gender && age == other.age;
        }
    }
}

