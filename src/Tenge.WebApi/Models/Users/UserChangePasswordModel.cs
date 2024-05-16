namespace Tenge.WebApi.Models.Users;

public class UserChangePasswordModel
{
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}