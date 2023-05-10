using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DataAPI;
using E_commerce.Model;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class ElectronicsModel : BaseModel
    {

        public JsonFileService productService;

        public ProductsAPIService productAPIService;

        public IEnumerable<Product> SmartPhones { get; set; }

        public IEnumerable<Product> LapTops { get; set; }

        public IEnumerable<Model.Products> EletronicsFromJson { get; private set; }

        public IEnumerable<Product> productsFromAPI { get; private set; }

        public ElectronicsModel(JsonFileService fileService, ProductsAPIService apiService)
        {
            productService = fileService;
            productAPIService = apiService;

        }
        public async Task OnGet()
        {
            EletronicsFromJson = productService.GetElectronics();
            var allData = await productAPIService.GetProductsFromAPI();
            SmartPhones = from each in allData.Product where each.Category == "smartphones" select each;
            LapTops = from each in allData.Product where each.Category == "laptops" select each;
        }
    }
}
