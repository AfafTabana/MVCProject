using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Librarian
{
    public class AddLibrarianViewModel
    {

        public string Name { get; set; }
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
        public string National_Number { get; set; }
    }
}
