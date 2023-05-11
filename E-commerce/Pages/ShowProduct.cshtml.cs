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
    public class ShowProductModel : BaseModel
    {

        public JsonFileService jsonfileservice;

        public ProductsAPIService productapiservice;

        public IEnumerable<Product> ProductsFromAPI { get; set; }

        public IEnumerable<Model.Products> ProductsFromJson { get; set; }

        public string TitleToFilter { get; set; }

        public string TitleValue { get; set; }

        public Dictionary<string, string> data { get; set; }

        public ShowProductModel(JsonFileService fileservice, ProductsAPIService apiservice)
        {
            jsonfileservice = fileservice;
            productapiservice = apiservice;
        }

        public async Task OnGet(string name)
        {
            TitleValue = name;
            var allDataFromAPI = await productapiservice.GetProductsFromAPI();
            ProductsFromAPI = from each in allDataFromAPI.Product where each.Title == TitleValue select each;
            var allDataFromJson = jsonfileservice.GetAll();
            ProductsFromJson = from each in allDataFromJson where each.Title == TitleValue select each;

        }
    }
}
