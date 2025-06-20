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
            IUserRepository userRepository,
            ICategoriesRepository catRepository
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
            
            AddBookViewModel Bookfromreq = new AddBookViewModel()
            {
                Cat_list = catRepository.GetAllCategories()
            };
            return View("AddBook" , Bookfromreq);
        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddBook(AddBookViewModel Book, IFormFile photo)
        {

            if (photo != null && photo.Length > 0)
            {

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");


                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string filePath = Path.Combine(imagesFolder, fileName);
                Console.WriteLine("Saving to: " + filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                 Book.ImageUrl = "/images/" + fileName;

            }

            if (ModelState.IsValid==true)
            {
                Books _Book = mapper.Map<Books>(Book);
                bookRepository.AddBook(_Book);
                return RedirectToAction("DisplayAllBooksForLibrarian");

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
        //public IActionResult DisplayAllBooksForLibrarian()
        //{
        //    List<Books> AllBooks = bookRepository.GetAllBooks().ToList();
        //    List<DisplayBookForLibrarianViewModel> Books = mapper.Map<List<DisplayBookForLibrarianViewModel>>(AllBooks);
        //    return View("DisplayAllBooksForLibrarian", Books);
        //}

        public IActionResult SearchBookByTitleForLibrarian(string title)
        {
            List<Books> Books = bookRepository.SearchBookByTitle(title).ToList();
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
        public async Task<IActionResult> UpdateBook(EditBookViewModel Book, IFormFile photo)
        {
            if (photo != null && photo.Length > 0)
            {

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(photo.FileName);
                string imagesFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");


                if (!Directory.Exists(imagesFolder))
                    Directory.CreateDirectory(imagesFolder);

                string filePath = Path.Combine(imagesFolder, fileName);
                Console.WriteLine("Saving to: " + filePath);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await photo.CopyToAsync(stream);
                }

                Book.ImageUrl = "/images/" + fileName;
            }

            if (ModelState.IsValid == true)
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
                TempData["Error"] = "Invalid quantity. Please check available stock.";
                return RedirectToAction("BuyBook", new { id = vm.BookId });
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

        


        public IActionResult BorrowBookView(int id)
        {
            // This action will display the form for borrowing a book
            // It will pre-fill the book details based on the book ID
            Books book = bookRepository.GetBookById(id);
            if (book == null || book.Borrow_quantity == 0) return NotFound();
            string nameIdentifier = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Users user = userRepository.getUserByApplicationUserId(nameIdentifier);
            if (user == null) return Unauthorized(); // Ensure the user is logged in

            BorrowBookViewModel borrowModel = new BorrowBookViewModel
            {
                BookId = book.ID,
                BookTitle = book.Title,
                BookAuthor = book.Author_Name,
                BorrowDate = DateTime.Now,
                DueDate = DateTime.Now,
                Price = book.Borrow_Price,
                UserId = user.Id // Assuming you want to get the user ID from the logged-in user
                               
                //get from identity
            };
            return View("BorrowBookview", borrowModel);
        }


        public IActionResult BorrowBook(BorrowBookViewModel borrow) {
            // This action will handle the form submission from the BorrowBookView


            
            Borrow myborrow = new Borrow
            {
                Book_ID = borrow.BookId,
                User_ID = borrow.UserId,
                StartDate = borrow.BorrowDate,
                DueDate = borrow.DueDate,
                Price = borrow.Price // Set the price as needed
            };
            Borrow.BorrowBook(myborrow);

            
            return RedirectToAction("DisplayAllBooksForUser");
        }


        #endregion
    }
}