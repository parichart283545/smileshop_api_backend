namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class ProductFilterDto:PaginationDto
    {
        public string Name { get; set; }
        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;//false is asc
    }
}