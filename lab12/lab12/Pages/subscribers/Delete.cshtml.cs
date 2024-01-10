using models_for_l12;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab12.Pages.subscriber;

public class DeleteModel : PageModel
{
    private lab12.Services.ICollection<subscribers> _db;

    public DeleteModel(lab12.Services.ICollection<subscribers> db)
    {
        _db = db;
    }

    [BindProperty]
    public subscribers? sub { get; set; }

    public IActionResult OnGet(int id)
    {
        sub = _db.Get(id);
        if (sub == null)
        {
            return RedirectToPage("../Error");
        }

        return Page();
    }

    public IActionResult OnPost()
    {
        _db.Delete(sub.Id);
        return RedirectToPage("./Index");
    }
}