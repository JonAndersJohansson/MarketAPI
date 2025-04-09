namespace DataAccessLayer.Models
{
    public class Ad
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
        public int CreatorId { get; set; }
        public User Creator { get; set; } = null!;
        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
    }
}
