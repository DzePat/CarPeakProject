using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPeak.Models
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public string Username { get; set; } = string.Empty;
        [BindProperty]
        public string Password { get; set; } = string.Empty;

        public IActionResult OnPost()
        {
            if (Username == "admin" && Password == "password")
            {
                return RedirectToPage("/Admin");
            }
            return RedirectToPage("/UserMainMenu");
        }
    }
}
