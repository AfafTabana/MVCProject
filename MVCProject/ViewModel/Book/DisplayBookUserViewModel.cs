using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Book
{
    public class DisplayBookUserViewModel
    {

        public int ID { set; get; }
        public string Title { set; get; }

        public double Price { set; get; }

        public string Description { set; get; }

        public string ImageUrl { set; get; } 


        public int Borrow_quantity { get; set; }

        public int Buy_quantity { get; set; }

        public string Categeory_Name { get; set; }

        public string Author_Name { get; set; }

        public int Borrow_Price { set; get; }
        public int AvailableQuantity { get; set; }
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "please enter a valid quantity")]
        public int QuantityToBuy { get; set; }
    }
}
