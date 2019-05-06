namespace Kontaktsplitter.Model
{
   
    public class Kunde
    {
        public Kunde(){}

        public Kunde(string anrede, string briefanrede, string titel, string geschlecht, string vorname, string nachname)
        {
            Anrede = anrede;
            Briefanrede = briefanrede;
            Titel = titel;
            Geschlecht = geschlecht;
            Vorname = vorname;
            Nachname = nachname;
        }
        public int Id { get; set; }
        public string Anrede { get; set; }
        public string Briefanrede { get; set; }
        public string Titel { get; set; }
        public string Geschlecht { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }
    }
}
