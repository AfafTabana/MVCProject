using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Librarian
{
    public class EditLibrarianViewModel
    {
        public int Id { get; set; }
        [MaxLength(25)]
        public string Name { get; set; }

        [Range(1000 , 5000)]
        public double Salary { get; set; }
        [MaxLength(14, ErrorMessage = "Maximum Number is 14 Digits")]
        public string National_Number { get; set; }
        private DateTime _hireDate;
        public string HireDate
        {
            get
            {
                return _hireDate.ToShortDateString();
            }
            set
            {
                if (DateTime.TryParse(value, out DateTime result))
                {
                    _hireDate = result;
                }
                else
                {
                    _hireDate = default;
                }
            }
        }
    }
}
