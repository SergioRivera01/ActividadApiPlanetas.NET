#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PlanetasApi.Models;

//API
namespace PlanetasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanetItemsController : ControllerBase
    {
        private readonly PlanetContext _context;

        public PlanetItemsController(PlanetContext context)
        {
            _context = context;
        }

        // GET: api/PlanetItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlanetItem>>> GetPlanetItems()
        {
            return await _context.PlanetItems.ToListAsync();
        }

        // GET: api/PlanetItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PlanetItem>> GetPlanetItem(long id)
        {
            var planetItem = await _context.PlanetItems.FindAsync(id);

            if (planetItem == null)
            {
                return NotFound();
            }

            return planetItem;
        }

        // PUT: api/PlanetItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlanetItem(long id, PlanetItem planetItem)
        {
            if (id != planetItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(planetItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlanetItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PlanetItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PlanetItem>> PostPlanetItem(PlanetItem planetItem)
        {
            _context.PlanetItems.Add(planetItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetPlanetItem), new { id = planetItem.Id }, planetItem);
        }

        // DELETE: api/PlanetItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlanetItem(long id)
        {
            var planetItem = await _context.PlanetItems.FindAsync(id);
            if (planetItem == null)
            {
                return NotFound();
            }

            _context.PlanetItems.Remove(planetItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PlanetItemExists(long id)
        {
            return _context.PlanetItems.Any(e => e.Id == id);
        }
    }
}
