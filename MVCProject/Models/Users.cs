using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(14)]
        public string National_Number { get; set; }

        public double Balance { get; set; }

        public string City {  get; set; }

        public string ImageUrl { get; set; }

        public string? street { get; set; }

        public List<Borrow> Borrows { get; set; }

        public List<Sales> Sales { get; set; }
    }
}
