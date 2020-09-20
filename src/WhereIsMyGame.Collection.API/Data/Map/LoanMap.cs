using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WhereIsMyGame.Collection.API.Models;

namespace WhereIsMyGame.Collection.API.Data.Map
{
    public class LoanMap : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.GameId)
                .IsRequired();

            builder.Property(c => c.FriendId)
                .IsRequired();

            builder.ToTable("GamesLoan");
        }
    }
}
