using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolOfDevs.Entities;

namespace SchoolOfDevs.Mapping
{
    public class NoteMapping : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Value)
                .HasColumnType("decimal(10, 2)")
                .IsRequired();
        }
    }
}
