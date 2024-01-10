using models_for_l12;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab12.Pages.Tariff;

public class EditTariff : PageModel
{
    private lab12.Services.ICollection<tariffs> _db;

    [BindProperty]
    public tariffs? tariff { get; private set; }

    public EditTariff(lab12.Services.ICollection<tariffs> db)
    {
        _db = db;
    }

    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            tariff = _db.Get(id);
        }
        else
        {
            tariff = new tariffs();
        }

        if (tariff == null)
        {
            return RedirectToPage("../Error");
        }

        return Page();
    }

    public IActionResult OnPost(tariffs tariff)
    {
        _db.Edit(tariff);

        return RedirectToPage("./Index");
    }
}