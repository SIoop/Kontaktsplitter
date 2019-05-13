namespace Kontaktsplitter.Model
{
    /// <summary>
    /// Das InternalGeschlecht enum zur eindeutigen Zuordnung des Geschlechts eines Kunden
    /// </summary>
    public enum Geschlecht
    {
        Männlich, Weiblich, Divers, Ohne
    }

    /// <summary>
    /// Hilfsklasse um das Geschlecht zu bestimmen
    /// </summary>
    public class GeschlechtHelper
    {
        public static Geschlecht GetGeschlecht(string geschlecht)
        {
            if (geschlecht == Geschlecht.Männlich.ToString())
            {
                return Geschlecht.Männlich;
            }
            if (geschlecht == Geschlecht.Weiblich.ToString())
            {
                return Geschlecht.Weiblich;
            }
            if (geschlecht == Geschlecht.Divers.ToString())
            {
                return Geschlecht.Divers;
            }

            return Geschlecht.Ohne;
        }
    }
}
