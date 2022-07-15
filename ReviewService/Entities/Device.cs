namespace ReviewService.Entities
{
    public class Device
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specification { get; set; }
        public Review DeviceReview { get; set; }
        public Rating Rating { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid UpdateddBy { get; set; }
    }
}
