using System;
using System.Collections.Generic;
using System.Linq;

namespace TrainingGround.Utils
{
    public class Enumerations
    {
        public void EnumerationsTest()
        {
            //var numbersToList = Enumerable.Range(1, 100).ToList();
            //IEnumerable<int> numbers = GetNumbers();

            //foreach (var number in numbers)
            //{
            //    Console.WriteLine(number);
            //}

            //var enumerator = numbers.GetEnumerator();
            //while (enumerator.MoveNext())
            //{
            //    Console.WriteLine(enumerator.Current);
            //}

            var items = GetItems();

            //var toolsQuery = from item in items
            //                 where item.Category == "Tools"
            //                 select item;

            var itemsFromToolsCategory = items
                .Where(x => x.Category == "Tools")
                .Select(x => x.Name)
                .ToList();

            foreach (var item in itemsFromToolsCategory)
            {
                Console.WriteLine(item);
            }

            var numbers = Enumerable.Range(1, 10);
            var sum = numbers.Sum();

            var vehicles = items.Where(x => x.Category == "Vehicle");
            var food = items.Where(x => x.Category == "Food");
            var totalPriceOfVehicle = vehicles.Sum(x => x.Price);
            Console.WriteLine(totalPriceOfVehicle);
            var vehiclesAndFood = vehicles.Union(food);

        }

        public class Item
        {
            public Guid Id { get; protected set; }
            public string Name { get; protected set; }
            public string Category { get; protected set; }
            public decimal Price { get; protected set; }
            public DateTime CreatedAt { get; protected set; }

            public Item(string name, string category, decimal price, DateTime date)
            {
                Id = Guid.NewGuid();
                Name = name;
                Category = category;
                Price = price;
                CreatedAt = date;
            }
        }

        public IEnumerable<Item> GetItems()
        {
            yield return new Item("Axe", "Tools", 250, DateTime.Now.AddDays(-15));
            yield return new Item("Driller", "Tools", 300, DateTime.Now.AddDays(-10));
            yield return new Item("Ball", "Sport", 60, DateTime.Now.AddDays(-7));
            yield return new Item("Monitor", "Electronics", 800, DateTime.Now.AddDays(-20));
            yield return new Item("Car", "Vehicle", 20000, DateTime.Now.AddDays(-5));
            yield return new Item("Bike", "Vehicle", 1500, DateTime.Now.AddDays(-10));
            yield return new Item("Notebook", "Electronics", 3000, DateTime.Now.AddDays(-1));
            yield return new Item("Mouse", "Animal", 200, DateTime.Now.AddDays(-5));
            yield return new Item("Pizza", "Food", 40, DateTime.Now.AddDays(-2));
            yield return new Item("Dog", "Animal", 1000, DateTime.Now.AddDays(-3));
            yield return new Item("Burger", "Fodd", 30, DateTime.Now.AddDays(-5));
        }

        public IEnumerable<int> GetNumbers()
        {
            yield return 1;
            yield return 2;
            yield return 3;
            yield return 4;
            yield return 5;
        }
    }
}
