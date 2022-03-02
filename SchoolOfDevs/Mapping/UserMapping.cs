using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfDevs.Entities;
using SchoolOfDevs.Entities.Enums;

namespace SchoolOfDevs.Mapping
{
    public class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.LastName)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.UserName)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.Password)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.TypeUser)
                .HasConversion(x => x.ToString(), x => (TypeUserEnum)Enum.Parse(typeof(TypeUserEnum), x))
                .HasColumnType("varchar(20)");

            builder.HasMany(x => x.Notes).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        }
    }
}
