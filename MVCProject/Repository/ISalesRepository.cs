using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface ISalesRepository
    {
        void AddBook(Sales sales);
        public List<Sales> GetAllSales();
    }
}
