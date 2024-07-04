using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebDbApp.Areas.Identity.Data;
using MyWebDbApp.Models;

namespace MyWebDbApp.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();

        // Seed Admin User
        AppUser adminUser = new AppUser() { Id = Guid.NewGuid().ToString(), UserName = "admin@abc.com" };
        adminUser.NormalizedUserName = adminUser.UserName.ToUpper();
        adminUser.PasswordHash = hasher.HashPassword(adminUser, "Admin*123");
        builder.Entity<AppUser>().HasData(adminUser);

        // Seed Office Users
        AppUser officeUser1 = new AppUser() { Id = Guid.NewGuid().ToString(), UserName = "office1@abc.com" };
        officeUser1.NormalizedUserName = officeUser1.UserName.ToUpper();
        officeUser1.PasswordHash = hasher.HashPassword(officeUser1, "Office*123");
        builder.Entity<AppUser>().HasData(officeUser1);

        AppUser officeUser2 = new AppUser() { Id = Guid.NewGuid().ToString(), UserName = "office2@abc.com" };
        officeUser2.NormalizedUserName = officeUser2.UserName.ToUpper();
        officeUser2.PasswordHash = hasher.HashPassword(officeUser2, "Office*123");
        builder.Entity<AppUser>().HasData(officeUser2);

        // Seed Roles
        IdentityRole adminRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Administrator" };
        adminRole.NormalizedName = adminRole.Name.ToUpper();
        builder.Entity<IdentityRole>().HasData(adminRole);

        IdentityRole officeRole = new IdentityRole() { Id = Guid.NewGuid().ToString(), Name = "Office" };
        officeRole.NormalizedName = officeRole.Name.ToUpper();
        builder.Entity<IdentityRole>().HasData(officeRole);

        // Assign Roles to Users
        IdentityUserRole<string> adminUserRole = new IdentityUserRole<string>() { UserId = adminUser.Id, RoleId = adminRole.Id };
        builder.Entity<IdentityUserRole<string>>().HasData(adminUserRole);

        IdentityUserRole<string> officeUserRole1 = new IdentityUserRole<string>() { UserId = officeUser1.Id, RoleId = officeRole.Id };
        builder.Entity<IdentityUserRole<string>>().HasData(officeUserRole1);

        IdentityUserRole<string> officeUserRole2 = new IdentityUserRole<string>() { UserId = officeUser2.Id, RoleId = officeRole.Id };
        builder.Entity<IdentityUserRole<string>>().HasData(officeUserRole2);
    }
}
