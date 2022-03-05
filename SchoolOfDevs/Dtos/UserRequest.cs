using SchoolOfDevs.Dtos.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolOfDevs.Dtos
{
    public class UserRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public string? LastName { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public int Age { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public string? UserName { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public string? Password { get; set; }
        public string? ConfirmPassword { get; set; }
        [Required(ErrorMessage = "O registro {0} é requerido")]
        public string? Role { get; set; }
        public TypeUserEnumDTO TypeUser { get; set; }
    }
}
