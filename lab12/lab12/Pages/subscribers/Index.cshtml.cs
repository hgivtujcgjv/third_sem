using models_for_l12;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab12.Pages.subscriber;

public class SubModel : PageModel
{
    private lab12.Services.ICollection<subscribers> _db;

    public IEnumerable<subscribers>? sub { get; set; }

    public SubModel(lab12.Services.ICollection<subscribers> db)
    {
        _db = db;
    }

    public void OnGet()
    {
        sub = _db.GetAll();
    }
}

