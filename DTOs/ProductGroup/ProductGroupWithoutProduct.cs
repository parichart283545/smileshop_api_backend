using System;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class ProductGroupWithoutProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }

    }
}