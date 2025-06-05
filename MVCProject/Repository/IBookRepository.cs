using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IBookRepository
    {

        public IEnumerable<Books> GetAllBooks();

        public Books GetBookById(int id);

        public Books GetBookByTitle(string title);

        public void AddBook(Books book);

        public void UpdateBook(Books book);

        public void DeleteBook(int id);
    }
}
