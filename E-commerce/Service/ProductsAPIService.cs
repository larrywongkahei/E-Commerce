using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using E_commerce.DataAPI;
using Microsoft.AspNetCore.Hosting;

namespace E_commerce.Service
{
    public class ProductsAPIService
    {
        public ProductsAPIService()
        {

        }
        public async Task<Products> GetProductsFromAPI()
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage response = await client.GetAsync("https://dummyjson.com/products/"))
                {
                    using (HttpContent content = response.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        return JsonSerializer.Deserialize<Products>(data, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }); ;

                    }

                }

            }
        }
    }
}
