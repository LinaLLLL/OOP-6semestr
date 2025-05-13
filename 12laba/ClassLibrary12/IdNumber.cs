using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary12
{
    public class IdNumber
    {
        public int number;
        public IdNumber(int n)
        {
            number = n;
        }
        public override string ToString()
        {
            return number.ToString();
        }
        public override bool Equals(object? obj)
        {
            if (obj is IdNumber nom)
            {
                return this.number == nom.number;
            }
            else { return  false; }
        }
    }
}
