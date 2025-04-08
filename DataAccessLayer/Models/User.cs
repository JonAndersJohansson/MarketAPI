namespace DataAccessLayer.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; } = true;

        public ICollection<Bid> Bids { get; set; } = new List<Bid>();
        public ICollection<Ad> Ads { get; set; } = new List<Ad>();
    }
}
