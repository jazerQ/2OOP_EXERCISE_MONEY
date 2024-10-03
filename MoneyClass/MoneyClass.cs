using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MoneyClass
{
    //Класс Деньги для работы с денежными суммами.
    //Число должно быть представлено двумя полями: типа long для рублей
    //и типа unsigned char - для копеек. Дробная часть (копейки) при выводе
    //на экран должна быть отделена от целой части запятой. Реализовать сложение,
    //вычитание, деление сумм, деление суммы на дробное число, умножение
    //на дробное число и операции сравнения. В функции main проверить эти методы.
    public struct Money
    {
        public ulong Rubls { get; private set; }
        private byte kopy;
        public byte Kopy { get { return kopy; } set {
                if (value >= 100) {
                    Rubls += (ulong) value / 100;
                    kopy =(byte)(value % 100);
                }
                else
                {
                    kopy = value;
                }
                
            } 
        }
        public void Print() {
            Console.WriteLine($"{Rubls} Рублей, {Kopy} Копеек");
        }
        public Money(ulong rubls, byte kopyi) : this() {
            Rubls = rubls;
            this.Kopy = kopyi;
        }
    }
}
