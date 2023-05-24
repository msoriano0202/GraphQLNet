namespace GraphQLDirector.Models
{
    public class Streamer
    {
        public int Id { get; set; }
        public string? Url { get; set; }
        public string? Nombre { get; set; }
        public virtual ICollection<Video>? Videos { get; set; }
    }
}
