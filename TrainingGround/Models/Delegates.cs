using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingGround.Models
{
    class Delegates
    {
        public delegate void Write();
        public delegate void WriteSomeMore(string message);
        public delegate void Add(int x, int y);

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

        private static int AddTwoNumbers(int x, int y)
        {
            return x + y;
        }
    }
}
