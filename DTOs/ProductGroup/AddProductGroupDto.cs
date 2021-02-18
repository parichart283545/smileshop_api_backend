using System.ComponentModel.DataAnnotations;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class AddProductGroup
    {
        [Required]
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}