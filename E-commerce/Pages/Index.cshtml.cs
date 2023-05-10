using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string input { get; set; }


        public void OnPost()
        {
            Console.WriteLine(input);
        }

        public void OnGet()
        {
            Console.WriteLine("This is index page");
        }
    }
}
