using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace MVCProject.Models
{
    public class Librarians
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate{ get; set; }

        [StringLength(14)]
        public string National_Number { get; set; }
        public List<Borrow> Borrows { get; set; }
        [ForeignKey("Applicationuser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser Applicationuser { get; set; }
    }
}
