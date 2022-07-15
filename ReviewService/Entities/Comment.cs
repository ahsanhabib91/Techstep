namespace ReviewService.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Comments { get; set; }
        public Review Review { get; set; }
        public int ReviewId { get; set; }
    }
}
