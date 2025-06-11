using System;

namespace ClassLibrary13
{
    public class Animal:IInit
    {
        static Random rnd = new Random();
        static string[] Names = { "Кошка", "Собака", "Лошадь", "Коза", "Баран" };
        public string name { get; set; }
        int age;
        public int Age
        {
            get { return age; }
            set
            {
                if (value > 0 && value < 30)
                {
                    age = value;
                }
                else
                {
                    Console.WriteLine("Error");
                    age = 1;
                }
            }
        }

        public Animal()
        {
            name = "NoName";
            age = 1;
        }

        public Animal(string _name, int _age)
        {
            name = _name;
            age = _age;
        }

        public override string ToString()
        {
            return name + ", " + age;
        }


        public virtual void RandomInit()
        {
            name = Names[rnd.Next(Names.Length)];
            age = rnd.Next(1,31);
        }

        public void Init()
        {
            Console.WriteLine("Введите имя: ");
            name = Console.ReadLine();    
            Console.WriteLine("Введите возраст: ");
            age = Convert.ToInt32(Console.ReadLine());
        }
    }   
    
}
