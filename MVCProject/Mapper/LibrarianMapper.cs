using AutoMapper;
using MVCProject.Models;
using MVCProject.ViewModel.Librarian;

namespace MVCProject.Mapper
{
    public class LibrarianMapper : Profile
    {
        public LibrarianMapper() { 
          CreateMap<Librarians,DisplayLibrarianViewModel>().ReverseMap();
            CreateMap<Librarians, AddLibrarianViewModel>().ReverseMap();
            CreateMap<Librarians, EditLibrarianViewModel>().ReverseMap();

        }
    }
}
