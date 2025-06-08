using Microsoft.AspNetCore.Mvc;
using MVCProject.Repository;
using MVCProject.ViewModel.Book;

namespace MVCProject.Controllers
{
    public class BookController : Controller
    {
        IBookRepository bookRepository;
        ISalesRepository salesRepository;
        public BookController(IBookRepository bookRepository, ISalesRepository salesRepository)
        {
            this.bookRepository = bookRepository;
            this.salesRepository = salesRepository;
        }
        public IActionResult Index()
        {
            var books = bookRepository.GetAllBooks().Select(b => new BuyBookViewModel
            {
                BookId = b.ID,
                BookTitle = b.Title,
                Price = b.Price,
                AvailableQuantity = b.Buy_quantity
            }).ToList();
            return View(books);
        }
        public IActionResult GetAllBooks()
        {
            var books = bookRepository.GetAllBooks().Select(b => new BuyBookViewModel
            {
                BookId = b.ID,
                BookTitle = b.Title,
                Price = b.Price,
                AvailableQuantity = b.Buy_quantity
            }).ToList();
            return View(books);
        }
        public IActionResult BuyBook (int id)
        {
            var book = bookRepository.GetBookById(id);
            if (book == null || book.Buy_quantity == 0) return NotFound();
            return View(new BuyBookViewModel
            {
                BookId = book.ID,
                BookTitle = book.Title,
                Price = book.Price,
                AvailableQuantity = book.Buy_quantity
            });
        }
        [HttpPost]
        public IActionResult ConfirmPurchase (BuyBookViewModel vm)
        {
            var book = bookRepository.GetBookById(vm.BookId);
            if (book ==null || vm.QuantityToBuy > book.Buy_quantity)
            {
                ModelState.AddModelError("", "Invalid Quantity");
                return View(vm);
            }
            int userId = 1;
            book.Buy_quantity -= vm.QuantityToBuy;
            bookRepository.UpdateBook(book);
            salesRepository.AddBook(new Models.Sales
            {
                Book_ID = book.ID,
                Quantity = book.Buy_quantity,
                User_ID = userId,
                Date = DateTime.Now


            });
            return RedirectToAction("Index");
        }
    }
}
