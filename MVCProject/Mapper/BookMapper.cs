using AutoMapper;
using MVCProject.Models;
using MVCProject.ViewModel.Book;

namespace MVCProject.Mapper
{
    public class BookMapper : Profile
    {
        public BookMapper() {

          // CreateMap<Books, DisplayBookForLibrarianViewModel>().ReverseMap();
           CreateMap<Books, DisplayBookForLibrarianViewModel>()
                .ForMember(dest => dest.Categeory_Name, opt => opt.MapFrom(src => src.categeory.Name))
                   .ReverseMap();

            CreateMap<Books, AddBookViewModel>().ReverseMap();
            CreateMap<Books, EditBookViewModel>().ReverseMap();
            //Ahmed Ashraf 
            //
            //CreateMap<Books,DisplayBookUserViewModel>().ReverseMap();
            //map to say that the  Categeory_Name in the view model equal that in the Categeory repo 
            CreateMap<Books, DisplayBookUserViewModel>()
                   .ForMember(dest => dest.Categeory_Name, opt => opt.MapFrom(src => src.categeory.Name)) 
                   .ReverseMap();
        }
    }
}
