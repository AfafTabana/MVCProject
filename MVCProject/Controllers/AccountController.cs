using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.Repository;
using MVCProject.ViewModel.Auth;
using System.Security.Claims;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signmanager;
        private readonly ILibrarianRepository librarianRepository;
        private readonly IUserRepository userRepository;

        public AccountController(UserManager<ApplicationUser> usermanager,
            SignInManager<ApplicationUser>signmanager,
            ILibrarianRepository librarianRepository,
            IUserRepository userRepository
            ) {
            this.usermanager = usermanager;
            this.signmanager = signmanager;
            this.librarianRepository = librarianRepository;
            this.userRepository = userRepository;
        }
        //register
        public IActionResult Register()
        {
            return View("RegisterView");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Register(RegisterViewModel rgModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser()
                {
                    UserName = rgModel.UserName,
                    Email = rgModel.Email,
                    PasswordHash = rgModel.Password
                };
                var result =await usermanager.CreateAsync(user, rgModel.Password);

                if (result.Succeeded) {
                    //add role user or librarian
                    if (rgModel.IsLibrarian)
                    {
                        await usermanager.AddToRoleAsync(user, "Librarian");
                        // add to librarians table
                        
                        Librarians librarian = new Librarians()
                        {
                            Name = rgModel.UserName,
                            ApplicationUserId = user.Id,
                            Salary = 0, 
                            HireDate = DateTime.Now, 
                            National_Number = "00000000000000" 
                        };
                        librarianRepository.AddLibrarian(librarian);
                    }
                    else
                    {
                        await usermanager.AddToRoleAsync(user, "User");
                        // add to users table
                        Users newUser = new Users()
                        {
                            Name = rgModel.UserName,
                             Balance = 5000, 
                            ApplicationUserId = user.Id,
                            National_Number = "00000000000000", 
                            City = "cairo",
                            street = "street 1",
                        };
                        userRepository.AddUser(newUser);
                    }


                    //make cookie
                    await signmanager.SignInAsync(user, isPersistent: false);
                    // place to go for 
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }

            return View("RegisterView",rgModel);
        }
        //login
        public IActionResult Login()
        {
            
            return View("LoginView");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lgModel)
        {
            if (ModelState.IsValid)
            {
                var result = await signmanager.PasswordSignInAsync(lgModel.UserName, lgModel.Password, lgModel.RememberMe, lockoutOnFailure: false);
                 
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Name or Password");
                }
            }
            return View("LoginView", lgModel);
        }
        //logout
        public async Task<IActionResult> Logout()
        {
            await signmanager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
