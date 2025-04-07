namespace DataAccessLayer.DTO
{
    public class AdUpdateDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }

        public bool IsActive { get; set; }
    }

}
