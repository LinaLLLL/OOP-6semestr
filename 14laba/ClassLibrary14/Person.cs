using System;

namespace ClassLibrary13
{
    public class Person:IInit, IComparable<Person>, ICloneable
    {
        protected static Random rnd = new Random();
        public static int GetMaxAge => 100;

        static string[] NamesMen = { "Петр", "Павел", "Константин", "Георгий", "Николай", "Михаил", "Сергей" };
        static string[] SurnamesMen = { "Петров", "Павлович", "Константинович", "Георгиевич", "Михайлович", "Сергеевич" };
        static string[] NamesWomen = { "Елизавета", "Наталия", "Лилия", "Ольга", "Марина", "Екатерина", "Алена" };
        static string[] SurnamesWomen = { "Петрова", "Павловна", "Константиновна", "Георгиевна", "Михайловна", "Сергеевна" };

        public IdNumber id;
        public string name;
        public string gender;
        public int age;

        // конструктор без параметров
        public Person()
        {
            id = new IdNumber(1);
            name = "No Name";
            gender = "No gender";
            age = 0;
        }

        // конструктор с параметрами
        public Person(int num, string _name, string _gender, int _age)
        {
            id = new IdNumber(num);
            name = _name;
            gender = _gender;
            age = _age;

        }

        // конструктор копирования
        public Person(Person p)
        {
            this.id=p.id;
            this.name = p.name;
            this.gender = p.gender;
            this.age = p.age;
        }

        //метод show для вывода Имени
        public virtual void ShowName()
        {
            Console.WriteLine(name);
        }

        // метод init для ввода информации с клавиатуры
        public void Init()
        {
            Console.WriteLine("Введите id: ");
            int num = Convert.ToInt32(Console.ReadLine());
            id = new IdNumber(num);
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();
            Console.WriteLine("Введите пол: ");
            gender = Console.ReadLine();
            Console.WriteLine("Введите возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
        }

        // метод random init для заполнения данных с помощью ДСЧ
        public virtual void RandomInit()
        {
            id = new IdNumber(rnd.Next(2,100));
            age = rnd.Next(21, 80);
            int value2 = rnd.Next(1, 3);
            if (value2 == 1)
            {
                gender = "Мужчина";
                name = NamesMen[rnd.Next(NamesMen.Length)] + " " + SurnamesMen[rnd.Next(SurnamesMen.Length)];
            }
            else
            {
                gender = "Женщина";
                name = NamesWomen[rnd.Next(NamesWomen.Length)] + " " + SurnamesWomen[rnd.Next(SurnamesWomen.Length)];
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
            return id.Equals(other.id) && name == other.name && gender == other.gender && age == other.age;
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(name, gender, age);
        }

        public override string ToString()
        {
            return GetType().Name + " - "+id +", " + name + ", " + gender + ", " + age;
        }

        // Реализация CompareTo для сортировки по имени
        public int CompareTo(Person other)
        {
            if (other == null) return 1;

            // Сортировка по имени (по алфавиту)
            return name.CompareTo(other.name);
            // Сортировка по возраст 
            //return age.CompareTo(other.age);
        }

        // Метод для поверхностного копирования с использованием MemberwiseClone
        public Person ShallowCopy()
        {
            return (Person)this.MemberwiseClone();
        }

        // Метод для глубокого копирования (в данном случае идентичен ShallowCopy)
        public virtual object Clone()
        {
            return new Person(id.number, name, gender, age);
        }
    }
}
