using models_for_l12;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Lab12.Pages.Users;

public class IndexUser : PageModel
{
    private lab12.Services.ICollection<users_tr> _db;
    public IEnumerable<users_tr> User { get; set; }

    public IndexUser(lab12.Services.ICollection<users_tr> db)
    {
        _db = db;
    }

    public void OnGet()
    {
        User = _db.GetAll();
    }
}