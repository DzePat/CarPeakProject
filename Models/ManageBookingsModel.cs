using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPeak.Models
{
    public class ManageBookingsModel : PageModel
    {
        [BindProperty]
        public string BookingId { get; set; }
        [BindProperty]
        public string CarId { get; set; }
        [BindProperty]
        public string StartDate { get; set; }
        [BindProperty]
        public string EndDate { get; set; }

        public IActionResult OnPost()
        {
            // Logik för att ändra bokningar
            return Page();
        }
    }
}
