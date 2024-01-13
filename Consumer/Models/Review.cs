namespace Consumer.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Username { get; set; }
        public DateTime PublishedOn { get; set; } = DateTime.Now;
        public int Stars { get; set; }
        public string Message { get; set; }
    }
}