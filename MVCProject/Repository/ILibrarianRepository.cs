using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface ILibrarianRepository
    {
       public IEnumerable<Librarians> GetAllLibrarians();

        public Librarians GetLibrarianById(int id);

        public Librarians GetLibrarianByName(string name);

        public void AddLibrarian(Librarians librarian);

        public void UpdateLibrarian(Librarians librarian);

        public void DeleteLibrarian(int id);

        public void AddToUserBalance(int userId,int amount);

    }
}
