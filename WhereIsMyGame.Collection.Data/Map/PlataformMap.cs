using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereIsMyGame.Collection.Domain.Entities;

namespace NerdStore.Catalog.Data.Mappings
{
    public class PlataformMap : IEntityTypeConfiguration<Plataform>
    {
        public void Configure(EntityTypeBuilder<Plataform> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // 1 : N => Plataform : Games
            builder.HasMany(c => c.Games)
                .WithOne(p => p.Plataform)
                .HasForeignKey(p => p.PlataformId);

            builder.ToTable("Plataforms");
        }
    }
}
