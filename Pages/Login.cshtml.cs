using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MakeITDigital.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MakeITDigital.Pages
{

    public class LoginModel : PageModel
    {
        [BindProperty]
        public Login Model { get; set; }
        public SignInManager<IdentityUser> SignInManager { get; }

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            SignInManager = signInManager;
        }

        public void OnGet()
        {
        }
        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var IdentityResult = await SignInManager.PasswordSignInAsync(Model.Email, Model.Password, Model.RememberMe, false);
                if(IdentityResult.Succeeded)
                {
                    if(returnUrl == null || returnUrl=="/")
                    {
                        return RedirectToPage("Index");
                    }
                    else
                    {
                        return RedirectToPage(returnUrl);
                    }
                }
                ModelState.AddModelError("", "Username or Password incorrect");
            }
            return Page();
        }
    }
}
