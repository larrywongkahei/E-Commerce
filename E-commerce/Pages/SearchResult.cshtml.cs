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
    public class SearchResultModel : BaseModel
    {
        public JsonFileService jsonfileservice;

        public ProductsAPIService productapiservice;

        public IEnumerable<Product> ProductsFromAPI { get; set; }

        public IEnumerable<Model.Products> ProductsFromJson { get; set; }

        public string SearchValue { get; set; }

        public Dictionary<string, string> data { get; set; }

        public int PageNumber { get; set; }

        public SearchResultModel(JsonFileService fileservice, ProductsAPIService apiservice)
        {
            jsonfileservice = fileservice;
            productapiservice = apiservice;
        }

        public async Task OnGet(Dictionary<string, string> param)
        {
            data = param;
            SearchValue = data.First().Value;
            var allDataFromAPI = await productapiservice.GetProductsFromAPI();            
            ProductsFromAPI = from each in allDataFromAPI.Product where each.Title.ToLower().Contains(SearchValue.ToLower()) select each;            
            var allDataFromJson = jsonfileservice.GetAll();
            ProductsFromJson = from each in allDataFromJson where each.Title.ToLower().Contains(SearchValue.ToLower()) select each;
            PageNumber = (ProductsFromAPI.Count() + ProductsFromJson.Count()) / 10;
            if (ProductsFromAPI.Count() > 10)
            {
                ProductsFromJson = null;
                ProductsFromAPI = ProductsFromAPI.Take(10);
            }
            else
            {
                ProductsFromJson.Take(10 - ProductsFromAPI.Count());
            }

        }

        //public IActionResult OnSwitchPage(int pageNum)
        //{
        //    //int allProductsCount = ProductsFromAPI.Count() + ProductsFromJson.Count();
        //    int numberOfAPI = ProductsFromAPI.Count() - ((pageNum - 1) * 10);
        //    if (numberOfAPI > (pageNum - 1) * 10)
        //    {
        //        for (var index = 0; index < 10; index++)
        //        {
        //            dataToPass[index] = ProductsFromAPI.ElementAt(10 + index);
        //        }
        //        return Page();
        //    }

        //}
    }
}
