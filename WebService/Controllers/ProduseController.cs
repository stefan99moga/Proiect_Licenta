using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebService.Data;
using System.Linq;
using WebService.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProduseController : ControllerBase
    {
        private readonly RestaurantContext _context;

        public ProduseController(RestaurantContext context)
        {
            _context = context;
        }

        // GET: api/<ProduseController>
        [HttpGet]
        public IEnumerable<Produs> Get(string sortOrder)
        {
            var produse = from p in _context.Produs where p.Is_Deprecated == false select p;

            int pizza = 1;
            int desert = 2;
            int bautura = 3;


            switch (sortOrder)
            {
                case "pizza":
                    produse = produse.Where(x => x.Categorie_Id == pizza);
                    break;
                case "desert":
                    produse = produse.Where(x => x.Categorie_Id == desert);
                    break;
                case "bautura":
                    produse = produse.Where(x => x.Categorie_Id == bautura);
                    break;
                case "nume_cresc":
                    produse = produse.OrderBy(x => x.Nume_Produs);
                    break;
                case "nume_desc":
                    produse = produse.OrderByDescending(x => x.Nume_Produs);
                    break;
                case "pret_cresc":
                    produse = produse.OrderBy(x => x.Pret_Produs);
                    break;
                case "pret_desc":
                    produse = produse.OrderByDescending(produse => produse.Pret_Produs);
                    break;
                default:
                    produse = produse.OrderBy(x => x.Categorie_Id);
                    break;
            }

            return produse.Include(x => x.Categorie_produs);
        }
    }
}
