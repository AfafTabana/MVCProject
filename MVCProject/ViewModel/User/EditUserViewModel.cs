using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.User
{
    public class EditUserViewModel
    {
        public string Name { get; set; }
        public string National_Number { get; set; }

        public double Balance { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public string? street { get; set; }

    }
}
