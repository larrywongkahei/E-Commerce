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
    public class BestSellerModel : BaseModel
    {
        public IEnumerable<Product> products { get; private set; }

        public IEnumerable<Product> SmartPhones { get; set; }

        public IEnumerable<Product> LapTops { get; set; }

        public IEnumerable<Product> Fragrances { get; set; }

        public IEnumerable<Product> Skincare { get; set; }

        public IEnumerable<Product> Groceries { get; set; }

        public IEnumerable<Product> HomeDecoration { get; set; }

        private readonly ILogger<BestSellerModel> _logger;
        public ProductsAPIService apiService;

        public BestSellerModel(ProductsAPIService ApiService, ILogger<BestSellerModel> logger)
        {
            _logger = logger;
            apiService = ApiService;
    }

        public async Task OnGet()
        {
            var data = await apiService.GetProductsFromAPI();
            products = data.Product;
            SmartPhones = from each in products where each.Category == "smartphones" select each;
            LapTops = from each in products where each.Category == "laptops" select each;
            Fragrances = from each in products where each.Category == "fragrances" select each;
            Skincare = from each in products where each.Category == "skincare" select each;
            Groceries = from each in products where each.Category == "groceries" select each;
            HomeDecoration = from each in products where each.Category == "home-decoration" select each;
        }
    }
}
