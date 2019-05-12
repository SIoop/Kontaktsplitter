using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kontaktsplitter.Model
{
    /// <summary>
    /// Die Klasse KundeMap ist eine Hilfsklasse für das OR-Mapping der Tabelle Kunde
    /// </summary>
    class KundeMap : EntityTypeConfiguration<Kunde>
    {
        /// <summary>
        /// Der Konstruktor für die Klasse KundeMap
        /// </summary>
        public KundeMap()
        {
            ToTable("Kunde");

            Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Anrede).IsOptional();
            Property(p => p.Briefanrede).IsOptional();
            Property(p => p.Geschlecht).IsOptional();
            Property(p => p.Nachname).IsOptional();
            Property(p => p.Vorname).IsOptional();
            Property(p => p.Titel).IsOptional();
        }
    }
}
