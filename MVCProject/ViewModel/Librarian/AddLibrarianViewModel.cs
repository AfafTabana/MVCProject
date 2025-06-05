using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Librarian
{
    public class AddLibrarianViewModel
    {

        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime HireDate { get; set; }
        public string National_Number { get; set; }
    }
}
