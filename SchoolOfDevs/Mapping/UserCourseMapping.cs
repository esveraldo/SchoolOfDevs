using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Mapping
{
    public class UserCourseMapping : IEntityTypeConfiguration<UserCourse>
    {
        public void Configure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.HasKey(x => new {x.UserId, x.CourseId});

            builder.Property(x => x.UserId)
            .IsRequired();

            builder.Property(x => x.CourseId)
                .IsRequired();
        }
    }
}
