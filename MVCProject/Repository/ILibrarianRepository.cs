using MVCProject.Models;
using MVCProject.ViewModel.Librarian;

namespace MVCProject.Repository
{
    public interface ILibrarianRepository
    {
       public List<Librarians> GetAllLibrarians();

        public Librarians GetLibrarianById(int id);

        public List<Librarians> SearchLibrarianByName(string name);

        public void AddLibrarian(Librarians librarian);

        public void UpdateLibrarian(Librarians librarian);

        public void DeleteLibrarian(int id);

        public void AddToUserBalance(int userId,int amount);

    }
}
