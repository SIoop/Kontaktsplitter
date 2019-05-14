using System.ComponentModel.DataAnnotations.Schema;

namespace Kontaktsplitter.Model
{

    /// <summary>
    /// Die Klasse Kunde stellt die verschiedenen Bestandteile des Kunden dar und entspricht der Datenbanktabelle Kunde
    /// </summary>
    public class Kunde
    {
        public Kunde(){}

        public Kunde(string anrede, string briefanrede, string titel, Geschlecht geschlecht, string vorname, string nachname)
        {
            Anrede = anrede;
            Briefanrede = briefanrede;
            Titel = titel;
            InternalGeschlecht = geschlecht;
            Vorname = vorname;
            Nachname = nachname;
        }
        public int Id { get; set; }
        public string Anrede { get; set; }
        public string Briefanrede { get; set; }
        public string Titel { get; set; }
        public string Geschlecht
        {
            get { return InternalGeschlecht.ToString(); }
            set { InternalGeschlecht = GeschlechtHelper.GetGeschlecht(value); }
        }

        [NotMapped]
        public Geschlecht InternalGeschlecht { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
