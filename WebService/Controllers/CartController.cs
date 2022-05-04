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
            var cos = from c in _context.Articol_Cos select c;
            var user_items = cos.Where(x => x.User_id == user_id);
            return user_items.Include(x => x.Produs);
        }

        // GET api/<CartController>/5
        [HttpGet("{id}")]
        public IEnumerable<Cos> Get(int id)
        {
            var cos = from c in _context.Articol_Cos select c;
            var user_items = cos.Where(x => x.id == id);
            return user_items.Include(x => x.Produs);
        }

        // POST api/<CartController>
        [HttpPost] //        [EnableCors(origin: "http://mywebclient.azurewebsites.net", headers: "*", methods: "*")]
        public void Post([FromBody] Cos cos)
        {
            var produse_similare_in_cos = _context.Articol_Cos.Where(x => x.Produs_id == cos.Produs_id && x.User_id == cos.User_id);
            var anonymus_user = cos.User_id.ToString();

            if (anonymus_user.Any()) //utilizatorul trebuie sa fie autentificat pentru a adauga in cos
            {
                if (produse_similare_in_cos.Any()) //verifica daca produsul este deja adaugat in cos
                {
                    //actualizare cantitate produs deja adaugat
                    var result = _context.Articol_Cos.SingleOrDefault(
                        x => x.User_id == cos.User_id && x.Produs_id == cos.Produs_id);
                    result.Quantity += cos.Quantity;
                    _context.SaveChanges();
                }
                else
                {
                    //adugare produs in cos
                    _context.AddAsync(cos);
                    _context.SaveChanges();
                }
            }
            else
            {
                //utilizator anonim
                throw new UserNotFoundException("Pentru a adăuga un produs trebuie să fiți autentificat!");
            }
        }

        // PUT api/<CartController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] Cos cos)
        //{
        //}

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

}
