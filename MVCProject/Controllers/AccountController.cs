using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVCProject.Models;
using MVCProject.ViewModel.Auth;

namespace MVCProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> usermanager;
        private readonly SignInManager<ApplicationUser> signmanager;

        public AccountController(UserManager<ApplicationUser> usermanager,SignInManager<ApplicationUser>signmanager) {
            this.usermanager = usermanager;
            this.signmanager = signmanager;
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
                    //make cookie
                    await signmanager.SignInAsync(user, isPersistent: false);
                    // place to go for 
                    return RedirectToAction("DisplayAllBooksForUser", "Book");
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
                    return RedirectToAction("DisplayAllBooksForUser", "Book");
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
