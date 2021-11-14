using System;

namespace TrainingGround
{
    class Order
    {
        public int Id { get; private set; }
        public decimal Price { get; private set; }
        public decimal Tax { get; } = 1.23M;
        public decimal TotalPrice { get { return Price * Tax; } }
        public bool IsPurchased { get; private set; }

        public Order(int id, decimal price)
        {
            if (price <= 0)
            {
                throw new Exception("Price must be greater than 0");
            }

            Id = id;
            Price = price;
        }

        public void Purchase()
        {
            if (IsPurchased)
            {
                throw new Exception("Order was alredy purchased");
            }

            IsPurchased = true;
        }
    }
}
