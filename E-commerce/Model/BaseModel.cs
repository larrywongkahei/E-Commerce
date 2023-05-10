using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Model
{
    public class BaseModel : PageModel
    {
        [BindProperty]
        public string  input { get; set; }


        public void OnPost()
        {
            Console.WriteLine(input);
        }

    }
}
