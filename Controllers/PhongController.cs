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
    public class PhongController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public PhongController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<PhongController>
        [HttpGet]
        public IEnumerable<Phong> Get()
        {
            return veXemPhimContext.Phongs;
        }

        // GET api/<PhimController>/5
        [HttpGet("{id}")]
        public Phong Get(int id)
        {
            return veXemPhimContext.Phongs.SingleOrDefault(x => x.IdPhong == id);

        }

        // POST api/<PhimController>
        [HttpPost]
        public void Post([FromBody] Phong phong)
        {
            veXemPhimContext.Phongs.Add(phong);
            veXemPhimContext.SaveChanges();
        }
        // PUT api/<PhimController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Phong phong)
        {
            phong.IdPhong = id;
            veXemPhimContext.Phongs.Update(phong);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<PhimController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.Phongs.FirstOrDefault(x => x.IdPhong == id);
            if (item != null)
            {
                veXemPhimContext.Phongs.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
