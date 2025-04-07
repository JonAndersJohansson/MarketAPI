namespace DataAccessLayer.DTO
{
    public class AdDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public DateTime CreatedAt { get; set; }

        public string CreatorName { get; set; } = null!;
    }

}
