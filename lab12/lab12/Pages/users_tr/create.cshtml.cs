using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using models_for_l12;

namespace Lab12.Pages.Users;
public class Createusers_tr : PageModel
{
    private lab12.Services.ICollection<users_tr> _db;

    [BindProperty]
    public users_tr users_tr { get; set; }

    public Createusers_tr(lab12.Services.ICollection<users_tr> db)
    {
        _db = db;
    }

    public IActionResult OnGet()
    {
        users_tr = new users_tr();
        if (users_tr == null)
        {
            return RedirectToPage("../Error");
        }

        return Page();
    }

    public IActionResult OnPost(users_tr users_tr)
    {
        _db.Add(users_tr);
        return RedirectToPage("./Index");
    }
}
