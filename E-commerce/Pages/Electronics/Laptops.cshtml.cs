using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DataAPI;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class LaptopsModel : PageModel
    {
        public ProductsAPIService productAPIService;

        public IEnumerable<Product> Laptops { get; set; }

        public LaptopsModel(ProductsAPIService apiService)
        {
            productAPIService = apiService;
        }

        public async Task OnGet()
        {
            var allData = await productAPIService.GetProductsFromAPI();
            Laptops = from each in allData.Product where each.Category == "laptops" select each;
        }
    }
}