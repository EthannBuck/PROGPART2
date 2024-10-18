using Microsoft.AspNetCore.Mvc;
using PROGPART1.Models;
using System.Collections.Generic;

namespace PROGPART1.Controllers
{
    public class AccountController : Controller
    {
        private static List<User> users = new List<User>();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                if (AuthenticateUser(user))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.ErrorMessage = "Invalid email or password.";
                }
            }
            return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                users.Add(user);
                TempData["SuccessMessage"] = "Registration successful! Please log in.";
                return RedirectToAction("Login");
            }
            return View(user);
        }

        private bool AuthenticateUser(User user)
        {
            return users.Exists(u => u.Email == user.Email && u.PasswordHash == user.PasswordHash);
        }
    }
}
