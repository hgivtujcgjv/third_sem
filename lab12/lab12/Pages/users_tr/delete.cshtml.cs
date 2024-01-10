using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using models_for_l12;
using lab12.Services;
namespace Lab12.Pages.Users;

public class Delete_users_tr : PageModel
{
    private lab12.Services.ICollection<users_tr> _db;

    public Delete_users_tr(lab12.Services.ICollection<users_tr> db)
    {
        _db = db;
    }

    [BindProperty]
    public users_tr? User { get; set; }

    public IActionResult OnGet(int id)
    {
        User = _db.Get(id);
        if (User == null)
        {
            return RedirectToPage("../Error");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        _db.Delete(User.Id);
        return RedirectToPage("./Index");
    }
}