using System.ComponentModel.DataAnnotations;



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
    }
}
