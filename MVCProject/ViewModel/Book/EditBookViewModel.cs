namespace MVCProject.ViewModel.Book
{
    public class EditBookViewModel
    {
        public string Title { set; get; }

        public double Price { set; get; }

        public int Borrow_quantity { get; set; }

        public int Buy_quantity { get; set; }

        public string Publisher_Name { get; set; }

        public string Author_Name { get; set; }

        public int Borrow_Price { set; get; }

        public int Cat_Id { get; set; }
    }
}
