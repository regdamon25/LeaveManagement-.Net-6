using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LeaveManagement.Data.Configurations.Entities
{
    public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "d635121f-4acf-41b0-a8f5-2aa2a120ffeb",
                    UserId = "26c61fd0-67c1-4769-a2a8-95fbe5dd8750",
                },
                new IdentityUserRole<string>
                {
                    RoleId = "c209edbc-61e8-4355-81c6-9dc48a639a13",
                    UserId = "808d5c0c-0b1f-49c4-9bf8-0223299a3c87",
                }
            );
        }
    }
}
