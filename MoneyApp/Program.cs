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
            Money mon = new Money(53275275143, 125);
            mon.Print();
        }
    }
}
