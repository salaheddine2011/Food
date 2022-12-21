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