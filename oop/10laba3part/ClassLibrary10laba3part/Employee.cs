using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba103part
{
    public class Employee : Person
    {
        public string placeOfWork;
        public string post;
        public int experience;
        // конструктор без параметров
        public Employee() : base()
        {
            placeOfWork = "Нет работы";
            post = "Нет должности";
            experience = 0;
            Console.WriteLine("Конструктор без параметров");
        }
        // конструктор с параметрами
        public Employee(string _name, string _gender, int _age, string _placeOfWork, string _post, int _experience) : base(_name, _gender, _age)
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

        //метод show для вывода результата
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Место работы: {placeOfWork}");
            Console.WriteLine($"Должность: {post}");
            Console.WriteLine($"Стаж: {experience}");
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
        public void RandomInit(Employee e)
        {
            base.RandomInit();
            Random rnd = new Random();
            int value = rnd.Next(1, age - 20);
            experience = value;
            int value1 = rnd.Next(1, 3);
            int value2 = rnd.Next(1, 3);
            if (value1 == 0)
            {
                placeOfWork = "Школа";
                if (value2 == 0)
                {
                    post = "Уборщик";
                }
                else if (value2 == 1)
                {
                    post = "Повар";
                }
                else if (value1 == 2)
                {
                    post = "Охраник";
                }
            }
            else if (value1 == 1)
            {
                placeOfWork = "Завод";
                if (value2 == 0)
                {
                    post = "Уборщик";
                }
                else if (value2 == 1)
                {
                    post = "Контроллер";
                }
                else if (value1 == 2)
                {
                    post = "Охраник";
                }
            }
            else if (value1 == 2)
            {
                placeOfWork = "Магазин";
                if (value2 == 0)
                {
                    post = "Уборщик";
                }
                else if (value2 == 1)
                {
                    post = "Кассир";
                }
                else if (value1 == 2)
                {
                    post = "Охраник";
                }
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
    }
}
