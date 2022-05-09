using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using WebService.Data;
using WebService.Models;

namespace WebService.Controllers
{
    [Route("api/[controller]")]
    //[ApiController]
    public class CartController : ControllerBase
    {
        private readonly RestaurantContext _context;
        public CartController(RestaurantContext context)
        {
            _context = context;
        }
        
        // GET: api/<CartController>
        [HttpGet]
        public IEnumerable<Cos> Get(string user_id)
        {
            var cos = from c in _context.Cos select c;
            
            var user_items = cos.Where(x => x.User_id == user_id && x.Is_Cart_In_Order == false);

            return user_items.Include(x => x.Produs)
                .Include(x => x.Comenzi)
                .Include(x => x.Comenzi.Adrese)
                .Include(x => x.Comenzi.Tip_plata)
                .OrderBy(x => x.Produs.Categorie_Id);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IEnumerable<Cos> Get(int id)
        {
            var cos = from c in _context.Cos select c;
            var user_items = cos.Where(x => x.id == id && x.Is_Cart_In_Order == false);
            return user_items.Include(x => x.Produs)
                .Include(x => x.Comenzi);
        }

        [HttpGet("GetComandaDetails")]
        public IEnumerable<Cos> GetComandaDetails(int comandaId)
        {
            var cos = from c in _context.Cos select c;

            var comanda_details = cos.Where(x => x.Comanda_id == comandaId);

            return comanda_details.Include(x => x.Produs);
        }

        // POST api/<CartController>
        [HttpPost("AddToCart")] //        [EnableCors(origin: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
        public void AddToCart([FromBody] Cos cos)
        {
            var produse_similare_in_cos = _context.Cos.Where(x => x.Produs_id == cos.Produs_id && x.User_id == cos.User_id && x.Is_Cart_In_Order == false);
            var anonymus_user = cos.User_id.ToString();

            if (anonymus_user.Any()) //utilizatorul trebuie sa fie autentificat pentru a adauga in cos
            {
                if (produse_similare_in_cos.Any()) //verifica daca produsul este deja adaugat in cos
                {
                    //actualizare cantitate produs deja adaugat
                    var result = _context.Cos.SingleOrDefault(
                        x => x.User_id == cos.User_id && x.Produs_id == cos.Produs_id && x.Is_Cart_In_Order == false);
                    result.Quantity += cos.Quantity;
                    _context.SaveChanges();
                }
                else
                {
                    //adugare produs in cos
                    cos.Is_Cart_In_Order = false;
                    _context.AddAsync(cos);
                    _context.SaveChanges();
                }
            }
            else
            {
                //utilizator anonim arunca exceptie
                throw new UserNotFoundException("Pentru a adăuga un produs trebuie să fiți autentificat!");
            }
        }

        [HttpPost("UpdateQtyCart")]
        public void IncrementQty([FromBody] Cos cos)
        {
            var produs_similar_in_cos = _context.Cos.Where(x => x.id == cos.id && x.User_id == cos.User_id && x.Is_Cart_In_Order == false).FirstOrDefaultAsync();

            if (produs_similar_in_cos.Result!=null)
            {
                produs_similar_in_cos.Result.Quantity = cos.Quantity;
                _context.SaveChanges();
            }
            else
            {
                throw new ProductNotFoundException("Produsul nu este gasit!");
            }

        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(Cos cos)
        {
            _context.Remove(cos);
            _context.SaveChanges();
        }
    }


    public class UserNotFoundException : Exception
    {
        readonly string result;
        public UserNotFoundException(string message)
            : base(message)
        {
            result = message;
        }

        public override string ToString()
        {
            return result;
        }
    }

    public class ProductNotFoundException : Exception
    {
        readonly string result;
        public ProductNotFoundException(string message)
            : base(message)
        {
            result = message;
        }

        public override string ToString()
        {
            return result;
        }
    }

}
