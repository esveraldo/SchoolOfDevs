using SchoolOfDevs.Dtos.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace SchoolOfDevs.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public TypeUserEnumDTO TypeUser { get; set; }
    }
}

