using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyWebApiApp.Data;
using MyWebApiApp.Models;
using MyWebApiApp.Repository;

namespace MyWebApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _bookRepo;

        public ProductsController(IProductRepository repo)
        {
            _bookRepo = repo;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            try
            {
                return Ok(await _bookRepo.GetAllProductAsync());
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(Guid id)
        {
            var product = await _bookRepo.GetProductAsync(id);

            return product == null ? NotFound() : Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> AddProduct(HangHoaModel model)
        {
            var newProduct = await _bookRepo.AddProductAsync(model);
            return Ok(newProduct);
        }
        [HttpDelete("(id)")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _bookRepo.DeleteProductAsync(id);
            return Ok(await _bookRepo.GetAllProductAsync());
        }
    }
}
