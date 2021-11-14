using System;

namespace TrainingGround.Models
{
    public abstract class Car
    {
        public int Speed { get; protected set; } = 50;
        public int Accelerate { get; } = 20;

        public void Start()
        {
            Console.WriteLine("Starting engine");
            Console.WriteLine($"Running at {Speed} km/h");
        }

        public void Stop()
        {
            Console.WriteLine("Stopping engine");
        }

        public virtual void Acceleration()
        {
            Console.WriteLine($"Current speed: {Speed}");
            Console.WriteLine("Accelerating");
            Speed += Accelerate;
            Console.WriteLine($"Running at {Speed} km/h");
        }
        public abstract void SetSpeed();

        public abstract void Boost();
        public abstract void DisplayInfo();
    }

    public class SportCar : Car
    {
        public override void SetSpeed()
        {
            Speed = 120;
        }

        public override void Acceleration()
        {
            Console.WriteLine("Accelerating a sport car");
            base.Acceleration();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a sport car");
            Speed *= 2;
            Console.WriteLine($"Running at {Speed} km/h");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Viewing a sport car");
        }
    }

    public class Truck : Car
    {
        public int Wheels { get; set; }

        public override void SetSpeed()
        {
            Speed = 40;
        }

        public override void Acceleration()
        {
            Console.WriteLine("Accelerating a truck");
            base.Acceleration();
        }

        public override void Boost()
        {
            Console.WriteLine("Boosting a sport car");
            Speed *= 2;
            Console.WriteLine($"Running at {Speed} km/h");
        }

        public override void DisplayInfo()
        {
            Console.WriteLine("Viewing a truck");
        }
    }
}