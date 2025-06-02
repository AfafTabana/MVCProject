using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;


namespace MVCProject.Models
{
    public class Borrow
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }

        public double Price { get; set; }

        [ForeignKey("book")]
        public int Book_ID { get; set; }

        public Books book {  get; set; }

        [ForeignKey("user")]
        public int User_ID { get; set; }

        public Users user { get; set; }

        [ForeignKey("librarian")]
        public int librarian_ID { get; set; }

        public Librarians librarian { get; set; }





    }
}
