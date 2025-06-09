using MVCProject.Models;

namespace MVCProject.Repository
{
    public class BorrowRepository : IBorrowRepository
    {
        public BorrowRepository(LibraryContext context)
        {
            Context = context;
        }

        public LibraryContext Context { get; }

        public void BorrowBook(Borrow borrow)
        {
            if (borrow == null)
            {
                throw new ArgumentNullException(nameof(borrow), "Borrow cannot be null");
            }
            Context.Books.FirstOrDefault(b => b.ID == borrow.Book_ID).Borrow_quantity--;
            Context.Borrows.Add(borrow);
            Context.SaveChanges();

        }

        public List<Borrow> GetAllBorrowRequestsByBookIdAndUserId(int bookId, int userId)
        {
            var borrows = Context.Borrows.Where(b=>b.Book_ID == bookId && b.User_ID == userId).ToList();
            if (borrows == null)
            {
                throw new InvalidOperationException("No borrow requests found for the specified book and user.");
            }
            return borrows;
        }

        public List<Borrow> GetAllBorrows()
        {
            var borrows = Context.Borrows.ToList();
            if (borrows == null || !borrows.Any())
            {
                throw new InvalidOperationException("No borrows found in the database.");
            }
            return borrows;

        }

        public List<Borrow> GetAllBorrowsByBookId(int id)
        {
            var borrows = Context.Borrows.Where(b => b.Book_ID == id).ToList();
            if (borrows == null || !borrows.Any())
            {
                throw new InvalidOperationException($"No borrows found for book with ID {id}.");
            }
            return borrows;
        }

        public List<Borrow> GetAllBorrowsByDueDate(DateTime startDate)
        {
            var borrows = Context.Borrows.Where(b=> b.DueDate.Date == startDate.Date).ToList();
            if (borrows == null || !borrows.Any())
            {
                throw new InvalidOperationException($"No borrows found with due date {startDate.Date}.");
            }   
            return borrows;
        }

        public List<Borrow> GetAllBorrowsByStartDate(DateTime startDate)
        {
            var borrows = Context.Borrows.Where(b => b.StartDate.Date == startDate.Date).ToList();
            if (borrows == null || !borrows.Any())
            {
                throw new InvalidOperationException($"No borrows found with start date {startDate.Date}.");
            }
            return borrows;
        }

        public List<Borrow> GetAllBorrowsByUserId(int id)
        {
            var borrows = Context.Borrows.Where(b => b.User_ID == id).ToList();
            if (borrows == null || !borrows.Any())
            {
                throw new InvalidOperationException($"No borrows found for user with ID {id}.");
            }
            return borrows;
        }

        public List<Borrow> GetAllOverDueDateBorrows()
        {
            var borrows = Context.Borrows.Where(b=>b.DueDate < DateTime.Now).ToList();
            if (borrows == null || !borrows.Any())
            {
                throw new InvalidOperationException("No overdue borrows found in the database.");
            }
            return borrows;
        }

        public Borrow GetBorrowById(int id)
        {
            var borrow = Context.Borrows.FirstOrDefault(b => b.Id == id);
            if (borrow == null)
            {
                throw new InvalidOperationException($"No borrow found with ID {id}.");
            }
            return borrow;
        }
    }
}
