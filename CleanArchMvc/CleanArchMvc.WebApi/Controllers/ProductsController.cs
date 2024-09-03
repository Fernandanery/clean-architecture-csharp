using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IProductService productService) : ControllerBase
    {
        private readonly IProductService _productService = productService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Products()
        {
            var products = await _productService.GetProducts();

            if (products == null)
            {
                return NotFound("Products not found");
            }

            return Ok(products);
        }

        [HttpGet("{id:int}", Name = "ProductdById")]
        public async Task<ActionResult<ProductDto>> ProductdById(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (productDto == null)
            {
                return BadRequest("Invalid Data");
            }

            await _productService.Add(productDto);

            return new CreatedAtRouteResult("ProductdById", new { id = productDto.Id }, productDto);

        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> UpdateProduct(int id, [FromBody] ProductDto productDto)
        {

            if (id != productDto.Id)
            {
                return BadRequest("Invalid Data");
            }

            if (productDto == null)
            {
                return BadRequest();
            }

            await _productService.Update(productDto);

            return Ok(productDto);

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<ProductDto>> RemoveProduct(int id)
        {
            var product = await _productService.GetById(id);

            if (product == null)
            {
                return NotFound("Product not found");
            }

            await _productService.Remove(id);

            return Ok(product);
        }
    }
}
