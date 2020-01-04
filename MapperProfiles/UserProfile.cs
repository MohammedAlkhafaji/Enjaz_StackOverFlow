using AutoMapper;
using Enjaz_StackOverFlow.Dtos;
using Enjaz_StackOverFlow.Models;
 

namespace Enjaz_StackOverFlow.MapperProfiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, User>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.User_Name, opt => opt.Ignore())
                .ForAllMembers(opt => opt.Condition(
                   (src, dest, srcMember) => srcMember != null)
                );

            CreateMap<UserForm, User>()
    .ForAllMembers(opt => opt.Condition(
       (src, dest, srcMember) => srcMember != null)
    );

            CreateMap<UpdateUserForm, User>()
.ForAllMembers(opt => opt.Condition(
(src, dest, srcMember) => srcMember != null)
);

        }

    }
}
