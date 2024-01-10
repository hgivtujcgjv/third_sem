using models_for_l12;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab12.Pages.Tariff;

public class DeleteTariff : PageModel
{
    private lab12.Services.ICollection<tariffs> _db;

    public DeleteTariff(lab12.Services.ICollection<tariffs> db)
    {
        _db = db;
    }

    [BindProperty]
    public tariffs? tariff { get; set; }

    public IActionResult OnGet(int id)
    {
        tariff = _db.Get(id);
        if (tariff == null)
        {
            return RedirectToPage("../Error");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        _db.Delete(tariff.Id);
        return RedirectToPage("./Index");
    }
}