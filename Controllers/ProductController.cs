using System.Threading.Tasks;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_DotNetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productservice;

        public ProductController(IProductService productService)
        {
            _productservice = productService;
        }

        [HttpGet("getproductfilter")]
        public async Task<IActionResult> GetProductFilter([FromQuery] ProductFilterDto filter)
        {
            return Ok(await _productservice.GetProductFilter(filter));
        }



        [HttpGet("getallproducts")]
        public async Task<IActionResult> GetAllProducts()
        {
            return Ok(await _productservice.GetProductAll());
        }



        [HttpGet("getproductById/{productId}")]
        public async Task<IActionResult> GetProductrById(int productId)
        {
            return Ok(await _productservice.GetProductById(productId));
        }



        [HttpPost("addproductr")]
        public async Task<IActionResult> AddProductr(AddProductDto newProduc)
        {
            return Ok(await _productservice.AddProduct(newProduc));
        }



        [HttpPut("editproductr")]
        public async Task<IActionResult> EditProductr(EditProductDto editProduct)
        {
            return Ok(await _productservice.EditProduct(editProduct));
        }


        [HttpDelete("removeproductr/{productId}")]
        public async Task<IActionResult> DelProducts(int productId)
        {
            return Ok(await _productservice.DeleteProduct(productId));
        }


    }
}