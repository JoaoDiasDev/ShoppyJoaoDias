namespace Entities
{
    public class PageDO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Slug { get; set; }
        public string? Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
