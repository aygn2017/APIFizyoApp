using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIFizyo.Data;
using APIFizyo.Model;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class İlçeController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public İlçeController(APIFizyoDBContext context)
        {
            _context = context;
        }

        // GET: api/İlçe
        [HttpGet]
        public async Task<ActionResult<IEnumerable<İlçe>>> Getİlçeler()
        {
            return await _context.İlçeler.ToListAsync();
        }

        // GET: api/İlçe/5
        [HttpGet("{id}")]
        public async Task<ActionResult<İlçe>> Getİlçe(int id)
        {
            var İlçe = await _context.İlçeler.FindAsync(id);

            if (İlçe == null)
            {
                return NotFound();
            }

            return İlçe;
        }

        // PUT: api/İlçe/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putİlçe(int id, İlçe İlçe)
        {
            if (id != İlçe.İlçeID)
            {
                return BadRequest();
            }

            _context.Entry(İlçe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!İlçeExists(id))
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

        // POST: api/İlçe
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<İlçe>> Postİlçe(İlçe İlçe)
        {
            _context.İlçeler.Add(İlçe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getİlçe", new { id = İlçe.İlçeID }, İlçe);
        }

        // DELETE: api/İlçe/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteİlçe(int id)
        {
            var İlçe = await _context.İlçeler.FindAsync(id);
            if (İlçe == null)
            {
                return NotFound();
            }

            _context.İlçeler.Remove(İlçe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool İlçeExists(int id)
        {
            return _context.İlçeler.Any(e => e.İlçeID == id);
        }

        //Devam
        [HttpGet("GetİlçeByBaşlangıç/{BaşHarfi}")]
        public async Task<ActionResult<IEnumerable<İlçe>>> GetİlçeByBaşlangıç(string Başlangıç)
        {
            List<İlçe> ilçe = await _context.İlçeler.Where(a => a.İlçeAdı.StartsWith(Başlangıç)).ToListAsync();

            if (ilçe == null)
            {
                return NotFound();
            }

            return ilçe;
        }

        [HttpGet("İliOlanİlçe/{il}")]
        public async Task<ActionResult<IEnumerable<İlçe>>> İliOlanİlçe(string il)
        {
            List<İlçe> ilçe = await _context.İlçeler.Where( a=>a.İl.İlAdı == il).ToListAsync();

            if (ilçe == null)
            {
                return NotFound();
            }

            return ilçe;
        }


    }
}
