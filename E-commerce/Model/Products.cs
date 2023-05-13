using System;
using System.Collections.Generic;
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

        [JsonPropertyName("rating")]
        public rating Rating { get; set; }

        public string Thumbnail { get; } = null;

        public override string ToString() => JsonSerializer.Serialize<Products>(this);

    }
    public class rating
    {
        public decimal rate { get; set; }
        public int count { get; set; }

}
}
