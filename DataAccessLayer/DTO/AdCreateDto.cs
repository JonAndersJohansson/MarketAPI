namespace DataAccessLayer.DTO
{
    public class AdCreateDto
    {
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public int CreatorId { get; set; }
    }

}
