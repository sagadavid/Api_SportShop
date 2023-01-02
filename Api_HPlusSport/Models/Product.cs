using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Api_HPlusSport.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Sku { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        [Required]
        public int CategoryId { get; set; }
        
        [JsonIgnore]//from product to category and back loop.. problem fo json
        public virtual Category? Category { get; set; }
    }
}
