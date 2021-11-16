using System;

namespace TrainingGround.Models
{
    public class EventsClassTest
    {
        public delegate void UpdateStatus(string message);

        public event UpdateStatus StatusUpdated;

        public EventHandler<StatusEventArgs> StatusUpdatedByHandler;

        public void StartUpdatingStatus()
        {
            var times = 0;
            while (times < 10)
            {
                var message = $"status, ticks {DateTime.Now}";
                StatusUpdated?.Invoke(message);
                StatusUpdatedByHandler?.Invoke(this, new StatusEventArgs(message));
                //if (StatusUpdated != null)
                //{
                //    StatusUpdated(message);
                //}
                times++;
            }
        }
    }

    public class StatusEventArgs : EventArgs
    {
        public string Status { get; }

        public StatusEventArgs(string status)
        {
            Status = status;
        }
    }

    public class EventsPlaying
    {
        public void Test()
        {
            var events = new EventsClassTest();
            events.StatusUpdated += DisplaySomething;
            events.StatusUpdated += DisplaySomething2;
            events.StatusUpdated -= DisplaySomething2;
            events.StatusUpdated += message => Console.WriteLine($"lambda - {message}");
            events.StatusUpdatedByHandler += (sender, eventArgs) =>
            {
                Console.WriteLine($"status -- {eventArgs.Status}");
            };
            events.StartUpdatingStatus();
        }

        public void DisplaySomething(string msg)
        {
            Console.WriteLine($"Something from events: {msg}");
        }

        public void DisplaySomething2(string msg)
        {
            Console.WriteLine($"Something from events: {msg}");
        }
    }
}
