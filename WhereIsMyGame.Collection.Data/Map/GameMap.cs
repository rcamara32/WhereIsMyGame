using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereIsMyGame.Collection.Domain.Entities;

namespace NerdStore.Catalog.Data.Mappings
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("varchar(250)");
            

            builder.ToTable("Games");
        }
    }
}
