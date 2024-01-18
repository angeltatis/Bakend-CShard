using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterApiTatis.Models;
using MasterApiTatis.Services;

namespace MasterApiTatis.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class GrupoController : ControllerBase
    {


        private readonly IGrupoService _grupoService;

        public GrupoController(IGrupoService grupoService)
        {
            _grupoService = grupoService;
        }


        // GET: api/v1/grupos
        [HttpGet]
        public async Task<IEnumerable<Grupo>> GetGrupos()
        {

            return await _grupoService.GetAllGruposAsync();



        }

        // GET: api/v1/Grupo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Grupo>> GetProduct(int id)
        {
            var product = await _grupoService.GetGrupoAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/v1/Grupo/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Grupo grupo)
        {
            if (id != grupo.codgrup)
            {
                return BadRequest("El id mandado no es igual es de la url");
            }

            try
            {
                await _grupoService.UpdateGrupoAsync(id, grupo);
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

        // POST: api/v1/Grupo

        [HttpPost]
        public async Task<ActionResult<Grupo>> PostGrupo(Grupo grupo)
        {
           
            try
            {
                await _grupoService.CreateGrupoAsync(grupo);
            }
            catch (DbUpdateException)
            {
                if (await _grupoService.grupoExiste(grupo.codgrup))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = grupo.codgrup }, grupo);
        }

        //metodo para desactivar el grupo
        //api/v1/prupos

        [HttpPut("des/{id}")]
        public async Task<IActionResult> StatusGrupot(int id)
        {
            try
            {
                await _grupoService.ToggleGrupoStatusAsync(id);
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
