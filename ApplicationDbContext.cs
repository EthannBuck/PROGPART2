using Microsoft.EntityFrameworkCore;
using PROGPART1.Models; 

namespace PROGPART1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Claim> Claims { get; set; }
        public DbSet<Approval> Approvals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Claim>().ToTable("Claims");
            modelBuilder.Entity<Approval>().ToTable("Approvals");

            modelBuilder.Entity<User>()
                .HasKey(u => u.UserId);

            modelBuilder.Entity<Claim>()
                .HasKey(c => c.ClaimId);

            modelBuilder.Entity<Approval>()
                .HasKey(a => a.ApprovalId);
        }
    }
}
