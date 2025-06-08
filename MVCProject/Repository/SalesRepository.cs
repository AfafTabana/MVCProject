using MVCProject.Models;

namespace MVCProject.Repository
{
    public class SalesRepository:ISalesRepository
    {
        private LibraryContext _context;
        public SalesRepository(LibraryContext context)
        {
            _context = context;
        }
        public void AddBook(Sales sales)
        {
            _context.Sales.Add(sales);
            _context.SaveChanges();
        }
        public List<Sales> GetAllSales() => _context.Sales.ToList();
    }
}
