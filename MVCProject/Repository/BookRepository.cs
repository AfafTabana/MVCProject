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

        public Books GetBookByTitle(string title)
        {
            return _context.Books
                .FirstOrDefault(b => b.Title.Contains(title));
        }

        public void UpdateBook(Books book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
