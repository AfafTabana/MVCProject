using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.ViewModel.Book;

namespace MVCProject.Controllers
{
    public class BookController : Controller
    {
        ICategoriesRepository catRepository;
        IBookRepository bookRepository;
        IMapper mapper;
        public BookController(IBookRepository bookRepository , IMapper mapper, ICategoriesRepository catRepository)
        {
            this.bookRepository = bookRepository;
            this.mapper = mapper;
            this.catRepository = catRepository;
        }

        public IActionResult DisplayAllBooksForUser()
        {
            List<Books> AllBooks = bookRepository.GetAllBooks().ToList();
            List<DisplayBookUserViewModel> Books = mapper.Map<List<DisplayBookUserViewModel>>(AllBooks);
            return View("DisplayAllBooksForUser" , Books);
        }

        public IActionResult DisplayAllBooksForLibrarian()
        {
            List<Books> AllBooks = bookRepository.GetAllBooks().ToList();
            List<DisplayBookForLibrarianViewModel> Books = mapper.Map<List<DisplayBookForLibrarianViewModel>>(AllBooks);
            return View("DisplayAllBooksForLibrarian", Books);
        }

        public IActionResult AddingBook() {

            AddBookViewModel Bookfromreq = new()
            {
                Cat_list = catRepository.GetAllCategories()
            };
            return View("AddBook",Bookfromreq);
        
        }

        [HttpPost]
        public IActionResult AddBook(AddBookViewModel Book )
        {
            if (ModelState.IsValid) {
                Books _Book = mapper.Map<Books>(Book);
                bookRepository.AddBook(_Book);
                return RedirectToAction("DisplayAllBooksForUser");

            }


            return View("AddBook" , Book);

        }

        [HttpPost]
        public IActionResult DeleteBook(int id)
        {

            bookRepository.DeleteBook(id);
            return RedirectToAction("DisplayAllBooksForLibrarian");


        }

        public IActionResult DisplayBookById(int id) { 
        
          Books _book = bookRepository.GetBookById(id);
          DisplayBookUserViewModel BookDetails = mapper.Map<DisplayBookUserViewModel>(_book);
          return View("DisplayBookDetails" , BookDetails);

        }

    
        public IActionResult SearchBookByTitle(string title) { 
          
           List<Books> Books = bookRepository.SearchBookByTitle(title);
            List<DisplayBookUserViewModel> _Books = mapper.Map<List<DisplayBookUserViewModel>>(Books);
           return View("DisplayByTitle" , _Books);
        }
      
        public IActionResult SearchBookByTitleForLibrarian(string title)
        {
            List<Books> Books = bookRepository.SearchBookByTitle(title);
            List<DisplayBookForLibrarianViewModel> _Books = mapper.Map<List<DisplayBookForLibrarianViewModel>>(Books);
            return View("DisplayByTitleForLibrarian", _Books);

        }

        public IActionResult EditBook(int id) {
            var book = bookRepository.GetBookById(id);
            var BookEdit= mapper.Map<EditBookViewModel>(book);
            return View("EditBook", BookEdit);
        }

        [HttpPost]
        public IActionResult UpdateBook(EditBookViewModel Book) {

            if (ModelState.IsValid) {
                Books _Book = mapper.Map<Books>(Book);
                bookRepository.UpdateBook(_Book);
                return RedirectToAction("DisplayAllBooksForLibrarian");

            }

            return View("EditBook" , Book); 
        
        }
    }
}
