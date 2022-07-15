using ReviewService.Entities;

namespace ReviewService.Services
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetReviewsAsync();
        Task<bool> AddReviewAsync(Review review);
    }
}
