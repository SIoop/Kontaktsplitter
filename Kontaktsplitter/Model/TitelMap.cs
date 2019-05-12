using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kontaktsplitter.Model
{
    /// <summary>
    /// Die Klasse TitelMap ist eine Hilfsklasse für das OR-Mapping der Tabelle Titel
    /// </summary>
    class TitelMap : EntityTypeConfiguration<Titel>
    {
        /// <summary>
        /// Der Konstruktor für die Klasse TitelMap
        /// </summary>
        public TitelMap()
        {
            ToTable("Titel");

            Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Bezeichnung).IsOptional();
            Property(p => p.Kuerzel).IsOptional();
        }
    }
}
