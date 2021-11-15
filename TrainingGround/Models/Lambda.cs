using System;
using System.Threading;

namespace TrainingGround.Models
{
    public class Lambda
    {
        public delegate void Write();
        public delegate void Add(int a, int b);
        public delegate void Alert(int number);

        public void TestingLambda()
        {
            Action writer = () => Console.WriteLine("im from lambda");
            writer();

            Action<string, int> advWriter = (msg, num) => Console.WriteLine($"zjadlbym {msg} {num} razy");

            Func<int, int, int> intAdder = (x, y) => x + y;
            advWriter("siano", 500);
            var sum = intAdder(5, 13);
            advWriter("sum:", sum);

            Func<int, int, int, int> duplicating = (a, b, c) => a * b * c;
            var dup = duplicating(1, 2, 3);
            Console.WriteLine($"writing duplicating result {dup}");

            Action<int, string> checkingTemperatureAgain = (temperature, msg) =>
            {
                Console.WriteLine($"Temperature is {temperature} C. Well, {msg}");
            };

            CheckingTemperature(
                t => checkingTemperatureAgain(t, "Too low"),
                t => checkingTemperatureAgain(t, "optimal"),
                t => checkingTemperatureAgain(t, "too high"));
        }

        public void CheckingTemperature(Action<int> low, Action<int> optimal, Action<int> high)
        {
            var temperature = 10;
            var random = new Random();
            var times = 0;

            while (times < 10)
            {
                var change = random.Next(-15, 15);
                temperature += change;
                Console.WriteLine($"Temperature is {temperature} C");
                if (temperature < 0)
                {
                    low(temperature);
                }
                else if (temperature > 0 && temperature < 20)
                {
                    optimal(temperature);
                }
                else
                {
                    high(temperature);
                }
                times++;
                Thread.Sleep(500);
            }
        }
    }
}
