using System.Collections.Generic;
using System.Threading.Tasks;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Models;
//using BackEnd_DotNetCoreAPI.Models;

namespace BackEnd_DotNetCoreAPI.Services
{
    public interface IProductGroupService
    {
         //Get all ProductGroup
         Task<ServiceResponseWithPagination<List<GetProductGroupDto>>> GetProductGroupFilter(ProductGroupFilterDto filter);
         //Add ProductGroup 
         Task<ServiceResponse<GetProductGroupDto>> AddProductGroup(AddProductGroup newProductGroup);
        Task<ServiceResponse<List<GetProductGroupDto>>> GetProductGroupAll();
        //Get ProductGroup by id
        Task<ServiceResponse<GetProductGroupDto>> GetProductGroupById(int productGroupId);
        
        //Update ProductGroup by id
        Task<ServiceResponse<GetProductGroupDto>> EditProductGroup(EditProductGroup productGroup);
        
        //Delete ProductGroup by id
        Task<ServiceResponse<List<GetProductGroupDto>>> DeleteProductGroup(int productGroupId);
    }
}