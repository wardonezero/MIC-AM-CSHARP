using IdentityMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace IdentityMVC.Controllers;

public class AdminController(UserManager<AppUser> usrMgr) : Controller
{
    private UserManager<AppUser> userManager = usrMgr;

    public IActionResult Index() => View(userManager.Users);

    public ViewResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(CreateModel model)
    {
        if (ModelState.IsValid)
        {
            AppUser user = new()
            {
                UserName = model.Name,
                Email = model.Email
            };
            IdentityResult result = await userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
                return RedirectToAction("Index");
            else
            {
                foreach (IdentityError error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
        }
        return View(model);
    }
}
