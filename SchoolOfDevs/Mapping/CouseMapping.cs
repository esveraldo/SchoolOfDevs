using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Mapping
{
    public class CouseMapping : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name)
                .HasColumnType("varchar(100)")
                .IsRequired();
            builder.Property(x => x.Price)
                .HasColumnType("decimal(18, 2)")
                .IsRequired();
        }
    }
}
