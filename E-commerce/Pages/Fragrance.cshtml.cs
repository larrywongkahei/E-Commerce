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
    public class FragranceModel : PageModel
    {
        
        public IEnumerable<Product> FragranceFromAPI { get; set; }

        public ProductsAPIService APIService;

        public FragranceModel(ProductsAPIService apiservice)
        {
            APIService = apiservice;
        }
        public async Task OnGet()
        {
            var allData = await APIService.GetProductsFromAPI();
            FragranceFromAPI = from data in allData.Product where data.Category == "fragrances" select data;
        }
    }
}
