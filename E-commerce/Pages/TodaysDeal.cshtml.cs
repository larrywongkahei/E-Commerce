using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using E_commerce.Model;
using E_commerce.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace E_commerce.Pages
{
    public class TodaysDealModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public JsonFileService ProductService;

        public IEnumerable<Products> Products { get; private set; }

        public TodaysDealModel(ILogger<IndexModel> logger, JsonFileService productService)



        {
            _logger = logger;
            ProductService = productService;
        }

        public void OnGet()
        {
            Products = ProductService.GetAll();
        }
    }
}


