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
    public class CommentsController : ControllerBase
    {
        private readonly IData data;

        public CommentsController(IData data)
        {
            this.data = data;
        }

        // GET: api/Comments
        [HttpGet]
        public IEnumerable<Comment> Getcomments()
        {
            return data.GetAllComment();
        }

        // GET: api/Comments/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = data.GetComment(id);

            if (comment == null)
            {
                return NotFound();
            }

            return Ok(comment);
        }

       
        // POST: api/Comments
        [HttpPost]
        public async Task<IActionResult> PostComment([FromBody] Comment comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            data.AddComment(comment);
            data.commit();

            return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        }

       
    }
}