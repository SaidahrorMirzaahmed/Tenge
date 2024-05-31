using AutoMapper;
using Tenge.Domain.Entities;
using Tenge.Service.Services.Assets.Assets;
using Tenge.WebApi.Models.Category;
using Tenge.WebApi.Models.Collections;
using Tenge.WebApi.Models.Items;
using Tenge.WebApi.Models.Users;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace Tenge.WebApi.Mappers;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Asset, AssetViewModel>();
        CreateMap<User, UserViewModel>().ReverseMap();
        CreateMap<UserCreateModel, User>().ReverseMap();
        CreateMap<UserUpdateModel, User>().ReverseMap();
        CreateMap<UserLoginViewModel, User>().ReverseMap();
        
        CreateMap<Collection, CollectionViewModel>().
            ForMember(dest => dest.Picture, opt => opt.MapFrom(src => src.Picture));

        CreateMap<CollectionCreateModel, Collection>().ReverseMap();
        CreateMap<CollectionUpdateModel, Collection>().ReverseMap();

        CreateMap<Item, ItemViewModel>().ReverseMap();
        CreateMap<ItemCreateModel, Item>().ReverseMap();
        CreateMap<ItemUpdateModel, Item>().ReverseMap();

        CreateMap<Category, CategoryViewModel>().ReverseMap();
        CreateMap<CategoryCreateModel, Category>().ReverseMap();
        CreateMap<CategoryUpdateModel, Category>().ReverseMap();
    }
}
