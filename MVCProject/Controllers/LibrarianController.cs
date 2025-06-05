using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.ViewModel.Librarian;

namespace MVCProject.Controllers
{
    public class LibrarianController : Controller
    {
        ILibrarianRepository librarianRepository;
        IMapper mapper;
        public LibrarianController(ILibrarianRepository librarianRepository,IMapper mapper)
        {
            this.librarianRepository = librarianRepository;
            this.mapper = mapper;
        }
        public IActionResult GetAllLibrarians()
        {
            List<Librarians> librarians = librarianRepository.GetAllLibrarians();
            List<DisplayLibrarianViewModel> displayLibrarianViewModels= mapper.Map<List<DisplayLibrarianViewModel>>(librarians);
            return View("AllLibrariansView", displayLibrarianViewModels);
        }
    }
}
