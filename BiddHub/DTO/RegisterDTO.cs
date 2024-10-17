using System.ComponentModel.DataAnnotations;

namespace BiddHub.DTO
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "First Name Is required")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is required")]
        public required string LastName { get; set; }
        [Required(ErrorMessage = "UserName Is required")]
        public required string Username { get; set; }
        [Required(ErrorMessage = "Password Is required")]
        public required string Password { get; set; }
        [Required(ErrorMessage = "Password Confirmation Is required")]
        public required string ConfirmPassword { get; set; }
        [Required(ErrorMessage = "Email Is required")]
        public required string Email { get; set; }
        
    }
}
