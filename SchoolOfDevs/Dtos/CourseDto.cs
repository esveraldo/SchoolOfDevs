using System.ComponentModel.DataAnnotations;

namespace SchoolOfDevs.Dtos
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
