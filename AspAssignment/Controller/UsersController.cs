using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspAssignment.Core;
using AspAssignment.Data;

namespace AspAssignment.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IData data;

        public UsersController(IData data)
        {
           
            this.data = data;
        }

        // GET: api/Users
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return data.GetAllUser();
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = data.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> PostUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            data.AddUser(user);
            data.commit();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

      
    }
}