using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_commerce.DataAPI
{

    public class Products
    {
        [JsonPropertyName("products")]
        public IEnumerable<Product> Product { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Products>(this);

    }

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("price")]
        public int Price { get; set; }

        [JsonPropertyName("rating")]
        public double Rating { get; set; }

        [JsonPropertyName("brand")]
        public string Brand { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; }

        [JsonPropertyName("images")]
        public IList<string> Images { get; set; }

    }

  
}
