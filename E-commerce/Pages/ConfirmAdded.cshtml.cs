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

        public Dictionary<string, double> SessionDic { get; set; } = new Dictionary<string, double>();

        public ConfirmAddedModel(JsonFileService jsonFileService, ProductsAPIService productsAPIService)
        {
            fileservice = jsonFileService;
            apiService = productsAPIService;
        }

        public async Task OnGetAsync(string name, double price)
        {            
            var jsonData = fileservice.GetAll();
            var apiData = await apiService.GetProductsFromAPI();
            if(apiData.Product.FirstOrDefault(each => each.Title == name) != null)
            {
                product = apiData.Product.First(each => each.Title == name);
                HttpContext.Session.SetString(product.Title, price.ToString());
            }
            else
            {
                products = jsonData.First(each => each.Title == name);
                HttpContext.Session.SetString(products.Title, price.ToString());

            }
            foreach(var each in HttpContext.Session.Keys)
            {
                var productPrice = Convert.ToDouble(HttpContext.Session.GetString(each));
                subtotal += productPrice;
                SessionDic[each] = productPrice;
            }

            productList = apiData.Product.Take(6);
        }
    }
}
