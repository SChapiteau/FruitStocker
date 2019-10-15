using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FruitStocker.Model;
using FruitStockerAPI;

namespace FruitStockerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitLotsController : ControllerBase
    {
        private readonly FruitStockerContext _context;

        public FruitLotsController(FruitStockerContext context)
        {
            _context = context;
        }

        // GET: api/FruitLots
        [HttpGet]
        public IEnumerable<FruitLot> GetFruitLots()
        {
            return _context.FruitLots;
        }

        // GET: api/FruitLots/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFruitLot([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fruitLot = await _context.FruitLots.FindAsync(id);

            if (fruitLot == null)
            {
                return NotFound();
            }

            return Ok(fruitLot);
        }

        // PUT: api/FruitLots/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFruitLot([FromRoute] Guid id, [FromBody] FruitLot fruitLot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != fruitLot.Id)
            {
                return BadRequest();
            }

            _context.Entry(fruitLot).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FruitLotExists(id))
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

        // POST: api/FruitLots
        [HttpPost]
        public async Task<IActionResult> PostFruitLot([FromBody] FruitLot fruitLot)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FruitLots.Add(fruitLot);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFruitLot", new { id = fruitLot.Id }, fruitLot);
        }

        // DELETE: api/FruitLots/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFruitLot([FromRoute] Guid id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fruitLot = await _context.FruitLots.FindAsync(id);
            if (fruitLot == null)
            {
                return NotFound();
            }

            _context.FruitLots.Remove(fruitLot);
            await _context.SaveChangesAsync();

            return Ok(fruitLot);
        }

        private bool FruitLotExists(Guid id)
        {
            return _context.FruitLots.Any(e => e.Id == id);
        }
    }
}