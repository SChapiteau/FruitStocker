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




        #region Old request
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
        #endregion
    }
}