using models_for_l12;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace Lab12.Pages.Tariff;

public class CreateTariff : PageModel
{
    private lab12.Services.ICollection<tariffs> _db;

    [BindProperty]
    public tariffs tariff { get; set; }

    public CreateTariff(lab12.Services.ICollection<tariffs> db)
    {
        _db = db;
    }

    public IActionResult OnGet()
    {
        tariff = new tariffs();
        if (tariff == null)
        {
            return RedirectToPage("../Error");
        }

        return Page();
    }

    public IActionResult OnPost(tariffs tariff)
    {
        _db.Add(tariff);
        return RedirectToPage("./Index");
    }
}