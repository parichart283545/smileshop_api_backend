using System.Threading.Tasks;
using BackEnd_DotNetCoreAPI.DTOs;
using BackEnd_DotNetCoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd_DotNetCoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovementStockController : ControllerBase
    {
        private readonly IMovementStockService _stock;
        public MovementStockController([FromQuery] IMovementStockService stock)
        {
            _stock = stock;
        }

        [HttpGet("getmovementstockfilter")]
        public async Task<IActionResult> GetMovementStockFilter([FromQuery] MovementStockFilterDto filter)
        {
            return Ok(await _stock.GetMovementStockFilter(filter));
        }

        [HttpGet("getallmovementstock")]
        public async Task<IActionResult> GetAllMovementStocks()
        {
            return Ok(await _stock.GetMovementStockAll());
        }

        [HttpGet("getmovementstockById/{movemenrStockId}")]
        public async Task<IActionResult> GetMovementStockById(int movemenrStockId)
        {
            return Ok(await _stock.GetMovementStockById(movemenrStockId));
        }

        [HttpGet("getallmovementtype")]
        public async Task<IActionResult> GetAllMovementType()
        {
            return Ok(await _stock.GetMovementTypeAll());
        }

        [HttpPost("addmovementstock")]
        public async Task<IActionResult> AddMovementStock([FromQuery] AddMovementStockDto newmovementstock)
        {
            return Ok(await _stock.AddMovementStock(newmovementstock));
        }

        [HttpPut("editmovementstock")]
        public async Task<IActionResult> EditMovementStock([FromQuery] EditMovementStockDto editMovementStock)
        {
            return Ok(await _stock.EditMovementStock(editMovementStock));
        }


        [HttpDelete("removemovementstock/{movementStockId}")]
        public async Task<IActionResult> DelMovementStock(int movementStockId)
        {
            return Ok(await _stock.DeleteMovementStock(movementStockId));
        }



    }
}