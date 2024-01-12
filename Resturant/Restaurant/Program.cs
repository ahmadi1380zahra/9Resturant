using System;

namespace Restaurant
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    Run();
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception.Message);
                }
            }
            static void Run()
            {
                var option = GetInt("1.Add Food\n 2.Add User \n 3.Add Order \n 4.Show Order");
                switch (option)
                {
                    case 1:
                        {
                            
                            var foodType = GetInt("1.FastFood 2.TraditionalFood");
                            var foodName = GetString("what is the food name?");
                            var foodPrice = GetInt("what is the food price?");
                            Restaurant.AddFood(foodType,foodName,foodPrice);
                           break;
                        }
                    case 2:
                        {
                            var userName = GetString("What's  user name?");
                            Restaurant.AddUser(userName);
                            break;
                        }
                    case 3:
                        {
                            var userName = GetString("What's  user name?");
                            var foodName = GetString("what is the food name?");
                            var foodCount = GetInt("how many do you want");
                            Restaurant.AddOrder(userName,foodName, foodCount);
                            break;
                        }
                    case 4:
                        {
                            Restaurant.ShowSoldFood();
                            break;
                        }
                }

            }
            static string GetString(string message)
            {
                Console.WriteLine(message);
                string value = Console.ReadLine()!;
                return value;
            }

            static int GetInt(string message)
            {
                Console.WriteLine(message);
                int value = int.Parse(Console.ReadLine()!);
                return value;
            }
        }
    }
}