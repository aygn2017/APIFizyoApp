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
    public class İlController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public İlController(APIFizyoDBContext context)
        {
            _context = context;
        }

        // GET: api/İl
        [HttpGet]
        public async Task<ActionResult<IEnumerable<İl>>> Getİller()
        {
            return await _context.İller.ToListAsync();
        }

        // GET: api/İl/5
        [HttpGet("{id}")]
        public async Task<ActionResult<İl>> Getİl(int id)
        {
            var İl = await _context.İller.FindAsync(id);

            if (İl == null)
            {
                return NotFound();
            }

            return İl;
        }

        // PUT: api/İl/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putİl(int id, İl İl)
        {
            if (id != İl.İlID)
            {
                return BadRequest();
            }

            _context.Entry(İl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!İlExists(id))
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

        // POST: api/İl
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<İl>> Postİl(İl İl)
        {
            _context.İller.Add(İl);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getİl", new { id = İl.İlID }, İl);
        }

        // DELETE: api/İl/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deleteİl(int id)
        {
            var İl = await _context.İller.FindAsync(id);
            if (İl == null)
            {
                return NotFound();
            }

            _context.İller.Remove(İl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool İlExists(int id)
        {
            return _context.İller.Any(e => e.İlID == id);
        }

        //Devam
        [HttpGet("GetİlByBaşlangıç/{BaşHarfi}")]
        public async Task<ActionResult<IEnumerable<İl>>> GetİlByBaşlangıç(string BaşHarfi)
        {
            List<İl> il = await _context.İller.Where(a => a.İlAdı.StartsWith(BaşHarfi)).ToListAsync();

            if (il == null)
            {
                return NotFound();
            }

            return il;
        }

        [HttpGet("İlçesiOlanİl/{ilçe}")]
        public async Task<ActionResult<IEnumerable<İlçe>>> İlçesiOlanİl(string ilçe)
        {
            List<İlçe> ilçeler = await _context.İlçeler.Include(a=>a.İl).Where( a => a.İlçeAdı == ilçe ).ToListAsync();

            if (ilçeler == null)
            {
                return NotFound();
            }
            return ilçeler;
        }

        [HttpGet("UzunluğaGöreİl/{uzunluk}")]
        public async Task<ActionResult<IEnumerable<İl>>> UzunluğaGöreİl(int uzunluk)
        {
            List<İl> iller = await _context.İller.Where(a => a.İlAdı.Length > uzunluk ).ToListAsync();

            if (iller == null)
            {
                return NotFound();
            }
            return iller;
        }

        ////reverse navigationla yapınca döngüye giriyor
        //[HttpGet("İlinİlçeleri/{ilAdı}")]
        //public async Task<ActionResult<İl>> İlinİlçeleri(string ilAdı)
        //{
        //    İl il = await _context.İller.Include(a => a.İlçeler).FirstOrDefaultAsync(a => a.İlAdı == ilAdı);

        //    if (il == null)
        //    {
        //        return NotFound();
        //    }

        //    return il;
        //}


    }
}
