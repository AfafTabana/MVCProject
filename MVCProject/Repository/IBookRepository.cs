using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IBookRepository
    {
      
        IEnumerable<Books> GetAllBooks();
        
        Books GetBookById(int id);

        Books GetBookByTitle(string title);

        void AddBook(Books book);
        
        void UpdateBook(Books book);
        
        void DeleteBook(int id);
    }
}
