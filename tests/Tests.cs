using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


using _01_02_03_BalanceProject;

namespace _01_02_03_BalanceProject.Tests
{
    [TestClass()]
    public class Tests
    {
        [TestMethod()]
        public void TestKonstrktor()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", 100);
                expected = "Pénzes Péter számláján 100 Ft van.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }

            Assert.AreEqual(expected, actual, "A Balance->Konstruktor nem tárolja el a paraméterben lévő adatokat vagy a Balance->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestKonstrktorNegativAmount()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", -10);
                expected = "Pénzes Péter számláján nincsen pénzösszeg.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }

            Assert.AreEqual(expected, actual, "A Balance->Konstruktor negatív értékű pénzösszeg esetén helytelenül működik vagy a Balance->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestKonstrktorWithdrawPossible()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", 100);
                balance.Withdraw(80);
                expected = "Pénzes Péter számláján 20 Ft van.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }

            Assert.AreEqual(expected, actual, "A Balance->Withdraw metódus amikor lehetséges az adott mennyiségű pénz kivétele nem jól működik vagy a Balance->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestKonstrktorWithdrawNotPossible()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", 100);
                balance.Withdraw(180);
                expected = "Pénzes Péter számláján 100 Ft van.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }

            Assert.AreEqual(expected, actual, "A Balance->Withdraw metódus amikor a megadott pénz mennyiség kivétele nem lehetséges nem jól működik vagy a Balance->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestKonstrktorWithdrawNegativ()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", 100);
                balance.Withdraw(-180);
                expected = "Pénzes Péter számláján 100 Ft van.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }

            Assert.AreEqual(expected, actual, "A Balance->Withdraw metódus amikor a negativ a megadott pénz kivétele  nem jól működik vagy a Balance->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestKonstrktorBalanceIsEmpty()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", 100);
                balance.Withdraw(20);
                balance.Withdraw(80);
                expected = "Pénzes Péter számláján nincsen pénzösszeg.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }

            Assert.AreEqual(expected, actual, "A Balance->ToConsole metódus amikor az összes pénzt kivették nem megfelelően működik.");
        }


        [TestMethod()]
        public void TestKonstrktorBalanceDepositPossible()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", 100);
                balance.Deposit(80);
                expected = "Pénzes Péter számláján 180 Ft van.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }
            Assert.AreEqual(expected, actual, "A Balance->Deposit metódus amikor lehetséges az adott mennyiségű pénz berakása a számlára nem jól működik vagy a Balance->ToConsole nem megfelően működik.");
        }

        [TestMethod()]
        public void TestKonstrktorBalanceDepositNotPosible()
        {
            string expected = string.Empty;
            string actual = "somthing";
            try
            {
                Balance balance = new Balance("Pénzes Péter", 100);
                balance.Deposit(-80);
                expected = "Pénzes Péter számláján 100 Ft van.\r\n";

                StringWriter sw = new StringWriter();
                Console.SetOut(sw);
                balance.ToConsole();
                actual = sw.ToString();
            }
            catch (Exception e)
            {
                Assert.Fail("Balance osztály kivételt dob!");
            }
            Assert.AreEqual(expected, actual, "A Balance->Deposit metódus amikor nem lehetséges az adott mennyiségű pénz berakása a számlára nem jól működik vagy a Balance->ToConsole nem megfelően működik.");
        }
    }
}