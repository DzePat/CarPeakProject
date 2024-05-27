using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPeak.Models
{
    public class ChangeCostModel : PageModel
    {
        [BindProperty]
        public string BookingId { get; set; }
        [BindProperty]
        public string NewCost { get; set; }

        public IActionResult OnPost()
        {
            // Logik för att ändra kostnad
            return Page();
        }
    }
}
