using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO;

public class UserLoginRequest
{
    [Required(ErrorMessage = "Email is required")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; set; }
}