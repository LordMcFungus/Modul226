using System;
using NUnit.Framework;

namespace BasciTest.Tests
{
    [TestFixture]
    internal class UnitTest
    {
        [Test]
        [STAThread]
        public void Testsif_reference_works()
        {
            var number = new Termcontent {Referencnumber = 1};

            var newMainwindow = Logik.Instance;

            newMainwindow.DoOutput(number);

            Assert.That(number.Referencnumber, Is.EqualTo(0));

        }

        [Test]
        [STAThread]
        public void Testsif_value_works()
        {
            var newMainwindow = new Logik
            {
                Num = 2
            };

            newMainwindow.DoOutputsimple(newMainwindow.Num);

            Assert.That(newMainwindow.Num, Is.EqualTo(2));

        }



    }
}