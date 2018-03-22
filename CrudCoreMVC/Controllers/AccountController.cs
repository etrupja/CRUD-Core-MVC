using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CrudCoreMVC.ViewModels;
using CrudCoreMVC.Models;
using Microsoft.AspNetCore.Identity;

namespace CrudCoreMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> LoggedIn(LoginViewModel loginVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("Login");
            }

            var result = await _signInManager.PasswordSignInAsync(loginVM.Email, loginVM.Password,loginVM.RememberMe,false);
            if (result.Succeeded)
            {
                return RedirectToAction("All", "School");
            }
            else
                return View("Login");
        }
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Registered(RegisterViewModel registerVM)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Something went wrong");
                return View("Register");
            }

            var user = new ApplicationUser() { UserName = registerVM.Email, Email = registerVM.Email };
            var result = await _userManager.CreateAsync(user, registerVM.Password);

            if (result.Succeeded)
            {
                return RedirectToAction("All", "School");
            }

            return View("Register");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("All", "School");
        }
    }
}