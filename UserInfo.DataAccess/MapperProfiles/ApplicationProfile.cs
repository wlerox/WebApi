using AutoMapper;
using UserInfo.Entities.DtoModel;
using UserInfo.Entities.Model;

namespace UserInfo.DataAccess.MapperProfiles
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile()
        {
            //Get user
            /*CreateMap<User, UserDto>()
                .ForMember(destination => destination.Id, operation => operation.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.Name))
                .ForMember(destination => destination.Username, operation => operation.MapFrom(source => source.Username))
                .ForMember(destination => destination.Email, operation => operation.MapFrom(source => source.Email))
                .ForMember(destination => destination.Address, operation => operation.MapFrom(source => source.Address))
                .ForMember(destination => destination.Phone, operation => operation.MapFrom(source => source.Phone))
                .ForMember(destination => destination.Website, operation => operation.MapFrom(source => source.Website))
                .ForMember(destination => destination.Company, operation => operation.MapFrom(source => source.Company)).ReverseMap();
            //post user
            CreateMap<UserDto, User>()
                //.ForMember(destination => destination.Id, operation => operation.MapFrom(source => source.Id))
                .ForMember(destination => destination.Name, operation => operation.MapFrom(source => source.Name))
                .ForMember(destination => destination.Username, operation => operation.MapFrom(source => source.Username))
                .ForMember(destination => destination.Email, operation => operation.MapFrom(source => source.Email))
                .ForMember(destination => destination.AddressId, operation => operation.MapFrom(source => source.AddressId))
                .ForMember(destination => destination.Phone, operation => operation.MapFrom(source => source.Phone))
                .ForMember(destination => destination.Website, operation => operation.MapFrom(source => source.Website))
                .ForMember(destination => destination.CompanyId, operation => operation.MapFrom(source => source.CompanyId)).ReverseMap();
            */
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<User, UserSetDto>().ReverseMap();
            CreateMap<UserSetDto, User>().ReverseMap();
            CreateMap<Address, AddressDto>().ReverseMap();
            CreateMap<AddressDto, Address>().ReverseMap();
            CreateMap<Company, CompanyDto>().ReverseMap();
            CreateMap<CompanyDto, Company>().ReverseMap();
            CreateMap<Geolocation, GeolocationDto>().ReverseMap();
            CreateMap<GeolocationDto, Geolocation>().ReverseMap();
            CreateMap<Role, RoleDto>().ReverseMap();
            CreateMap<RoleDto, Role>().ReverseMap();
            CreateMap<User, UserAuthDto>().ReverseMap();
            CreateMap<UserAuthDto, User>().ReverseMap();
            CreateMap<User, UserSecurityDto>().ReverseMap();
            CreateMap<UserSecurityDto, User>().ReverseMap();

        }
    }
}
