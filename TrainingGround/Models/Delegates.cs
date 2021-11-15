using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrainingGround.Models
{
    class Delegates
    {
        public delegate void Write();
        public delegate void WriteSomeMore(string message);
        public delegate void Add(int x, int y);
        public delegate void Alert(int number);

        public void TestMethod()
        {
            Write writer = WriteMessage;
            writer();

            WriteSomeMore writer2 = WriteAnotherMessage;
            writer2("tryn tryn");

            writer2 = Console.WriteLine;
            writer2("IM writing from console directly");

            Add adder = WriteAboutNumbers;
            adder(5, 7);

            CheckTemperature(TooLowAlert, OptimalAlert, TooHighAlert);
        }

        public void WriteMessage() 
        {
            Console.WriteLine("YO from WriteMessage");
        }

        public void WriteAnotherMessage(string message)
        {
            Console.WriteLine($"YO {message} from WriteAnotherMessage");
        }

        public void ConsoleWriteOnly(string message)
        {
            Console.WriteLine($"YO {message} from ConsoleWriteOnly");
        }

        public void WriteAboutNumbers(int x, int y)
        {
            var sum = AddTwoNumbers(x, y).ToString();
            Console.WriteLine($"YO {sum} from WriteAboutNumbers");
        }

        public void CheckTemperature(Alert low, Alert optimal, Alert high)
        {
            var temperature = 10;
            var random = new Random();
            var times = 0;

            while (times < 10)
            {
                var change = random.Next(-15, 15);
                temperature += change;
                Console.WriteLine($"Temperature is {temperature} C");

                if (temperature <= 0)
                {
                    low(change);
                }
                else if (temperature > 0 && temperature <= 20)
                {
                    optimal(change);
                }
                else
                {
                    high(change);
                }

                times++;
                Thread.Sleep(500);
            }
        }

        public void TooLowAlert(int change)
        {
            Console.WriteLine($"Temperature is too low. Changed by {change} C");
        }

        public void OptimalAlert(int change)
        {
            Console.WriteLine($"Temperature is optimal. Changed by {change} C");
        }

        public void TooHighAlert(int change)
        {
            Console.WriteLine($"Temperature is too high. Changed by {change} C");
        }

        private static int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }
    }
}
