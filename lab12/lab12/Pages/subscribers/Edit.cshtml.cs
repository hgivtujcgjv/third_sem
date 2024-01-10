using models_for_l12;
using Lab12.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using lab12.Services;

namespace Lab12.Pages.subscriber;

public class EditModel : PageModel
{
    private mobile_operator_Context _db;

    [BindProperty]
    public subscribers? sub { get; private set; }
    public IEnumerable<users_tr> User { get; set; }
    public IEnumerable<tariffs> tariff { get; set; }

    public EditModel(mobile_operator_Context db)
    {
        _db = db;
        User = _db.users;
        tariff = _db.tariffs;
    }

    public IActionResult OnGet(int? id)
    {
        var sb = _db.subs.Find(id);

        if (sb != null)
        {
            subscribers? sbx = new subscribers()
            {
                Id = sb.Id,
                name = sb.name,
                name_of_tarif = sb.name_of_tarif,
                email = sb.email,
                discount = sb.discount
            };
            return Page();
        }
        else
        {
            return RedirectToPage("../Error");
        }

    }

    public IActionResult OnPost()
    {

        if (sub != null)
        {
            var existingsub = _db.subs.Find(sub.Id);
            if (existingsub != null)
            {
                existingsub.Id = sub.Id;
                existingsub.name = sub.name;
                existingsub.email = sub.email;
                existingsub.name_of_tarif = _db.tariffs.FirstOrDefault(a => a.Id == existingsub.Id).name_of_tarif;
                existingsub.discount = sub.discount;
                _db.SaveChanges();
            }
        }
        return RedirectToPage("./Index");
    }
}