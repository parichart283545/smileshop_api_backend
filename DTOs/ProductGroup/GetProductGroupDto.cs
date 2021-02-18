using System;
using System.Collections.Generic;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class GetProductGroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Guid CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public List<GetProductDto> Product { get; set; }

    }
}