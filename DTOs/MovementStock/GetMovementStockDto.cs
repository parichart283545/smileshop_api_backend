using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BackEnd_DotNetCoreAPI.Models;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class GetMovementStockDto
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public MovementType MovementType { get; set; }
        public int QuantityOld { get; set; }
        public int Quantity { get; set; }
        //public User CreateBy { get; set; }
        public Guid CreateById { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string Remark { get; set; }

    }
}