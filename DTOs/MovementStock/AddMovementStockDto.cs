using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class AddMovementStockDto
    {
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int MovementTypeId { get; set; }
        [Required]
        public int Quantity { get; set; }
        //public DateTime CreateDate { get; set; }
        //public DateTime ExpiredDate { get; set; }
        public string Remark { get; set; }
    }
}