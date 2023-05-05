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
    public class GroceriesModel : PageModel
    {

        public IEnumerable<Product> GroceriesFromAPI { get; set; }

        public ProductsAPIService APIService { get; set; }

        public GroceriesModel(ProductsAPIService apiservice)
        {
            APIService = apiservice;
        }

        public async Task OnGet()
        {
            var allData = await APIService.GetProductsFromAPI();
            GroceriesFromAPI = from data in allData.Product where data.Category == "groceries" select data;
        }
    }
}
