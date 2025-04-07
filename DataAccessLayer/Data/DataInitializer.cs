using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void MigrateData()
        {
            _dbContext.Database.Migrate();
            SeedData();
            _dbContext.SaveChanges();
        }

        private void SeedData()
        {
            // Users
            if (!_dbContext.Users.Any(u => u.Name == "Pelle Jönsson"))
            {
                _dbContext.Users.Add(new User
                {
                    Name = "Pelle Jönsson",
                    Email = "volvo@ads.se"
                });
            }

            if (!_dbContext.Users.Any(u => u.Name == "Karin Andersson"))
            {
                _dbContext.Users.Add(new User
                {
                    Name = "Karin Andersson",
                    Email = "soffa@ads.se"
                });
            }

            _dbContext.SaveChanges();

            var pelle = _dbContext.Users.First(u => u.Name == "Pelle Jönsson");
            var karin = _dbContext.Users.First(u => u.Name == "Karin Andersson");

            // Ads
            if (!_dbContext.Ads.Any(a => a.Title == "Volvo 240"))
            {
                var ad = new Ad
                {
                    Title = "Volvo 240",
                    Description = "A classic car in good condition.",
                    Price = 5000,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatorId = pelle.Id
                };
                _dbContext.Ads.Add(ad);
                _dbContext.SaveChanges();

                _dbContext.Bids.Add(new Bid
                {
                    Amount = 5200,
                    BidTime = DateTime.UtcNow,
                    AdId = ad.Id,
                    UserId = karin.Id
                });
            }

            if (!_dbContext.Ads.Any(a => a.Title == "IKEA Soffa"))
            {
                var ad = new Ad
                {
                    Title = "IKEA Soffa",
                    Description = "Soffa i bra skick, 3-sits.",
                    Price = 800,
                    CreatedAt = DateTime.UtcNow,
                    IsActive = true,
                    CreatorId = karin.Id
                };
                _dbContext.Ads.Add(ad);
                _dbContext.SaveChanges();

                _dbContext.Bids.Add(new Bid
                {
                    Amount = 850,
                    BidTime = DateTime.UtcNow,
                    AdId = ad.Id,
                    UserId = pelle.Id
                });
            }

            _dbContext.SaveChanges();
        }
    }
}
