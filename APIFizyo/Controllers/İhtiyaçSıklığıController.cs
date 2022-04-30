using APIFizyo.Data;
using APIFizyo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class İhtiyaçSıklığıController : ControllerBase
    {
        private readonly APIFizyoDBContext _context;

        public İhtiyaçSıklığıController(APIFizyoDBContext context)
        {
            _context = context;
        }

        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<İhtiyaçSıklığı>>> GetİhtiyaçSıklıkları()
        {
            return await _context.İhtiyaçSıklıkları.ToListAsync();
        }

        [HttpGet("seçiliİhtiyaçSıklığınıGetir/{id}")]
        public async Task<ActionResult<İhtiyaçSıklığı>> seçiliİhtiyaçSıklığınıGetir(int id)
        {

            return await _context.İhtiyaçSıklıkları.FindAsync(id);
        }


        [HttpPost]
        public async Task<ActionResult> İhtiyaçSıklığıEkle(İhtiyaçSıklığı ihtiyaçsıklığı)
        {
            _context.İhtiyaçSıklıkları.Add(ihtiyaçsıklığı);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<İhtiyaçSıklığı>> AdresGüncelle(int id, İhtiyaçSıklığı ihtiyaçsıklığı)
        {
            _context.Entry(ihtiyaçsıklığı).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.İhtiyaçSıklıkları.FindAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> İhtiyaçSıklığıSil(int id)
        {
            İhtiyaçSıklığı ihtiyaçsıklığı = await _context.İhtiyaçSıklıkları.FindAsync(id);

            if (ihtiyaçsıklığı == null)
            {
                return NotFound();
            }

            _context.Remove(ihtiyaçsıklığı);
            await _context.SaveChangesAsync();
            return NoContent();
        }
        [HttpGet("İhtiyaçSıklıklarıFiltreli")]
        public
            async Task<ActionResult<IEnumerable<İhtiyaçSıklığı>>> İhtiyaçSıklıklarıFiltreli(string İhtiyaçSıklığıAdı)
        {

            return await _context.İhtiyaçSıklıkları.Where(a => a.İhtiyaçSıklığıAdı == İhtiyaçSıklığıAdı).ToListAsync();
        }
    }
}
