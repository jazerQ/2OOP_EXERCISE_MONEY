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
        private short kopy;
        public short Kopy { get { return kopy; } set {
                if (value >= 100) {
                    Rubls += (ulong) value / 100;
                    kopy =(short)(value % 100);
                }
                else if(value <= -100)
                {
                    Rubls -= (ulong)(value / 100);
                    kopy = (short)(100 - Math.Abs(value) % 100);
                }
                else if(value < 0)
                {
                    kopy = (short) (100 - Math.Abs(value));
                    Rubls -= 1;
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
        public Money(ulong rubls, short kopyi) : this() {
            Rubls = rubls;
            this.Kopy = kopyi;
        }
        private decimal fullvalue;
        public decimal FullValue { get {
                fullvalue += Rubls;
                if (Kopy.ToString().Length == 1)
                {
                    fullvalue += (decimal)(Kopy * Math.Pow(10, -(Kopy.ToString().Length +1)));
                }
                else
                {
                    fullvalue += (decimal)(Kopy * Math.Pow(10, -Kopy.ToString().Length));
                }
                return fullvalue;
                    }  
        }
        public static Money operator +(Money a, Money b)
        {
            Money newMoney = new Money(a.Rubls + b.Rubls, (short)(a.Kopy + b.Kopy));
            return newMoney;
        }
        public static Money operator -(Money a, Money b)
        {
            Money newMoney = new Money(a.Rubls - b.Rubls, (short)(a.Kopy - b.Kopy));
            return newMoney;
        }
        public static Money operator *(Money a, int b)
        {
            Money newMoney = new Money(a.Rubls * (ulong)b , (short)(a.Kopy * b));
            return newMoney;
        }
        public static Money operator /(Money a, int b)
        {
            Money newMoney = new Money(a.Rubls / (ulong)b, (short)(a.Kopy / b));
            return newMoney;
        }
    }
}
