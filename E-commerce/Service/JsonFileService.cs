using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using E_commerce.Model;
using Microsoft.AspNetCore.Hosting;

namespace E_commerce.Service
{
    public class JsonFileService
    {

        public JsonFileService(IWebHostEnvironment webHostEnvironment)
        {
            WebHostEnvironment = webHostEnvironment;
        }

        public IWebHostEnvironment WebHostEnvironment { get; }

        private string theFile
        {
            get
            {
                return Path.Combine(WebHostEnvironment.WebRootPath, "data", "MockData.json");
            }
        }

        public IEnumerable<Products> GetAll()
        {
            using (var fileReader = File.OpenText(theFile))
            {
                return JsonSerializer.Deserialize<Products[]>(fileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    }
                );
            }

        }

        public IEnumerable<Products> GetElectronics()
        {
            var allData = this.GetAll();
            return from data in allData where data.Category == "electronics" select data;
        }

        public IEnumerable<Products> GetMenClothes()
        {
            var allData = this.GetAll();
            return from data in allData where data.Category == "men's clothing" select data;
        }

        public IEnumerable<Products> GetWomenClothes()
        {
            var allData = this.GetAll();
            return from data in allData where data.Category == "women's clothing" select data;
            
        }

        public IEnumerable<Products> GetJewelery()
        {
            var allData = this.GetAll();
            return from data in allData where data.Category == "jewelery" select data;
        }
    }
}
