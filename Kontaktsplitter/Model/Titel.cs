namespace Kontaktsplitter.Model
{
    /// <summary>
    /// Die Klasse Titel stellt die verschiedenen Bestandteile des Titeles dar und entspricht der Datenbanktabelle Titel
    /// </summary>
    public class Titel
    {
        public int Id { get; set; }
        public string Bezeichnung { get; set; }
        public string Kuerzel { get; set; }
    }
}
