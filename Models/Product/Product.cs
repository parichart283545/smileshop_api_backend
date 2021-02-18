using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_DotNetCoreAPI.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductGroup ProductGroup { get; set; }
        public int ProductGroupId { get; set; }
        public int StockCount { get; set; }
        public User CreateBy { get; set; }
        public Guid CreateById { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}