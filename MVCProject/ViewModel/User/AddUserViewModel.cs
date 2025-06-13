using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.User
{
    public class AddUserViewModel
    {

        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(14, ErrorMessage = "Maximum Number is 14 Digits")]
        public string National_Number { get; set; }

        public string City { get; set; }
        [RegularExpression(@"^.*\.(png|jpg)$")]
        public string ImageUrl { get; set; }

        public string? street { get; set; }
    }
}
