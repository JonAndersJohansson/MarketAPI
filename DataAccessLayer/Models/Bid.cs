namespace DataAccessLayer.Models
{
    public class Bid
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime BidTime { get; set; } = DateTime.UtcNow;
        public int AdId { get; set; }
        public Ad Ad { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
