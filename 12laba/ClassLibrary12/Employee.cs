using System;

namespace ClassLibrary12
{
    public class Employee:Person
    {
        static string[] PlaceWork = { "Школа", "Завод", "Магазин" };
        static string[] PostSchool = { "Повар", "Охранник", "Уборщик" };
        static string[] PostFactory = { "Контроллер", "Токарь", "Наладчик" };
        static string[] PostShop = { "Кассир", "Консультант", "Менеджер" };

        public string placeOfWork;
        public string post;
        public int experience;
        // конструктор без параметров
        public Employee() : base()
        {
            placeOfWork = "Нет работы";
            post = "Нет должности";
            experience = 0;

        }
        // конструктор с параметрами
        public Employee(int num,string _name, string _gender, int _age,  string _placeOfWork, string _post, int _experience) : base(num, _name, _gender, _age)
        {
            post = _post;
            placeOfWork = _placeOfWork;
            experience = _experience;
        }

        // конструктор копирования
        public Employee(Employee e)
        {
            this.placeOfWork = e.placeOfWork;
            this.post = e.post;
            this.experience = e.experience;
        }

        // метод init для ввода информации с клавиатуры
        public void Init(Employee e)
        {
            Console.WriteLine("Введите место работы: ");
            e.placeOfWork = Console.ReadLine();
            Console.WriteLine("Введите должность: ");
            e.post = Console.ReadLine();
            Console.WriteLine("Введите стаж: ");
            e.experience = Convert.ToInt32(Console.ReadLine());
        }

        // метод random init для заполнения данных с помощью ДСЧ
        public override void RandomInit()
        {
            base.RandomInit();
            experience = rnd.Next(1, age - 20);
            placeOfWork = PlaceWork[rnd.Next(PlaceWork.Length)];
            if (placeOfWork == "Школа")
            {
                post = PostSchool[rnd.Next(PostSchool.Length)];
            }
            else if (placeOfWork == "Завод")
            {
                post = PostFactory[rnd.Next(PostFactory.Length)];
            }
            else
            {
                post = PostShop[rnd.Next(PostShop.Length)];
            }

        }
        //Метод Equals для сравнения объектов
        public override bool Equals(object obj)
        {
            // Сравниваем базовые свойства
            if (!base.Equals(obj)) return false;

            // Приведение к типу Student
            var other = (Employee)obj;

            // Сравнение ключевых свойств
            return placeOfWork == other.placeOfWork && post == other.post && experience == other.experience;
        }

        public override string ToString()
        {
            return base.ToString() + ", " + placeOfWork + ", " + post + ", " + experience;
        }

        // Переопределяем Clone для глубокого копирования
        public override object Clone()
        {
            return new Employee(id.number,name, gender, age,  placeOfWork,post, experience);
        }
    }
}

