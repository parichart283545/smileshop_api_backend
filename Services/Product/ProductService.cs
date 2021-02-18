using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Configuration;
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
    public class ProductService : ServiceBase, IProductService
    {
        #region  Declaration
        private readonly AppDBContext _dBContext;
        private readonly IMapper _mapper;
        private readonly ILogger<ProductService> _log;
        private readonly IHttpContextAccessor _httpContext;
        #endregion


        //Constructor with inheritance ServiceBase
        public ProductService(AppDBContext dBContext,
                            IMapper mapper,
                            IHttpContextAccessor httpContext,
                            ILogger<ProductService> log) : base(dBContext, mapper, httpContext)
        {
            _httpContext = httpContext;
            _dBContext = dBContext;
            _mapper = mapper;
            _log = log;
        }

        public async Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto newProduct)
        {
            try
            {
                //validate product
                var prodGrp = _dBContext.ProductGroups.FirstOrDefault(x => x.Id == newProduct.ProductGroupId);
                if (prodGrp is null) return ResponseResult.Failure<GetProductDto>($"ProductGroup Id '{newProduct.ProductGroupId}' not found");
                //Validate duplicate
                var prodDb = await _dBContext.Products.FirstOrDefaultAsync(x => x.Name == newProduct.Name);
                if (prodDb != null) return ResponseResult.Failure<GetProductDto>($"Product name '{newProduct.Name}' is duplicate");

                Product prod = new Product();
                prod.Name = newProduct.Name;
                prod.Price = newProduct.Price;
                prod.ProductGroupId = newProduct.ProductGroupId;
                prod.StockCount = newProduct.StockCount;
                prod.IsActive = newProduct.IsActive;
                prod.CreateById = Guid.Parse(GetUserId());
                prod.CreatedDate = Now();


                //var prodDB = _mapper.Map<Product>(newProduct);
                _dBContext.Products.Add(prod);
                await _dBContext.SaveChangesAsync();

                var dto = _mapper.Map<GetProductDto>(prod);

                //Update movement stock
                Models.MovementStock stockDb = new Models.MovementStock();
                stockDb.ProductId = dto.Id;
                stockDb.MovementTypeId = 1;
                stockDb.Quantity = newProduct.StockCount;
                stockDb.QuantityOld = prod.StockCount;
                stockDb.CreateById = Guid.Parse(GetUserId());
                stockDb.CreateDate = Now();
                stockDb.ExpiredDate = Now();
                stockDb.Remark = "Add new product with add StockCount";
                _dBContext.MovementStocks.Add(stockDb);
                await _dBContext.SaveChangesAsync();


                Product saveProd = await _dBContext.Products.Include(x => x.ProductGroup).FirstOrDefaultAsync(x => x.Name == prod.Name);

                GetProductDto prodDto = _mapper.Map<GetProductDto>(saveProd);
                return ResponseResult.Success(prodDto);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"AddProduct is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetProductDto>($"AddProduct error detail: {ex.Message}");
            }

        }

        public async Task<ServiceResponse<GetProductDto>> EditProduct(EditProductDto editProduct)
        {
            //Find product from id
            var product = await _dBContext.Products.Include(x => x.ProductGroup).FirstOrDefaultAsync(x => x.Id == editProduct.Id);
            //return if not found
            if (product == null) { return ResponseResult.Failure<GetProductDto>($"Product Id '{editProduct.Id}' is not found"); }

            var productGrp = await _dBContext.ProductGroups.FirstOrDefaultAsync(x => x.Id == editProduct.ProductGroupId);
            if (productGrp == null) { return ResponseResult.Failure<GetProductDto>($"ProductGroup Id {editProduct.ProductGroupId} is not found"); }
            //let's update data
            try
            {
                product.Name = editProduct.Name;
                product.Price = editProduct.Price;
                product.ProductGroupId = editProduct.ProductGroupId;
                product.StockCount = editProduct.StockCount;
                product.IsActive = editProduct.IsActive;
                //code update data
                _dBContext.Update(product);
                //Save update above
                await _dBContext.SaveChangesAsync();
                //Get productDto to return
                GetProductDto prodDto = _mapper.Map<GetProductDto>(product);
                return ResponseResult.Success(prodDto);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Update product is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetProductDto>($"Update product error detail: {ex.Message}");
            }
        }


        public async Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int productId)
        {
            try
            {
                var product = await _dBContext.Products.FirstOrDefaultAsync(x => x.Id == productId);

                if (product == null)
                {
                    return ResponseResult.Failure<List<GetProductDto>>($"Product Id {productId} is not found");
                }

                _dBContext.Products.Remove(product);
                await _dBContext.SaveChangesAsync();
                var dto = _mapper.Map<List<GetProductDto>>(await _dBContext.Products.Include(x => x.ProductGroup).AsNoTracking().ToListAsync());

                return ResponseResult.Success(dto);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Delete Product is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<List<GetProductDto>>($"Delete Product error detail: {ex.Message}");
            }
        }

        public async Task<ServiceResponseWithPagination<List<GetProductDto>>> GetProductFilter(ProductFilterDto filter)
        {
            var queryable = _dBContext.Products.Include(x => x.ProductGroup).AsNoTracking().AsQueryable();

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
                    return ResponseResultWithPagination.Failure<List<GetProductDto>>($"Could not order by field: {filter.OrderingField}");
                }
            }

            var paginationResult = await _httpContext.HttpContext
                .InsertPaginationParametersInResponse(queryable, filter.RecordsPerPage, filter.Page);

            var dto = await queryable.Paginate(filter).AsNoTracking().ToListAsync();

            var prodDto = _mapper.Map<List<GetProductDto>>(dto);

            return ResponseResultWithPagination.Success(prodDto, paginationResult);

        }

        public async Task<ServiceResponse<List<GetProductDto>>> GetProductAll()
        {
            //Get data from model
            var products = await _dBContext.Products.Include(x => x.ProductGroup).ToListAsync();
            //Mapping
            List<GetProductDto> productDtos = _mapper.Map<List<GetProductDto>>(products);
            //Return result with ResponseResultl format
            return ResponseResult.Success(productDtos);
        }

        public async Task<ServiceResponse<GetProductDto>> GetProductById(int productId)
        {
            Product product;
            try
            {
                //FirstOrDefaultAsync(x=> x.Id == productId) >>>> select with condition
                product = await _dBContext.Products.Include(x => x.ProductGroup).FirstOrDefaultAsync(x => x.Id == productId);
            }
            catch (System.Exception ex)
            {
                //Write log
                _log.LogError($"Get ProductById({productId}) is error detail: {ex.Message}");
                //Return 
                return ResponseResult.Failure<GetProductDto>($"{productId} is error to find");
            }

            //Validate if null
            if (product != null)
            {
                //mapping and return result
                GetProductDto productDto = _mapper.Map<GetProductDto>(product);
                return ResponseResult.Success(productDto);
            }
            else
            {
                //return not found result
                return ResponseResult.Failure<GetProductDto>($"{productId} is not found");
            }
        }


    }
}