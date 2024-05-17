using Tenge.WebApi.Models.Accounts;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.ApiServices.Accounts;

public interface IAccountApiService
{
    ValueTask<UserLoginViewModel> LoginAsync(LoginModel loginModel);
    ValueTask<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel);
    ValueTask<bool> SendCodeAsync(SendCodeModel sendCodeModel);
    ValueTask<bool> ConfirmCodeAsync(ConfirmCodeModel confirmCodeModel);
}