using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPeak.Models
{
    public class AdminModel : PageModel
    {
        public IActionResult OnPostLogout()
        {
            return RedirectToPage("/Login");
        }
    }
}
