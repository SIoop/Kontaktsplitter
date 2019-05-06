using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kontaktsplitter.Model
{
    class KundeMap : EntityTypeConfiguration<Kunde>
    {
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
