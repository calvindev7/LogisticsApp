using LogisticsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class EnviosTerrestresController : ControllerBase
{
    private readonly AppDbContext _context;

    public EnviosTerrestresController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/EnviosTerrestres
    [HttpGet]
    public async Task<IActionResult> GetEnviosTerrestres()
    {
        var enviosTerrestres = await _context.EnviosTerrestres
            .Include(e => e.Cliente)
            .Include(e => e.Producto)
            .ToListAsync();
        return Ok(enviosTerrestres);
    }

    // GET: api/EnviosTerrestres/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetEnvioTerrestre(int id)
    {
        var envioTerrestre = await _context.EnviosTerrestres
            .Include(e => e.Cliente)
            .Include(e => e.Producto)
            .FirstOrDefaultAsync(e => e.Id == id);
        if (envioTerrestre == null)
        {
            return NotFound();
        }
        return Ok(envioTerrestre);
    }

    // POST: api/EnviosTerrestres
    [HttpPost]
    public async Task<IActionResult> CreateEnvioTerrestre(EnvioTerrestre envioTerrestre)
    {
        _context.EnviosTerrestres.Add(envioTerrestre);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetEnvioTerrestre), new { id = envioTerrestre.Id }, envioTerrestre);
    }

    // PUT: api/EnviosTerrestres/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEnvioTerrestre(int id, EnvioTerrestre envioTerrestre)
    {
        if (id != envioTerrestre.Id)
        {
            return BadRequest();
        }

        _context.Entry(envioTerrestre).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/EnviosTerrestres/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEnvioTerrestre(int id)
    {
        var envioTerrestre = await _context.EnviosTerrestres.FindAsync(id);
        if (envioTerrestre == null)
        {
            return NotFound();
        }

        _context.EnviosTerrestres.Remove(envioTerrestre);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}
