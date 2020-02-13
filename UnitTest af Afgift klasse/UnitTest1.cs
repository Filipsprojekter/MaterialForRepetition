using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SkatUnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestAfUpperBoundries()
        {
            string bilType = "Personbil";
            double pris = Double.MaxValue;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Skat.Afgift.BilAfgift(pris, bilType));

        }

        [TestMethod]
        public void TestAfLowerBoundries()
        {
            string bilType = "Personbil";
            double pris = -2000;

            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Skat.Afgift.BilAfgift(pris, bilType));

        }

        [TestMethod]
        public void TestAfMiddelVærdiBilligBil()
        {
            string bilType = "Personbil";
            double pris = 150000;
            double forventetResultat = 127500;
            double aktueltResultat = Skat.Afgift.BilAfgift(pris, bilType);

            Assert.AreEqual(forventetResultat, aktueltResultat);
        }

        [TestMethod]
        public void TestAfMiddelVærdiDyrBil()
        {
            string bilType = "Personbil";
            double pris = 250000;
            double forventetResultat = 245000;

            double aktueltResultat = Skat.Afgift.BilAfgift(pris, bilType);

            Assert.AreEqual(forventetResultat,aktueltResultat);


        }

        [TestMethod]
        public void TestAfGrænseVærdiImellemBilligOgDyrBil()
        {
            string bilType = "Personbil";
            double pris = 200000;
            double forventetResultat = 170000;

            double aktueltResultat = Skat.Afgift.BilAfgift(pris, bilType);

            Assert.AreEqual(forventetResultat, aktueltResultat);
        }

        [TestMethod]
        public void TestAfMiddleValueBilligElBilAfgift()
        {
            string biltype = "Elbil";
            double resultat = Skat.Afgift.ElBilAfgift(100000, biltype);
            double forventetResultat = 17000;
            Assert.AreEqual(resultat, forventetResultat);

        }

        [TestMethod]
        public void TestAfMiddleValueDyrElBilAfgift()
        {
            string biltype = "Elbil";
            double resultat = Skat.Afgift.ElBilAfgift(300000, biltype);
            double forventetResultat = 64000;
            Assert.AreEqual(forventetResultat, resultat);
        }

        [TestMethod]
        public void TestAfGrænseVærdiImellemDyrOgBilligElBil()
        {
            string biltype = "Elbil";
            double resultat = Skat.Afgift.ElBilAfgift(200000, biltype);
            double forventetResultat = 34000;
            Assert.AreEqual(forventetResultat, resultat);

        }
    }
}
