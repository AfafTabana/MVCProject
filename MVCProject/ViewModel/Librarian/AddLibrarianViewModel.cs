using MVCProject.Custom_Validation;
using System.ComponentModel.DataAnnotations;
using MVCProject.Custom_Validation;

namespace MVCProject.ViewModel.Librarian
{
    public class AddLibrarianViewModel
    {

        [MaxLength(25 , ErrorMessage ="Name Max Length is 25")]
        public string Name { get; set; }
        [Range(1000, 5000 , ErrorMessage ="Salary Must be between 1000 and 5000")]
        public double Salary { get; set; }
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
        [MaxLength(14,ErrorMessage ="Maximum Number is 14 Digits")]
        [Unique]
        public string National_Number { get; set; }
    }
}
