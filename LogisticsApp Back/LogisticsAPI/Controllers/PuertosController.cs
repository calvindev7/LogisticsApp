using LogisticsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class PuertosController : ControllerBase
{
    private readonly AppDbContext _context;

    public PuertosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Puertos
    [HttpGet]
    public async Task<IActionResult> GetPuertos()
    {
        var Puertos = await _context.Puertos.ToListAsync();
        return Ok(Puertos);
    }

    // GET: api/Puertos/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetPuerto(int id)
    {
        var Puerto = await _context.Puertos.FindAsync(id);
        if (Puerto == null)
        {
            return NotFound();
        }
        return Ok(Puerto);
    }

    // POST: api/Puertos
    [HttpPost]
    public async Task<IActionResult> CreatePuerto(Puerto puerto)
    {
        _context.Puertos.Add(puerto);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetPuerto), new { id = puerto.Id }, puerto);
    }

    // PUT: api/Puertos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePuerto(int id, Puerto puerto)
    {
        if (id != puerto.Id)
        {
            return BadRequest();
        }

        _context.Entry(puerto).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Puertos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePuerto(int id)
    {
        var Puerto = await _context.Puertos.FindAsync(id);
        if (Puerto == null)
        {
            return NotFound();
        }

        _context.Puertos.Remove(Puerto);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

