namespace MVCProject.ViewModel.Book
{
    public class BorrowRecordViewModel
    {
        //public int BorrowId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        public int Price { get; set; }


    }
}
