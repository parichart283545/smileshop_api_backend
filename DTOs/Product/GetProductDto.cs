using System;
using BackEnd_DotNetCoreAPI.Models;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class GetProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public ProductGroupWithoutProduct productGroups { get; set; }
        public int ProductGroupId { get; set; }
        public int StockCount { get; set; }
        //public User CreateBy { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}