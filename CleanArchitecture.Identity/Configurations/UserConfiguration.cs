using CleanArchitecture.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "bc4405da-97ee-47d5-bc2c-e4c01d5e86bd",
                    Email = "admin@localhost.com",
                    NormalizedEmail = "admin@localhost.com",
                    Nombre = "Santiago",
                    Apellidos = "Vizcaino",
                    UserName = "santiagov",
                    NormalizedUserName = "santiagov",
                    PasswordHash = hasher.HashPassword(null, "santiago123456"),
                    EmailConfirmed = true,
                },
                new ApplicationUser
                {
                     Id = "54b4bd09-2f32-46ed-adaf-00fe2931c5ab",
                     Email = "juan@localhost.com",
                     NormalizedEmail = "juan@localhost.com",
                     Nombre = "juan",
                     Apellidos = "perez",
                     UserName = "perez",
                     NormalizedUserName = "perez",
                     PasswordHash = hasher.HashPassword(null, "santiago123456"),
                     EmailConfirmed = true,
                }

                );
        }
    }
}
