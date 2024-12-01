using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laba103part
{
    public class Student:Person, IInit
    {
        public string placeStudy;
        public int yearUniversity;
        // конструктор без параметров
        public Student() : base()
        {
            placeStudy = "No university";
            yearUniversity = 0;
            Console.WriteLine("Конструктор без параметров");
        }
        // конструктор с параметрами
        public Student(string _name, string _gender, int _age, string _placeOfStudy, int _yearUniversity) : base(_name, _gender, _age)
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

        //метод show для вывода результата
        public override void Show()
        {
            base.Show();
            Console.WriteLine($"Место учебы: {placeStudy}");
            Console.WriteLine($"Курс: {yearUniversity}");
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
        public new void RandomInit()
        {
            base.RandomInit();
            Random rnd = new Random();
            int value = rnd.Next(1, 5);
            yearUniversity = value;
            int value1 = rnd.Next(0, 3);
            if (value1 == 0)
            {
                placeStudy = "Политехнический университет";
            }
            else if (value1 == 1)
            {
                placeStudy = "ПГНИУ";
            }
            else if (value1 == 2)
            {
                placeStudy = "Педогогический университет";
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
            return placeStudy == other.placeStudy && yearUniversity == other.yearUniversity;
        }
    }
}
