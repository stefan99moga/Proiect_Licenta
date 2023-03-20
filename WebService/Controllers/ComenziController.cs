using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebService.Data;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComenziController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public ComenziController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/Comenzi
        [HttpGet]
        public IEnumerable<Comenzi> GetComenzi(string sortOrder)
        {
            var comenzi = from c in _context.Comenzi where c.Is_Deprecated == false select c;

            int indecisa = 0;
            int primita = 1;
            int confirmata = 2;
            int refuzata = 3;
            int anulata = 4;
            int livrata = 5;

            switch (sortOrder)
            {
                case "indecisa":
                    comenzi = comenzi.Where(x => x.Stare_Comanda_ID == indecisa);
                    break;
                case "primita":
                    comenzi = comenzi.Where(x => x.Stare_Comanda_ID == primita);
                    break;
                case "confirmata":
                    comenzi = comenzi.Where(x => x.Stare_Comanda_ID == confirmata);
                    break;
                case "refuzata":
                    comenzi = comenzi.Where(x => x.Stare_Comanda_ID == refuzata);
                    break;
                case "anulata":
                    comenzi = comenzi.Where(x => x.Stare_Comanda_ID == anulata);
                    break;
                case "livrata":
                    comenzi = comenzi.Where(x => x.Stare_Comanda_ID == livrata);
                    break;
                default:
                    comenzi = comenzi.OrderBy(c => c.Stare_Comanda_ID);
                    break;
            }

            return comenzi
                .Include(x => x.Adrese)
                .Include(x => x.Stare_Comanda)
                .Include(x => x.Tip_plata);
        }

        //GET: api/Comenzi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comenzi>> GetComenzi(int id)
        {
            var comenzi = await _context.Comenzi
                .Include(x => x.Adrese)
                .Include(x => x.Stare_Comanda)
                .Include(x => x.Tip_plata)
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (comenzi == null)
            {
                return NotFound();
            }

            return comenzi;
        }

        // PUT: api/Comenzi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("{id}")]
        public async Task<IActionResult> EditComenzi(int id, Comenzi comenzi)
        {
            var comanda = _context.Comenzi.Where(x => x.Id == id).SingleOrDefaultAsync();
            comanda.Wait();
            comanda.Result.Stare_Comanda_ID = comenzi.Stare_Comanda_ID;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComenziExists(id))
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

        // POST: api/Comenzi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comenzi>> PostComenzi(Comenzi comenzi)
        {
            var cos_user = _context.Cos.Where(x => x.User_id == comenzi.User_ID && x.Is_Cart_In_Order == false).Include(x => x.Produs);
            var total_plata = cos_user.Sum(x => x.Quantity * x.Produs.Pret_Produs);

            comenzi.Total_Plata = total_plata;
            comenzi.Adrese = _context.Adrese.Where(x => x.Id == comenzi.Adress_ID).SingleOrDefault();
            comenzi.Tip_plata = _context.Tip_Plata.Where(x => x.Id == comenzi.Tip_Plata_ID).SingleOrDefault();
            comenzi.Stare_Comanda = _context.Stare_Comanda.Where(x => x.Id == comenzi.Stare_Comanda_ID).SingleOrDefault();
            comenzi.Is_Deprecated = true;

            _context.Comenzi.Add(comenzi);
            await _context.SaveChangesAsync();

            UpdateCartOrderID(comenzi);
            return comenzi;
        }



        private bool ComenziExists(int id)
        {
            return _context.Comenzi.Any(e => e.Id == id);
        }

        private void UpdateCartOrderID(Comenzi comenzi)
        {
            var cos_user = _context.Cos.Where(x => x.User_id == comenzi.User_ID && x.Is_Cart_In_Order == false).ToList();
            cos_user.ForEach(x => x.Comanda_id = comenzi.Id);
            _context.SaveChanges();

        }

        [HttpPost("OrderSent")]
        public void UpdateCart([FromBody] Comenzi comenzi)
        {
            var userId = comenzi.User_ID;
            var comandaId = comenzi.Id;
            var cos_user = _context.Cos.Where(x => x.User_id == userId && x.Is_Cart_In_Order == false).ToList();
            cos_user.ForEach(x => x.Is_Cart_In_Order = true);
            var comanda = _context.Comenzi.Where(x => x.Id == comandaId).SingleOrDefault();
            comanda.Is_Deprecated = false;
            comanda.Stare_Comanda_ID = 1;
            _context.SaveChanges();
        }
    }
}
