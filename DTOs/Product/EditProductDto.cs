using System.ComponentModel.DataAnnotations;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class EditProductDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int ProductGroupId { get; set; }
        public int StockCount { get; set; } 
        public bool IsActive {get; set;}
    }
}