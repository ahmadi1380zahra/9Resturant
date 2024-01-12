using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
   static class Restaurant
    {
        private static List<Food> _foods = new();
        private static List<User> _users = new();

        public static void AddFood(int foodType, string name, int price)
        {
            switch (foodType)
            {
                case 1:
                    {
                        var fastfood = new FastFood(name,price);
                        fastfood.SetPrice(price);
                        if (_foods.Any(item => item.Name == name))
                        {
                            throw new Exception("Name should be unique");
                        }
                        _foods.Add(fastfood);
                        break;
                    }
                case 2:
                    {
                        var traditionalfood = new TraditionalFood(name, price);
                        traditionalfood.SetPrice(price);
                        if (_foods.Any(item => item.Name == name))
                        {
                            throw new Exception("Name should be unique");
                        }
                        _foods.Add(traditionalfood);
                        break;
                    }
               
                default:
                    {
                        throw new Exception("we dont have this option");
                    }
            }
        }
        public static void AddUser(string userName)
        {
            var user = new User(userName);
            var isExist = _users.Any(item => item.Name == userName);
            if (isExist)
            {
                throw new Exception("name should be unique");
            }
            _users.Add(user);
        }
        public static void AddOrder(string userName,string foodName,int foodcount)
        {
            var user = _users.Find(item => item.Name == userName);
            if (user == null)
            {
                throw new Exception("user id null");
            }
            var food=_foods.Find(item => item.Name == foodName);
            if (food == null)
            {
                throw new Exception("food id null");
            }
            if (foodcount <= 0)
            {
                throw new Exception("not valid count");
            }
            user.SetOrderedFood(food.Name,food.Price, foodcount,(food is FastFood? "FastFood":"TraditionalFood"));
        }
        public static void ShowSoldFood()
        {

            foreach (var user in _users)
            {
                Console.WriteLine($"{ user.Name } ");
                user.ShowOrderedFoods();
            }


        }
    }
}
