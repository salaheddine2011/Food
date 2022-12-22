using System;
using System.Collections.Generic;
using System.Linq;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class InMemoryRestaurantData:IRestaurantData
    {
        private List<Restaurant> restaurants;

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant { Id = 1, Cuisine = CuisineType.Italic, Name = "Scott's Pizza" },
                new Restaurant { Id = 2, Cuisine = CuisineType.French, Name = "Tersiguels" },
                new Restaurant { Id = 3, Cuisine = CuisineType.Indian, Name = "Mongo Grove" },
            };
        }

        public void Add(Restaurant restaurant)
        {
            restaurants.Add(restaurant);
            restaurant.Id = restaurants.Max(r => r.Id) + 1;
        }

        public void Update(Restaurant restaurant)
        {
            var existing = Get(restaurant.Id);
                         //restaurants.FirstOrDefault(r => r.Id == restaurant.Id);
            if(existing!=null)
            {
                existing.Name = restaurant.Name;
                existing.Cuisine = restaurant.Cuisine;
            }
            
           
        }

        public Restaurant Get(int id)
        {
            return restaurants.FirstOrDefault(r => r.Id == id);//or null reference
        }

        public IEnumerable<Restaurant> GetAll()
        {
            return restaurants.OrderBy(r=> r.Name);
        }
    }
}