using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TrainingGround.Models
{
    public class Reflection
    {
        public void Run()
        {
            var user = new User("jadzka", "example@example.com", "secret");
            var type = user.GetType();
            Console.WriteLine($"{type.Name} {type.Namespace} {type.FullName}");

            var methods = type.GetMethods();
            foreach (var method in methods)
            {
                Console.WriteLine($"{ method.Name}");
            }

            user.Activate();
            Console.WriteLine($"{user.IsActive}");

            var deactivateMethod = methods.First(x => x.Name == "Deactivate");
            deactivateMethod.Invoke(user, null);
            Console.WriteLine($"{user.IsActive}");

            Console.WriteLine($"{user.Email}");
            var setEmailMethod = type.GetMethod("SetEmail");
            setEmailMethod.Invoke(user, new[]{"example2@example.com"});
            Console.WriteLine($"{user.Email}");

            Console.WriteLine($"{typeof(User)}");

            var user2 = (User)Activator.CreateInstance(typeof(User), new[] {"jadzka", "example5@gmail.com", "secret3" });
            Console.WriteLine($"{user2.Email}");
        }
    }
}
