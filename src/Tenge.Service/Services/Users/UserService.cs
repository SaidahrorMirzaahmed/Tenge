using Arcana.Service.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Domain.Entities;
using Tenge.Service.Configurations;
using Tenge.Service.Exceptions;
using Tenge.Service.Helpers;
using Tenge.WebApi.Configurations;

namespace Tenge.Service.Services.Users;

public class UserService(IUnitOfWork unitOfWork, IMemoryCache memoryCache) : IUserService
{
    private readonly string cacheKey = "EmailCodeKey";
    public async ValueTask<User> CreateNonAdminAsync(User user)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => (u.Email == user.Email) && !u.IsDeleted);
        if (existUser is not null)
            throw new AlreadyExistException($"This user already exists with this email={user.Email}");

        user.Role = Domain.Enums.UserRole.NonAdmin;

        user.CreatedByUserId = HttpContextHelper.UserId;
        user.Password = PasswordHasher.Hash(user.Password);
        var createdUser = await unitOfWork.Users.InsertAsync(user);
        await unitOfWork.SaveAsync();

        return createdUser;
    }

    public async ValueTask<User> CreateAdminAsync(User user)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => (u.Email == user.Email) && !u.IsDeleted);
        if (existUser is not null)
            throw new AlreadyExistException($"This user already exists with this email={user.Email}");

        user.Role = Domain.Enums.UserRole.Admin;

        user.CreatedByUserId = HttpContextHelper.UserId;
        user.Password = PasswordHasher.Hash(user.Password);
        var createdUser = await unitOfWork.Users.InsertAsync(user);
        await unitOfWork.SaveAsync();

        return createdUser;
    }

    public async ValueTask<bool> DeleteAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(u => u.Id == id && !u.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this ID={id}");

        existUser.DeletedByUserId = HttpContextHelper.UserId;
        await unitOfWork.Users.DeleteAsync(existUser);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<IEnumerable<User>> GetAllAsync(PaginationParams @params, Filter filter, string search = null)
    {
        var users = unitOfWork.Users
            .SelectAsQueryable(expression: user => !user.IsDeleted, isTracked: false)
            .OrderBy(filter);

        if (!string.IsNullOrEmpty(search))
            users = users.Where(user =>
                user.FirstName.ToLower().Contains(search) ||user.LastName.ToLower().Contains(search));

        return await users.ToPaginateAsQueryable(@params).ToListAsync();
    }

    public async ValueTask<User> GetByIdAsync(long id)
    {
        var existUser = await unitOfWork.Users.SelectAsync(expression: u => u.Id == id && !u.IsDeleted, includes: ["Role"])
            ?? throw new NotFoundException($"User is not found with this ID={id}");

        return existUser;
    }

    public async ValueTask<User> UpdateAsync(long id, User user)
    {
        var existUser = await unitOfWork.Users.SelectAsync(expression: u => u.Id == id && !u.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this ID={id}");

        var alreadyExistUser = await unitOfWork.Users.SelectAsync(u => (u.Email == user.Email || u.Email == user.Email) && !u.IsDeleted && u.Id != id);
        if (alreadyExistUser is not null)
            throw new AlreadyExistException($"This user already exists with this emil={user.Email}");

        existUser.Id = id;
        existUser.Email = user.Email;
        existUser.LastName = user.LastName;
        existUser.FirstName = user.FirstName;
        existUser.UpdatedAt = DateTime.UtcNow;
        existUser.UpdatedByUserId = HttpContextHelper.UserId;
        await unitOfWork.SaveAsync();
        return existUser;
    }

    public async ValueTask<User> ChangePasswordAsync(string email, string oldPassword, string newPassword)
    {
        var existUser = await unitOfWork.Users.SelectAsync(
            expression: u =>
                u.Email == email && PasswordHasher.Verify(oldPassword, u.Password) && !u.IsDeleted)
            ?? throw new ArgumentIsNotValidException($"Email or password is not valid");

        existUser.Password = PasswordHasher.Hash(newPassword);
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();

        return existUser;
    }

    public async ValueTask<bool> ConfirmCodeAsync(string email, string code)
    {
        var user = await unitOfWork.Users.SelectAsync(user => user.Email == email)
            ?? throw new NotFoundException($"User is not found with this email={email}");

        if (memoryCache.Get(cacheKey) as string == code)
            return true;

        return false;
    }
    public async ValueTask<(User user, string token)> LoginAsync(string email, string password)
    {
        var existUser = await unitOfWork.Users.SelectAsync(
            expression: u => u.Email == email && !u.IsDeleted)
            ?? throw new ArgumentIsNotValidException($"Email or password is not valid");

        if (!PasswordHasher.Verify(password, existUser.Password))
            throw new ArgumentIsNotValidException($"Email or password is not valid");

        return (user: existUser, token: AuthHelper.GenerateToken(existUser));
    }

    public async ValueTask<bool> ResetPasswordAsync(string email, string newPassword)
    {
        var existUser = await unitOfWork.Users.SelectAsync(user => user.Email == email && !user.IsDeleted)
            ?? throw new NotFoundException($"User is not found with this email={email}");

        var code = memoryCache.Get(cacheKey) as string;
        if (!await ConfirmCodeAsync(email, code))
            throw new ArgumentIsNotValidException("Confirmation failed");

        existUser.Password = PasswordHasher.Hash(newPassword);
        await unitOfWork.Users.UpdateAsync(existUser);
        await unitOfWork.SaveAsync();

        return true;
    }

    public async ValueTask<bool> SendCodeAsync(string email)
    {
        var user = await unitOfWork.Users.SelectAsync(user => user.Email == email)
            ?? throw new NotFoundException($"User is not found with this email={email}");

        var random = new Random();
        var code = random.Next(10000, 99999);
        await EmailHelper.SendMessageAsync(user.Email, "Confirmation Code", code.ToString());

        var memoryCacheOptions = new MemoryCacheEntryOptions()
             .SetSize(50)
             .SetAbsoluteExpiration(TimeSpan.FromSeconds(60))
             .SetSlidingExpiration(TimeSpan.FromSeconds(30))
             .SetPriority(CacheItemPriority.Normal);

        memoryCache.Set(cacheKey, code.ToString(), memoryCacheOptions);

        return true;
    }

    public async ValueTask<string> QuitAdminAsync()
    {
        var existUser =await unitOfWork.Users.SelectAsync(u => u.Id == HttpContextHelper.UserId);
        existUser.Role = Domain.Enums.UserRole.NonAdmin;
        await unitOfWork.SaveAsync();
        return AuthHelper.GenerateToken(existUser);
    }
    //private async Task LogoutUserAndRefreshTokenAsync(User existUser)
    //{
    //    // Generate a new token for the user with the updated role
    //    var newToken = AuthHelper.GenerateToken(existUser);

    //    // Update the user's token in the application state
    //    UpdateUserToken(existUser, newToken);
    //}
}

