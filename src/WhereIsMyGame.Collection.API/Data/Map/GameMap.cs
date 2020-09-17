using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereIsMyGame.Collection.API.Models;

namespace WhereIsMyGame.Collection.API.Data.Map
{
    public class GameMap : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.UserId)
                .IsRequired();            

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            builder.Property(c => c.Description)
                .IsRequired()
                .HasColumnType("varchar(500)");

            builder.Property(c => c.Image)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // 1 : N => Game : Loan
            builder.HasMany(c => c.Loans)
                .WithOne(p => p.Game)
                .HasForeignKey(p => p.GameId);

            builder.ToTable("Games");
        }
    }
}
