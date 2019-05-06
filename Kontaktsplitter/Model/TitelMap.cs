using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Kontaktsplitter.Model
{
    class TitelMap : EntityTypeConfiguration<Titel>
    {
        public TitelMap()
        {
            ToTable("Titel");

            Property(p => p.Id).IsRequired().HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Bezeichnung).IsOptional();
            Property(p => p.Kuerzel).IsOptional();
        }
    }
}
