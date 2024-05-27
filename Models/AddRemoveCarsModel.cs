using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarPeak.Models
{
    public class AddRemoveCarsModel : PageModel
    {
        [BindProperty]
        public string CarModel { get; set; }
        [BindProperty]
        public string PricePerDay { get; set; }
        [BindProperty]
        public string CarId { get; set; }

        public IActionResult OnPostAddCar()
        {
            // Logik för att lägga till bil
            return Page();
        }

        public IActionResult OnPostRemoveCar()
        {
            // Logik för att ta bort bil
            return Page();
        }
    }
}
