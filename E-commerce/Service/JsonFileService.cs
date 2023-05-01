using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
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
                return Path.Combine(WebHostEnvironment.WebRootPath, "Data", "MockData.json");
            }
        }

        public IEnumerable<Products> GetAll()
        {
            using (var fileReader = File.OpenText(theFile))
            {
                return JsonSerializer.Deserialize<Products[]>(fileReader.ReadToEnd(),
                    new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = false
                    }
                );
            }

        }
    }
}
