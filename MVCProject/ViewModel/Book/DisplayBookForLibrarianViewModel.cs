namespace MVCProject.ViewModel.Book
{
    public class DisplayBookForLibrarianViewModel
    {
        public int ID { set; get; }
        public string Title { set; get; }

        public double Price { set; get; }

        public int Borrow_quantity { get; set; }

        public int Buy_quantity { get; set; }

        public string Publisher_Name { get; set; }

        public string Categeory_Name { get; set; }

        public string Author_Name { get; set; }

        public int Borrow_Price { set; get; }
    }
}
