using System.ComponentModel.DataAnnotations;

namespace OrderSystem.APIs.DTOs
{
    public class CustomerDto
    {
        [Required]
        [MaxLength(100), MinLength(5)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
