using System.ComponentModel.DataAnnotations;

namespace SchoolOfDevs.Dtos
{
    public class NoteRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public decimal Value { get; set; }
    }
}
