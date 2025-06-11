using System.ComponentModel.DataAnnotations;

namespace MVCProject.ViewModel.Auth
{
    public class RoleViewModel
    {
        [Required]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }
}
