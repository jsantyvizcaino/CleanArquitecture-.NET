using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId= "bd363116-8a6d-4a35-82ec-296df19ec069",
                    UserId= "bc4405da-97ee-47d5-bc2c-e4c01d5e86bd"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "9af2e29d-4e33-491f-8163-374b40662835",
                    UserId = "54b4bd09-2f32-46ed-adaf-00fe2931c5ab"
                }

                );
        }
    }
}
