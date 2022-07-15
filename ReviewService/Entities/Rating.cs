namespace ReviewService.Entities
{
    public class Rating
    {
        public int Id { get; set; }
        public double Score { get; set; }
        public Device Device { get; set; }
        public int DeviceId { get; set; }
        public int UserId { get; set; }

    }
}
