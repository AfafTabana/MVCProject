using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        public string? ImageUrl { get; set; }

        public string? street { get; set; }

        public List<Borrow> Borrows { get; set; }

        public List<Sales> Sales { get; set; }

        [ForeignKey("Applicationuser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser Applicationuser { get; set; }
    }
}
