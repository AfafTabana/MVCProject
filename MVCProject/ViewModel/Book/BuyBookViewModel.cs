using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Book
{
    public class BuyBookViewModel
    {
        public int BookId { get; set; }
        public string BookTitle { get; set; }
        public double Price { get; set; }
        public int AvailableQuantity { get; set; }
        [Required]
        [Range(1,int.MaxValue,ErrorMessage="please enter a valid quantity")]
        public int QuantityToBuy { get; set; }
    }
}
