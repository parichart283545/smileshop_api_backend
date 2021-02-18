using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BackEnd_DotNetCoreAPI.Models
{
    [Table("MovementStock")]
    public class MovementStock
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public Product Product { get; set; }
        public int ProductId { get; set; }
        public MovementType MovementType { get; set; }
        public int MovementTypeId { get; set; }
        public int QuantityOld { get; set; }
        public int Quantity { get; set; }
        public User CreateBy { get; set; }
        public Guid CreateById { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Remark { get; set; }


    }
}