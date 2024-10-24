﻿namespace Blog.Models
{
    public class DTO
    {
        public record CreateBloggerDto(string Name, string Sex);
        public record UpdateBloggerDto(string Name, string Sex);
        public record CreateBlogRegistryDto(string Title, string Description, Guid BloggerId);
    }
}
