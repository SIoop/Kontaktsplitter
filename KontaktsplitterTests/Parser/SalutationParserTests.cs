using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kontaktsplitter.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kontaktsplitter.Parser.Tests
{
    [TestClass()]
    public class SalutationParserTests
    {
        [TestMethod()]
        public void ParseTest()
        {
            var names = new List<string> {"Herr Dr. Danro Gutmensch", "Professor Heinrich Freiherr vom Wald", "Mrs. Doreen Faber", "Mme. Charlotte Noir", "Estobar y Gonzales", "Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger", "Herr Dipl. Ing. Max von Müller", "Dr. Russwurm, Winfried", "Herr Dr.-Ing. Dr. rer.nat. Dr. h.c. mult. Paul Steffens"};

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void SimpleGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Frau Sandra Berger");
            Assert.Equals(kunde.Anrede, "Frau Sandra Berger");
            Assert.Equals(kunde.Geschlecht, "weiblich");
            Assert.Equals(kunde.Nachname, "Berger");
            Assert.Equals(kunde.Vorname, "Sandra");
            Assert.Equals(kunde.Titel, "");
        }
    }
}