namespace ReviewService.Entities
{
    public class Review
    {
        public Review()
        {
            Comments = new List<Comment>();
        }
        public int Id { get; set; }
        public string DeviceReview { get; set; }

        public ReviewStatus Status { get; set; }


        public int DeviceId { get; set; }
        public Device Device { get; set; }

        public List<Comment> Comments { get; set; }

        public Guid CreatedBy { get; set; }
        public Guid UpdateddBy { get; set; }
    }

    public enum ReviewStatus
    {
        WorkInProgress,
        Published,
        Completed
    }

}
