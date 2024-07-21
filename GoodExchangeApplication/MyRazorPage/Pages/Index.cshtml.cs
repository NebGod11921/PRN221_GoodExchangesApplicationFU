using BusinessObjects;
using DataAccessObjects.IServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace MyRazorPage.Pages
{
    public class IndexModel : PageModel
    {
        

        public IndexModel()
        {
           

        }


        public IActionResult OnPostLogout()
        {
            var getSession = HttpContext.Session.GetString("GetUser");
            if (getSession != null)
            {
                HttpContext.Session.Clear();
                return RedirectToPage("/Account/Login");
            } else
            {
                return Page();
            }



         
        }
    }
}
