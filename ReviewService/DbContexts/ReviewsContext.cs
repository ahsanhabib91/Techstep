using Microsoft.EntityFrameworkCore;
using ReviewService.Entities;

namespace CityInfo.API.DbContexts;

public class ReviewsContext : DbContext
{
    public DbSet<Device> Devices { get; set; }
    public DbSet<Review> Reviews { get; set; }

    public ReviewsContext(DbContextOptions<ReviewsContext> options)
        : base(options)
    {

    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = ReviewDatabase")
            //.LogTo(log => Debug.WriteLine(log)) // In order to target Debug window, we need lambda expression instead of delegate
            .LogTo(
                Console.WriteLine,
                //_writer.WriteLine,
                new[] {
                    DbLoggerCategory.Database.Command.Name,
                    DbLoggerCategory.Query.Name
                },
                LogLevel.Information
            )
            .EnableSensitiveDataLogging();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var device = new Device { Id = 1, Name = "Mac M1" };
        var Review = new Review { 
            Id = 1, 
            DeviceReview = "This is a nice device",
            Device = device,
            Status = ReviewStatus.WorkInProgress
        };

    }
}
