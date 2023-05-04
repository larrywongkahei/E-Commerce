using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DataAPI;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace E_commerce.Pages
{
    public class BestSellerModel : PageModel
    {
        public IEnumerable<Product> products { get; private set; }

        private readonly ILogger<BestSellerModel> _logger;
        public ProductsAPIService apiService;
        public string greeting;

        public BestSellerModel(ProductsAPIService ApiService, ILogger<BestSellerModel> logger)
        {
            _logger = logger;
            apiService = ApiService;
    }

        

        //private async Task ConvertData()
        //{
        //    var task = apiService.GetProductsFromAPI();
        //    Console.WriteLine("Ready");
        //    products = await task;
        //    Console.WriteLine("Done");

        //}


        public async Task OnGet()
        {
            greeting = "hi";
            var data = await apiService.GetProductsFromAPI();
            products = data.Product;
            Console.WriteLine(products.Count());
        }
    }
}
