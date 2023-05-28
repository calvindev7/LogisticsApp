using LogisticsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EnviosMaritimosController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnviosMaritimosController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/EnviosMaritimos
    [HttpGet]
    public async Task<IActionResult> GetEnviosMaritimos()
    {
        var enviosMaritimos = await _context.EnviosMaritimos
            .Include(e => e.Cliente)
            .Include(e => e.Producto)
            .ToListAsync();
        return Ok(enviosMaritimos);
    }

    // GET: api/EnviosMaritimos/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnvioMaritimo(int id)
    {
        var envioMaritimo = await _context.EnviosMaritimos
            .Include(e => e.Cliente)
            .Include(e => e.Producto)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (envioMaritimo == null)
        {
            return NotFound();
        }
        return Ok(envioMaritimo);
    }

    // POST: api/EnviosMaritimos
    [HttpPost]
    public async Task<IActionResult> CreateEnvioMaritimo(EnvioMaritimo envioMaritimo)
    {
        _context.EnviosMaritimos.Add(envioMaritimo);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEnvioMaritimo), new { id = envioMaritimo.Id }, envioMaritimo);
    }

    // PUT: api/EnviosMaritimos/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnvioMaritimo(int id, EnvioMaritimo envioMaritimo)
    {
        if (id != envioMaritimo.Id)
        {
            return BadRequest();
        }

        _context.Entry(envioMaritimo).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/EnviosMaritimos/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnvioMaritimo(int id)
    {
        var envioMaritimo = await _context.EnviosMaritimos.FindAsync(id);
        if (envioMaritimo == null)
        {
            return NotFound();
        }

        _context.EnviosMaritimos.Remove(envioMaritimo);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
