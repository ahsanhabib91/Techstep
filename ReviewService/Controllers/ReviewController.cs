using Microsoft.AspNetCore.Mvc;
using ReviewService.Entities;
using ReviewService.Models;
using ReviewService.Services;

namespace ReviewService.Controllers;

[ApiController]
[Route("[controller]")]
public class ReviewsController : ControllerBase
{
    private readonly IReviewRepository _reviewRepository;
    private readonly ILogger<ReviewsController> _logger;

    public ReviewsController(
        ILogger<ReviewsController> logger,
        IReviewRepository reviewRepository)
    {
        _logger = logger;
        _reviewRepository = reviewRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetReviews()
    {
        try
        {
            string status = HttpContext.Request.Query["status"]; // convert this to ReviewStatus Enum
            return Ok(await _reviewRepository.GetReviewsAsync());
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while getting reviews", ex);
            return StatusCode(500, "A problem happened while your request");
        }
    }

    [HttpPost]
    public async Task<IActionResult> CreateReview(ReviewDto reviewDto)
    {
        try
        {
            await _reviewRepository.AddReviewAsync(
                new Review
                {
                    DeviceReview = reviewDto.DeviceReview,
                    Status = ReviewStatus.WorkInProgress,
                    DeviceId = reviewDto.DeviceId,
                    CreatedBy = Guid.NewGuid(),
                    UpdateddBy = Guid.NewGuid(),
                });
            return Ok();
        }
        catch (Exception ex)
        {
            _logger.LogCritical($"Exception while creating review for device {reviewDto.DeviceId}", ex);
            return StatusCode(500, "A problem happened while your request");
        }
    }
}