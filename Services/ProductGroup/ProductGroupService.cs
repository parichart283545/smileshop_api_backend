using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BackEnd_DotNetCoreAPI.Data;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Helpers;
using BackEnd_DotNetCoreAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq.Dynamic.Core;
using System;

namespace BackEnd_DotNetCoreAPI.Services
{
    public class ProductGroupService : ServiceBase, IProductGroupService
    {
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductGroupService> _log;
        private readonly IHttpContextAccessor _httpContext;
        public ProductGroupService(AppDBContext dBContext,
        IMapper mapper,
        IHttpContextAccessor httpContext,
        ILogger<ProductGroupService> log) : base(dBContext, mapper, httpContext)
        {
            _httpContext = httpContext;
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;
        }

        public async Task<ServiceResponse<List<GetProductGroupDto>>> DeleteProductGroup(int productGroupId)
        {
            try
            {
                var prodGrp = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == productGroupId);

                if (prodGrp == null)
                {
                    return ResponseResult.Failure<List<GetProductGroupDto>>($"ProductGroup Id {productGroupId} is not found");
                }

                _dBContext.ProductGroups.Remove(prodGrp);
                await _dBContext.SaveChangesAsync();
                var dto = _mapper.Map<List<GetProductGroupDto>>(await _dBContext.ProductGroups.AsNoTracking().ToListAsync());

                return ResponseResult.Success(dto);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Delete ProductGroup is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<List<GetProductGroupDto>>($"Delete ProductGroup error detail: {ex.Message}");
            }
        }

        public async Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(EditProductGroup productGroup)
        {
            try
            {
                //Find ProductGroup
                var prodGrp = await _dBContext.ProductGroups.Include(x => x.Product).Include(x => x.CreateBy).FirstOrDefaultAsync(x => x.Id == productGroup.Id);
                if (prodGrp == null) { return ResponseResult.Failure<GetProductGroupDto>("ProductGroup Id not found"); }

                //Update data
                prodGrp.Name = productGroup.Name;
                prodGrp.IsActive = productGroup.IsActive;
                _dBContext.Update(prodGrp);
                await _dBContext.SaveChangesAsync();
                //Mapping
                GetProductGroupDto prodGrpDto = _mapper.Map<GetProductGroupDto>(prodGrp);
                return ResponseResult.Success(prodGrpDto);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Update product is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetProductGroupDto>($"Update ProductGroup error detail: {ex.Message}");
            }



        }

        public async Task<ServiceResponse<List<GetProductGroupDto>>> GetProductGroupAll()
        {
            //Get data from model
            List<ProductGroup> productGroups = await _dBContext.ProductGroups.Include(x => x.Product).Include(x => x.CreateBy).AsNoTracking().ToListAsync();
            //let's mapping data between model data and Dto data
            List<GetProductGroupDto> productGroupDtos = _mapper.Map<List<GetProductGroupDto>>(productGroups);
            //Return result with ResponseResultl format
            return ResponseResult.Success(productGroupDtos);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId)
        {
            ProductGroup productGroup;
            try
            {
                //FirstOrDefaultAsync(x=> x.Id == productId) >>>> select with condition
                productGroup = await _dBContext.ProductGroups.Include(x => x.Product).Include(x => x.CreateBy).FirstOrDefaultAsync(x => x.Id == productGroupId);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Get ProductGroupById({productGroupId}) is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetProductGroupDto>($"{productGroupId} is error to find");
            }

            //Validate if null
            if (productGroup != null)
            {
                //mapping and return result
                GetProductGroupDto productGroupDto = _mapper.Map<GetProductGroupDto>(productGroup);
                return ResponseResult.Success(productGroupDto);
            }
            else
            {
                //return not found result
                return ResponseResult.Failure<GetProductGroupDto>($"{productGroupId} is not found");
            }
        }
        public async Task<ServiceResponseWithPagination<List<GetProductGroupDto>>> GetProductGroupFilter(ProductGroupFilterDto filter)
        {
            var queryable = _dBContext.ProductGroups.Include(x => x.Product).Include(x => x.CreateBy).AsNoTracking().AsQueryable();

            //Filter
            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                queryable = queryable.Where(x => x.Name.Contains(filter.Name.Trim()));
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
                    return ResponseResultWithPagination.Failure<List<GetProductGroupDto>>($"Could not order by field: {filter.OrderingField}");
                }
            }

            var paginationResult = await _httpContext.HttpContext
                .InsertPaginationParametersInResponse(queryable, filter.RecordsPerPage, filter.Page);

            var dto = await queryable.Paginate(filter).AsNoTracking().ToListAsync();

            var prodGrpDto = _mapper.Map<List<GetProductGroupDto>>(dto);

            return ResponseResultWithPagination.Success(prodGrpDto, paginationResult);
        }

        public async Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroup newProductGroup)
        {
            try
            {
                //Validate duplicate
                var prodGrpV = _dBContext.ProductGroups.FirstOrDefault(x => x.Name == newProductGroup.Name);
                if (prodGrpV != null) return ResponseResult.Failure<GetProductGroupDto>($"ProductGroup name '{newProductGroup.Name}' is duplicate");

                ProductGroup prodGrp = new ProductGroup();
                prodGrp.Name = newProductGroup.Name;
                prodGrp.IsActive = newProductGroup.IsActive;
                prodGrp.CreateById = Guid.Parse(GetUserId());
                prodGrp.CreatedDate = Now();

                //var prodGrpDB = _mapper.Map<ProductGroup>(newProductGroup);
                _dBContext.ProductGroups.Add(prodGrp);
                await _dBContext.SaveChangesAsync();

                ProductGroup saveProdGrp = await _dBContext.ProductGroups.Include(x => x.Product).Include(x => x.CreateBy).FirstOrDefaultAsync(x => x.Name == newProductGroup.Name);

                GetProductGroupDto prodGrpDto = _mapper.Map<GetProductGroupDto>(saveProdGrp);
                return ResponseResult.Success(prodGrpDto);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"AddProductGroup is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetProductGroupDto>($"AddProductGroup error detail: {ex.Message}");
            }
        }

    }
}