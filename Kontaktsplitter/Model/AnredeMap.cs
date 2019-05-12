using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kontaktsplitter.Model
{
    /// <summary>
    /// Die Klasse AnredeMap ist eine Hilfsklasse für das OR-Mapping der Tabelle Anrede
    /// </summary>
    class AnredeMap : EntityTypeConfiguration<Anrede>
    {
        /// <summary>
        /// Der Konstruktor für die Klasse AnredeMap
        /// </summary>
        public AnredeMap()
        {
            ToTable("Anrede");

            Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Geschlecht).IsOptional();
            Property(p => p.AnredeBrief).IsOptional();
            Property(p => p.AnredeNormal).IsOptional();
            Property(p => p.Sprache).IsOptional();
        }
    }
}
