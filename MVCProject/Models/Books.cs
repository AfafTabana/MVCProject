using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace MVCProject.Models
{
    public class Books
    {
        public int ID { set; get; }

        public string Title { set; get; }

        public string ImageUrl { set; get; }

        public string Description { set; get; }

        public double Price { set; get; }

        public int Borrow_quantity {get; set; }

        public int Buy_quantity { get; set; }

        [StringLength(50)]
        public string Publisher_Name { get; set; }

        [StringLength(50)]
        public string Author_Name { get; set; }

        public int Borrow_Price { set; get; }

        [ForeignKey("categeory")]
        public int Cat_Id { get; set; }

        public Categeories categeory { set; get; }

       public  List<Borrow> Borrows { get; set; }

       public List<Sales> Sales { get; set; }
    }
}
