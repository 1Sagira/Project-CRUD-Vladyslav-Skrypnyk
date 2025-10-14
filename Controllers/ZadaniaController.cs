using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZadanieApp.Api.Data;
using ZadanieApp.Api.Models;

namespace ZadanieApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ZadaniaController : ControllerBase
    {
        private readonly AppDbContext _db;
        public ZadaniaController(AppDbContext db) => _db = db;

        // GET /api/zadania
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int skip = 0, [FromQuery] int take = 100)
        {
            var list = await _db.Zadania
                                .OrderBy(z => z.Id)
                                .Skip(Math.Max(0, skip))
                                .Take(Math.Clamp(take, 1, 500))
                                .ToListAsync();
            return Ok(list);
        }

        // GET /api/zadania/{id}
        [HttpGet("{id:long}")]
        public async Task<IActionResult> Get(long id)
        {
            var z = await _db.Zadania.FindAsync(id);
            if (z == null) return NotFound(new { message = "Zadanie nie znalezione" });
            return Ok(z);
        }

        // POST /api/zadania
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Zadanie model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (model.Priorytet < 1 || model.Priorytet > 5)
                return BadRequest(new { message = "Priorytet must be between 1 and 5" });

            model.CreatedAt = DateTime.UtcNow;
            model.UpdatedAt = null;

            _db.Zadania.Add(model);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = model.Id }, model);
        }

        // PUT /api/zadania/{id}
        [HttpPut("{id:long}")]
        public async Task<IActionResult> Update(long id, [FromBody] Zadanie input)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var exist = await _db.Zadania.FindAsync(id);
            if (exist == null) return NotFound(new { message = "Zadanie nie znalezione" });

            exist.Tytul = input.Tytul;
            exist.Opis = input.Opis;
            exist.Deadline = input.Deadline;
            exist.Priorytet = input.Priorytet;
            exist.Status = input.Status;
            exist.UpdatedAt = DateTime.UtcNow;

            await _db.SaveChangesAsync();
            return Ok(exist);
        }

        // DELETE /api/zadania/{id}
        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var exist = await _db.Zadania.FindAsync(id);
            if (exist == null) return NotFound(new { message = "Zadanie nie znalezione" });

            _db.Zadania.Remove(exist);
            await _db.SaveChangesAsync();
            return NoContent();
        }
    }
}