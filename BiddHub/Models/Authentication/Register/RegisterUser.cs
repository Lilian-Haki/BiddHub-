using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Web.Http.Results;

namespace BiddHub.Models.Authentication.Register
{
    public class RegisterUser : IdentityUser<Guid> 
    {
        [Required(ErrorMessage = "First Name Is required")]
        public required string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name Is required")]
        public required string LastName { get; set; }

    }

    public class RoleUser : IdentityRole<Guid>
    {
        public string? role { get; set; }
    }

}
