using Microsoft.AspNetCore.Mvc;
using MVCProject.Repository;

namespace MVCProject.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        public BookController(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
