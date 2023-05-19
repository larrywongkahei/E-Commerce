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
    public class AllProductClass
    {
        public Product productfromapi { get; set; }

        public Model.Products productfromjson { get; set; }
    }

    public class BasketModel : BaseModel
    {
        public JsonFileService fileservice { get; set; }

        public ProductsAPIService apiService { get; set; }

        public List<AllProductClass> productsList { get; set; } = new List<AllProductClass>();

        public Dictionary<string, double> SessionDic { get; set; } = new Dictionary<string, double>();

        public BasketModel(JsonFileService jsonFileService, ProductsAPIService productsAPIService)
        {
            fileservice = jsonFileService;
            apiService = productsAPIService;
        }

        public async Task OnGetAsync()
        {
            var apidata = await apiService.GetProductsFromAPI();
            var jsondata = fileservice.GetAll();

            foreach (var each in HttpContext.Session.Keys)
            {
                var productPrice = Convert.ToDouble(HttpContext.Session.GetString(each));
                SessionDic[each] = productPrice;
                if (apidata.Product.FirstOrDefault(product => product.Title == each) != null)
                {
                    var newclass = new AllProductClass();
                    var product = apidata.Product.First(product => product.Title == each);
                    newclass.productfromapi = product;
                    productsList.Add(newclass);
                }
                else
                {
                    var newclass = new AllProductClass();
                    var product = jsondata.First(product => product.Title == each);
                    newclass.productfromjson = product;
                    productsList.Add(newclass);
                }
            }
        }

        public IActionResult OnPostDeleteProduct(string title)
        {
            HttpContext.Session.Remove(title);
            Console.WriteLine("called");
            Console.WriteLine(HttpContext.Session.Keys.Count());
            return RedirectToPage("Basket");
        }
    }
}
