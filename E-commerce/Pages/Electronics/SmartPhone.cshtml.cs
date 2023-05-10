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
    public class SmartPhoneModel : BaseModel
    {
        public ProductsAPIService productAPIService;

        public IEnumerable<Product> SmartPhones { get; set; }

        public SmartPhoneModel(ProductsAPIService apiService)
        {
            productAPIService = apiService;
        }

        public async Task OnGet()
        {
            var allData = await productAPIService.GetProductsFromAPI();
            SmartPhones = from each in allData.Product where each.Category == "smartphones" select each;
        }
    }
}
