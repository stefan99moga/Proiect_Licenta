using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<CartController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CartController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CartController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
