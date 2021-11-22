using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TrainingGround.Utils.Enumerations;

namespace TrainingGround.Utils
{
    public class Linqs
    {
        public void LinqTesting()
        {
            var enumerations = new Enumerations();
            var items = enumerations.GetItems();
            AggregateFunction(items);
            AllFunction(items);
            AnyFunction(items);
        }

        private void AnyFunction(IEnumerable<Item> items)
        {
            var anyCategory = items.Where(x => x.Category.Any());
            var a = items.Any(x => x.Price > 5000);
        }

        private static void AllFunction(IEnumerable<Item> items)
        {
            var startsWithA = items.All(x => x.Name.StartsWith("A"));
            var endsWithE = items.All(x => x.Name.EndsWith("E"));
            var expensiveThan = items.All(x => x.Price > 5000);
        }

        private static void AggregateFunction(IEnumerable<Item> items)
        {
            string longestName = items.Aggregate("yo", (longest, item) => item.Name.Length > longest.Length ? item.Name : longest,
                x => x.ToUpper());
        }
    }
}
