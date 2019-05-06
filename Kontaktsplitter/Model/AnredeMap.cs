using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kontaktsplitter.Model
{
    class AnredeMap : EntityTypeConfiguration<Anrede>
    {
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
