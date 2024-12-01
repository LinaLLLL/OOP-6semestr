using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba103part
{
    public class Teacher:Person, IInit
    {
        public int experience;
        public string placeWork;
        // конструктор без параметров
        public Teacher() : base()
        {
            placeWork = "No work";
            experience = 0;
            Console.WriteLine("Конструктор без параметров");
        }
        // конструктор с параметрами
        public Teacher(string _name, string _gender, int _age, string _placeOfWork, int _experience) : base(_name, _gender, _age)
        {
            placeWork = _placeOfWork;
            experience = _experience;
        }

        // конструктор копирования
        public Teacher(Teacher t)
        {
            this.placeWork = t.placeWork;
            this.experience = t.experience;
        }

        //метод show для вывода результата
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Место работы: {placeWork}");
            Console.WriteLine($"Стаж: {experience}");
        }

        // метод init для ввода информации с клавиатуры
        public void Init()
        {
            Console.WriteLine("Введите место работы: ");
            placeWork = Console.ReadLine();
            Console.WriteLine("Введите стаж: ");
            experience = Convert.ToInt32(Console.ReadLine());
        }

        // метод random init для заполнения данных с помощью ДСЧ
        public void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            int value = rnd.Next(1, age - 20); // age-20 необходимо для того чтобы возраст был больше стажа
            experience = value;
            int value1 = rnd.Next(1, 3);
            if (value1 == 0)
            {
                placeWork = "Школа";
            }
            else if (value1 == 1)
            {
                placeWork = "ПНИПУ";
            }
            else if (value1 == 2)
            {
                placeWork = "ПГНИУ";
            }
        }
        //Метод Equals для сравнения объектов
        public override bool Equals(object obj)
        {
            // Сравниваем базовые свойства
            if (!base.Equals(obj)) return false;

            // Приведение к типу Student
            var other = (Teacher)obj;

            // Сравнение ключевых свойств
            return placeWork == other.placeWork && experience == other.experience;
        }
    }
}

