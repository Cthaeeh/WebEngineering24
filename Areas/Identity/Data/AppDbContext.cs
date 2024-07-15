using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MyWebDbApp.Areas.Identity.Data;
using MyWebDbApp.Models;

namespace MyWebDbApp.Data;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Department> Departments { get; set; }
    public DbSet<Workspace> Workspaces { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<Equipment> Equipment { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Occupancy> Occupancies { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        PasswordHasher<AppUser> hasher = new PasswordHasher<AppUser>();

        builder.Entity<Employee>()
            .HasOne(e => e.Department)
            .WithMany(d => d.Employees)
            .HasForeignKey(e => e.DepartmentId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Workspace>()
            .HasOne(w => w.Room)
            .WithMany(r => r.Workspaces)
            .HasForeignKey(w => w.RoomId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Equipment>()
            .HasOne(e => e.Workspace)
            .WithMany(w => w.Equipment)
            .HasForeignKey(e => e.WorkspaceId);

        builder.Entity<Occupancy>()
            .HasOne(o => o.Workspace)
            .WithMany(w => w.Occupancies)
            .HasForeignKey(o => o.WorkspaceId)
            .OnDelete(DeleteBehavior.Cascade);


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

        var rooms = new List<Room>
    {
        new Room { Id = 1, Name = "Room 1", Type = Room.RoomType.Regular },
        new Room { Id = 2, Name = "Room 2", Type = Room.RoomType.Laboratory },
        new Room { Id = 3, Name = "Room 3", Type = Room.RoomType.Kitchen },
        new Room { Id = 4, Name = "Room 4", Type = Room.RoomType.Assembly },
        new Room { Id = 5, Name = "Room 5", Type = Room.RoomType.Ballroom },
        new Room { Id = 6, Name = "Room 6", Type = Room.RoomType.Relaxation },
        new Room { Id = 7, Name = "Room 7", Type = Room.RoomType.Regular },
        new Room { Id = 8, Name = "Room 8", Type = Room.RoomType.Laboratory },
        new Room { Id = 9, Name = "Room 9", Type = Room.RoomType.Kitchen },
        new Room { Id = 10, Name = "Room 10", Type = Room.RoomType.Assembly }
    };

        builder.Entity<Room>().HasData(rooms);

        // Seed Workspaces
        var workspaces = new List<Workspace>();
        for (int i = 1; i <= 30; i++)
        {
            workspaces.Add(new Workspace
            {
                Id = i,
                Name = $"Workspace {i}",
                RoomId = (i % 10) + 1,  // Assigning room IDs cyclically
            });
        }

        builder.Entity<Workspace>().HasData(workspaces);

        // Seed Equipment
    var equipmentList = new List<Equipment>();
    for (int i = 1; i <= 30; i++)
    {
        equipmentList.Add(new Equipment { Id = i, Name = "Desk", WorkspaceId = i });
        equipmentList.Add(new Equipment { Id = i + 30, Name = "Chair", WorkspaceId = i });
    }

    builder.Entity<Equipment>().HasData(equipmentList);

    // Seeding data for Employees
        string[] vorname = new string[] { "Anton", "Bernd", "Clara", "Dieter", "Eva", "Friedrich", "Greta", "Heinz", "Ingrid", "Johann" };
        string[] nachname = new string[] { "Meier", "Schmidt", "Fischer", "Weber", "Müller", "Bauer", "Richter", "Koch", "Wagner", "Becker" };
        Random rnd = new Random();

        for (int i = 0; i < 123; i++)
        {
            string vn = vorname[rnd.Next(vorname.Length)];
            string nn = nachname[rnd.Next(nachname.Length)];
            int departmentId = rnd.Next(1, 6); // Assuming there are 5 departments

            builder.Entity<Employee>().HasData(new Employee
            {
                Id = i + 1,
                Name = vn + " " + nn,
                DepartmentId = departmentId
            });
        }
    }

    
}
