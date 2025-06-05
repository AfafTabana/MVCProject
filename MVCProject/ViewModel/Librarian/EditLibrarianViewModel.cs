namespace MVCProject.ViewModel.Librarian
{
    public class EditLibrarianViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
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
