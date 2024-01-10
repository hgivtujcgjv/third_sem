using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using models_for_l12;

namespace Lab12.Pages.subscriber;

public class CreateModel : PageModel
{
    private lab12.Services.ICollection<subscribers> _db;

    [BindProperty]
    public subscribers? sub { get; private set; }
    public IEnumerable<tariffs> tariff { get; set; }
    public IEnumerable<users_tr> User { get; set; }

    public CreateModel(lab12.Services.ICollection<subscribers> db_sub,
        lab12.Services.ICollection<tariffs> db_tariff,
        lab12.Services.ICollection<users_tr> db_user)
    {
        _db = db_sub;
        tariff = db_tariff.GetAll();
        User = db_user.GetAll();
    }

    public IActionResult OnGet()
    {
        sub = new subscribers();
        if (sub == null)
        {
            return RedirectToPage("../Error");
        }
        return Page();
    }

    public IActionResult OnPost(subscribers t)
    {
        t.name = User.FirstOrDefault(a => a.Id == t.Id).name;
        t.name_of_tarif = tariff.FirstOrDefault(p => p.Id == t.Id).name_of_tarif;
        _db.Add(t);
        return RedirectToPage("./Index");
    }
}