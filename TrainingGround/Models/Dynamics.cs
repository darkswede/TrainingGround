using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrainingGround.Models
{
    public class Dynamics
    {
        public void Run()
        {
            dynamic user = new User("jadzka", "example@example.com", "secret");
            Console.WriteLine($"{user.Email}");
            user.SetEmail("example7@example.com");
            Console.WriteLine($"{user.Email}");

            dynamic something = new ExpandoObject();
            something.Id = 1;
            something.Name = "yo";
            Console.WriteLine($"{something.Id}, {something.Name}");

        }
    } 

    public class Attribiutes
    {
        public void Run()
        {
            var user = new User("jadzka", "example@example.com", "secret");
            var passwordAttribute = (UserPasswordAttribiute)user.GetType()
                                        .GetTypeInfo()
                                        .GetProperty("Password")
                                        .GetCustomAttribute(typeof(UserPasswordAttribiute));

            var isPasswordValid = user.Password.Length == passwordAttribute.Lenght;
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class UserPasswordAttribiute : Attribute
    {
        public int Lenght { get; }

        public UserPasswordAttribiute(int lenght = 4)
        {
            Lenght = lenght;
        }
    }
}
