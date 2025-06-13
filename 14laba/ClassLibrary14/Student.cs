using System;
using System.Linq;

namespace ClassLibrary13
{
   
        public class Student : Person
        {
            static string[] PlaceStudy = { "ПНИПУ", "ПГНИУ", "Педагогический университет" };
            static string[] FacultyPNIPY = { "Аэрокосмический", "Гуманитарный", "Электротехнический" };
            static string[] FacultyPGNY = { "Биологический", "Географический", "Геологический" };
            static string[] FacultyPED = { "Математический", "Филологический", "Физический"};

            public string placeStudy;
            public string faculty;
            public int yearUniversity;
            // конструктор без параметров
            public Student() : base()
            {
                placeStudy = "No university";
                faculty = "No faculty";
                yearUniversity = 0;
            }
            // конструктор с параметрами
            public Student(int num,string _name, string _gender, int _age, string _placeOfStudy,string _faculty, int _yearUniversity) : base(num, _name, _gender, _age)
            {
                placeStudy = _placeOfStudy;
                faculty = _faculty;
                yearUniversity = _yearUniversity;
            }

            // конструктор копирования
            public Student(Student s)
            {
                this.placeStudy = s.placeStudy;
                this.faculty = s.faculty;
                this.yearUniversity = s.yearUniversity;
            }

            // метод init для ввода информации с клавиатуры
            public void Init()
            {
                Console.WriteLine("Введите университет: ");
                placeStudy = Console.ReadLine();
                Console.WriteLine("Введите факультет: ");
                faculty = Console.ReadLine();
                Console.WriteLine("Введите год обучения: ");
                yearUniversity = Convert.ToInt32(Console.ReadLine());
            }

            // метод random init для заполнения данных с помощью ДСЧ
            public override void RandomInit()
            {
                base.RandomInit();
                placeStudy = PlaceStudy[rnd.Next(PlaceStudy.Length)];
                yearUniversity = rnd.Next(1, 6);
                if(placeStudy == "ПНИПУ")
                {
                    faculty = FacultyPNIPY[rnd.Next(FacultyPNIPY.Length)];
                }
                else if(placeStudy == "ПГНИУ")
                {
                    faculty = FacultyPGNY[rnd.Next(FacultyPGNY.Length)];
                }
                else
                {
                    faculty = FacultyPED[rnd.Next(FacultyPED.Length)];
                }
            }
            //Метод Equals для сравнения объектов
            public override bool Equals(object obj)
            {
                // Сравниваем базовые свойства
                if (!base.Equals(obj)) return false;

                // Приведение к типу Student
                var other = (Student)obj;

                // Сравнение ключевых свойств
                return placeStudy == other.placeStudy && faculty == other.faculty && yearUniversity == other.yearUniversity;
            }
        public override int GetHashCode()
        {
            return name?.GetHashCode() ?? 0;
        }

        public override string ToString()
        {
            return base.ToString()+ ", " + placeStudy + ", " + faculty + ", " + yearUniversity;
        }

        // Переопределяем Clone для глубокого копирования
        public override object Clone()
        {
            return new Student(id.number,name, gender, age,  placeStudy, faculty, yearUniversity);
        }

        
    }
}
