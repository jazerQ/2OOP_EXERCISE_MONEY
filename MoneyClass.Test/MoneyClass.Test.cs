namespace MoneyClass.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase((ulong)146574, (short)2565, 146599.65)]
        [TestCase((ulong)500000, (short)1535, 500015.35)]
        [TestCase((ulong)750000, (short)2500, 750025.00)]
        [TestCase((ulong)800000, (short)1234, 800012.34)]
        [TestCase((ulong)999000, (short)500, 999005.00)]
        [TestCase((ulong)450000, (short)7891, 450078.91)]
        [TestCase((ulong)300000, (short)4567, 300045.67)]
        [TestCase((ulong)304000, (short)7, 304000.07)]
        public void Test1(ulong a, short b, decimal expected)
        {
            Money money = new Money(a, b);
            Assert.AreEqual(expected, money.FullValue);
        }
        [Test]
        [TestCase((ulong)800, (short) 1, (ulong) 1542,(short) 4, 800.01 + 1542.04)]
        [TestCase((ulong)1000, (short)2, (ulong)2500, (short)5, 1000.02 + 2500.05)]
        [TestCase((ulong)1500, (short)4, (ulong)3000, (short)7, 1500.04 + 3000.07)]
        [TestCase((ulong)200, (short)1, (ulong)800, (short)3, 200.01 + 800.03)]
        [TestCase((ulong)750, (short)2, (ulong)1800, (short)8, 750.02 + 1800.08)]

        public void Test2(ulong a, short b, ulong c, short d, decimal expected)
        {
            Money money1 = new Money(a, b);
            Money money2 = new Money(c, d);
            Assert.AreEqual(expected, (money1 + money2).FullValue);
        }
        [Test]
        [TestCase((ulong)1200, (short)5, (ulong)300, (short)5, 1200.05 - 300.05)]
        [TestCase((ulong)1500, (short)3, (ulong)400, (short)7, 1500.03 - 400.07)]
        [TestCase((ulong)2000, (short)5, (ulong)600, (short)10, 2000.05 - 600.10)]
        [TestCase((ulong)2500, (short)8, (ulong)800, (short)12, 2500.08 - 800.12)]
        [TestCase((ulong)3000, (short)1, (ulong)1000, (short)15, 3000.01 - 1000.15)]
        [TestCase((ulong)3500, (short)4, (ulong)1200, (short)20, 3500.04 - 1200.20)]
        [TestCase((ulong)4000, (short)6, (ulong)1400, (short)25, 4000.06 - 1400.25)]
        [TestCase((ulong)4500, (short)9, (ulong)1600, (short)30, 4500.09 - 1600.30)]
        [TestCase((ulong)5000, (short)11, (ulong)1800, (short)35, 5000.11 - 1800.35)]
        [TestCase((ulong)5500, (short)12, (ulong)2000, (short)40, 5500.12 - 2000.40)]
        [TestCase((ulong)6000, (short)15, (ulong)2200, (short)45, 6000.15 - 2200.45)]
        public void Test3(ulong a, short b, ulong c, short d, decimal expected)
        {
            Money money1 = new Money(a, b);
            Money money2 = new Money(c, d);
            Money money3 = money1 - money2;
            Assert.AreEqual(expected, money3.FullValue);
        }
        [Test]
        [TestCase((ulong)1200, (short)5,6, 1200.05 * 6 )]
        [TestCase((ulong)1500, (short)3, 4, 1500.03 * 4)]
        [TestCase((ulong)2000, (short)7, 2, 2000.07 * 2)]
        [TestCase((ulong)2500, (short)1, 5, 2500.01 * 5)]
        [TestCase((ulong)3000, (short)6, 3, 3000.06 * 3)]
        [TestCase((ulong)3500, (short)4, 8, 3500.04 * 8)]
        [TestCase((ulong)4000, (short)2, 9, 4000.02 * 9)]
        [TestCase((ulong)4500, (short)5, 7, 4500.05 * 7)]
        [TestCase((ulong)5000, (short)8, 6, 5000.08 * 6)]
        [TestCase((ulong)5500, (short)9, 1, 5500.09 * 1)]
        [TestCase((ulong)6000, (short)0, 10, 6000.00 * 10)]

        public void Test4(ulong a, short b, int c, decimal expected)
        {
            Money money = new Money(a, b);
            Money money1 = money * c;
            Assert.AreEqual(expected, money1.FullValue);
        }

        [Test]
        [TestCase((ulong)1200, (short)5, 6, 1200.05 / 6)]
        [TestCase((ulong)1500, (short)3, 4, 1500.03 / 4)]
        [TestCase((ulong)2000, (short)7, 2, 2000.07 / 2)]
        [TestCase((ulong)2500, (short)1, 5, 2500.01 / 5)]
        [TestCase((ulong)3000, (short)6, 3, 3000.06 / 3)]
        [TestCase((ulong)3500, (short)4, 8, 3500.04 / 8)]
        [TestCase((ulong)4000, (short)2, 9, 4000.02 / 9)]
        [TestCase((ulong)4500, (short)5, 7, 4500.05 / 7)]
        [TestCase((ulong)5000, (short)8, 6, 5000.08 / 6)]
        [TestCase((ulong)5500, (short)9, 1, 5500.09 / 1)]
        [TestCase((ulong)6000, (short)0, 10, 6000.00 / 10)]

        public void Test5(ulong a, short b, int c, decimal expected)
        {
            Money money = new Money(a, b);
            Money money1 = money / c;
            Assert.AreEqual(Math.Floor(expected * 100)/ 100, money1.FullValue);
        }
    }
}