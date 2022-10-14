using Microsoft.AspNetCore.Mvc;
using DesafioGranto.Models;
using DesafioGranto.Models.Entities;

namespace DesafioGranto.Controllers
{
    [Route("core/oportunidades")]
    [ApiController]
    public class OportunidadesController : ControllerBase
    {
        private readonly DesafioContext _context;

        public OportunidadesController(DesafioContext context)
        {
            _context = context;
        }

        // POST: api/Oportunidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Oportunidade>> PostOportunidade(Oportunidade oportunidade)
        {
            //_context.Oportunidade.Add(oportunidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOportunidade", new { id = oportunidade.Id }, oportunidade);
        }
    }
}
