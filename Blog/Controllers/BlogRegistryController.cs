using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using static Blog.Models.DTO;

namespace Blog.Controllers
{
    [Route("blogregistry")]
    [ApiController]
    public class BlogRegistryController : Controller
    {
        [HttpPost]
        public ActionResult<BlogRegistry> Post(CreateBlogRegistryDto createBlogRegistryDto)
        {
            using (var context = new BlogDbContext())
            {
                DateTime currentTime = DateTime.Now;
                var blogRegistry = new BlogRegistry()
                {
                    Id = Guid.NewGuid(),
                    Title = createBlogRegistryDto.Title,
                    Description = createBlogRegistryDto.Description,
                    CreatedTime = currentTime,
                    LastUpdatedTime = currentTime,
                    BloggerId = createBlogRegistryDto.BloggerId,
                };

                if (blogRegistry != null)
                {
                    context.BlogRegistry.Add(blogRegistry);
                    context.SaveChanges();
                    return StatusCode(201, blogRegistry);
                }
            }
            return Ok();
        }
        [HttpGet("{id}")]
        public ActionResult<BlogRegistry> GetById(Guid id)
        {
            using (var context = new BlogDbContext())
            {
                var result = context.BlogRegistries.Select(x => new {x.Blogger.Name, x.Title, x.Description});
            }
        }
    }
}
