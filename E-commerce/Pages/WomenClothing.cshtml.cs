using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class WomenClothingModel : PageModel
    {

        public JsonFileService jsonfileservice;

        public IEnumerable<Model.Products> WomenClothingFromJson { get; private set; }

        public WomenClothingModel(JsonFileService fileService)
        {
            jsonfileservice = fileService;
        }
            public void OnGet()
        {
            WomenClothingFromJson = jsonfileservice.GetWomenClothes();
        }
    }
}
