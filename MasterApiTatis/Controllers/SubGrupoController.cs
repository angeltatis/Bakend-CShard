using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterApiTatis.Models;
using MasterApiTatis.Services;

namespace MasterApiTatis.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class SubGrupoController : ControllerBase
    {


        private readonly ISubGrupoService _subGrupoService;

        public SubGrupoController(ISubGrupoService subGrupoService)
        {
            _subGrupoService = subGrupoService;
        }


        // GET: api/v1/grupos
        [HttpGet]
        public async Task<IEnumerable<SubGrupo>> GetSubGrupos()
        {

            return await _subGrupoService.GetAllSubGruposAsync();



        }

        // GET: api/v1/Grupo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SubGrupo>> GetSubGrupo(int id)
        {
            var product = await _subGrupoService.GetSubGrupoAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/v1/Grupo/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubGrupo(int id, SubGrupo subgrupo)
        {
            if (id != subgrupo.codsubgrup)
            {
                return BadRequest("El id mandado no es igual es de la url");
            }

            try
            {
                await _subGrupoService.UpdateSubGrupoAsync(id, subgrupo);
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
        public async Task<ActionResult<Grupo>> PostSubGrupo(SubGrupo subgrupo)
        {
           
            try
            {
                await _subGrupoService.CreateSubGrupoAsync(subgrupo);
            }
            catch (DbUpdateException)
            {
                if (await _subGrupoService.SubGrupoExist(subgrupo.codsubgrup))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = subgrupo.codsubgrup }, subgrupo);
        }

        //metodo para desactivar el grupo
        //api/v1/prupos

        [HttpPut("des/{id}")]
        public async Task<IActionResult> StatusSubGrupo(int id)
        {
            try
            {
                await _subGrupoService.ToggleSubGrupoStatusAsync(id);
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
