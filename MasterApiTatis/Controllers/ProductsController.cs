using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterApiTatis.Models;
using MasterApiTatis.Services;

namespace MasterApiTatis.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {


        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService ;
        }


        // GET: api/v1/Products
        [HttpGet]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            
            return await _productService.GetAllProductsAsync();
        }

        // GET: api/v1/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(string id)
        {
            var product = await _productService.GetProductAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/v1/Products/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(string id, Product product)
        {
            if (id != product.codpro)
            {
                return BadRequest("El id mandado no es igual es de la url");
            }

            try
            {
                await _productService.UpdateProductAsync(id, product);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (ArgumentException)
            {
                return BadRequest();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                // Puede que quieras manejar la concurrencia de una forma diferente o
                // simplemente pasar el mensaje de error.
                return StatusCode(500, "No se pudo guardar los cambios. Error: " + ex.Message);
            }

            return NoContent();
        }

        // POST: api/v1/Products

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
           
            try
            {
                await _productService.CreateProductAsync(product);
            }
            catch (DbUpdateException)
            {
                if (await _productService.ProductExistsAsync(product.codpro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = product.codpro }, product);
        }

        //metodo para desactivar el producto
        //api/v1/Products

        [HttpPut("des/{id}")]
        public async Task<IActionResult> StatusProduct(string id)
        {
            try
            {
                await _productService.ToggleProductStatusAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return StatusCode(500, "No se pudo guardar los cambios. Error: " + ex.Message);
            }

            return NoContent();
        }


 
    }
}
