using System;
using System.Collections;

namespace ClassLibrary13
{
    public class PersonAgeComparer:IComparer
    {
        public int Compare(object x, object y)
        {
            if (x is Person person1 && y is Person person2)
            {
                // Сравнение по возрасту
                return person1.age.CompareTo(person2.age);
            }
            throw new ArgumentException("Объекты должны быть типа Person");
        }
    }
}
