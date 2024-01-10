using models_for_l12;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab12.Pages.Tariff;

public class IndexTariff : PageModel
{
    private lab12.Services.ICollection<tariffs> _db;
    public IEnumerable<tariffs> tariff { get; set; }

    public IndexTariff(lab12.Services.ICollection<tariffs> db)
    {
        _db = db;
    }

    public void OnGet()
    {
        tariff = _db.GetAll();
    }
}