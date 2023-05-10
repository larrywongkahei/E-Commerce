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
    public class SearchResultModel : PageModel
    {
        public JsonFileService jsonfileservice;

        public ProductsAPIService productapiservice;

        public IEnumerable<Product> ProductsFromAPI { get; set; }

        public IEnumerable<Model.Products> ProductsFromJson { get; set; }

        public string SearchValue { get; set; }

        public Dictionary<string, string> data { get; set; }

        public SearchResultModel(JsonFileService fileservice, ProductsAPIService apiservice)
        {
            jsonfileservice = fileservice;
            productapiservice = apiservice;
        }

        //public async Task OnGet(Dictionary<string, string> param)
        //{
        //    data = param;
        //    SearchValue = data.First().Value;
        //    var allDataFromAPI = await productapiservice.GetProductsFromAPI();
        //    ProductsFromAPI = from each in allDataFromAPI.Product where each.Title.Contains(SearchValue) select each;
        //    var allDataFromJson = jsonfileservice.GetAll();
        //    ProductsFromJson = from each in allDataFromJson where each.Title.Contains(SearchValue) select each;

        //}
        public void OnGet(Dictionary<string, string> param)
        {
            Console.WriteLine(param.Count());
        }
    }
}
