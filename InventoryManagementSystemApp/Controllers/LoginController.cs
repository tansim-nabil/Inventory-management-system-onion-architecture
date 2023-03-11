using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.IService;
using InventoryManagementSystemInfrastructure.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using InventoryManagementSystemInfrastructure.DataContext;

namespace InventoryManagementSystemApp.Controllers
{
    public class LoginController : Controller
    {
       
        private readonly ILoginService _loginService;

        private readonly ApplicationDbContext context;

        public LoginController(ILoginService loginService, ApplicationDbContext context)
        {
            _loginService = loginService;
            this.context= context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(Login model) 
        {
            if (ModelState.IsValid)
            {
                var data = context.LoginUsers.Where(e => e.Name == model.Name).SingleOrDefault();
                if (data != null)
                {
                    bool IsValid = (data.Name == model.Name && data.Password == model.Password);
                    if (IsValid)
                    {
                        var identity = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, model.Name) },
                            CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);
                        HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                        HttpContext.Session.SetString("Username", model.Name);
                        return RedirectToAction("Index", "AppUser");
                    }
                    else
                    {
                        TempData["errorPassword"] = "Incorrect Password";
                        return View(model);
                    }
                }
                else
                {
                    TempData["errorUsername"] = "Username not found";
                    return View(model);
                }
            }
            else
            {
                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            var storedCookies = Request.Cookies.Keys;
            foreach (var cookies in storedCookies)
            {
                Response.Cookies.Delete(cookies);
            }
            return RedirectToAction("Login", "Login");
        }
    }
}
