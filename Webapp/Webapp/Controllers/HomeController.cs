using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Webapp.models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Webapp.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/posts")]
        public IActionResult Index()
        {
            return Ok(data.posts);
        }

        [HttpGet("/posts/{id:int}")]
        public IActionResult SearchById(int id)
        {
            var post = data.posts.FirstOrDefault(p => p.Id == id);
            return post is null ? NotFound("Post not found") : Ok(post);
        }

        [HttpPost("/posts")]
        public IActionResult Create([FromBody]BlogPost post)
        {
            post.Id = data.nextId++;
            data.posts.Add(post);
            return Ok(post);
        }

        [HttpPut("/posts/{id:int}")]
        public IActionResult Update(int id, [FromBody]BlogPost updatedpost)
        {
            var post = data.posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound("Post Not Found");
            post.Title = updatedpost.Title;
            post.Content = updatedpost.Content;
            return Ok(post);
        }
        [HttpPatch("/posts/{id:int}")]
        public IActionResult PartialUpdate(int id, [FromBody]BlogPost newPost)
        {
            var post = data.posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound("Post Not Found");
            if (!string.IsNullOrEmpty(newPost.Title)) post.Title = newPost.Title;
            if (!string.IsNullOrEmpty(newPost.Content)) post.Content = newPost.Content;
            return Ok(post);
        }

        [HttpDelete("/posts/{id:int}")]
        public IActionResult Delete(int id)
        {
            var post = data.posts.FirstOrDefault(p => p.Id == id);
            if (post == null) return NotFound("Post not found");
            data.posts.Remove(post);
            return Ok(post);
        }

    }
}
