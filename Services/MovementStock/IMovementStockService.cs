using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Models;

namespace BackEnd_DotNetCoreAPI.Services
{
    public interface IMovementStockService
    {
        //Get all MovementStock list
        Task<ServiceResponse<List<GetMovementStockDto>>> GetMovementStockAll();
        //Get MovementStock by id
        Task<ServiceResponse<GetMovementStockDto>> GetMovementStockById(int MovementStockId);
        Task<ServiceResponse<List<GetMovementStockDto>>> AddMovementStock(AddMovementStockDto newMovementStock);
        Task<ServiceResponseWithPagination<List<GetMovementStockDto>>> GetMovementStockFilter(MovementStockFilterDto filter);
        //Update MovementStock by id
        Task<ServiceResponse<GetMovementStockDto>> EditMovementStock(EditMovementStockDto MovementStock);

        //Delete MovementStock by id
        Task<ServiceResponse<List<GetMovementStockDto>>> DeleteMovementStock(int MovementStockId);

        //Get Movement Type for all
        Task<ServiceResponse<List<GetMovementTypeDto>>> GetMovementTypeAll();
    }
}