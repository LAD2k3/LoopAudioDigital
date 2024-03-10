using Microsoft.EntityFrameworkCore;
using LoopAudioDigital.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.Drawing.Drawing2D;

namespace LoopAudioDigital.DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Songs> Song { get; set; }
        public DbSet<Artists> Artist { get; set; }
        //public DbSet<PaymentRecords> PaymentRecord { get; set; }
        //public DbSet<TaxYear> TaxYear { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IdentityUserRole<string>>().HasKey(ur => new { ur.UserId, ur.RoleId });
            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = "133f85fc-3e0c-4bd0-a820-d379c0bf9dc5",
                    Name = "Admin",
                    NormalizedName = "ADMIN".ToUpper()
                },
                new IdentityRole
                {
                    Id = "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130",
                    Name = "Artist",
                    NormalizedName = "ARTIST".ToUpper()
                }
            );
            var hasher = new PasswordHasher<IdentityUser>();
            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                    UserName = "lad",
                    Email = "l.a.d11052003@gmail.com",
                    NormalizedUserName = "LAD".ToUpper(),
                    NormalizedEmail = "L.A.D11052003@GMAIL.COM".ToUpper(),
                    PasswordHash = hasher.HashPassword(null, "Admin@123"),
                }
            );

            /* var User = new IdentityUser()
             {
                 Id = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                 UserName = "lad",
                 Email = "l.a.d11052003@gmail.com",
                 NormalizedUserName = "LAD".ToUpper(),
                 NormalizedEmail = "L.A.D11052003@GMAIL.COM".ToUpper(),
             };
             var hasher = new PasswordHasher<IdentityUser>();
             hasher.HashPassword(User, "Admin@123");
             modelBuilder.Entity<IdentityUser>().HasData(User);*/

            modelBuilder.Entity<IdentityUserRole<string>>().HasData
            (
                new IdentityUserRole<string>
                {
                    UserId = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                    RoleId = "133f85fc-3e0c-4bd0-a820-d379c0bf9dc5"
                },
                 new IdentityUserRole<string>
                 {
                     UserId = "f139186b-6419-4cb1-8c80-32755a3f7c01",
                     RoleId = "13ae282b-4fbc-49e6-8deb-4a5e4e8bb130"
                 }
            );
        }
    }
}
