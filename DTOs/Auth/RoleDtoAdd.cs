using BackEnd_DotNetCoreAPI.Validations;

namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class RoleDtoAdd
    {
        [FirstLetterUpperCase]
        public string RoleName { get; set; }
    }
}