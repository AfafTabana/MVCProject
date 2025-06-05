using AutoMapper;
using MVCProject.Models;
using MVCProject.ViewModel.Book;

namespace MVCProject.Mapper
{
    public class BookMapper : Profile
    {
        public BookMapper() {

            CreateMap<Books, DisplayBookForLibrarianViewModel>().ReverseMap();
            CreateMap<Books, AddBookViewModel>().ReverseMap();
            CreateMap<Books, EditBookViewModel>().ReverseMap();
            CreateMap<Books,DisplayBookUserViewModel>().ReverseMap();
        }
    }
}
