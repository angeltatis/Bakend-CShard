using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;

namespace MasterApiTatis.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class TipoProductController : ControllerBase
    {


        private readonly ITipoProductService _tipoProductService;

        public TipoProductController(ITipoProductService tipoProductService)
        {
            _tipoProductService = tipoProductService;
        }


        // GET: api/v1/tipo Products
        [HttpGet]
        public async Task<IEnumerable<TipoProduct>> GetTipoProducts()
        {

            return await _tipoProductService.GetAllTipoProductsAsync();
        }

        // GET: api/v1/ tipo Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TipoProduct>> GetTipoProduct(int id)
        {
            var tipoproduct = await _tipoProductService.GetTipoProductAsync(id);

            if (tipoproduct == null)
            {
                return NotFound();
            }

            return tipoproduct;
        }

        // PUT: api/v1/ tipo Products/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, TipoProduct tipoproduct)
        {
            if (id != tipoproduct.codtippro)
            {
                return BadRequest("El id mandado no es igual es de la url");
            }

            try
            {
                await _tipoProductService.UpdateTipoProductAsync(id, tipoproduct);
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

        // POST: api/v1/tipo Products

        [HttpPost]
        public async Task<ActionResult<TipoProduct>> PostTipoProduct(TipoProduct tipoproduct)
        {

            try
            {
                await _tipoProductService.CreateTipoProductAsync(tipoproduct);
            }
            catch (DbUpdateException)
            {
                if (await _tipoProductService.TipoExist(tipoproduct.codtippro))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = tipoproduct.codtippro }, tipoproduct);
        }

        //metodo para desactivar el tipo  producto
        //api/v1/Products

        [HttpPut("des/{id}")]
        public async Task<IActionResult> StatusTipoProduct(int id)
        {
            try
            {
                await _tipoProductService.ToggleTipoProductStatusAsync(id);
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
