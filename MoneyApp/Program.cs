using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClass
{
    class Program
    {
        static void Main(string[] args)
        {
            Money mon1 = new Money(1200, 3);
            Money mon2 = new Money(300, 5);
            mon1.Print();
            mon2.Print();
            Money mon3 = mon1 - mon2;
            mon3.Print();
            Console.WriteLine(mon3.FullValue);
        }
    }
}
