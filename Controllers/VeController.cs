using BookingMovie.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookingMovie.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public VeController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<VeController>
        [HttpGet]
        public IEnumerable<Ve> Get()
        {
            return veXemPhimContext.Ves;
        }

        // GET api/<VeController>/5
        [HttpGet("{id}")]
        public Ve Get(int id)
        {
            return veXemPhimContext.Ves.SingleOrDefault(x => x.MaVe == id);
        }

        // POST api/<VeController>
        [HttpPost]
        public void Post([FromBody] Ve ve)
        {
            veXemPhimContext.Ves.Add(ve);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<VeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Ve ve)
        {
            ve.MaVe = id;
            veXemPhimContext.Ves.Update(ve);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<VeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.Ves.FirstOrDefault(x => x.MaVe == id);
            if (item != null)
            {
                veXemPhimContext.Ves.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
