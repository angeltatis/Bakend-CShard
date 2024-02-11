using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MasterApiTatis.Domain.Models;
using MasterApiTatis.Infraestructur.Services;

namespace MasterApiTatis.Application.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class DepartamentoController : ControllerBase
    {


        private readonly IDepartamentoService _departamentoService;

        public DepartamentoController(IDepartamentoService departamentoService)
        {
            _departamentoService = departamentoService;
        }


        // GET: api/v1/departamentos
        [HttpGet]
        public async Task<IEnumerable<Departamento>> GetAllDepartamentos()
        {

            return await _departamentoService.GetAllDepartamentosAsync();
        }

        // GET: api/v1/departamentos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _departamentoService.GetDepartamentoAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }

            return departamento;
        }

        // PUT: api/v1/departamento/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.coddep)
            {
                return BadRequest("El id mandado no es igual es de la url");
            }

            try
            {
                await _departamentoService.UpdateDepartamentoAsync(id, departamento);
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
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {

            try
            {
                await _departamentoService.CreateDepartamentoAsync(departamento);
            }
            catch (DbUpdateException)
            {
                if (await _departamentoService.ExistDepartamento(departamento.coddep))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProduct", new { id = departamento.coddep }, departamento);
        }

        //metodo para desactivar el producto
        //api/v1/Products

        [HttpPut("des/{id}")]
        public async Task<IActionResult> StatusDepartamento(int id)
        {
            try
            {
                await _departamentoService.ToggleDepartamentoStatusAsync(id);
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
