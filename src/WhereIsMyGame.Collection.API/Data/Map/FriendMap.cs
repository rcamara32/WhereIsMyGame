using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereIsMyGame.Collection.API.Models;

namespace WhereIsMyGame.Collection.API.Data.Map
{
    public class FriendMap : IEntityTypeConfiguration<Friend>
    {
        public void Configure(EntityTypeBuilder<Friend> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                .IsRequired()
                .HasColumnType("varchar(250)");

            // 1 : N => Friend : Loan
            builder.HasMany(c => c.Loans)
                .WithOne(p => p.Friend)
                .HasForeignKey(p => p.FriendId);

            builder.ToTable("Friends");
        }
    }
}
