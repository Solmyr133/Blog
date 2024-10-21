namespace Blog.Models
{
    public class Blogger
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public string Status { get; set; }
        public DateTime RegistrationTime { get; set; }
    }
}
