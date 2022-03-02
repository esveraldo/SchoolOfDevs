using System.ComponentModel.DataAnnotations;

namespace SchoolOfDevs.Dtos
{
    public class NoteDto
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
