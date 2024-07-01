using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebDbApp.Areas.Identity.Data;
using MyWebDbApp.Models;
using System.Reflection.Emit;

namespace MyWebDbApp.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Customer> Customers { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();
        AppUser user = new AppUser() { Id = Guid.NewGuid().ToString(), UserName = "admin@abc.com" };
        user.NormalizedUserName = user.UserName.ToUpper();
        user.PasswordHash = hasher.HashPassword(user, "Admin*123");
        builder.Entity<AppUser>().HasData(user);

        IdentityRole role = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Administrator" };
        role.NormalizedName = role.Name.ToUpper();
        builder.Entity<IdentityRole>().HasData(role);

        IdentityUserRole<string> ur = new IdentityUserRole<string>() { UserId = user.Id, RoleId = role.Id };
        builder.Entity<IdentityUserRole<string>>().HasData(ur);


        string[] Vornamen = new string[] { "Anton", "Berta", "Christian", "Daniela", "Egon", "Franziska" };
        string[] Nachnamen = new string[] { "Alpha", "Beta", "Delta", "Epsilon", "Gamma", "Omega" };
        Random rnd = new Random();

        for (int i = 0; i < 123; i++)
        {
            string vn = Vornamen[rnd.Next(Vornamen.Length)];
            string nn = Nachnamen[rnd.Next(Nachnamen.Length)];
            int share = rnd.Next(100);

            builder.Entity<Customer>().HasData(new Customer()
            {
                Id = i + 1,
                Name = vn + " " + nn,
                EMail = vn.ToLower() + "." + nn.ToLower() + "@uni-wuerzburg.de",
                Gender = i % 2 == 0 ? Customer.GenderType.Male : Customer.GenderType.Female,
                Birthday = new DateTime(rnd.Next(1950, 2000), rnd.Next(12) + 1, rnd.Next(28) + 1),
                ShareStocks = share,
                ShareBonds = 100 - share
            });
        }
    }
}
