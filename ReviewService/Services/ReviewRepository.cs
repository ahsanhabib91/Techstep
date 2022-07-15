using CityInfo.API.DbContexts;
using ReviewService.Entities;
using Microsoft.EntityFrameworkCore;

namespace ReviewService.Services;

public class ReviewRepository : IReviewRepository
{
    private readonly ReviewsContext _context;

    public ReviewRepository(ReviewsContext context)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public async Task<IEnumerable<Review>> GetReviewsAsync()
    {
        return await _context.Reviews.OrderBy(c => c.Id).ToListAsync();
    }

    public async Task<bool> AddReviewAsync(Review review)
    {
        _context.Reviews.Add(review);
        return (await _context.SaveChangesAsync() >= 0);
    }
}
