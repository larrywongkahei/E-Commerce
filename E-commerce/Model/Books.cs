using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace E_commerce.Model
{
    public class Books
    {
        [Key]
        public string Id { get; set; }

        [JsonPropertyName("volumnInfo")]
        public VolumeInfo Volume { get; set; }

    }

    public class VolumeInfo
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("authors")]
        public IList<string> Authors { get; set; }

        [JsonPropertyName("publisher")]
        public string Publisher { get; set; }

        [JsonPropertyName("publishedDate")]
        public string PulbishedDate { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("imageLinks")]
        public Dictionary<string, string> ImageLinks { get; set; }

    }
}
