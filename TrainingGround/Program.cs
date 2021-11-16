using TrainingGround.Models;

namespace TrainingGround
{
    class Program
    {
        static void Main(string[] args)
        {
            //Race race = new Race();
            //SportCar sportCar = new SportCar();
            //Truck truck = new Truck();

            //////race.Begin();
            //////race.UpCasting(sportCar);
            //////race.UpCasting(truck);
            //////race.DownCasting(sportCar);
            //////race.DownCasting(truck);

            //var overrideTest = new HideOverride();
            //overrideTest.Test();

            //var writeTest = new Delegates();
            //writeTest.TestMethod();

            //var lambdaTest = new Lambda();
            //lambdaTest.TestingLambda();

            var eventsTest = new EventsPlaying();
            eventsTest.Test();
        }
    }
}
