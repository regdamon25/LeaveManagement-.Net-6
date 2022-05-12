using LeaveManagement.Web.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Web.Configurations.Entities
{
    public class UserSeedConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            var hasher = new PasswordHasher<Employee>();
            builder.HasData(
                new Employee
                {
                    Id = "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                    Email = "admin@local.com",
                    NormalizedEmail = "ADMIN@LOCAL.COM",
                    UserName = "admin@local.com",
                    NormalizedUserName = "ADMIN@LOCAL.COM",
                    FirstName = "System",
                    LastName = "Admin",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                },
                new Employee
                {
                    Id = "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                    Email = "user@Localhost.com",
                    NormalizedEmail = "USER@LOCALHOST.COM",
                    UserName = "user@Localhost.com",
                    NormalizedUserName = "USER@LOCALHOST.COM",
                    FirstName = "System",
                    LastName = "User",
                    PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                    EmailConfirmed = true
                }
            ); ; ;
        }
    }
}