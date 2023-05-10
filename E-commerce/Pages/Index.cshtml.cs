using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class BaseModel : PageModel
    {
        [BindProperty]
        public string input { get; set; }


        public IActionResult OnPost()
        {
            var param = new Dictionary<string, string>
            {
                {"input", input }
            };
            if (Request.Path == "/SearchResult")
            {;
                Console.WriteLine("Redirect to index");
                return RedirectToPage("/SearchResult", param);
            }
            else
            {
                Console.WriteLine("Redirect to SearchResult page with param");
                return RedirectToPage("/SearchResult", param);
            }
        }

    }
    public class IndexModel : BaseModel
    {

        public void OnGet()
        {
            Console.WriteLine(Request.Path);

            Console.WriteLine("this is index page");
        }
    }
}
