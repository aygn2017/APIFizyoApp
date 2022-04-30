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
    public class İhtiyaçController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public İhtiyaçController(APIFizyoDBContext context)
        {
            _context = context;
        }

        // GET: api/İhtiyaç
        [HttpGet]
        public async Task<ActionResult<IEnumerable<İhtiyaç>>> Getİhtiyaç()
        {
            return await _context.İhtiyaçlar.Include(a => a.Kullanıcı).Include(a => a.İhtiyaçSıklığı).ToListAsync();
        }

        // GET: api/İhtiyaç/5
        [HttpGet("{id}")]
        public async Task<ActionResult<İhtiyaç>> Getİhtiyaç(int id)
        {
            var ihtiyaç = await _context.İhtiyaçlar.FindAsync(id);

            if (ihtiyaç == null)
            {
                return NotFound();
            }

            return ihtiyaç;
        }

        // PUT: api/İhtiyaç/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putİhtiyaç(int id, İhtiyaç İhtiyaç)
        {
            if (id != İhtiyaç.İhtiyaçID)
            {
                return BadRequest();
            }

            _context.Entry(İhtiyaç).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!İhtiyaçExists(id))
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

        // POST: api/İhtiyaç
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<İhtiyaç>> Postİhtiyaç(İhtiyaç İhtiyaç)
        {
            if(İhtiyaç.İhtiyaçSıklığıID == 1)
            {
                İhtiyaç.Açıklama += "ACİL!";
            }
            _context.İhtiyaçlar.Add(İhtiyaç);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getİhtiyaç", new { id = İhtiyaç.İhtiyaçID }, İhtiyaç);
        }

        // DELETE: api/İhtiyaç/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteİhtiyaç(int id)
        {
            var İhtiyaç = await _context.İhtiyaçlar.FindAsync(id);
            if (İhtiyaç == null)
            {
                return NotFound();
            }

            _context.İhtiyaçlar.Remove(İhtiyaç);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool İhtiyaçExists(int id)
        {
            return _context.İhtiyaçlar.Any(e => e.İhtiyaçID == id);
        }


        // GET: api/İhtiyaç
        [HttpGet("İhtiyaçByContains/{kelime}")]
        public async Task<ActionResult<IEnumerable<İhtiyaç>>> İhtiyaçByContains(string kelime)
        {
            return await _context.İhtiyaçlar.Include(a => a.Kullanıcı).Include(a => a.İhtiyaçSıklığı).Where(a => a.Açıklama.Contains(kelime)).ToListAsync();
        }


        // GET: api/İhtiyaç
        [HttpGet("İhtiyaçBySıklık/{sıklık}")]
        public async Task<ActionResult<IEnumerable<İhtiyaç>>> İhtiyaçBySıklık(string sıklık)
        {
            return await _context.İhtiyaçlar.Include(a => a.İhtiyaçSıklığı).Where(a => a.İhtiyaçSıklığı.İhtiyaçSıklığıAdı == sıklık).ToListAsync();
        }

        //kullanıcıya göre

        [HttpGet("GetİhtiyacByKullanıcı/{kullanıcıID}")]
        public async Task<ActionResult<IEnumerable<İhtiyaç>>> GetİhtiyacByKullanıcı(int kullanıcıID)
        {
            return await _context.İhtiyaçlar.Include(a => a.Kullanıcı).Where(a => a.Kullanıcı.KullanıcıID == kullanıcıID).ToArrayAsync();
        }




    }
}
