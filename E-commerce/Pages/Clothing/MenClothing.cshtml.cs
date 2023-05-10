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
    public class MenClothingModel : BaseModel
    {

        public JsonFileService jsonFileService;

        public IEnumerable<Model.Products> MenClothesFromJson { get; set; }

        public MenClothingModel(JsonFileService fileService)
        {
            jsonFileService = fileService;
            
        }
            public void OnGet()
        {
            MenClothesFromJson = jsonFileService.GetMenClothes();

        }
    }
}
