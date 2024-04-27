using OdeToFood.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OdeToFood.Data.Services
{
    public class SqlRestaurantData : IRestaurantData
    {
        private OdeToFoodDbContext _dbContext;

        public SqlRestaurantData(OdeToFoodDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(Restaurant restaurant)
        {
            _dbContext.Restaurants.Add(restaurant);
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var restaurant = _dbContext.Restaurants.Find(id);
            if (restaurant != null)
            {
                _dbContext.Restaurants.Remove(restaurant);
                _dbContext.SaveChanges();
            }
        }

        public Restaurant Get(int id)
        {
            return _dbContext.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return _dbContext.Restaurants.OrderBy(r => r.Name).ToList();
        }

        public void Update(Restaurant restaurant)
        {
            var entry = _dbContext.Entry(restaurant);
            entry.State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
