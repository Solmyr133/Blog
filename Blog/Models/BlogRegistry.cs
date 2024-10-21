using System.ComponentModel.DataAnnotations;

namespace Blog.Models
{
    public class BlogRegistry
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime LastUpdatedTime { get; set; }

        // Kapcsolatok
        public Blogger ? Blogger { get; set; }
        public Guid BloggerId { get; set; }
    }
}
