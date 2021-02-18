using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Models;

namespace BackEnd_DotNetCoreAPI.Services
{
    public interface IProductService 
    {
        //Get all product list
        Task<ServiceResponse<List<GetProductDto>>> GetProductAll();
        //Get product by id
        Task<ServiceResponse<GetProductDto>> GetProductById(int productId);
        Task<ServiceResponse<GetProductDto>> AddProduct(AddProductDto newProduct);
        Task<ServiceResponseWithPagination<List<GetProductDto>>> GetProductFilter(ProductFilterDto filter);
        //Update Product by id
        Task<ServiceResponse<GetProductDto>> EditProduct(EditProductDto product);
        
        //Delete Product by id
        Task<ServiceResponse<List<GetProductDto>>> DeleteProduct(int productId);
    }
}