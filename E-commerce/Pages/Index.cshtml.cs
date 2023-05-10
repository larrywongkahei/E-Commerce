using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class BaseModel : BaseModel
    {
        [BindProperty]
        public string input { get; set; }


        public IActionResult OnPost()
        {
            var param = new Dictionary<string, string>
            {
                {"input", input }
            };
            return RedirectToPage("SearchResult", param);
        }

    }
    public class IndexModel : BaseModel
    {

        public void OnGet()
        {
            Console.WriteLine("this is index page");
        }
    }
}
