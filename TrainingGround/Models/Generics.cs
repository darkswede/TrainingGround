namespace TrainingGround.Models
{
    public class Generics
    {
        public void Test()
        {
            GenericOrderProcessor genericOrderProcessor = new GenericOrderProcessor();
            //Result<Order> result = genericOrderProcessor.ProcessOrder(1, 150);
        }
    }

    public class Result<T>
    {
        public T Item {get; set;}
        public bool IsValid { get; set; }
        public string Error { get; set; }
    }

    public class GenericOrderProcessor
    {
        private Result<Order> ProcessOrder(int id, decimal price)
        {
            Order order = new Order(id, price);

            return new Result<Order>
            {
                Item = order
            };
        }
    }

    public class Pair<TFirst, TSecond>
    {
        public TFirst First { get; set; }
        public TSecond Second { get; set; }
    }

    public class Triple<TFirst, TSecond, TThird> : Pair<TFirst, TSecond>
    {
        public TThird Third { get; set; }
    }
}