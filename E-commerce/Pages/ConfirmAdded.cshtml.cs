using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DataAPI;
using E_commerce.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public static class SessionExtensions
    {
        public static double? GetDouble(this ISession session, string key)
        {
            var data = session.Get(key);
            if (data == null)
            {
                return null;
            }
            return BitConverter.ToDouble(data, 0);
        }

        public static void SetDouble(this ISession session, string key, double value)
        {
            session.Set(key, BitConverter.GetBytes(value));
        }
    }

    public class ConfirmAddedModel : BaseModel
    {
        public JsonFileService fileservice { get; set; }

        public ProductsAPIService apiService { get; set; }

        public Product product { get; set; }

        public IEnumerable<Product> productList { get; set; }

        public Model.Products products { get; set; }

        public double subtotal { get; set; }

        public ConfirmAddedModel(JsonFileService jsonFileService, ProductsAPIService productsAPIService)
        {
            fileservice = jsonFileService;
            apiService = productsAPIService;
        }

        public async Task OnGetAsync(string name, double price)
        {
            HttpContext.Session.SetString("Product" + HttpContext.Session.Keys.Count().ToString(), name);
            
            var jsonData = fileservice.GetAll();
            var apiData = await apiService.GetProductsFromAPI();
            if(apiData.Product.FirstOrDefault(each => each.Title == name) != null)
            {
                product = apiData.Product.First(each => each.Title == name);
                if (HttpContext.Session.GetDouble("subtotal") == null)
                {
                    HttpContext.Session.SetDouble("subtotal", price);
                }
                else
                {
                    var currentPrice = HttpContext.Session.GetDouble("subtotal");
                    HttpContext.Session.SetDouble("subtotal", (double)(currentPrice + price));
                }


            }
            else
            {
                products = jsonData.First(each => each.Title == name);
                if (HttpContext.Session.GetDouble("subtotal") == null)
                {
                    HttpContext.Session.SetDouble("subtotal", (double)price);
                }
                else
                {
                    var currentPrice = HttpContext.Session.GetDouble("subtotal");
                    HttpContext.Session.SetDouble("subtotal", (double)(currentPrice + (double)price));
                }

            }
            subtotal = (double)HttpContext.Session.GetDouble("subtotal");
            productList = apiData.Product.Take(6);
        }
    }
}
