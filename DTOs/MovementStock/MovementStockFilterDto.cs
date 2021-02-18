namespace BackEnd_DotNetCoreAPI.DTOs
{
    public class MovementStockFilterDto:PaginationDto
    {
        public int Id { get; set; }
        public string OrderingField { get; set; }
        public bool AscendingOrder { get; set; } = true;//false is asc
    }
}