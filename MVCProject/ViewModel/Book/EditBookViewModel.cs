using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Book
{
    public class EditBookViewModel
    {
        public int ID { set; get; }
        [MaxLength(50)]
        public string Title { set; get; }

        [MaxLength (150)]

        public string Description { set; get; }

        [RegularExpression(@"^.*\.(png|jpg)$")]

        public string ImageUrl { set; get; }

        [Range(500, 2000)]
        public double Price { set; get; }

        public int Borrow_quantity { get; set; }

        public int Buy_quantity { get; set; }

        [MaxLength(25)]
        public string Publisher_Name { get; set; }

        [MaxLength(25)]

        public string Author_Name { get; set; }
        [Range(100, 1000)]
        public int Borrow_Price { set; get; }

        public int Cat_Id { get; set; }
    }
}
