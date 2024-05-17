using Tenge.Service.Configurations;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Models.Users;

namespace Tenge.WebApi.ApiServices.Users;

public interface IUserApiService
{
    ValueTask<UserViewModel> PostAsync(UserCreateModel createModel);
    ValueTask<UserViewModel> PutAsync(long id, UserUpdateModel createModel);
    ValueTask<bool> DeleteAsync(long id);
    ValueTask<UserViewModel> GetAsync(long id);
    ValueTask<IEnumerable<UserViewModel>> GetAllAsync(PaginationParams @params, Filter filter, string search = null);
    ValueTask<UserViewModel> ChangePasswordAsync(UserChangePasswordModel changePasswordModel);
}