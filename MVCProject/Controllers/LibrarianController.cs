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
        public LibrarianController(ILibrarianRepository librarianRepository, IMapper mapper)
        {
            this.librarianRepository = librarianRepository;
            this.mapper = mapper;
        }
        public IActionResult GetAllLibrarians()
        {
            List<Librarians> librarians = librarianRepository.GetAllLibrarians();
            List<DisplayLibrarianViewModel> displayLibrarianViewModels = mapper.Map<List<DisplayLibrarianViewModel>>(librarians);
            return View("AllLibrariansView", displayLibrarianViewModels);
        }

        public IActionResult GetLibrarianById(int id)
        {
            Librarians librarian = librarianRepository.GetLibrarianById(id);
            DisplayLibrarianViewModel displayLibrarianViewModel = mapper.Map<DisplayLibrarianViewModel>(librarian);
            return View("DisplayLibrarianView", displayLibrarianViewModel);
        }

        public IActionResult SearchLibrarianByName(string name)
        {
            List<Librarians> librarians = librarianRepository.SearchLibrarianByName(name);
            List<DisplayLibrarianViewModel> displayLibrarianViewModels = mapper.Map<List<DisplayLibrarianViewModel>>(librarians);
            return View("AllLibrariansView", displayLibrarianViewModels);
        }

        public IActionResult UpdateLibrarianView(int id)
        {
            Librarians librarian = librarianRepository.GetLibrarianById(id);
            EditLibrarianViewModel editLibrarianViewModel = mapper.Map<EditLibrarianViewModel>(librarian);
            return View("EditLibrarianView", editLibrarianViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateLibrarian(EditLibrarianViewModel librarianViewModel)
        {
            if (ModelState.IsValid)
            {
                Librarians librarian = mapper.Map<Librarians>(librarianViewModel);
                librarianRepository.UpdateLibrarian(librarian);
                return RedirectToAction("GetAllLibrarians");
            }
            return View("EditLibrarianView", librarianViewModel);
        }

        public IActionResult DeleteLibrarian(int id)
        {
            librarianRepository.DeleteLibrarian(id);
            return Json(true);
        }

        public IActionResult AddLibrarianView()
        {
            return View("AddLibrarianView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddLibrarian(AddLibrarianViewModel librarianViewModel)
        {
            if (ModelState.IsValid)
            {
                Librarians librarian = mapper.Map<Librarians>(librarianViewModel);
                librarianRepository.AddLibrarian(librarian);
                return RedirectToAction("GetAllLibrarians");
            }
            return View("AddLibrarianView", librarianViewModel);
        }
    }
}
