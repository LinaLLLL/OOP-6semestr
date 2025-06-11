using System;

namespace ClassLibrary13
{
    public class Teacher:Person
    {
        static string[] PlaceWork = { "Школа", "ПНИПУ", "ПГНИУ" };

        public int experience;
        public string placeWork;
        // конструктор без параметров
        public Teacher() : base()
        {
            placeWork = "No work";
            experience = 0;
        }
        // конструктор с параметрами
        public Teacher(int num,string _name, string _gender, int _age,  string _placeOfWork, int _experience) : base(num, _name, _gender, _age)
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

        // метод init для ввода информации с клавиатуры
        public void Init()
        {
            Console.WriteLine("Введите место работы: ");
            placeWork = Console.ReadLine();
            Console.WriteLine("Введите стаж: ");
            experience = Convert.ToInt32(Console.ReadLine());
        }

        // метод random init для заполнения данных с помощью ДСЧ
        public override void RandomInit()
        {
            base.RandomInit();
            experience = rnd.Next(1, age - 20); // age-20 необходимо для того чтобы возраст был больше стажа
            placeWork = PlaceWork[rnd.Next(PlaceWork.Length)];
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
        public override int GetHashCode()
        {
            return name?.GetHashCode() ?? 0;
        }
        public override string ToString()
        {
            return base.ToString() + ", " + placeWork + ", " + experience;
        }

        // Переопределяем Clone для глубокого копирования
        public override object Clone()
        {
            return new Teacher( id.number, name,gender, age, placeWork,experience);
        }
    }
}
