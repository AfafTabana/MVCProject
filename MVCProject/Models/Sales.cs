using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCProject.Models
{
    public class Sales
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public double TotalPrice { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [ForeignKey("Books")]
        public int Book_ID { get; set; }

        public Books Books { get; set; }

        [ForeignKey("user")]
        public int User_ID { get; set; }

        public Users user { get; set; }

    }
}
