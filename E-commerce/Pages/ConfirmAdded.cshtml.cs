﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.DataAPI;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class ConfirmAddedModel : BaseModel
    {
        public JsonFileService fileservice { get; set; }

        public ProductsAPIService apiService { get; set; }

        public Product product { get; set; }

        public Model.Products products { get; set; }

        public ConfirmAddedModel(JsonFileService jsonFileService, ProductsAPIService productsAPIService)
        {
            fileservice = jsonFileService;
            apiService = productsAPIService;
        }

        public async Task OnGetAsync(string name)
        {
            var jsonData = fileservice.GetAll();
            var apiData = await apiService.GetProductsFromAPI();
            if(apiData.Product.First(each => each.Title == name) != null)
            {
                product = apiData.Product.First(each => each.Title == name);

            }
            else
            {
                products = jsonData.First(each => each.Title == name);
            }

        }
    }
}