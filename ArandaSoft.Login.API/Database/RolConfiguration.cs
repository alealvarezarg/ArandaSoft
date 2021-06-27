using ArandaSoft.Login.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaSoft.Login.API.Database
{
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Rolname)
                .IsRequired();
            builder.Property(s => s.Description)
                .IsRequired();
        }
    }
}
