using LogisticsApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[Authorize]
[ApiController]
[Route("api/[controller]")]
public class BodegasController : ControllerBase
{
    private readonly AppDbContext _context;

    public BodegasController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Bodegas
    [HttpGet]
    public async Task<IActionResult> GetBodegas()
    {
        var Bodegas = await _context.Bodegas.ToListAsync();
        return Ok(Bodegas);
    }

    // GET: api/Bodegas/5
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBodega(int id)
    {
        var Bodega = await _context.Bodegas.FindAsync(id);
        if (Bodega == null)
        {
            return NotFound();
        }
        return Ok(Bodega);
    }

    // POST: api/Bodegas
    [HttpPost]
    public async Task<IActionResult> CreateBodega(Bodega bodega)
    {
        _context.Bodegas.Add(bodega);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetBodega), new { id = bodega.Id }, bodega);
    }

    // PUT: api/Bodegas/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBodega(int id, Bodega bodega)
    {
        if (id != bodega.Id)
        {
            return BadRequest();
        }

        _context.Entry(bodega).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/Bodegas/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteBodega(int id)
    {
        var Bodega = await _context.Bodegas.FindAsync(id);
        if (Bodega == null)
        {
            return NotFound();
        }

        _context.Bodegas.Remove(Bodega);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

