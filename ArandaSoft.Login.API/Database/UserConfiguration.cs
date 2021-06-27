using ArandaSoft.Login.API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaSoft.Login.API.Database
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Username)
                .IsRequired();
            builder.Property(s => s.Password)
                .IsRequired();
            builder.Property(s => s.Name)
                .IsRequired();
            builder.Property(s => s.Lastname)
                .IsRequired();
            builder.Property(s => s.Phone)
                .IsRequired();
            builder.Property(s => s.Email)
                .IsRequired();
            builder.Property(s => s.Age)
                .IsRequired();
        }
    }
}
