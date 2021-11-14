using System;
using System.Collections.Generic;

namespace TrainingGround.Models
{
    public class Race
    {
        public void Begin()
        {
            SportCar sportcar = new SportCar();
            Truck truck = new Truck();

            List<Car> cars = new List<Car>
            {
                sportcar, truck
            };

            foreach (Car car in cars)
            {
                car.Start();
                car.SetSpeed();
                car.Acceleration();
                car.Boost();
                car.Stop();
            }
        }

        public void UpCasting(Car car)
        {
            var realCar = car as Car;
            if (realCar != null)
            {
                Console.WriteLine("Upcasting successfull");
            }
            Console.WriteLine("Upcasting failed");
        }

        public void DownCasting(Car car)
        {
            var sportCarCheck = car as SportCar;
            if (sportCarCheck != null)
            {
                ((SportCar)car).DisplayInfo();
            }

            var truckCarCheck = car as Truck;
            if (truckCarCheck != null)
            {
                ((Truck)car).DisplayInfo();
            }
        }
    }
}
