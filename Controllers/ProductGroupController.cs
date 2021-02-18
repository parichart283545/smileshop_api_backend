using System.Threading.Tasks;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_DotNetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductGroupController : ControllerBase
    {
        private readonly IProductGroupService _productGroupService;
        public ProductGroupController(IProductGroupService productGroupService)
        {
            _productGroupService = productGroupService;

        }

        [HttpGet("getproductgroupfilter")]
        public async Task<IActionResult> GetProductGroupFilter([FromQuery] ProductGroupFilterDto filter)
        {
            return Ok(await _productGroupService.GetProductGroupFilter(filter));
        }

        [HttpGet("getallproductgroups")]
        public async Task<IActionResult> GetAllGroupProducts()
        {
            return Ok(await _productGroupService.GetProductGroupAll());
        }

        [HttpGet("getproductgroupById/{productGroupId}")]
        public async Task<IActionResult> GetProductGroupById(int productGroupId)
        {
            return Ok(await _productGroupService.GetProductGroupById(productGroupId));
        }

        [HttpPost("addproductgroup")]
        public async Task<IActionResult> AddProductGroup(AddProductGroup newProductGrp)
        {
            return Ok(await _productGroupService.AddProductGroup(newProductGrp));
        }

        [HttpPut("editproductgroup")]
        public async Task<IActionResult> EditProductGroup(EditProductGroup editProductGroup)
        {
            return Ok(await _productGroupService.EditProductGroup(editProductGroup));
        }

        [HttpDelete("removeproductgroup/{productGrpId}")]
        public async Task<IActionResult> DelProductGroup(int productGrpId)
        {
            return Ok(await _productGroupService.DeleteProductGroup(productGrpId));
        }
    }
}