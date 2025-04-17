using Microsoft.EntityFrameworkCore;
using UserManagement.Models;

namespace UserManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Role> Roles { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Configure unique constraint for email
            modelBuilder.Entity<Utilisateur>()
                .HasIndex(u => u.email)
                .IsUnique();
                
            // Configure relationships
            modelBuilder.Entity<Utilisateur>()
                .HasOne(u => u.Role)
                .WithMany(r => r.Utilisateurs)
                .HasForeignKey(u => u.idrole);
                
            // Set table names to match SQL Server schema
            modelBuilder.Entity<Utilisateur>().ToTable("utilisateur");
            modelBuilder.Entity<Role>().ToTable("role");
        }
    }
}

