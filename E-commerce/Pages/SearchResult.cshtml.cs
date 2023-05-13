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
    public class SearchResultModel : BaseModel
    {
        public JsonFileService jsonfileservice;

        public ProductsAPIService productapiservice;

        public IEnumerable<Product> ProductsFromAPI { get; set; }


        public IEnumerable<Model.Products> ProductsFromJson { get; set; }

        public IEnumerable<Product> AllProductsFromAPI { get; set; }

        public IEnumerable<Model.Products> AllProductsFromJson { get; set; }

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
            AllProductsFromAPI = from each in allDataFromAPI.Product where each.Title.ToLower().Contains(SearchValue.ToLower()) select each;            
            var allDataFromJson = jsonfileservice.GetAll();
            AllProductsFromJson = from each in allDataFromJson where each.Title.ToLower().Contains(SearchValue.ToLower()) select each;
            PageNumber = (AllProductsFromAPI.Count() + AllProductsFromJson.Count()) / 10;
            if (AllProductsFromAPI.Count() > 10)
            {
                ProductsFromJson = null;
                ProductsFromAPI = AllProductsFromAPI.Take(10);
            }
            else if (AllProductsFromAPI.Count() < 10) 
            {
                ProductsFromJson = AllProductsFromJson.Take(10 - AllProductsFromAPI.Count());
            }

        }

        public IActionResult OnPostSwitchPage(int pageNum)
        {
            Console.WriteLine("123");

            Console.WriteLine(AllProductsFromAPI.GetType());
            //if (AllProductsFromAPI.Count() > (pageNum - 1) * 10 && AllProductsFromAPI.Count() < pageNum * 10)
            //{
            //    ProductsFromAPI = AllProductsFromAPI.Skip(10);
            //    ProductsFromJson = AllProductsFromJson.Take(10 - ProductsFromAPI.Count());
            //    return Page();
            //}
            //else if (AllProductsFromAPI.Count() > pageNum * 10)
            //{
            //    ProductsFromAPI.Skip(10).Take(10);
            //    ProductsFromJson = null;
            //    return Page();
            //}
            //else if (AllProductsFromJson.Count() > (pageNum - 1) * 10 && AllProductsFromJson.Count() < pageNum * 10)
            //{
            //    ProductsFromAPI = null;
            //    ProductsFromJson.Skip(10);
            //    return Page();
            //}
            //else if (AllProductsFromJson.Count() > pageNum * 10)
            //{
            //    ProductsFromAPI = null;
            //    ProductsFromJson.Skip(10).Take(10);
            //    return Page();
            //}
            return Page();
        }
    }
}
