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
    public class PostsController : ControllerBase
    {
        private readonly IData data;

        public PostsController(IData data)
        {
            this.data = data;
        }

        // GET: api/Posts
        [HttpGet]
        public IEnumerable<Post> GetPosts()
        {
            return data.GetAllPost();
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public ActionResult GetPost([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = data.GetPost(id);

            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        // GET: api/Posts/5/like
        [HttpGet("{id}/like")]
        public async Task<IActionResult> GetPostLike([FromRoute] int id)
        {
            data.AddLike(id);
            var post = data.GetPost(id);
            data.commit();
            return CreatedAtAction("GetPost", new { id },post);
        }

        // POST: api/Posts
        [HttpPost("{id}")]
        public async Task<IActionResult> PostPost(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            data.AddLike(id);
            data.commit();
            return CreatedAtAction("GetPost", new { id = id });
        }


        // POST: api/Posts
        [HttpPost]
        public async Task<IActionResult> PostPost([FromBody] Post post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            data.AddPost(post);
            data.commit();

            return CreatedAtAction("GetPost", new { id = post.ID }, post);
        }

      
    }
}