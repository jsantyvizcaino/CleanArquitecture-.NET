using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Identity.Configurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Id = "bd363116-8a6d-4a35-82ec-296df19ec069",
                    Name = "Administrador",
                    NormalizedName = "ADMINISTRADOR"
                },
                 new IdentityRole
                 {
                     Id = "9af2e29d-4e33-491f-8163-374b40662835",
                     Name = "Operador",
                     NormalizedName = "OPERADOR"
                 }


                );
        }
    }
}
