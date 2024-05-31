using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;
using Tenge.DataAccess.UnitOfWorks;
using Tenge.Service.Assets.Service;
using Tenge.Service.Helpers;
using Tenge.Service.Services.Assets.Assets;
using Tenge.Service.Services.Categories;
using Tenge.Service.Services.Collections;
using Tenge.Service.Services.Items;
using Tenge.Service.Services.Users;
using Tenge.WebApi.ApiServices.Accounts;
using Tenge.WebApi.ApiServices.Categories;
using Tenge.WebApi.ApiServices.Collections;
using Tenge.WebApi.ApiServices.Items;
using Tenge.WebApi.ApiServices.Users;
using Tenge.WebApi.Configurations;
using Tenge.WebApi.Middlewares;
using Tenge.WebApi.Models.Assets;
using Tenge.WebApi.Validators.Accounts;
using Tenge.WebApi.Validators.Categories;
using Tenge.WebApi.Validators.Collections;
using Tenge.WebApi.Validators.Users;

namespace Tenge.WebApi.Extensions;

public static class CollectionExtension
{
    public static void AddServices(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IItemService, ItemService>();
        services.AddScoped<IAssetService, AssetService>();
        services.AddScoped<ICategoryService, CategoryService>();
        services.AddScoped<ICollectionService, CollectionService>();
    }

    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddScoped<IAccountApiService, AccountApiService>();
        services.AddScoped<IUserApiService, UserApiService>();
        services.AddScoped<IItemApiService, ItemApiService>();
        services.AddScoped<ICategoryApiService, CategoryApiService>();
        services.AddScoped<ICollectionApiService, CollectionApiService>();
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
    }

    public static void AddValidators(this IServiceCollection services)
    {
        services.AddTransient<FileModelValidator>();
        services.AddTransient<UserCreateModelValidator>();
        services.AddTransient<UserUpdateModelValidator>();

        services.AddTransient<CategoryCreateModelValidator>();
        services.AddTransient<CategoryUpdateModelValidator>();

        services.AddTransient<ItemCreateModelValidator>();
        services.AddTransient<ItemUpdateModelValidator>();

        services.AddTransient<CollectionCreateModelValidator>();
        services.AddTransient<CollectionUpdateModelValidator>();

        services.AddTransient<ConfirmCodeModelValidator>();
        services.AddTransient<LoginModelValidator>();
        services.AddTransient<ResetPasswordModelValidator>();
        services.AddTransient<SendCodeModelValidator>();

        services.AddTransient<UserChangePasswordModelValidator>();
    }

    public static void AddExceptionHandlers(this IServiceCollection services)
    {
        services.AddExceptionHandler<NotFoundExceptionHandler>();
        services.AddExceptionHandler<AlreadyExistExceptionHandler>();
        services.AddExceptionHandler<ArgumentIsNotValidExceptionHandler>();
        services.AddExceptionHandler<CustomExceptionHandler>();
        services.AddExceptionHandler<InternalServerExceptionHandler>();
    }
    public static void InjectEnvironmentItems(this WebApplication app)
    {
        HttpContextHelper.ContextAccessor = app.Services.GetRequiredService<IHttpContextAccessor>();
        EnvironmentHelper.WebRootPath = Path.GetFullPath("wwwroot");
        EnvironmentHelper.JWTKey = app.Configuration.GetSection("JWT:Key").Value;
        EnvironmentHelper.TokenLifeTimeInHours = app.Configuration.GetSection("JWT:LifeTime").Value;
        EnvironmentHelper.EmailAddress = app.Configuration.GetSection("Email:EmailAddress").Value;
        EnvironmentHelper.EmailPassword = app.Configuration.GetSection("Email:Password").Value;
        EnvironmentHelper.SmtpPort = app.Configuration.GetSection("Email:Port").Value;
        EnvironmentHelper.SmtpHost = app.Configuration.GetSection("Email:Host").Value;
        EnvironmentHelper.PageSize = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageSize").Value);
        EnvironmentHelper.PageIndex = Convert.ToInt32(app.Configuration.GetSection("PaginationParams:PageIndex").Value);
    }
    public static void AddJwtService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).AddJwtBearer(o =>
        {
            var key = Encoding.UTF8.GetBytes(configuration["JWT:Key"]);
            o.SaveToken = true;
            o.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["JWT:Issuer"],
                ValidAudience = configuration["JWT:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key)
            };
        });
    }

    public static void ConfigureSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(setup =>
        {
            var jwtSecurityScheme = new OpenApiSecurityScheme
            {
                BearerFormat = "JWT",
                Name = "JWT Authentication",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                Description = "Put **_ONLY_** your JWT Bearer token on textbox below!",

                Reference = new OpenApiReference
                {
                    Id = JwtBearerDefaults.AuthenticationScheme,
                    Type = ReferenceType.SecurityScheme
                }
            };

            setup.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

            setup.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { jwtSecurityScheme, Array.Empty<string>() }
                });
        });
    }
}
