using System.ComponentModel.DataAnnotations.Schema;

namespace Kontaktsplitter.Model
{
    /// <summary>
    /// Die Klasse Anrede stellt die verschiedenen Bestandteile der Anrede dar und entspricht der Datenbanktabelle Anrede
    /// </summary>
    public class Anrede
    {
        public int Id { get; set; }
        public string AnredeNormal { get; set; }
        public string AnredeBrief { get; set; }

        public string Geschlecht
        {
            get { return InternalGeschlecht.ToString(); }
            set { InternalGeschlecht = GeschlechtHelper.GetGeschlecht(value); }
        }

        [NotMapped]
        public Geschlecht InternalGeschlecht { get; set; }
        public string Sprache { get; set; }
    }
}
