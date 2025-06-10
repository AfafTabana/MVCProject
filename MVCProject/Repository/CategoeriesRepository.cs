using MVCProject.Models;

namespace MVCProject.Repository
{
    public class CategoeriesRepository : ICategoriesRepository
    {
        private readonly LibraryContext _context;
        public CategoeriesRepository(LibraryContext context)
        {
            this._context = context;
        }
        public List<Categeories> GetAllCategories()
        {
            return _context.Categeories.ToList();
        }
    }
}
