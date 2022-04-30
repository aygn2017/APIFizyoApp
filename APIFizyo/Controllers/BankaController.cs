using APIFizyo.Data;
using APIFizyo.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIFizyo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankaController : ControllerBase
    {

        private readonly APIFizyoDBContext _context;

        public BankaController(APIFizyoDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Banka>>> TümBankalarıGetir()
        {

            return await _context.Bankalar.ToListAsync();
        }

        // GET: api/seçiliAdresiGetir
        [HttpGet("seçiliBankayıGetir/{id}")]
        public async Task<ActionResult<Banka>> seçiliBankayıGetir(int id)
        {

            return await _context.Bankalar.FindAsync(id);
        }
        [HttpPost]
        public async Task<ActionResult> BankaEkle(Banka banka)
        {
             await _context.Bankalar.AddAsync(banka);
            await _context.SaveChangesAsync();
            return NoContent();
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<Banka>> BankaGüncelle(int id, Banka banka)
        {
            _context.Entry(banka).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return await _context.Bankalar.FindAsync(id);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> BankaSil(int id)
        {
            Banka banka = await _context.Bankalar.FindAsync(id);

            if (banka == null)
            {
                return NotFound();
            }

            _context.Remove(banka);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpGet("BankalarFiltreli")]
        public
        async Task<ActionResult<IEnumerable<Banka>>> BankalarFiltreli(string BankalarAdı)
        {

            return await _context.Bankalar.Where(a => a.BankaAdı == BankalarAdı).ToListAsync();
        }



    }
}
