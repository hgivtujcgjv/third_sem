using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace lab12.Pages;

public class Index : PageModel
{
    public IActionResult OnGet()
    {
        return RedirectToPage("./users_tr/Index");
    }
}