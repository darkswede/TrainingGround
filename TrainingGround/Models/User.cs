using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using TrainingGround.Models;

namespace TrainingGround
{
    public class Person
    {
        public string FirstName { get; set; }
        public string Adress { get; set; }
    }

     class User
    {
        private Person _person = new Person();

        private readonly ISet<Order> _orders = new HashSet<Order>();
        [Required]
        [EmailAddress]
        public string Email { get; private set; }
        [UserPasswordAttribiute]
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public int Age { get; private set; }
        public bool IsActive { get; private set; }
        public DateTime UpdateAt { get; private set; }
        public decimal Funds { get; private set; }
        public IEnumerable<Order> Order { get { return _orders; } }

        public User(string firstname, string email, string password)
        {
            _person.FirstName = firstname;
            SetEmail(email);
            SetPassword(password);
        }

        public void SetEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                throw new Exception("Email not set.");
            }

            if (Email == email)
            {
                return;
            }

            Email = email;
            ChangeUpdateTime();
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
            {
                throw new Exception("Password not set");
            }

            if (Password == password)
            {
                return;
            }

            Password = password;
            ChangeUpdateTime();
        }

        public void IncreaseFunds(decimal funds)
        {
            if (funds <= 0)
            {
                throw new Exception("Funds must exceed 0");
            }

            Funds += funds;
            ChangeUpdateTime();
        }

        public void PurchaseOrder(Order order)
        {
            if (IsActive == false)
            {
                throw new Exception("You are not able to purchase");
            }

            if (order != null)
            {
                throw new Exception("Item doesnt exist");
            }

            var orderPrice = order.TotalPrice;
            if (Funds - orderPrice < 0)
            {
                throw new Exception("You dont have enough money");
            }

            order.Purchase();
            Funds -= orderPrice;
            ChangeUpdateTime();
        }

        public void Activate()
        {
            if (IsActive)
            {
                return;
            }

            IsActive = true;
            ChangeUpdateTime();
        }

        public void Deactivate()
        {
            if (IsActive == false)
            {
                return;
            }

            IsActive = false;
            ChangeUpdateTime();
        }

        private void ChangeUpdateTime()
        {
            UpdateAt = DateTime.Now;
        }
    }
}
