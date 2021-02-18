using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_DotNetCoreAPI.Models
{
    public class ProductGroup
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

         public User CreateBy { get; set; }
         public Guid CreateById { get; set; }

        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
        public List<Product> Product { get; set; }
    }
}