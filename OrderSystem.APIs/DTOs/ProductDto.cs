using System.ComponentModel.DataAnnotations;

namespace OrderSystem.APIs.DTOs
{
    public class ProductDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Stock { get; set; }
    }
}
