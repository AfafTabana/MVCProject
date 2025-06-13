using AutoMapper;
using MVCProject.Models;
using MVCProject.ViewModel.User;

namespace MVCProject.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper() {
            CreateMap<Users, DisplayUserViewModel>().ReverseMap();
        }
       
    }
}
