using InventoryManagementSystemDomain.Entity;
using InventoryManagementSystemInfrastructure.DataContext;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace InventoryManagementSystemApp.Controllers
{
    
    public class RegistrationController : Controller
    {
        private readonly ApplicationDbContext context;

        public RegistrationController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        [HttpPost]
        public IActionResult SignUp(Registration model)
        {
            if (ModelState.IsValid)
            {
                var data = new Registration()
                {
               
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    UserName = model.UserName,
                    Email = model.Email,
                    Phone = model.Phone,
                    Password = model.Password,
                    ConfirmPassword =model.ConfirmPassword
                };
                context.Registrations.Add(data);
                context.SaveChanges();
                TempData["successMessage"] = "You are eligible now";
                return RedirectToAction("Login");
            }
            else
            {

                return View(model);
            }

        }
    }
}
