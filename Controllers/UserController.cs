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
    public class UserController : ControllerBase
    {
        private readonly VeXemPhimContext veXemPhimContext;
        public UserController(VeXemPhimContext veXemPhimContextt)
        {
            veXemPhimContext = veXemPhimContextt;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return veXemPhimContext.Users;
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public User Get(int id)
        {
            return veXemPhimContext.Users.SingleOrDefault(x => x.IdUser == id);
        }
        [HttpGet("{username}/{password}")]
        public User login(string username, string password)
        {
            return veXemPhimContext.Users.SingleOrDefault(x => x.TaiKhoan == username && x.MatKhau == password);
        }

        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody]User user)
        {
            veXemPhimContext.Users.Add(user);
            veXemPhimContext.SaveChanges();
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            user.IdUser = id;
            veXemPhimContext.Users.Update(user);
            veXemPhimContext.SaveChanges();
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = veXemPhimContext.Users.FirstOrDefault(x => x.IdUser == id);
            if (item != null)
            {
                veXemPhimContext.Users.Remove(item);
                veXemPhimContext.SaveChanges();
            }
        }
    }
}
