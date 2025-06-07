namespace MVCProject.ViewModel.Book
{
    public class DisplayBookUserViewModel
    {

        public string Title { set; get; }

        public double Price { set; get; }

        public string Description { set; get; }

        public string ImageUrl { set; get; }


        public int Borrow_quantity { get; set; }

        public int Buy_quantity { get; set; }

        public string Categeory_Name { get; set; }

        public string Author_Name { get; set; }

        public int Borrow_Price { set; get; }
    }
}
