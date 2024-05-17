using AutoMapper;
using Tenge.WebApi.Models.Accounts;
using Tenge.WebApi.Models.Users;
using Tenge.Service.Services.Users;
using Tenge.WebApi.Validators.Accounts;
using Tenge.WebApi.Extensions;

namespace Tenge.WebApi.ApiServices.Accounts;

public class AccountApiService(
    IMapper mapper,
    IUserService userService,
    LoginModelValidator loginModelValidator,
    SendCodeModelValidator sendCodeModelValidator,
    ConfirmCodeModelValidator confirmCodeModelValidator,
    ResetPasswordModelValidator resetPasswordModelValidator) : IAccountApiService
{
    public async ValueTask<bool> ConfirmCodeAsync(ConfirmCodeModel confirmCodeModel)
    {
        await confirmCodeModelValidator.EnsureValidatedAsync(confirmCodeModel);
        return await userService.ConfirmCodeAsync(confirmCodeModel.Email, confirmCodeModel.Code);
    }

    public async ValueTask<UserLoginViewModel> LoginAsync(LoginModel loginModel)
    {
        await loginModelValidator.EnsureValidatedAsync(loginModel);
        var loginResult = await userService.LoginAsync(loginModel.Email, loginModel.Password);
        var mappedUser = mapper.Map<UserLoginViewModel>(loginResult.user);
        mappedUser.Token = loginResult.token;
        return mappedUser;
    }

    public async ValueTask<bool> ResetPasswordAsync(ResetPasswordModel resetPasswordModel)
    {
        await resetPasswordModelValidator.EnsureValidatedAsync(resetPasswordModel);
        return await userService.ResetPasswordAsync(resetPasswordModel.Email, resetPasswordModel.NewPassword);
    }

    public async ValueTask<bool> SendCodeAsync(SendCodeModel sendCodeModel)
    {
        await sendCodeModelValidator.EnsureValidatedAsync(sendCodeModel);
        return await userService.SendCodeAsync(sendCodeModel.Email);
    }
}