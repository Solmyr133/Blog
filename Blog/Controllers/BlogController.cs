using Blog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Controllers
{
    [Route("blog")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public ActionResult<Blogger> Get()
        {
            using (var context = new BlogDbContext())
            {
                return Ok(context.Bloggers.ToList());
            }

        }
    }
}