using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kontaktsplitter.Parser.Tests
{
    [TestClass]
    public class SalutationParserTests
    {

        [TestMethod]
        public void SimpleGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Frau Sandra Berger");
            Assert.Equals(kunde.Anrede, "Frau Sandra Berger");
            Assert.Equals(kunde.Geschlecht, "weiblich");
            Assert.Equals(kunde.Nachname, "Berger");
            Assert.Equals(kunde.Vorname, "Sandra");
            Assert.Equals(kunde.Titel, "");
            Assert.Equals(kunde.Briefanrede, "Sehr geehrte Frau Sandra Berger");
        }

        [TestMethod]
        public void SimpleTitleGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Herr Dr. Sandro Gutmensch");
            Assert.Equals(kunde.Anrede, "Herr Dr. Sandro Gutmensch");
            Assert.Equals(kunde.Geschlecht, "männlich");
            Assert.Equals(kunde.Nachname, "Gutmensch");
            Assert.Equals(kunde.Vorname, "Sandro");
            Assert.Equals(kunde.Titel, "Dr");
            Assert.Equals(kunde.Briefanrede, "Sehr geehrter Herr Dr. Sandro Gutmensch");
        }

        [TestMethod]
        public void LongLastNameGermanTest()
        {
            var kunde = new SalutationParser().Parse("Professor Heinrich Freiherr vom Wald");
            Assert.Equals(kunde.Anrede, "Herr Professor Heinrich Freiherr vom Wald");
            Assert.Equals(kunde.Geschlecht, "männlich");
            Assert.Equals(kunde.Nachname, "Freiherr vom Wald");
            Assert.Equals(kunde.Vorname, "Heinrich");
            Assert.Equals(kunde.Titel, "Professor");
            Assert.Equals(kunde.Briefanrede, "Sehr geehrter Herr Professor Heinrich Freiherr vom Wald");
        }

        [TestMethod]
        public void SimpleEnglishNameTest()
        {
            var kunde = new SalutationParser().Parse("Mrs. Doreen Faber");
            Assert.Equals(kunde.Anrede, "Mrs. Doreen Faber");
            Assert.Equals(kunde.Geschlecht, "weiblich");
            Assert.Equals(kunde.Nachname, "Faber");
            Assert.Equals(kunde.Vorname, "Doreen");
            Assert.Equals(kunde.Titel, "");
            Assert.Equals(kunde.Briefanrede, "Dear Mrs. Doreen Faber");
        }

        [TestMethod]
        public void FrenchSimpleNameTest()
        {
            var kunde = new SalutationParser().Parse("Mme. Charlotte Noir");
            Assert.Equals(kunde.Anrede, "Mme. Charlotte Noir");
            Assert.Equals(kunde.Geschlecht, "weiblich");
            Assert.Equals(kunde.Nachname, "Noir");
            Assert.Equals(kunde.Vorname, "Charlotte");
            Assert.Equals(kunde.Titel, "");
            Assert.Equals(kunde.Briefanrede, "Madame Charlotte Noir");
        }

        [TestMethod]
        public void ItalianLastNameTest()
        {
            var kunde = new SalutationParser().Parse("Estobar y Gonzales");
            Assert.Equals(kunde.Anrede, "Señor Estobar y Gonzales");
            Assert.Equals(kunde.Geschlecht, "männlich");
            Assert.Equals(kunde.Nachname, "Estobar y Gonzales");
            Assert.Equals(kunde.Vorname, "");
            Assert.Equals(kunde.Titel, "");
            Assert.Equals(kunde.Briefanrede, "Egregio Signor Estobar y Gonzales");
        }

        [TestMethod]
        public void LongGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger");
            Assert.Equals(kunde.Anrede, "Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger");
            Assert.Equals(kunde.Geschlecht, "weiblich");
            Assert.Equals(kunde.Nachname, "von Leuthäuser-Schnarrenberger");
            Assert.Equals(kunde.Vorname, "Maria");
            Assert.Equals(kunde.Titel, "Prof. Dr. rer. nat.");
            Assert.Equals(kunde.Briefanrede, "Sehr geehrte Frau Prof. Dr. rer. nat. Maria von Leuthäuser-Schnarrenberger");
        }

        [TestMethod]
        public void PrefixTitleGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Herr Dipl. Ing. Max von Müller");
            Assert.Equals(kunde.Anrede, "Herr Dipl. Ing. Max von Müller");
            Assert.Equals(kunde.Geschlecht, "männlich");
            Assert.Equals(kunde.Nachname, "von Müller");
            Assert.Equals(kunde.Vorname, "Max");
            Assert.Equals(kunde.Titel, "Dipl. Ing.");
            Assert.Equals(kunde.Briefanrede, "Sehr geehrter Herr Dipl. Ing. Max von Müller");
        }

        [TestMethod]
        public void NamesBackwardsGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Dr. Russwurm, Winfried");
            Assert.Equals(kunde.Anrede, "Herr Dr. Winfried Russwurm");
            Assert.Equals(kunde.Geschlecht, "männlich");
            Assert.Equals(kunde.Nachname, "Russwurm");
            Assert.Equals(kunde.Vorname, "Winfried");
            Assert.Equals(kunde.Titel, "Dr.");
            Assert.Equals(kunde.Briefanrede, "Sehr geehrter Herr Dr. Winfried Russwurm");
        }

        [TestMethod]
        public void MutlipleTitlesGermanNameTest()
        {
            var kunde = new SalutationParser().Parse("Herr Dr.-Ing. Dr. rer.nat. Dr. h.c. mult. Paul Steffens");
            Assert.Equals(kunde.Anrede, "Herr Dr.-Ing. Dr. rer.nat. Dr. h.c. mult. Paul Steffens");
            Assert.Equals(kunde.Geschlecht, "männlich");
            Assert.Equals(kunde.Nachname, "Steffens");
            Assert.Equals(kunde.Vorname, "Paul");
            Assert.Equals(kunde.Titel, "Dr.-Ing. Dr. rer.nat. Dr. h.c. mult.");
            Assert.Equals(kunde.Briefanrede, "Sehr geehrter Herr Dr.-Ing. Dr. rer.nat. Dr. h.c. mult. Paul Steffens");
        }
    }
}