using Microsoft.EntityFrameworkCore;
using UrnaEletronica.Domain.Models;
using UrnaEletronica.Infra.Mappings;

namespace UrnaEletronica.Infra.Context
{
    public sealed class UrnaEletronicaContext : DbContext
    {
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Vote> Vote { get; set; }

        public UrnaEletronicaContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CandidateMap());
            modelBuilder.ApplyConfiguration(new VoteMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
