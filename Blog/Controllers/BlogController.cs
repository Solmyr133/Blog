using Blog.Models;
using Microsoft.AspNetCore.Mvc;
using static Blog.Models.DTO;

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

        [HttpPost]
        public ActionResult<Blogger> Post(CreateBloggerDto createBloggerDto)
        {
            using (var context = new BlogDbContext())
            {
                var blogger = new Blogger()
                {
                    Id = Guid.NewGuid(),
                    Name = createBloggerDto.Name,
                    Sex = createBloggerDto.Sex,
                    Status = "Waiting",
                    RegistrationTime = DateTime.Now
                };

                if (blogger != null)
                {
                    context.Bloggers.Add(blogger);
                    context.SaveChanges();
                    return StatusCode(201, blogger);
                }
                return BadRequest();
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Blogger> GetById(Guid id)
        {
            using (var context = new BlogDbContext())
            {
                var blogger = context.Bloggers.FirstOrDefault(x => x.Id == id);

                if (blogger != null)
                {
                    return StatusCode(200, blogger);
                }

                return NotFound();
            }

        }

        [HttpPut]
        public ActionResult<Blogger> Put(UpdateBloggerDto updateBloggerDto, Guid id)
        {
            using (var context = new BlogDbContext())
            {
                var existingBlogger = context.Bloggers.FirstOrDefault(x => x.Id == id);
                
                if (existingBlogger != null)
                {
                    existingBlogger.Name = updateBloggerDto.Name;
                    existingBlogger.Sex = updateBloggerDto.Sex;

                    context.Bloggers.Update(existingBlogger);
                    context.SaveChanges();

                    return StatusCode(202, existingBlogger);
                }

                return BadRequest();
            }
        }

        [HttpDelete]
        public ActionResult<Blogger> Delete(Guid id)
        {
            using (var context = new BlogDbContext())
            {
                var existingBlogger = context.Bloggers.FirstOrDefault(x => x.Id == id);

                if (existingBlogger != null)
                {
                    context.Bloggers.Remove(existingBlogger);
                    context.SaveChanges();

                    return StatusCode(204);
                }

                return BadRequest();
            }
        }
    }
}