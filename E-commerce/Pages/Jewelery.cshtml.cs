using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Model;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class JeweleryModel : PageModel
    {
        public JsonFileService JsonService;

        public IEnumerable<Products> JeweleryFromJson { get; private set; }

        public JeweleryModel(JsonFileService jsonservice)
        {
            JsonService = jsonservice;

        }

        public void OnGet()
        {
            JeweleryFromJson = JsonService.GetJewelery();
            Console.WriteLine(JeweleryFromJson);
        }
    }
}
