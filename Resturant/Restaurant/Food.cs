using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    abstract class Food
    {
        protected Food(string name, int price)
        {
            Name = name;
            Price = price;
        }
        public string Name { get; set; }
        public int Price { get; private set; }
        public virtual void SetPrice(int price)
        {
            if (price <= 0)
            {
                throw new Exception("not valid price");
            }
        }
    }
    class FastFood : Food
    {
        public FastFood(string name, int price) : base(name, price)
        {

        }
        public override void SetPrice(int price)
        {
            if (price >= 500)
            {
                throw new Exception("fast food price cant be more than 500");
            }
            base.SetPrice(price);
        }
    }
    class TraditionalFood : Food
    {
        public TraditionalFood(string name, int price) : base(name, price)
        {

        }
        public override void SetPrice(int price)
        {
            if (price >= 900)
            {
                throw new Exception("TraditionalFood price cant be more than 900");
            }
            base.SetPrice(price);
        }
    }
    class User
    {   
        private List<UserOrderedFoods> _OrderedFoods;
        public User(string name)
        {
            Name = name;
            _OrderedFoods = new();
        }
        public string Name { get; set; }
     public void SetOrderedFood(string name, int price, int count, string type)
        {
            _OrderedFoods.Add(new UserOrderedFoods(name,price,count,type));
        }
        public void ShowOrderedFoods()
        {
            foreach(var food in _OrderedFoods)
            {
                Console.WriteLine($"{food.FoodName} is {food.FoodType}=> {food.FoodCount} * {food.FoodPrice} costs {food.TotalCost}");
            }
        }
    }
    class UserOrderedFoods
    {
       
        public UserOrderedFoods(string name,int price,int count,string type)
        {
            FoodName=name;
            FoodPrice = price;
            FoodCount = count;
            FoodType = type;
            TotalCost = FoodCount * FoodPrice;
    }
        public string FoodName { get; set; }
        public int FoodPrice { get; set; }
        public int FoodCount { get; set; }
        public string FoodType { get; set; }
        public int TotalCost { get; private set; }


    }
}
