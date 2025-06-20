namespace MVCProject.ViewModel.Book
{
    public class BorrowBookViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public string BookAuthor { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime DueDate { get; set; }

        public int UserId { get; set; }
        public int Price { get; set; }
    }
}
