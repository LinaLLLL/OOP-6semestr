using System;

namespace ClassLibrary13
{
   
        public class Student : Person
        {
            static string[] PlaceStudy = { "ПНИПУ", "ПГНИУ", "Педагогический университет" };

            public string placeStudy;
            public int yearUniversity;
            // конструктор без параметров
            public Student() : base()
            {
                placeStudy = "No university";
                yearUniversity = 0;
            }
            // конструктор с параметрами
            public Student(int num,string _name, string _gender, int _age, string _placeOfStudy, int _yearUniversity) : base(num, _name, _gender, _age)
            {
                placeStudy = _placeOfStudy;
                yearUniversity = _yearUniversity;
            }

            // конструктор копирования
            public Student(Student s)
            {
                this.placeStudy = s.placeStudy;
                this.yearUniversity = s.yearUniversity;
            }

            // метод init для ввода информации с клавиатуры
            public void Init()
            {
                Console.WriteLine("Введите университет: ");
                placeStudy = Console.ReadLine();
                Console.WriteLine("Введите год обучения: ");
                yearUniversity = Convert.ToInt32(Console.ReadLine());
            }

            // метод random init для заполнения данных с помощью ДСЧ
            public override void RandomInit()
            {
                base.RandomInit();
                placeStudy = PlaceStudy[rnd.Next(PlaceStudy.Length)];
                yearUniversity = rnd.Next(1, 6);
            }
            //Метод Equals для сравнения объектов
            public override bool Equals(object obj)
            {
                // Сравниваем базовые свойства
                if (!base.Equals(obj)) return false;

                // Приведение к типу Student
                var other = (Student)obj;

                // Сравнение ключевых свойств
                return placeStudy == other.placeStudy && yearUniversity == other.yearUniversity;
            }
        public override int GetHashCode()
        {
            return name?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return base.ToString()+ ", " + placeStudy + ", " + yearUniversity;
        }

        // Переопределяем Clone для глубокого копирования
        public override object Clone()
        {
            return new Student(id.number,name, gender, age,  placeStudy, yearUniversity);
        }

        
    }
}
