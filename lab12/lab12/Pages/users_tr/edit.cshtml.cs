using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using models_for_l12;
using lab12.Services;
namespace Lab12.Pages.Users;

public class EditUser : PageModel
{
    private lab12.Services.ICollection<users_tr> _db;

    [BindProperty]
    public users_tr? User { get; private set; }

    public EditUser(lab12.Services.ICollection<users_tr> db)
    {
        _db = db;
    }

    public IActionResult OnGet(int? id)
    {
        if (id.HasValue)
        {
            User = _db.Get(id);
        }
        else
        {
            User = new users_tr();
        }

        if (User == null)
        {
            return RedirectToPage("../Error");
        }

        return Page();
    }

    public IActionResult OnPost(users_tr user)
    {
        _db.Edit(user);

        return RedirectToPage("./Index");
    }
}