using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd_DotNetCoreAPI.Data;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using BackEnd_DotNetCoreAPI.Helpers;
using System;

namespace BackEnd_DotNetCoreAPI.Services
{
    public class MovementStockService : ServiceBase, IMovementStockService
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MovementStockService> _log;
        private readonly IHttpContextAccessor _httpContext;
        public MovementStockService(AppDBContext dBContext,
                            IMapper mapper,
                            IHttpContextAccessor httpContext,
                            ILogger<MovementStockService> log) : base(dBContext, mapper, httpContext)
        {
            _httpContext = httpContext;
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;
        }

        protected async Task<List<GetMovementStockDto>> GetMovementStockDtosList()
        {
            var gStock = await _dBContext.MovementStocks.Include(x => x.Product).
                                                             Include(x => x.MovementType).
                                                             AsNoTracking().ToListAsync();

            List<GetMovementStockDto> stockDto = _mapper.Map<List<GetMovementStockDto>>(gStock);
            return stockDto;
        }

        protected int GetTotalQuantity(int moveTypeId, int oldVal, int newVal)
        {
            switch (moveTypeId)
            {
                case 1: return newVal + oldVal;
                case 2: return oldVal - newVal;
                default: return 0;
            }
        }

        public async Task<ServiceResponse<List<GetMovementStockDto>>> AddMovementStock(AddMovementStockDto newMovementStock)
        {
            try
            {
                //validate product
                var prod = _dBContext.Products.FirstOrDefault(x => x.Id == newMovementStock.ProductId);
                if (prod is null) return ResponseResult.Failure<List<GetMovementStockDto>>($"Product Id {newMovementStock.ProductId} not found");


                //validate movement type
                var moveType = _dBContext.MovementTypes.FirstOrDefault(x => x.Id == newMovementStock.MovementTypeId);
                if (moveType is null) return ResponseResult.Failure<List<GetMovementStockDto>>($"Movement Type {newMovementStock.MovementTypeId} not found");

                //Validate product StockCount <= new quantity
                if (moveType.Id == 2)
                    if (newMovementStock.Quantity > prod.StockCount) return ResponseResult.Failure<List<GetMovementStockDto>>($"New quantity product less than quantity in stock.");

                Models.MovementStock stockDb = new Models.MovementStock();
                stockDb.ProductId = newMovementStock.ProductId;
                stockDb.MovementTypeId = newMovementStock.MovementTypeId;
                stockDb.Quantity = newMovementStock.Quantity;
                stockDb.QuantityOld = prod.StockCount;
                stockDb.CreateById = Guid.Parse(GetUserId());
                stockDb.CreateDate = Now();
                stockDb.ExpiredDate = Now();
                stockDb.Remark = newMovementStock.Remark;
                _dBContext.MovementStocks.Add(stockDb);
                await _dBContext.SaveChangesAsync();

                //Update on Product Table
                prod.StockCount = GetTotalQuantity(moveType.Id, prod.StockCount, newMovementStock.Quantity);
                _dBContext.Products.Update(prod);
                await _dBContext.SaveChangesAsync();








                //_dBContext.SaveChanges();


                // var gStock = await _dBContext.MovementStocks.Include(x => x.Product).
                //                                              Include(x => x.MovementType).
                //                                              AsNoTracking().ToListAsync();

                // List<GetMovementStockDto> stockDto = _mapper.Map<List<GetMovementStockDto>>(gStock);
                return ResponseResult.Success(await GetMovementStockDtosList());
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"AddMovementStock is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<List<GetMovementStockDto>>($"AddMovementStock error detail: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<List<GetMovementStockDto>>> DeleteMovementStock(int MovementStockId)
        {
            try
            {
                var stock = await _dBContext.MovementStocks.FirstOrDefaultAsync(x => x.Id == MovementStockId);

                if (stock == null)
                {
                    return ResponseResult.Failure<List<GetMovementStockDto>>($"MovementStock Id {MovementStockId} is not found");
                }

                _dBContext.MovementStocks.Remove(stock);
                await _dBContext.SaveChangesAsync();
                // var dto = _mapper.Map<List<GetMovementStockDto>>(await _dBContext.MovementStocks.AsNoTracking().ToListAsync());

                return ResponseResult.Success(await GetMovementStockDtosList());
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Delete MovementStock is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<List<GetMovementStockDto>>($"Delete MovementStock error detail: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<GetMovementStockDto>> EditMovementStock(EditMovementStockDto MovementStock)
        {
            //Find product from id
            var stock = await _dBContext.MovementStocks.FirstOrDefaultAsync(x => x.Id == MovementStock.Id);
            //return if not found
            if (stock == null) { return ResponseResult.Failure<GetMovementStockDto>($"MovementStock Id '{MovementStock.Id}' is not found"); }

            //Find Product id
            var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == MovementStock.ProductId);
            if (product == null) { return ResponseResult.Failure<GetMovementStockDto>($"Product Id {MovementStock.ProductId} is not found"); }

            //Find MovementType id
            var moveType = await _dBContext.MovementTypes.FirstOrDefaultAsync(x => x.Id == MovementStock.MovementTypeId);
            if (moveType == null) { return ResponseResult.Failure<GetMovementStockDto>($"MovementType Id {MovementStock.MovementTypeId} is not found"); }

            //let's update data
            try
            {
                stock.ProductId = MovementStock.ProductId;
                stock.MovementTypeId = MovementStock.MovementTypeId;
                stock.Quantity = MovementStock.Quantity;
                stock.CreateById = Guid.Parse(GetUserId());
                stock.CreateDate = Now();
                stock.ExpiredDate = Now();
                stock.Remark = MovementStock.Remark;
                //code update data
                _dBContext.Update(stock);
                //Save update above
                await _dBContext.SaveChangesAsync();


                //Get productDto to return
                GetMovementStockDto stockDto = _mapper.Map<GetMovementStockDto>(stock);
                return ResponseResult.Success(stockDto);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Update MovementStock is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetMovementStockDto>($"Update MovementStock error detail: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<List<GetMovementStockDto>>> GetMovementStockAll()
        {
            //Get data from model
            List<Models.MovementStock> stocks = await _dBContext.MovementStocks.AsNoTracking().ToListAsync();
            //Mapping
            //List<GetMovementStockDto> stockDtos = _mapper.Map<List<GetMovementStockDto>>(stocks);
            //Return result with ResponseResultl format
            return ResponseResult.Success(await GetMovementStockDtosList());
        }

        public async Task<ServiceResponse<GetMovementStockDto>> GetMovementStockById(int MovementStockId)
        {
            Models.MovementStock stock;
            try
            {
                //FirstOrDefaultAsync(x=> x.Id == productId) >>>> select with condition
                stock = await _dBContext.MovementStocks.Include(x => x.Product).
                                                             Include(x => x.MovementType).
                                                             FirstOrDefaultAsync(x => x.Id == MovementStockId);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Get MovementStockById({MovementStockId}) is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetMovementStockDto>($"{MovementStockId} is error to find");
            }

            //Validate if null
            if (stock != null)
            {
                //mapping and return result
                GetMovementStockDto stockDto = _mapper.Map<GetMovementStockDto>(stock);
                return ResponseResult.Success(stockDto);
            }
            else
            {
                //return not found result
                return ResponseResult.Failure<GetMovementStockDto>($"{MovementStockId} is not found");
            }
        }

        public async Task<ServiceResponseWithPagination<List<GetMovementStockDto>>> GetMovementStockFilter(MovementStockFilterDto filter)
        {
            var queryable = _dBContext.MovementStocks.Include(x => x.Product).
                                                             Include(x => x.MovementType).
                                                             AsNoTracking().AsQueryable();

            //Filter
            if (filter.Id != 0)
            {
                queryable = queryable.Where(x => x.Id == filter.Id);
            }

            //Ordering
            if (!string.IsNullOrWhiteSpace(filter.OrderingField))
            {
                try
                {
                    queryable = queryable.OrderBy($"{filter.OrderingField} {(filter.AscendingOrder ? "ascending" : "descending")}");
                }
                catch
                {
                    return ResponseResultWithPagination.Failure<List<GetMovementStockDto>>($"Could not order by field: {filter.OrderingField}");
                }
            }

            var paginationResult = await _httpContext.HttpContext
                .InsertPaginationParametersInResponse(queryable, filter.RecordsPerPage, filter.Page);

            var dto = await queryable.Paginate(filter).AsNoTracking().ToListAsync();

            var stockDto = _mapper.Map<List<GetMovementStockDto>>(dto);

            return ResponseResultWithPagination.Success(stockDto, paginationResult);
        }

        public async Task<ServiceResponse<List<GetMovementTypeDto>>> GetMovementTypeAll()
        {
            //Get data from model
            List<MovementType> typesDb = await _dBContext.MovementTypes.AsNoTracking().ToListAsync();
            //Mapping
            List<GetMovementTypeDto> typeDtos = _mapper.Map<List<GetMovementTypeDto>>(typesDb);
            //Return result with ResponseResultl format
            return ResponseResult.Success(typeDtos);
        }
    }
}