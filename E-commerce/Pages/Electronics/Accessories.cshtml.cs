using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace E_commerce.Pages
{
    public class AccessoriesModel : BaseModel
    {

        public JsonFileService productService;

        public IEnumerable<Model.Products> Accessories { get; private set; }

        public AccessoriesModel(JsonFileService fileService)
        {
            productService = fileService;
        }

        public void OnGet()
        {
            Accessories = productService.GetElectronics();
        }
    }
}
