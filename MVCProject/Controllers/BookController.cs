using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.ViewModel.Book;
using System.Security.Claims;

namespace MVCProject.Controllers
{
    public class BookController : Controller
    {
        ICategoriesRepository catRepository;
        ISalesRepository salesRepository;
        IBookRepository bookRepository;
        IMapper mapper;
        private readonly IUserRepository userRepository;

        // public BookController(IBookRepository bookRepository , IMapper mapper, ICategoriesRepository catRepository)

        IBorrowRepository Borrow;

        public BookController(IBookRepository bookRepository,
            IBorrowRepository borrow,
            ISalesRepository salesRepository,
            IMapper mapper,
            IUserRepository userRepository
            )
        {
            this.bookRepository = bookRepository;
            this.salesRepository = salesRepository;
            Borrow = borrow;
            this.mapper = mapper;
            this.userRepository = userRepository;
            this.catRepository = catRepository;
        }

        
        public IActionResult DisplayAllBooksForUser()
        {
            List<Books> AllBooks = bookRepository.GetAllBooks().ToList();
            List<DisplayBookUserViewModel> Books = mapper.Map<List<DisplayBookUserViewModel>>(AllBooks);
            return View("DisplayAllBooksForUser", Books);
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
        [ValidateAntiForgeryToken]
        public IActionResult AddBook(AddBookViewModel Book)
        {
            if (ModelState.IsValid)
            {
                Books _Book = mapper.Map<Books>(Book);
                bookRepository.AddBook(_Book);
                return RedirectToAction("DisplayAllBooksForUser");

            }
            // Ahmed Ashraf 
            // put this line to take the list of categeory to view model
            //  if the model state isn't valid and return the data in view model  with  categeoruies
            Book.Cat_list = catRepository.GetAllCategories();
            return View("AddBook" , Book);

        }

        [HttpPost]
        public IActionResult DeleteBook(int id)
        {

            bookRepository.DeleteBook(id);
            return RedirectToAction("DisplayAllBooksForLibrarian");


        }

        public IActionResult DisplayBookById(int id)
        {

            Books _book = bookRepository.GetBookById(id);
            DisplayBookUserViewModel BookDetails = mapper.Map<DisplayBookUserViewModel>(_book);
            return View("DisplayBookDetails", BookDetails);

        }


        public IActionResult SearchBookByTitle(string title)
        {

            List<Books> Books = bookRepository.SearchBookByTitle(title);
            List<DisplayBookUserViewModel> _Books = mapper.Map<List<DisplayBookUserViewModel>>(Books);
            return View("DisplayByTitle", _Books);
        }

        public IActionResult SearchBookByTitleForLibrarian(string title)
        {
            List<Books> Books = bookRepository.SearchBookByTitle(title);
            List<DisplayBookForLibrarianViewModel> _Books = mapper.Map<List<DisplayBookForLibrarianViewModel>>(Books);
            return View("DisplayByTitleForLibrarian", _Books);

        }

        public IActionResult EditBook(int id)
        {
            var book = bookRepository.GetBookById(id);
            var BookEdit = mapper.Map<EditBookViewModel>(book);
            return View("EditBook", BookEdit);
        }

        [HttpPost]
        public IActionResult UpdateBook(EditBookViewModel Book)
        {

            if (ModelState.IsValid)
            {
                Books _Book = mapper.Map<Books>(Book);
                bookRepository.UpdateBook(_Book);
                return RedirectToAction("DisplayAllBooksForLibrarian");

            }

            return View("EditBook", Book);

        }
        public IActionResult BuyBook(int id)
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
        public IActionResult ConfirmPurchase(BuyBookViewModel vm)
        {
            var book = bookRepository.GetBookById(vm.BookId);
            if (book == null || vm.QuantityToBuy > book.Buy_quantity)
            {
                ModelState.AddModelError("", "Invalid Quantity");
                return View(vm);
            }
          
           
            
            string nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = 0;
           
                Users user = userRepository.getUserByApplicationUserId(nameIdentifier);
           
                    userId = user.Id;
                
            
            double totalPrice = vm.QuantityToBuy * book.Price;
            book.Buy_quantity -= vm.QuantityToBuy;
            bookRepository.UpdateBook(book);
            salesRepository.AddBook(new Models.Sales
            {
                Book_ID = book.ID,
                Quantity = vm.QuantityToBuy,
                User_ID = userId,
                Date = DateTime.Now,
                 TotalPrice = totalPrice

            });
            return RedirectToAction("PurchaseConfirmation", new {totalPrice});
        }
        public IActionResult PurchaseConfirmation (double totalPrice)
        {
            ViewBag.TotalPrice = totalPrice;
            return View();
        }

         #region Borrowing Books

        public IActionResult ConfirmBorrowing()
        {
            //if book borrow quantity is 0, then the book cannot be borrowed and does not show the borrow button


            //take book data from the book card  and in the DisplayBookDetails view 
            //and pass it to the BorrowBookView
            //make form wuth pre-filled book details
            //borrowbook action will handle the form submission and retrieve the user input 


            // Assuming you have a way to get the list of books and users for the dropdowns
            //it is linked to a button in the DisplayBookDetails view
            //triggered when the user clicks on "Borrow Book"

            return RedirectToAction("DisplayAllBooksForUser");

        }


        public IActionResult BorrowBook(int id) {
            // This action will handle the form submission from the BorrowBookView

            //int bookId = Convert.ToInt32(Request.Form["bookId"]);//getting bookId from form data
            //int userId = Convert.ToInt32(Request.Form["userId"]);//getting userId from form data
            string nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            int userId = 0;

            Users user = userRepository.getUserByApplicationUserId(nameIdentifier);

            userId = user.Id;
            int borrowPrice = 100 ; // Assuming a price of 0 for borrowing, you can set it as needed
            //int borrowPrice = bookRepository.GetBookPriceById(id) ; // Assuming a price of 0 for borrowing, you can set it as needed
            DateTime startDate = DateTime.Now; // Assuming the borrowing starts now[should get that from form ]
            DateTime dueDate = startDate.AddDays(14); // Assuming a 2-week borrowing period
            
            Borrow borrow = new Borrow
            {
                Book_ID = id,
                User_ID = userId,
                StartDate = startDate,
                DueDate = dueDate,
                Price = borrowPrice // Set the price as needed
            };
            Borrow.BorrowBook(borrow);

            //create a reciept or confirmation message
            
            return RedirectToAction("DisplayAllBooksForUser");
        }


        #endregion
    }
}