using System.ComponentModel.DataAnnotations;

namespace SchoolOfDevs.Dtos
{
    public class CourseRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public decimal Price { get; set; }
    }
}
