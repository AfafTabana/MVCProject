using MVCProject.Models;

namespace MVCProject.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        

        public BookRepository(LibraryContext context)
        {
            _context = context;
        }

        public void AddBook(Books book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Books> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Books GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public List<Books> SearchBookByTitle(string title)
        {
            return _context.Books
                .Where(b => b.Title.Contains(title)).ToList();
        }

        public void UpdateBook(Books book)
        {
            var existing = _context.Books.FirstOrDefault(e=>e.ID == book.ID);
            if (existing != null)
            {

                existing.Title = book.Title;
                existing.Price = book.Price;
                existing.Description = book.Description;
                existing.ImageUrl = book.ImageUrl;
                existing.Borrow_quantity = book.Borrow_quantity;
                existing.Buy_quantity = book.Buy_quantity;
                existing.Publisher_Name = book.Publisher_Name;
                existing.Author_Name = book.Author_Name;
                existing.Borrow_Price = book.Borrow_Price;
                existing.Cat_Id = book.Cat_Id;

              
            }

            _context.SaveChanges();
        }

    }
}
