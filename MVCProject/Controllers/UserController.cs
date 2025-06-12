using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.ViewModel.User;

namespace MVCProject.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> usermanager;

        public UserController(IUserRepository  UserRepository, IMapper mapper,UserManager<ApplicationUser>usermanager)
        {
            userRepository = UserRepository;
            this.mapper = mapper;
            this.usermanager = usermanager;
        }

        public IActionResult GetAllUsers()
        {
            var users = userRepository.GetAllUsers();
            var userViewModels = mapper.Map<List<DisplayUserViewModel>>(users);
            return View("AllUsersView", userViewModels);
        }

        public async Task< IActionResult> DeleteUser(string name)
        {
            var user = userRepository.GetAllUsers().FirstOrDefault(u => u.Name == name);
            var applicationUser = usermanager.Users.FirstOrDefault(u => u.UserName == name);
            if (user != null)
            {
                userRepository.DeleteUser(user.Id);
                if (applicationUser != null)
                {
                    var result =await usermanager.DeleteAsync(applicationUser);
                    if (!result.Succeeded)
                    {
                        ModelState.AddModelError("", "Failed to delete application user.");
                        
                    }
                }

            }
            return RedirectToAction("GetAllUsers");
        }
    }
}
