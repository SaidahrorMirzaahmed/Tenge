using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Users;

public interface IUserService
{
    ValueTask<User> CreateNonAdminAsync(User user);
    ValueTask<User> CreateAdminAsync(User user);
    ValueTask<User> UpdateAsync(long id, User user);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<User> GetByIdAsync(long id);
    ValueTask<IEnumerable<User>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<(User user, string token)> LoginAsync(string email, string password);
    ValueTask<bool> ResetPasswordAsync(string email, string newPassword);
    ValueTask<bool> SendCodeAsync(string email);
    ValueTask<bool> ConfirmCodeAsync(string email, string code);
    ValueTask<User> ChangePasswordAsync(string email, string oldPassword, string newPassword);
}

