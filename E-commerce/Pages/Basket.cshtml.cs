using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DataAPI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class AllProductClass
    {
        public Product productfromapi { get; set; }

        public Model.Products productfromjson { get; set; }
    }

    public class BasketModel : BaseModel
    {
        public void OnGet()
        {
            var ListToLoop = from each in HttpContext.Session.Keys where each.StartsWith("Product") select each;
            foreach (var each in HttpContext.Session.Keys)
            {
                
                var newclass = new AllProductClass();
                
            }
        }
    }
}
