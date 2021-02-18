using System;
using System.ComponentModel.DataAnnotations;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class EditMovementStockDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public int MovementTypeId { get; set; }
        [Required]
        public int QuantityOld { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        // public DateTime CreateDate { get; set; }
        // public DateTime ExpiredDate { get; set; }
        public string Remark { get; set; }
    }
}