using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Book
{
    public class EditBookViewModel
    {
        public int ID { set; get; }
        [MaxLength(50, ErrorMessage = "Title Max Length is 50")]
        public string Title { set; get; }

        [MaxLength(150, ErrorMessage = "Description Max Length is 150")]

        public string Description { set; get; }

        public string? ImageUrl { set; get; }

        [Required(ErrorMessage = "Please upload a file.")]
        //[RegularExpression(@".*\.(png|jpg|PNG|JPG)$", ErrorMessage = "Image must end with .png or .jpg extension")]


        public IFormFile photo { get; set; }

        [Range(500, 2000, ErrorMessage = "Price Must Be between 500 and 2000")]
        public double Price { set; get; }

        public int Borrow_quantity { get; set; }

        public int Buy_quantity { get; set; }

        [MaxLength(25, ErrorMessage = "PublisherName Max length is 25")]
        public string Publisher_Name { get; set; }

        [MaxLength(25, ErrorMessage = "AuthorName Max length is 25")]

        public string Author_Name { get; set; }
        [Range(100, 1000, ErrorMessage = "Price Must Be between 100 and 1000")]
        public int Borrow_Price { set; get; }

        public int Cat_Id { get; set; }
    }
}
