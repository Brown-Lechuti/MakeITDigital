using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MakeITDigital.Models;
using System.Text;
using System.Security.Cryptography;

namespace MakeITDigital.Pages.Usars
{
    public class CreateModel : PageModel
    {
        private readonly MakeITDigital.Models.MarketMedia _context;

        public CreateModel(MakeITDigital.Models.MarketMedia context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public User User { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            //String user_input = Request.Form["User.Passwordhash"];//
            //User.PasswordHash = GetHashedText(user_input);//
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Users.Add(User);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        //private byte[] GetHashedText(string input_pasword)//
        //{
        //    byte[] tmpSource;
        //    byte[] tmpData;
        //    tmpSource = ASCIIEncoding.ASCII.GetBytes(input_pasword);
        //    tmpData = new MD5CryptoServiceProvider().ComputeHash(tmpSource);
        //    return tmpData;
        //}
    }
}
