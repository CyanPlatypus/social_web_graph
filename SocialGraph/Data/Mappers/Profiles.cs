using AutoMapper;
using Data.Dtos;
using Data.Models;
using System.Linq;

namespace Data.Mappers
{
    public class Profiles: Profile
    {
        public Profiles()
        {
            CreateMap<User, UserDto>()
                .ForMember(uDto => uDto.Gender, a => a.MapFrom(u => u.Gender.Name))
                .ForMember(uDto => uDto.PlaceOfBirth, a => a.MapFrom(u => u.PlaceOfBirth.Name))
                .ForMember(uDto => uDto.Residence, a => a.MapFrom(u => u.Residence.Name))
                .ForMember(uDto => uDto.Hobbies, a => a.MapFrom(u => u.Hobbies.Select(h => h.Name)))
                .ForMember(uDto => uDto.Friends, 
                    a => a.MapFrom(u => u.Friends.Select(f=>new UserInfoDto()
                    {
                        Id = f.FriendId,
                        Name = f.Friend.Name,
                        Surname = f.Friend.Surname,
                        Patronymic = f.Friend.Patronymic
                    })));

            CreateMap<UserDto, User>();

            CreateMap<User, UserNodeDto>()
                .ForMember(uDto => uDto.Friends, a => a.MapFrom(u => u.Friends.Select(f => f.FriendId)));
        }
    }
}