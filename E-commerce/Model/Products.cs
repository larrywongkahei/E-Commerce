using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace E_commerce.Model
{
    public class Products
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        [JsonPropertyName("image")]
        public string Img { get; set; }

        public object Rating { get; set; }

        public override string ToString() => JsonSerializer.Serialize<Products>(this);

    }
}
