using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrnaEletronica.Domain.Models;

namespace UrnaEletronica.Infra.Mappings
{
    public class CandidateMap : IEntityTypeConfiguration<Candidate>
    {
        public void Configure(EntityTypeBuilder<Candidate> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.FullName)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(c => c.ViceName)
                .HasColumnType("varchar(MAX)")
                .IsRequired();

            builder.Property(c => c.Registered)
                .IsRequired()
                .HasDefaultValueSql("getdate()");

            builder.Property(c => c.Ticket)
                .IsRequired();

            // References

            builder.HasMany(c => c.Votes)
                .WithOne()
                .HasForeignKey(v => v.CandidateId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
