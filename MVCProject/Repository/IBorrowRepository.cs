using MVCProject.Models;

namespace MVCProject.Repository
{
    public interface IBorrowRepository
    {
        public List<Borrow> GetAllBorrowsByBookId(int id);
        public List<Borrow> GetAllBorrowsByUserId(int id);
        public Borrow GetBorrowById(int id);
        public List<Borrow> GetAllBorrows();
        public List<Borrow> GetAllBorrowsByStartDate(DateTime startDate);
        public List<Borrow> GetAllBorrowsByDueDate(DateTime startDate);
        public List<Borrow> GetAllOverDueDateBorrows();
        public List<Borrow> GetAllBorrowRequestsByBookIdAndUserId(int bookId, int userId);
        public void BorrowBook(Borrow borrow);

    }
}
