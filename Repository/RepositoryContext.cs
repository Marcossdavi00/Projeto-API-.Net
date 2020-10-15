using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Domain.Identity;
using Microsoft.AspNetCore.Identity;

namespace Repository
{
    public class RepositoryContext : IdentityDbContext<User, Role, int,
                                                        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options): base (options){}

        public DbSet<Event> Events { get; set; }
        public DbSet<Palestrante> Palestrantes { get; set; }
        public DbSet<Lote> Lotes { get; set; }
        public DbSet<RedeSocial> RedeSociais { get; set; }
        public DbSet<PalestranteEvent> PalestrantesEvents { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
                {
                    userRole.HasKey(ur => new {ur.UserId, ur.RoleId});

                    userRole.HasOne(ur => ur.Role)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.RoleId)
                    .IsRequired();

                     userRole.HasOne(ur => ur.User)
                    .WithMany(r => r.UserRoles)
                    .HasForeignKey(ur => ur.UserId)
                    .IsRequired();
                }
            );

            modelBuilder.Entity<PalestranteEvent>()
            .HasKey(PE => new {PE.EventId, PE.PalestranteId});
        }
    }
}