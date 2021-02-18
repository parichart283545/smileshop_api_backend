using System.ComponentModel.DataAnnotations;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class EditProductGroup
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}