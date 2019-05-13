using Kontaktsplitter.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontaktsplitter.Parser.Tests
{
    [TestClass]
    public class SalutationParserTests
    {

        [TestMethod]
        public void SimpleGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Frau  Sandra Berger");
            Assert.AreEqual(kunde.Anrede, "Frau");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Weiblich);
            Assert.AreEqual(kunde.Nachname, "Berger");
            Assert.AreEqual(kunde.Vorname, "Sandra");
            Assert.AreEqual(kunde.Titel, null);
            Assert.AreEqual(kunde.Briefanrede, "Sehr geehrte Frau");
        }

        [TestMethod]
        public void SimpleTitleGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Herr Dr. Sandro Gutmensch");
            Assert.AreEqual(kunde.Anrede, "Herrn Dr");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Männlich);
            Assert.AreEqual(kunde.Nachname, "Gutmensch");
            Assert.AreEqual(kunde.Vorname, "Sandro");
            Assert.AreEqual(kunde.Titel, "Dr");
            Assert.AreEqual(kunde.Briefanrede, "Sehr geehrter Herr Dr");
        }

        [TestMethod]
        public void LongLastNameGermanTest()
        {
            var kunde = new SalutationParser().Parse("Professor Heinrich Freiherr vom Wald");
            Assert.AreEqual(kunde.Anrede, "Herrn Professor");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Männlich);
            Assert.AreEqual(kunde.Nachname, "Freiherr vom Wald");
            Assert.AreEqual(kunde.Vorname, "Heinrich");
            Assert.AreEqual(kunde.Titel, "Professor");
            Assert.AreEqual(kunde.Briefanrede, "Sehr geehrter Herr Professor");
        }

        [TestMethod]
        public void SimpleEnglishNameTest()
        {
            var kunde = new SalutationParser().Parse("Mrs. Doreen Faber");
            Assert.AreEqual(kunde.Anrede, "Mrs");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Weiblich);
            Assert.AreEqual(kunde.Nachname, "Faber");
            Assert.AreEqual(kunde.Vorname, "Doreen");
            Assert.AreEqual(kunde.Titel, "");
            Assert.AreEqual(kunde.Briefanrede, "Dear Mrs.");
        }

        [TestMethod]
        public void FrenchSimpleNameTest()
        {
            var kunde = new SalutationParser().Parse("Mme. Charlotte Noir");
            Assert.AreEqual(kunde.Anrede, "Mme");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Weiblich);
            Assert.AreEqual(kunde.Nachname, "Noir");
            Assert.AreEqual(kunde.Vorname, "Charlotte");
            Assert.AreEqual(kunde.Titel, "");
            Assert.AreEqual(kunde.Briefanrede, "Madame");
        }

        [TestMethod]
        public void ItalianLastNameTest()
        {
            var kunde = new SalutationParser().Parse("Estobar y Gonzales");
            Assert.AreEqual(kunde.Anrede, "Señor");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Männlich);
            Assert.AreEqual(kunde.Nachname, "Estobar y Gonzales");
            Assert.AreEqual(kunde.Vorname, "");
            Assert.AreEqual(kunde.Titel, "");
            Assert.AreEqual(kunde.Briefanrede, "Egregio Signor");
        }

        [TestMethod]
        public void LongGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger");
            Assert.AreEqual(kunde.Anrede, "Frau Prof Dr rer nat");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Weiblich);
            Assert.AreEqual(kunde.Nachname, "von Leuthäuser-Schnarrenberger");
            Assert.AreEqual(kunde.Vorname, "Maria");
            Assert.AreEqual(kunde.Titel, "Prof Dr rer nat");
            Assert.AreEqual(kunde.Briefanrede, "Sehr geehrte Frau Prof Dr rer nat");
        }

        [TestMethod]
        public void PrefixTitleGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Herr Dipl. Ing. Max von Müller");
            Assert.AreEqual(kunde.Anrede, "Herrn Dipl Ing");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Männlich);
            Assert.AreEqual(kunde.Nachname, "von Müller");
            Assert.AreEqual(kunde.Vorname, "Max");
            Assert.AreEqual(kunde.Titel, "Dipl Ing");
            Assert.AreEqual(kunde.Briefanrede, "Sehr geehrter Herr Dipl Ing");
        }

        [TestMethod]
        public void NamesBackwardsGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Dr. Russwurm, Winfried");
            Assert.AreEqual(kunde.Anrede, "Herrn Dr");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Männlich);
            Assert.AreEqual(kunde.Nachname, "Russwurm");
            Assert.AreEqual(kunde.Vorname, "Winfried");
            Assert.AreEqual(kunde.Titel, "Dr.");
            Assert.AreEqual(kunde.Briefanrede, "Sehr geehrter Herr Dr");
        }

        [TestMethod]
        public void MutlipleTitlesGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Herr Dr.-Ing. Dr. rer.nat. Dr. h.c. mult. Paul Steffens");
            Assert.AreEqual(kunde.Anrede, "Herrn Dr-Ing Dr rer nat Dr hc mult");
            Assert.AreEqual(kunde.Geschlecht, Geschlecht.Männlich);
            Assert.AreEqual(kunde.Nachname, "Steffens");
            Assert.AreEqual(kunde.Vorname, "Paul");
            Assert.AreEqual(kunde.Titel, "Dr.-Ing. Dr. rer.nat. Dr. h.c. mult.");
            Assert.AreEqual(kunde.Briefanrede, "Sehr geehrter Herr Dr-Ing Dr rer nat Dr hc mult");
        }
    }
}