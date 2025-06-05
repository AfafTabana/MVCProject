using MVCProject.Models;

namespace MVCProject.Repository
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private readonly LibraryContext _context;
        public LibrarianRepository(LibraryContext context)
        {
            _context = context;
        }
        public void AddLibrarian(Librarians librarian)
        {
           _context.Librarians.Add(librarian);
            _context.SaveChanges();
        }

        public void AddToUserBalance(int userId, int amount)
        {
            throw new NotImplementedException();
        }

        public void DeleteLibrarian(int id)
        {
          _context.Librarians.Remove(_context.Librarians.Find(id));
            _context.SaveChanges();
        }

        public List<Librarians> GetAllLibrarians()
        {
         
            return _context.Librarians.ToList();
        }

        public Librarians GetLibrarianById(int id)
        {
            Librarians librarian = _context.Librarians.Find(id);
           
            return librarian;
        }

        public List<Librarians> SearchLibrarianByName(string name)
        {
            List<Librarians> librarians = _context.Librarians
                .Where(l => l.Name.Contains(name))
                .ToList();
            return librarians;
        }

        public void UpdateLibrarian(Librarians librarian)
        {
           _context.Librarians.Update(librarian);
            _context.SaveChanges();
        }
    }
}
