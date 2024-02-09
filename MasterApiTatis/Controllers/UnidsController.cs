using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterApiTatis.Models;
using MasterApiTatis.Services;

namespace MasterApiTatis.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UnidsController : ControllerBase
    {
        private readonly IUnidadService _unidadService;

        public UnidsController(IUnidadService unidadService)
        {
            _unidadService = unidadService;
        }

        // GET: api/v1/Unids
        [HttpGet]
        public async Task<IEnumerable<Unidad>> GetUnids()
        {
           return await _unidadService.GetAllUnidsAsync();
        }

        // GET: api/Unids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Unidad>> GetUnid(int id)
        {
            var unid = await _unidadService.GetUnidByIdAsync(id);

            if (unid == null)
            {
                return NotFound();
            }

            return unid;
        }

        // PUT: api/v1/Unids/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnid(int id, Unidad unid)
        {
            if (id != unid.coduni)
            {
                return BadRequest("El id mandado no es igula Al de la url");
            }

            try
            {
                await _unidadService.UpdateUnidAsync(id, unid);
            }
            catch (ArgumentException ex)
            {
                // This is where you handle the argument exception thrown from the service layer.
                return BadRequest(ex.Message);
            }
            catch (KeyNotFoundException ex)
            {
                // This is where you handle the case where the Unid doesn't exist.
                return NotFound(ex.Message);
            }
            catch (DbUpdateConcurrencyException)
            {

                return StatusCode(StatusCodes.Status409Conflict);
            }

           // return NoContent();
            return CreatedAtAction("GetUnid", new { id = unid.coduni }, unid);
        }


        // POST: api/Unids
        
        [HttpPost]
        public async Task<ActionResult<Unidad>> PostUnid(Unidad unid)
        {
          
            try
            {
                bool existe = await _unidadService.ExisteConDescripcion(unid.desuni); 
                if (existe)
                {
                    return BadRequest($"La Unidad Existe: {unid.desuni}");

                }
                await _unidadService.AddUnidAsync(unid);
            }
            catch (DbUpdateException)
            {
                if (await _unidadService.UnidExistsAsync(unid.coduni))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetUnid", new { id = unid.coduni }, unid);
        }

        //Desctivar
        [HttpPut("des/{id}")]
        public async Task<IActionResult> StatusUnid(int id)
        {
            try
            {
                await _unidadService.desactivarUnidAsync(id);
            }
            catch(KeyNotFoundException) 
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
